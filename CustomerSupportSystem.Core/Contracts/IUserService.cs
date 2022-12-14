using System.Security.Claims;

namespace CustomerSupportSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByID(string id);

        Task DeactivateUser(string id);

        Task<string> Create(string emailAddress, string phoneNumber, string password, string role);

        Task ChangeUserEmail(string id, string emailAddress);

        Task ChangeUserPhoneNumber(string id, string phoneNumber);

        Task<string> UserName(ClaimsPrincipal user);
        Task<string> UserNameByUserId(string userId);

        string UserId(ClaimsPrincipal user);

        Task<bool> IsClient(ClaimsPrincipal user);
    }
}
