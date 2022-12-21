namespace CustomerSupportSystem.Core.Contracts
{
    public interface IEmailAddressService
    {
        Task<Email> GetEmailByAddress(string emailAddress);

        Task UpdateEmailAddress(string emailAddress, string newEmailAddress);

        Task DeleteEmailAddress(string emailAddress);

        Task<bool> EmailExists(string emailAddress);

        Task<Email> AddEmail(string emailAddress, int? contactId, int? employeeId, bool? isMain);
    }
}
