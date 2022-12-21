using System.Net.Mail;

namespace CustomerSupportSystem.Core.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public PhoneNumberService(
            IRepository _repo,
            ILogger<PhoneNumberService> _logger
            )
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<PhoneNumber> AddPhoneNumber(string phoneNumber, int? contactId, int? employeeId, bool? isMain)
        {
            if (await repo.AllReadonly<PhoneNumber>().AnyAsync(e =>
                e.ContactId != null &&
                e.ContactId == contactId &&
                e.IsMain != null &&
                e.IsMain == true)
                || await repo.AllReadonly<PhoneNumber>().AnyAsync(e =>
                e.EmployeeId != null &&
                e.EmployeeId == employeeId &&
                e.IsMain != null &&
                e.IsMain == true)
                )
            {
                isMain = false;
            }

            var entity = new PhoneNumber()
            {
                Number = phoneNumber,
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
                logger.LogError(nameof(AddPhoneNumber), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return entity;
        }

        public async Task DeletePhoneNumber(string phoneNumber)
        {
            var entity = await GetPhoneByNumber(phoneNumber);
            entity.Number = null;
            entity.IsMain = false;

            try
            {
                repo.Update(entity);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeletePhoneNumber), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task<PhoneNumber> GetPhoneByNumber(string phoneNumber)
        {
            return await repo.AllReadonly<PhoneNumber>()
                .Where(e => e.Number == phoneNumber)
                .FirstAsync();
        }

        public async Task<bool> PhoneNumberExists(string phoneNumber)
        {
            return await repo.AllReadonly<PhoneNumber>()
                .AnyAsync(e => e.Number == phoneNumber);
        }

        public async Task UpdatePhoneNumber(string phoneNumber, string newPhoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                var entity = await GetPhoneByNumber(phoneNumber);
                entity.Number = newPhoneNumber;

                if(string.IsNullOrWhiteSpace(newPhoneNumber))
                {
                    entity.IsMain = false;
                }

                try
                {
                    repo.Update(entity);
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(UpdatePhoneNumber), ex);
                    throw new ApplicationException("Database failed to edit info", ex);
                }
            }
        }
    }
}
