using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
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

        public async Task<PartnersQueryModel> QueryPartners(string sortOrder)
        {
            var model = new PartnersQueryModel();

            var partners = await repo.AllReadonly<Partner>()
                .Include(partner => partner.Country)
                .Include(partner => partner.Consultant)
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

            model.IdSort = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.NameSort = sortOrder == "Name" ? "Name_Desc" : "Name";

            partners = sortOrder switch
            {
                "Name" => partners.OrderBy(s => s.Name).ToList(),
                "Name_Desc" => partners.OrderByDescending(s => s.Name).ToList(),
                "Id_Desc" => partners.OrderByDescending(s => s.Id).ToList(),
                _ => partners.OrderBy(s => s.Id).ToList(),
            };

            model.Partners = partners;

            return model;
        }
    }
}
