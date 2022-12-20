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

        private readonly ILogger logger;

        public ContactService(
            IRepository _repo,
            IEmailAddressService _emailService,
            ILogger<ContactService> _logger
            )
        {
            repo = _repo;
            emailService = _emailService;
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
                UserId = model.UserId,
                Emails = new List<Email>()
                {
                    new Email()
                    {
                        EmailAddress = model.EmailAddress,
                        IsMain = true
                    }
                },
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber()
                    {
                        Number = model.PhoneNumber,
                        IsMain = true
                    }
                }
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

            return contact.Id;
        }

        public async Task Edit(int contactId, ContactModel model)
        {
            var contact = await repo.GetByIdAsync<Contact>(contactId);

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.JobTitleId = model.JobTitleId;
            contact.UserId = model.UserId;

            var emails = contact.Emails;

            if (model.CurrentEmailAddress != null && model.CurrentEmailAddress != model.EmailAddress)
            {
                await emailService.UpdateEmailAddress(model.CurrentEmailAddress, model.EmailAddress);
            }

            var phoneNumber = await ContactDefaultPhoneNumber(contactId);

            if (phoneNumber != null)
            {
                phoneNumber.Number = model.PhoneNumber;
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

        public async Task<PhoneNumber> ContactDefaultPhoneNumber(int id)
        {
            return await repo.AllReadonly<PhoneNumber>()
                .Where(e =>
                        e.ContactId != null &&
                        e.ContactId == id &&
                        e.IsMain != null &&
                        e.IsMain == true
                        )
                .FirstAsync();
        }
    }
}
