using CustomerSupportSystem.Infrastructure.Data.Models;
using System.Data;

namespace CustomerSupportSystem.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository repo;
        private readonly IEmailAddressService emailService;
        private readonly IPhoneNumberService phoneNumberService;
        private readonly IPartnerService partnerService;
        private readonly ILogger logger;

        public ContactService(
            IRepository _repo,
            IEmailAddressService _emailService,
            IPhoneNumberService _phoneNumberService,
            IPartnerService _partnerService,
            ILogger<ContactService> _logger
            )
        {
            repo = _repo;
            emailService = _emailService;
            phoneNumberService = _phoneNumberService;
            partnerService = _partnerService;
            logger = _logger;
        }

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
                    JobTitle = contact.JobTitle == null ? string.Empty : contact.JobTitle.Title,
                    UserId = contact.UserId,
                    EmailAddress = contact.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    PhoneNumber = contact.PhoneNumbers.First(p => p.IsMain ?? false).Number
                })
                .FirstAsync();
        }

        public async Task<ContactDetailsModel> ContactDetailsByUserId(string id)
        {
            return await repo.AllReadonly<Contact>()
                .Include(contact => contact.Emails)
                .Include(contact => contact.PhoneNumbers)
                .Where(contact => contact.UserId != null && contact.UserId == id)
                .Select(contact => new ContactDetailsModel()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    JobTitleId = contact.JobTitleId,
                    JobTitle = contact.JobTitle == null ? string.Empty : contact.JobTitle.Title,
                    UserId = contact.UserId,
                    EmailAddress = contact.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    PhoneNumber = contact.PhoneNumbers.First(p => p.IsMain ?? false).Number
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<PartnersListModel>> ContactDetailsPartners(int id)
        {
            return await repo.AllReadonly<PartnerContact>()
                .Include(partnerContact => partnerContact.Partner)
                .Where(partnerContact => partnerContact.ContactId == id && (partnerContact.Partner.IsActive ?? false) == true)
                .Select(partnerContact => new PartnersListModel()
                {
                    Id = partnerContact.Partner.Id,
                    Name = partnerContact.Partner.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PartnersListModel>> AllPartners()
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => partner.IsActive ?? false)
                .Select(partner => new PartnersListModel()
                {
                    Id = partner.Id,
                    Name = partner.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PartnersListModel>> AllPartnersNotEqualToContactId(int id)
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => partner.IsActive ?? false)
                .Include(partner => partner.PartnerContacts)
                .Where(partner => !partner.PartnerContacts.Any(partnerContact => partnerContact.ContactId == id))
                .Select(partner => new PartnersListModel()
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

        public async Task RemovePartner(int contactId, int partnerId)
        {
            if (partnerId > 0)
            {
                var partnerContact = await repo.All<PartnerContact>()
                    .Where(partnerContact => partnerContact.ContactId == contactId && partnerContact.PartnerId == partnerId)
                    .FirstAsync();

                try
                {
                    repo.Delete(partnerContact);
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(AddPartner), ex);
                    throw new ApplicationException("Database failed to delete info", ex);
                }
            }
        }

        public async Task<ContactsQueryModel> QueryContacts(string? sortOrder, int partnerId, string? filter, int currentPage, int rowsPerPage)
        {
            var model = new ContactsQueryModel();

            var contacts = repo.AllReadonly<Contact>()
                .Where(contact => contact.IsActive == true);

            if (await partnerService.PartnerExists(partnerId))
            {
                contacts = contacts
                    .Include(contact => contact.PartnerContacts)
                    .Where(contact => contact.PartnerContacts.Any(partnerContact => partnerContact.PartnerId == partnerId));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = $"%{filter.ToLower()}%";

                contacts = contacts
                    .Include(c => c.Emails)
                    .Include(c => c.PhoneNumbers)
                    .Where(c =>
                        EF.Functions.Like(c.FirstName == null ? string.Empty : c.FirstName.ToLower(), filter) ||
                        EF.Functions.Like(c.LastName == null ? string.Empty : c.LastName.ToLower(), filter) ||
                        EF.Functions.Like(c.JobTitle == null ? string.Empty : c.JobTitle.Title.ToLower(), filter) ||
                        EF.Functions.Like(c.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : c.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress.ToLower(), filter) ||
                        EF.Functions.Like(c.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : c.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number.ToLower(), filter)
                        );
            }

            model.SortFields.Id = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.SortFields.FirstName = sortOrder == "FirstName" ? "FirstName_Desc" : "FirstName";
            model.SortFields.LastName = sortOrder == "LastName" ? "LastName_Desc" : "LastName";
            model.SortFields.JobTitle = sortOrder == "JobTitle" ? "JobTitle_Desc" : "JobTitle";
            model.SortFields.EmailAddress = sortOrder == "EmailAddress" ? "EmailAddress_Desc" : "EmailAddress";
            model.SortFields.PhoneNumber = sortOrder == "PhoneNumber" ? "PhoneNumber_Desc" : "PhoneNumber";

            contacts = sortOrder switch
            {
                "FirstName" => contacts.OrderBy(s => s.FirstName),
                "LastName" => contacts.OrderBy(s => s.LastName),
                "JobTitle" => contacts.OrderBy(s => s.JobTitle),
                "EmailAddress" => contacts.OrderBy(s => s.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress),
                "PhoneNumber" => contacts.OrderBy(s => s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number),

                "FirstName_Desc" => contacts.OrderByDescending(s => s.FirstName),
                "LastName_Desc" => contacts.OrderByDescending(s => s.LastName),
                "JobTitle_Desc" => contacts.OrderByDescending(s => s.JobTitle),
                "EmailAddress_Desc" => contacts.OrderByDescending(s => s.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress),
                "PhoneNumber_Desc" => contacts.OrderByDescending(s => s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number),

                "Id_Desc" => contacts.OrderByDescending(s => s.Id),
                _ => contacts.OrderBy(s => s.Id),
            };

            string ascOrderImageClass = "bi-caret-up";
            string descOrderImageClass = "bi-caret-down";

            switch (sortOrder)
            {
                case "Name":
                    model.SortFields.FirstNameImageClass = ascOrderImageClass;
                    break;
                case "Address":
                    model.SortFields.LastNameImageClass = ascOrderImageClass;
                    break;
                case "JobTitle":
                    model.SortFields.JobTitleImageClass = ascOrderImageClass;
                    break;
                case "EmailAddress":
                    model.SortFields.EmailAddressImageClass = ascOrderImageClass;
                    break;
                case "PhoneNumber":
                    model.SortFields.PhoneNumberImageClass = ascOrderImageClass;
                    break;

                case "Name_Desc":
                    model.SortFields.FirstNameImageClass = descOrderImageClass;
                    break;
                case "Address_Desc":
                    model.SortFields.LastNameImageClass = descOrderImageClass;
                    break;
                case "JobTitle_Desc":
                    model.SortFields.JobTitleImageClass = descOrderImageClass;
                    break;
                case "EmailAddress_Desc":
                    model.SortFields.EmailAddressImageClass = descOrderImageClass;
                    break;
                case "PhoneNumber_Desc":
                    model.SortFields.PhoneNumberImageClass = descOrderImageClass;
                    break;

                case "Id_Desc":
                    model.SortFields.IdImageClass = descOrderImageClass;
                    break;
                default:
                    model.SortFields.IdImageClass = ascOrderImageClass;
                    break;
            };

            model.Contacts = await contacts
                .Skip((currentPage - 1) * rowsPerPage)
                .Take(rowsPerPage)
                .Select(contact => new ContactsQueryDetailModel()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    JobTitle = contact.JobTitle.Title,
                    PhoneNumber = contact.PhoneNumbers.First(e => e.IsMain == true).Number,
                    EmailAddress = contact.Emails.First(e => e.IsMain == true).EmailAddress
                })
                .ToListAsync();

            model.TotalRowsCount = await contacts.CountAsync();

            return model;
        }
    }
}
