﻿using CustomerSupportSystem.Core.Contracts;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace CustomerSupportSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task ChangeUserEmail(string id, string emailAddress)
        {
            var applicationUser = await GetUserByID(id);

            if (applicationUser != null)
            {
                applicationUser.UserName = emailAddress;
                applicationUser.NormalizedUserName = userManager.NormalizeEmail(emailAddress);
                applicationUser.Email = emailAddress;
                applicationUser.NormalizedEmail = userManager.NormalizeEmail(emailAddress);

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
                applicationUser.IsActive = false;
                applicationUser.UserName = null;
                applicationUser.NormalizedUserName = null;
                applicationUser.Email = null;
                applicationUser.NormalizedEmail = null;
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

        
    }
}
