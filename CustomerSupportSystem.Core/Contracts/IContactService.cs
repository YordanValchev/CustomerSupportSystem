using CustomerSupportSystem.Core.Models.Contact;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IContactService
    {
        //Task<IEnumerable<ContactModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(ContactModel model);
    }
}
