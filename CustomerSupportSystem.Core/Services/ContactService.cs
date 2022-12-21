using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Net.Mail;

namespace CustomerSupportSystem.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository repo;

        private readonly IEmailAddressService emailService;

        private readonly IPhoneNumberService phoneNumberService;

        private readonly ILogger logger;

        public ContactService(
            IRepository _repo,
            IEmailAddressService _emailService,
            IPhoneNumberService _phoneNumberService,
            ILogger<ContactService> _logger
            )
        {
            repo = _repo;
            emailService = _emailService;
            phoneNumberService = _phoneNumberService;
            logger = _logger;
        }

        //public async Task<IEnumerable<ContactModel>> All()
        //{
        //    return await repo.AllReadonly<Contact>()
        //        .OrderBy(e => e.FirstName)
        //        .ThenBy(e => e.LastName)
        //        .Select(e => new ContactModel()
        //        {
        //            Id = e.Id,
        //            Title = e.Title
        //        })
        //        .ToListAsync();
        //}

        public async Task<int> Create(ContactModel model)
        {
            var contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                JobTitleId = model.JobTitleId,
                UserId = model.UserId
            };

            try
            {
                await repo.AddAsync(contact);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            if(!string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                await emailService.AddEmail(model.EmailAddress, contact.Id, null, true);
            }

            if(!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                await phoneNumberService.AddPhoneNumber(model.PhoneNumber, contact.Id, null, true);
            }

            return contact.Id;
        }

        public async Task Edit(int contactId, ContactModel model)
        {
            var contact = await repo.GetByIdAsync<Contact>(contactId);

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.JobTitleId = model.JobTitleId;
            contact.UserId = model.UserId;

            string currentEmailAddress = model.CurrentEmailAddress ?? string.Empty;
            string newEmailAddress = model.EmailAddress ?? string.Empty;

            if (currentEmailAddress != newEmailAddress)
            {
                if(string.IsNullOrWhiteSpace(currentEmailAddress) && !string.IsNullOrWhiteSpace(newEmailAddress))
                {
                    await emailService.AddEmail(newEmailAddress, model.Id, null, true);
                }
                else
                {
                    await emailService.UpdateEmailAddress(currentEmailAddress, newEmailAddress);
                }
            }

            string currentPhoneNumber = model.CurrentPhoneNumber ?? string.Empty;
            string newPhoneNumber = model.PhoneNumber ?? string.Empty;

            if (currentPhoneNumber != newPhoneNumber)
            {
                if (string.IsNullOrWhiteSpace(currentPhoneNumber) && !string.IsNullOrWhiteSpace(newPhoneNumber))
                {
                    await phoneNumberService.AddPhoneNumber(newPhoneNumber, model.Id, null, true);
                }
                else
                {
                    await phoneNumberService.UpdatePhoneNumber(currentPhoneNumber, newPhoneNumber);
                }
            }

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Edit), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Contact>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<ContactDetailsModel> ContactDetails(int id)
        {
            return await repo.AllReadonly<Contact>()
                .Include(contact => contact.Emails)
                .Include(contact => contact.PhoneNumbers)
                .Where(contact => contact.Id == id)
                .Select(contact => new ContactDetailsModel()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    JobTitleId = contact.JobTitleId,
                    UserId = contact.UserId,
                    EmailAddress = contact.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    PhoneNumber = contact.PhoneNumbers.First(p => p.IsMain ?? false).Number
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<ContactDetailsPartnerModel>> ContactDetailsPartners(int id)
        {
            return await repo.AllReadonly<PartnerContact>()
                .Include(partnerContact => partnerContact.Partner)
                .Where(partnerContact => partnerContact.ContactId == id && (partnerContact.Partner.IsActive ?? false) == true)
                .Select(partnerContact => new ContactDetailsPartnerModel()
                {
                    Id = partnerContact.Partner.Id,
                    Name = partnerContact.Partner.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ContactDetailsPartnerModel>> AllPartners(int id)
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => partner.IsActive ?? false)
                .Include(partner => partner.PartnerContacts)
                .Where(partner => !partner.PartnerContacts.Any(partnerContact => partnerContact.ContactId == id))
                .Select(partner => new ContactDetailsPartnerModel()
                {
                    Id = partner.Id,
                    Name = partner.Name
                })
                .ToListAsync();
        }

        public async Task Delete(int contactId, ContactDetailsModel model)
        {
            var contact = await repo.GetByIdAsync<Contact>(contactId);

            contact.FirstName = null;
            contact.LastName = null;
            contact.JobTitleId = null;
            contact.IsActive = false;

            if (!string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                await emailService.DeleteEmailAddress(model.EmailAddress);
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                await phoneNumberService.DeletePhoneNumber(model.PhoneNumber);
            }

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Edit), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task AddPartner(int contactId, int partnerId)
        {
            if(partnerId > 0)
            {
                var partnerContact = new PartnerContact()
                {
                    ContactId = contactId,
                    PartnerId = partnerId
                };

                try
                {
                    await repo.AddAsync(partnerContact);
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(AddPartner), ex);
                    throw new ApplicationException("Database failed to save info", ex);
                }
            }
        }
    }
}
