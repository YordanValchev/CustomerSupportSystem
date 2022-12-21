namespace CustomerSupportSystem.Core.Contracts
{
    public interface IPhoneNumberService
    {
        Task<PhoneNumber> GetPhoneByNumber(string phoneNumber);

        Task UpdatePhoneNumber(string phoneNumber, string newPhoneNumber);

        Task DeletePhoneNumber(string phoneNumber);

        Task<bool> PhoneNumberExists(string phoneNumber);

        Task<PhoneNumber> AddPhoneNumber(string phoneNumber, int? contactId, int? employeeId, bool? isMain);
    }
}
