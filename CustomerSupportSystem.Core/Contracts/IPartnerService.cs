using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IPartnerService
    {
        Task<IEnumerable<PartnerCountriesModel>> AllCountries();

        Task<bool> CountryExists(int countryId);

        Task<IEnumerable<PartnerConsultantsModel>> AllConsultants();

        Task<bool> ConsultantExists(int consultantId);

        Task<int> Create(PartnerModel model);

        Task<PartnerDetailsModel> PartnerDetails(int id);
    }
}
