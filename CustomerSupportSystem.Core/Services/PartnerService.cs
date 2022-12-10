using CustomerSupportSystem.Core.Models.Partner;

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
    }
}
