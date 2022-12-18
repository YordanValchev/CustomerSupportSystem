using Microsoft.AspNetCore.Identity;

namespace CustomerSupportSystem.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        private readonly UserManager<ApplicationUser> userManager;

        public ContactService(
            IRepository _repo,
            ILogger<ContactService> _logger,
            UserManager<ApplicationUser> _userManager
            )
        {
            repo = _repo;
            logger = _logger;
            userManager = _userManager;
        }

        //public async Task<IEnumerable<ContactModel>> All()
        //{
        //    return await repo.AllReadonly<Contact>()
        //        .OrderBy(e => e.FirstName)
        //        .ThenBy(e => e.LastName)
        //        .Select(e => new ContactModel()
        //        {
        //            Id = e.Id,
        //            Title = e.Title
        //        })
        //        .ToListAsync();
        //}

        public async Task<int> Create(ContactModel model)
        {
            var contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                JobTitleId = model.JobTitleId
            };

            if(!string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                contact.Emails.Add(new Email() 
                { 
                    EmailAddress = model.EmailAddress,
                    IsMain = true
                });
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                contact.PhoneNumbers.Add(new PhoneNumber() 
                { 
                    Number = model.PhoneNumber,
                    IsMain = true
                });
            }

            if (model.IsUser && !string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                var user = new ApplicationUser()
                {
                    UserName = model.EmailAddress,
                    Email = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await userManager.CreateAsync(user,"n3w_Us3r!");

                if (result.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, "Client");

                    if(roleResult.Succeeded)
                    {
                        contact.UserId = await userManager.GetUserIdAsync(user);
                    }
                }
            }

            try
            {
                await repo.AddAsync(contact);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return contact.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Contact>()
                .AnyAsync(e => e.Id == id);
        }
    }
}
