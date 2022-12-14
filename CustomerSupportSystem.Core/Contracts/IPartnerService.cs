using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IPartnerService
    {
        Task<IEnumerable<PartnerCountriesModel>> AllCountries();

        Task<bool> CountryExists(int id);

        Task<IEnumerable<PartnerConsultantsModel>> AllConsultants();

        Task<bool> ConsultantExists(int? id);

        Task<int> Create(PartnerModel model);

        Task Edit(int partnerId, PartnerModel model);

        Task<bool> PartnerExists(int id);

        Task<PartnerDetailsModel> PartnerDetails(int id);

        Task<IEnumerable<PartnerDetailsContactsModel>> PartnerDetailsContacts(int id);

        Task<PartnersQueryModel> QueryPartners(string? sortOrder, int consultantId, int activeType, string? filter, int currentPage, int rowsPerPage);

        Task CreatePartnerContact(int partnerId, int contactId);
    }
}
