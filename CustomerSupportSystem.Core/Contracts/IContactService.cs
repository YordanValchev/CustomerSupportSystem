using CustomerSupportSystem.Core.Models.Contact;
using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IContactService
    {
        //Task<IEnumerable<ContactModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(ContactModel model);

        Task Edit(int contactId, ContactModel model);

        Task<ContactDetailsModel> ContactDetails(int id);

        Task<PhoneNumber> ContactDefaultPhoneNumber(int id);
    }
}
