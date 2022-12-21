using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace CustomerSupportSystem.Core.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public PartnerService(
            IRepository _repo,
            ILogger<PartnerService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<PartnerConsultantsModel>> AllConsultants()
        {
            return await repo.AllReadonly<Employee>()
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)    
                .Select(e => new PartnerConsultantsModel()
                {
                    Id = e.Id,
                    Name = $"{e.FirstName} {e.LastName}"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PartnerCountriesModel>> AllCountries()
        {
            return await repo.AllReadonly<Country>()
                .OrderBy(e => e.Name)
                .Select(e => new PartnerCountriesModel()
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync();
        }

        public async Task<bool> ConsultantExists(int id)
        {
            return await repo.AllReadonly<Employee>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<bool> CountryExists(int id)
        {
            return await repo.AllReadonly<Country>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<int> Create(PartnerModel model)
        {
            var partner = new Partner()
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Postcode = model.Postcode,
                CountryId = model.CountryId,
                RegistrationNumber = model.RegistrationNumber,
                TaxNumber = model.TaxNumber,
                Website = model.Website,
                ConsultantId = model.ConsultantId,
                SubscriptionContractNumber = model.SubscriptionContractNumber,
                IsSubscriptionActive = model.IsSubscriptionActive
            };

            try
            {
                await repo.AddAsync(partner);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return partner.Id;
        }

        public async Task Edit(int partnerId, PartnerModel model)
        {
            var partner = await repo.GetByIdAsync<Partner>(partnerId);

            partner.Name = model.Name;
            partner.Address = model.Address;
            partner.City = model.City;
            partner.Postcode = model.Postcode;
            partner.CountryId = model.CountryId;
            partner.RegistrationNumber = model.RegistrationNumber;
            partner.TaxNumber = model.TaxNumber;
            partner.Website = model.Website;
            partner.ConsultantId = model.ConsultantId;
            partner.SubscriptionContractNumber = model.SubscriptionContractNumber;
            partner.IsSubscriptionActive = model.IsSubscriptionActive;
            partner.IsActive = model.IsActive;

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

        public async Task CreatePartnerContact(int partnerId, int contactId)
        {
            var partnerContact = new PartnerContact()
            {
                PartnerId = partnerId,
                ContactId = contactId
            };

            try
            {
                await repo.AddAsync(partnerContact);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<PartnerDetailsModel> PartnerDetails(int id)
        {
            return await repo.AllReadonly<Partner>()
                .Include(partner => partner.Country)
                .Include(partner => partner.Consultant)
                .Where(partner => partner.Id == id)
                .Select(partner => new PartnerDetailsModel()
                {
                    Id = partner.Id,
                    Name = partner.Name,
                    Address = partner.Address,
                    City = partner.City,
                    Postcode = partner.Postcode,
                    CountryId = partner.CountryId,
                    Country = partner.Country == null ? string.Empty : partner.Country.Name,
                    RegistrationNumber = partner.RegistrationNumber,
                    TaxNumber = partner.TaxNumber,
                    Website = partner.Website,
                    ConsultantId = partner.ConsultantId,
                    Consultant = partner.Consultant == null ? string.Empty : $"{partner.Consultant.FirstName} {partner.Consultant.LastName}",
                    SubscriptionContractNumber = partner.SubscriptionContractNumber,
                    IsSubscriptionActive = partner.IsSubscriptionActive ?? false,
                    IsActive = partner.IsActive ?? false,
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<PartnerDetailsContactsModel>> PartnerDetailsContacts(int id)
        {
            return await repo.AllReadonly<PartnerContact>()
                .Include(partnerContact => partnerContact.Contact)
                .Where(partnerContact => partnerContact.PartnerId == id && (partnerContact.Contact.IsActive ?? false) == true)
                .Select(partnerContact => new PartnerDetailsContactsModel()
                {
                    Id = partnerContact.Contact.Id,
                    Name = $"{partnerContact.Contact.FirstName} {partnerContact.Contact.LastName}",
                    PhoneNumber = partnerContact.Contact.PhoneNumbers.First(e => e.IsMain ?? false).Number,
                    EmailAddress = partnerContact.Contact.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    JobTitle = partnerContact.Contact.JobTitle == null ? string.Empty : partnerContact.Contact.JobTitle.Title,
                    IsUser = partnerContact.Contact.User == null ? false : true
                })
                .ToListAsync();
        }

        public async Task<bool> PartnerExists(int id)
        {
            return await repo.AllReadonly<Partner>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<PartnersQueryModel> QueryPartners(string? sortOrder = null, int consultantId = -1, int activeType = 1, string? filter = null, int currentPage = 1, int rowsPerPage = 20)
        {
            var model = new PartnersQueryModel();

            var partners = repo.AllReadonly<Partner>();

            if (Enum.GetName(typeof(ActiveTypeFilter), activeType) == "Active")
            {
                partners = partners
                    .Where(partner => partner.IsActive == true);
            }

            if (Enum.GetName(typeof(ActiveTypeFilter), activeType) == "Inactive")
            {
                partners = partners
                    .Where(partner => partner.IsActive == false);
            }

            if (await ConsultantExists(consultantId))
            {
                partners = partners
                    .Where(p => p.Consultant != null && p.Consultant.Id == consultantId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = $"%{filter.ToLower()}%";

                partners = partners
                    .Where(p => 
                        EF.Functions.Like(p.Name.ToLower(), filter) ||
                        EF.Functions.Like(p.Address == null ? string.Empty : p.Address.ToLower(), filter) ||
                        EF.Functions.Like(p.City == null ? string.Empty : p.City.ToLower(), filter) ||
                        EF.Functions.Like(p.Country == null ? string.Empty : p.Country.Name.ToLower(), filter) ||
                        EF.Functions.Like(p.Postcode == null ? string.Empty : p.Postcode.ToLower(), filter) ||
                        EF.Functions.Like(p.RegistrationNumber == null ? string.Empty : p.RegistrationNumber.ToLower(), filter) ||
                        EF.Functions.Like(p.TaxNumber == null ? string.Empty : p.TaxNumber.ToLower(), filter) ||
                        EF.Functions.Like(p.Website == null ? string.Empty : p.Website.ToLower(), filter)
                        );
            }

            model.SortFields.Id = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.SortFields.Name = sortOrder == "Name" ? "Name_Desc" : "Name";
            model.SortFields.Address = sortOrder == "Address" ? "Address_Desc" : "Address";
            model.SortFields.City = sortOrder == "City" ? "City_Desc" : "City";
            model.SortFields.Country = sortOrder == "Country" ? "Country_Desc" : "Country";
            model.SortFields.Postcode = sortOrder == "Postcode" ? "Postcode_Desc" : "Postcode";
            model.SortFields.RegistrationNumber = sortOrder == "RegistrationNumber" ? "RegistrationNumber_Desc" : "RegistrationNumber";
            model.SortFields.TaxNumber = sortOrder == "TaxNumber" ? "TaxNumber_Desc" : "TaxNumber";
            model.SortFields.Website = sortOrder == "Website" ? "Website_Desc" : "Website";
            model.SortFields.Consultant = sortOrder == "Consultant" ? "Consultant_Desc" : "Consultant";

            partners = sortOrder switch
            {
                "Name" => partners.OrderBy(s => s.Name),
                "Address" => partners.OrderBy(s => s.Address),
                "City" => partners.OrderBy(s => s.City),
                "Country" => partners.OrderBy(s => s.Country == null ? string.Empty : s.Country.Name),
                "Postcode" => partners.OrderBy(s => s.Postcode),
                "RegistrationNumber" => partners.OrderBy(s => s.RegistrationNumber),
                "TaxNumber" => partners.OrderBy(s => s.TaxNumber),
                "Website" => partners.OrderBy(s => s.Website),
                "Consultant" => partners.OrderBy(s => s.Consultant),

                "Name_Desc" => partners.OrderByDescending(s => s.Name),
                "Address_Desc" => partners.OrderByDescending(s => s.Address),
                "City_Desc" => partners.OrderByDescending(s => s.City),
                "Country_Desc" => partners.OrderByDescending(s => s.Country),
                "Postcode_Desc" => partners.OrderByDescending(s => s.Postcode),
                "RegistrationNumber_Desc" => partners.OrderByDescending(s => s.RegistrationNumber),
                "TaxNumber_Desc" => partners.OrderByDescending(s => s.TaxNumber),
                "Website_Desc" => partners.OrderByDescending(s => s.Website),
                "Consultant_Desc" => partners.OrderByDescending(s => s.Consultant),

                "Id_Desc" => partners.OrderByDescending(s => s.Id),
                _ => partners.OrderBy(s => s.Id),
            };

            string ascOrderImageClass = "bi-caret-up";
            string descOrderImageClass = "bi-caret-down";

            switch (sortOrder)
            {
                case "Name":
                    model.SortFields.NameImageClass = ascOrderImageClass;
                    break;
                case "Address":
                    model.SortFields.AddressImageClass = ascOrderImageClass;
                    break;
                case "City":
                    model.SortFields.CityImageClass = ascOrderImageClass;
                    break;
                case "Country":
                    model.SortFields.CountryImageClass = ascOrderImageClass;
                    break;
                case "Postcode":
                    model.SortFields.PostcodeImageClass = ascOrderImageClass;
                    break;
                case "RegistrationNumber":
                    model.SortFields.RegistrationNumberImageClass = ascOrderImageClass;
                    break;
                case "TaxNumber":
                    model.SortFields.TaxNumberImageClass = ascOrderImageClass;
                    break;
                case "Website":
                    model.SortFields.WebsiteImageClass = ascOrderImageClass;
                    break;
                case "Consultant":
                    model.SortFields.ConsultantImageClass = ascOrderImageClass;
                    break;

                case "Name_Desc":
                    model.SortFields.NameImageClass = descOrderImageClass;
                    break;
                case "Address_Desc":
                    model.SortFields.AddressImageClass = descOrderImageClass;
                    break;
                case "City_Desc":
                    model.SortFields.CityImageClass = descOrderImageClass;
                    break;
                case "Country_Desc":
                    model.SortFields.CountryImageClass = descOrderImageClass;
                    break;
                case "Postcode_Desc":
                    model.SortFields.PostcodeImageClass = descOrderImageClass;
                    break;
                case "RegistrationNumber_Desc":
                    model.SortFields.RegistrationNumberImageClass = descOrderImageClass;
                    break;
                case "TaxNumber_Desc":
                    model.SortFields.TaxNumberImageClass = descOrderImageClass;
                    break;
                case "Website_Desc":
                    model.SortFields.WebsiteImageClass = descOrderImageClass;
                    break;
                case "Consultant_Desc":
                    model.SortFields.ConsultantImageClass = descOrderImageClass;
                    break;

                case "Id_Desc":
                    model.SortFields.IdImageClass = descOrderImageClass;
                    break;
                default:
                    model.SortFields.IdImageClass = ascOrderImageClass;
                    break;
            };

            model.Partners = await partners
                .Skip((currentPage - 1) * rowsPerPage)
                .Take(rowsPerPage)
                .Select(partner => new PartnersQueryDetailModel()
                {
                    Id = partner.Id,
                    Name = partner.Name,
                    Address = partner.Address,
                    City = partner.City,
                    Postcode = partner.Postcode,
                    Country = partner.Country == null ? string.Empty : partner.Country.Name,
                    RegistrationNumber = partner.RegistrationNumber,
                    TaxNumber = partner.TaxNumber,
                    Website = partner.Website,
                    Consultant = partner.Consultant == null ? string.Empty : $"{partner.Consultant.FirstName} {partner.Consultant.LastName}"
                })
                .ToListAsync();

            model.TotalPartnersCount = await partners.CountAsync();

            return model;
        }
    }
}
