namespace CustomerSupportSystem.Core.Services
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public EmailAddressService(
            IRepository _repo,
            ILogger<EmailAddressService> _logger
            )
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<Email> AddEmail(string emailAddress, int contactId, int employeeId, bool isMain)
        {
            if (await repo.AllReadonly<Email>().AnyAsync(e =>
                e.ContactId != null &&
                e.ContactId == contactId &&
                e.IsMain != null &&
                e.IsMain == true)
                || await repo.AllReadonly<Email>().AnyAsync(e =>
                e.EmployeeId != null &&
                e.EmployeeId == employeeId &&
                e.IsMain != null &&
                e.IsMain == true)
                )
            {
                isMain = false;
            }

            var entity = new Email()
            {
                EmailAddress = emailAddress,
                IsMain = isMain,
                ContactId = contactId,
                EmployeeId = employeeId
            };

            try
            {
                await repo.AddAsync(entity);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(AddEmail), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return entity;
        }

        public async Task<bool> EmailExists(string emailAddress)
        {
            return await repo.AllReadonly<Email>()
                .AnyAsync(e => e.EmailAddress == emailAddress);
        }

        public async Task<Email> GetEmailByAddress(string emailAddress)
        {
            return await repo.AllReadonly<Email>()
                .Where(e => e.EmailAddress == emailAddress)
                .FirstAsync();
        }

        public async Task UpdateEmailAddress(string emailAddress, string newEmailAddress)
        {
            if(!string.IsNullOrWhiteSpace(newEmailAddress))
            {
                var email = await GetEmailByAddress(emailAddress);
                email.EmailAddress = newEmailAddress;

                try
                {
                    repo.Update(email);
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(UpdateEmailAddress), ex);
                    throw new ApplicationException("Database failed to edit info", ex);
                }
            }
        }
    }
}
