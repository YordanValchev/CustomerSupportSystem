using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IContactService
    {
        //Task<IEnumerable<ContactModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(ContactModel model);

        Task Edit(int contactId, ContactModel model);

        Task Delete(int contactId, ContactDetailsModel model);

        Task<ContactDetailsModel> ContactDetails(int id);

        Task<IEnumerable<ContactDetailsPartnerModel>> ContactDetailsPartners(int id);

        Task<IEnumerable<ContactDetailsPartnerModel>> AllPartners(int id);

        Task AddPartner(int contactId, int partnerId);
    }
}
