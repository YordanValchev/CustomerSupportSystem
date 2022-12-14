using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

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

        public async Task<bool> ConsultantExists(int consultantId)
        {
            return await repo.AllReadonly<Employee>()
                .AnyAsync(e => e.Id == consultantId);
        }

        public async Task<bool> CountryExists(int countryId)
        {
            return await repo.AllReadonly<Country>()
                .AnyAsync(e => e.Id == countryId);
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

        public async Task<PartnerDetailsModel> PartnerDetails(int id)
        {
            return await repo.AllReadonly<Partner>()
                .Include(partner => partner.PartnerContacts)
                .ThenInclude(partnerContacts => partnerContacts.Contact)
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
                    Country = partner.Country == null ? string.Empty : partner.Country.Name,
                    RegistrationNumber = partner.RegistrationNumber,
                    TaxNumber = partner.TaxNumber,
                    Website = partner.Website,
                    Consultant = partner.Consultant == null ? string.Empty : $"{partner.Consultant.FirstName} {partner.Consultant.LastName}",
                    SubscriptionContractNumber = partner.SubscriptionContractNumber,
                    IsSubscriptionActive = partner.IsSubscriptionActive ?? false,
                    Contacts = partner.PartnerContacts
                        .Select(partnerContact => new PartnerDetailsContactsModel()
                        {
                            Name = $"{partnerContact.Contact.FirstName} {partnerContact.Contact.LastName}",
                            PhoneNumber = partnerContact.Contact.PhoneNumbers.Any() ? partnerContact.Contact.PhoneNumbers.FirstOrDefault().Number : string.Empty,
                            EmailAddress = partnerContact.Contact.Emails.Any() ? partnerContact.Contact.Emails.FirstOrDefault().EmailAddress : string.Empty,
                            JobTitle = partnerContact.Contact.JobTitle == null ? string.Empty : partnerContact.Contact.JobTitle.Title,
                            IsUser = partnerContact.Contact.User == null ? false : true
                        })
                        .ToList()


                })
                .FirstAsync();
        }

        public async Task<PartnersQueryModel> QueryPartners(string? sortOrder = null, int consultantId = -1, string? filter = null, int currentPage = 1, int rowsPerPage = 20)
        {
            var model = new PartnersQueryModel();

            var partners = repo.AllReadonly<Partner>();

            if (await ConsultantExists(consultantId))
            {
                partners = partners
                    .Where(h => h.Consultant != null && h.Consultant.Id == consultantId);
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

            model.IdSort = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.NameSort = sortOrder == "Name" ? "Name_Desc" : "Name";
            model.AddressSort = sortOrder == "Address" ? "Address_Desc" : "Address";
            model.CitySort = sortOrder == "City" ? "City_Desc" : "City";
            model.CountrySort = sortOrder == "Country" ? "Country_Desc" : "Country";
            model.PostcodeSort = sortOrder == "Postcode" ? "Postcode_Desc" : "Postcode";
            model.RegistrationNumberSort = sortOrder == "RegistrationNumber" ? "RegistrationNumber_Desc" : "RegistrationNumber";
            model.TaxNumberSort = sortOrder == "TaxNumber" ? "TaxNumber_Desc" : "TaxNumber";
            model.WebsiteSort = sortOrder == "Website" ? "Website_Desc" : "Website";
            model.ConsultantSort = sortOrder == "Consultant" ? "Consultant_Desc" : "Consultant";

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
                    model.NameSortImageClass = ascOrderImageClass;
                    break;
                case "Address":
                    model.AddressSortImageClass = ascOrderImageClass;
                    break;
                case "City":
                    model.CitySortImageClass = ascOrderImageClass;
                    break;
                case "Country":
                    model.CountrySortImageClass = ascOrderImageClass;
                    break;
                case "Postcode":
                    model.PostcodeSortImageClass = ascOrderImageClass;
                    break;
                case "RegistrationNumber":
                    model.RegistrationNumberSortImageClass = ascOrderImageClass;
                    break;
                case "TaxNumber":
                    model.TaxNumberSortImageClass = ascOrderImageClass;
                    break;
                case "Website":
                    model.WebsiteSortImageClass = ascOrderImageClass;
                    break;
                case "Consultant":
                    model.ConsultantSortImageClass = ascOrderImageClass;
                    break;

                case "Name_Desc":
                    model.NameSortImageClass = descOrderImageClass;
                    break;
                case "Address_Desc":
                    model.AddressSortImageClass = descOrderImageClass;
                    break;
                case "City_Desc":
                    model.CitySortImageClass = descOrderImageClass;
                    break;
                case "Country_Desc":
                    model.CountrySortImageClass = descOrderImageClass;
                    break;
                case "Postcode_Desc":
                    model.PostcodeSortImageClass = descOrderImageClass;
                    break;
                case "RegistrationNumber_Desc":
                    model.RegistrationNumberSortImageClass = descOrderImageClass;
                    break;
                case "TaxNumber_Desc":
                    model.TaxNumberSortImageClass = descOrderImageClass;
                    break;
                case "Website_Desc":
                    model.WebsiteSortImageClass = descOrderImageClass;
                    break;
                case "Consultant_Desc":
                    model.ConsultantSortImageClass = descOrderImageClass;
                    break;

                case "Id_Desc":
                    model.IdSortImageClass = descOrderImageClass;
                    break;
                default:
                    model.IdSortImageClass = ascOrderImageClass;
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
