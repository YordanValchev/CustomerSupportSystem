using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IContactService
    {
        Task<bool> Exists(int id);

        Task<int> Create(ContactModel model);

        Task Edit(int contactId, ContactModel model);

        Task Delete(int contactId, ContactDetailsModel model);

        Task<ContactDetailsModel> ContactDetails(int id);

        Task<ContactDetailsModel> ContactDetailsByUserId(string id);

        Task<IEnumerable<ContactDetailsPartnerModel>> ContactDetailsPartners(int id);

        Task<IEnumerable<ContactDetailsPartnerModel>> AllPartners();

        Task<IEnumerable<ContactDetailsPartnerModel>> AllPartnersNotEqualToContactId(int id);

        Task AddPartner(int contactId, int partnerId);

        Task RemovePartner(int contactId, int partnerId);

        Task<ContactsQueryModel> QueryContacts(string? sortOrder, int partnerId, string? filter, int currentPage, int rowsPerPage);
    }
}
