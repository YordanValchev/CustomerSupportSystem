using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CustomerSupportSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IContactService contactService;
        private readonly IEmployeeService employeeService;

        public UserService(
            UserManager<ApplicationUser> _userManager, 
            IContactService _contactService,
            IEmployeeService _employeeService)
        {
            userManager = _userManager;
            contactService = _contactService;
            employeeService = _employeeService;
        }

        public async Task ChangeUserEmail(string id, string emailAddress)
        {
            var applicationUser = await GetUserByID(id);

            if (applicationUser != null)
            {
                await userManager.SetUserNameAsync(applicationUser, emailAddress);
                applicationUser.Email = emailAddress;
                await userManager.UpdateNormalizedEmailAsync(applicationUser);

                var result = await userManager.UpdateAsync(applicationUser);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task ChangeUserPhoneNumber(string id, string phoneNumber)
        {
            var applicationUser = await GetUserByID(id);

            if (applicationUser != null)
            {
                applicationUser.PhoneNumber = phoneNumber;

                var result = await userManager.UpdateAsync(applicationUser);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task<string> Create(string emailAddress, string phoneNumber, string password, string role)
        {
            var user = new ApplicationUser()
            {
                UserName = emailAddress,
                Email = emailAddress,
                PhoneNumber = phoneNumber
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(user, role);

                if (roleResult.Succeeded)
                {
                    return await userManager.GetUserIdAsync(user);
                }
            }

            throw new InvalidOperationException();
        }

        public async Task DeactivateUser(string id)
        {
            var applicationUser = await GetUserByID(id);

            if (applicationUser != null)
            {
                await userManager.RemovePasswordAsync(applicationUser);
                applicationUser.IsActive = false;
                applicationUser.UserName = applicationUser.Id;
                await userManager.UpdateNormalizedUserNameAsync(applicationUser);
                applicationUser.Email = null;
                await userManager.UpdateNormalizedEmailAsync(applicationUser);
                applicationUser.PhoneNumber = null;

                var result = await userManager.UpdateAsync(applicationUser);

                if(!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public async Task<ApplicationUser> GetUserByID(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<string> UserName(ClaimsPrincipal user)
        {
            string userId = userManager.GetUserId(user);
            var applicationUser = await GetUserByID(userId);

            if (await userManager.IsInRoleAsync(applicationUser, "Client"))
            {
                var contact = await contactService.ContactDetailsByUserId(userId);
                return $"{contact.FirstName} {contact.LastName}";
            }

            var employee = await employeeService.EmployeeDetailsByUserId(userId);
            return $"{employee.FirstName} {employee.LastName}";
        }
    }
}
