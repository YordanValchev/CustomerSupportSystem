using CustomerSupportSystem.Infrastructure.Data.Models;

namespace CustomerSupportSystem.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository repo;

        private readonly IEmailAddressService emailService;

        private readonly IPhoneNumberService phoneNumberService;

        private readonly IPartnerService partnerService;

        private readonly ILogger logger;

        public EmployeeService(
            IRepository _repo,
            IEmailAddressService _emailService,
            IPhoneNumberService _phoneNumberService,
            IPartnerService _partnerService,
            ILogger<EmployeeService> _logger
            )
        {
            repo = _repo;
            emailService = _emailService;
            phoneNumberService = _phoneNumberService;
            partnerService = _partnerService;
            logger = _logger;
        }

        public async Task AddPartner(int employeeId, int partnerId)
        {
            var entity = await repo.GetByIdAsync<Partner>(partnerId);

            if(entity.ConsultantId == null)
            {
                entity.ConsultantId = employeeId;

                try
                {
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(AddPartner), ex);
                    throw new ApplicationException("Database failed to save info", ex);
                }
            }
        }

        public async Task<IEnumerable<EmployeeDetailsPartnerModel>> AllPartners()
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => partner.IsActive ?? false)
                .Select(partner => new EmployeeDetailsPartnerModel()
                {
                    Id = partner.Id,
                    Name = partner.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeDetailsPartnerModel>> AllPartnersWithoutConsultant()
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => (partner.IsActive ?? false) && partner.ConsultantId == null)
                .Select(partner => new EmployeeDetailsPartnerModel()
                {
                    Id = partner.Id,
                    Name = partner.Name
                })
                .ToListAsync();
        }

        public async Task<int> Create(EmployeeModel model)
        {
            var entity = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                JobTitleId = model.JobTitleId,
                UserId = model.UserId
            };

            try
            {
                await repo.AddAsync(entity);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            if (!string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                await emailService.AddEmail(model.EmailAddress, null, entity.Id, true);
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                await phoneNumberService.AddPhoneNumber(model.PhoneNumber, null, entity.Id, true);
            }

            return entity.Id;
        }

        public async Task Delete(int employeeId, EmployeeDetailsModel model)
        {
            var entity = await repo.GetByIdAsync<Employee>(employeeId);

            entity.FirstName = null;
            entity.LastName = null;
            entity.JobTitleId = null;
            entity.IsActive = false;

            if (!string.IsNullOrWhiteSpace(model.EmailAddress))
            {
                await emailService.DeleteEmailAddress(model.EmailAddress);
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                await phoneNumberService.DeletePhoneNumber(model.PhoneNumber);
            }

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Edit), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task Edit(int employeeId, EmployeeModel model)
        {
            var entity = await repo.GetByIdAsync<Employee>(employeeId);

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.JobTitleId = model.JobTitleId;
            entity.UserId = model.UserId;

            string currentEmailAddress = model.CurrentEmailAddress ?? string.Empty;
            string newEmailAddress = model.EmailAddress ?? string.Empty;

            if (currentEmailAddress != newEmailAddress)
            {
                if (string.IsNullOrWhiteSpace(currentEmailAddress) && !string.IsNullOrWhiteSpace(newEmailAddress))
                {
                    await emailService.AddEmail(newEmailAddress, null, model.Id, true);
                }
                else
                {
                    await emailService.UpdateEmailAddress(currentEmailAddress, newEmailAddress);
                }
            }

            string currentPhoneNumber = model.CurrentPhoneNumber ?? string.Empty;
            string newPhoneNumber = model.PhoneNumber ?? string.Empty;

            if (currentPhoneNumber != newPhoneNumber)
            {
                if (string.IsNullOrWhiteSpace(currentPhoneNumber) && !string.IsNullOrWhiteSpace(newPhoneNumber))
                {
                    await phoneNumberService.AddPhoneNumber(newPhoneNumber, null, model.Id, true);
                }
                else
                {
                    await phoneNumberService.UpdatePhoneNumber(currentPhoneNumber, newPhoneNumber);
                }
            }

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Edit), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task<EmployeeDetailsModel> EmployeeDetails(int id)
        {
            return await repo.AllReadonly<Employee>()
                .Include(employee => employee.Emails)
                .Include(employee => employee.PhoneNumbers)
                .Where(employee => employee.Id == id)
                .Select(employee => new EmployeeDetailsModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    JobTitleId = employee.JobTitleId,
                    JobTitle = employee.JobTitle == null ? string.Empty : employee.JobTitle.Title,
                    UserId = employee.UserId,
                    EmailAddress = employee.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    PhoneNumber = employee.PhoneNumbers.First(p => p.IsMain ?? false).Number
                })
                .FirstAsync();
        }

        public async Task<EmployeeDetailsModel> EmployeeDetailsByUserId(string id)
        {
            return await repo.AllReadonly<Employee>()
                .Include(employee => employee.Emails)
                .Include(employee => employee.PhoneNumbers)
                .Where(employee => employee.UserId != null && employee.UserId == id)
                .Select(employee => new EmployeeDetailsModel()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    JobTitleId = employee.JobTitleId,
                    JobTitle = employee.JobTitle == null ? string.Empty : employee.JobTitle.Title,
                    UserId = employee.UserId,
                    EmailAddress = employee.Emails.First(e => e.IsMain ?? false).EmailAddress,
                    PhoneNumber = employee.PhoneNumbers.First(p => p.IsMain ?? false).Number
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<EmployeeDetailsPartnerModel>> EmployeeDetailsPartners(int id)
        {
            return await repo.AllReadonly<Partner>()
                .Where(partner => partner.ConsultantId == id && (partner.IsActive ?? false))
                .Select(partner => new EmployeeDetailsPartnerModel()
                {
                    Id = partner.Id,
                    Name = partner.Name
                })
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Employee>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task RemovePartner(int employeeId, int partnerId)
        {
            var entity = await repo.GetByIdAsync<Partner>(partnerId);

            if (entity.ConsultantId != null && entity.ConsultantId == employeeId)
            {
                entity.ConsultantId = null;

                try
                {
                    await repo.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(nameof(AddPartner), ex);
                    throw new ApplicationException("Database failed to save info", ex);
                }
            }
        }

        public async Task<EmployeesQueryModel> QueryEmployees(string? sortOrder, int partnerId, string? filter, int currentPage, int rowsPerPage)
        {
            var model = new EmployeesQueryModel();

            var entities = repo.AllReadonly<Employee>()
                .Where(e => e.IsActive == true);

            if (await partnerService.PartnerExists(partnerId))
            {
                entities = entities
                    .Include(e => e.Clients)
                    .Where(e => e.Clients.Any(c => c.Id == partnerId));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = $"%{filter.ToLower()}%";

                entities = entities
                    .Include(e => e.Emails)
                    .Include(e => e.PhoneNumbers)
                    .Where(e =>
                        EF.Functions.Like(e.FirstName == null ? string.Empty : e.FirstName.ToLower(), filter) ||
                        EF.Functions.Like(e.LastName == null ? string.Empty : e.LastName.ToLower(), filter) ||
                        EF.Functions.Like(e.JobTitle == null ? string.Empty : e.JobTitle.Title.ToLower(), filter) ||
                        EF.Functions.Like(e.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : e.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress.ToLower(), filter) ||
                        EF.Functions.Like(e.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : e.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number.ToLower(), filter)
                        );
            }

            model.SortFields.Id = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.SortFields.FirstName = sortOrder == "FirstName" ? "FirstName_Desc" : "FirstName";
            model.SortFields.LastName = sortOrder == "LastName" ? "LastName_Desc" : "LastName";
            model.SortFields.JobTitle = sortOrder == "JobTitle" ? "JobTitle_Desc" : "JobTitle";
            model.SortFields.EmailAddress = sortOrder == "EmailAddress" ? "EmailAddress_Desc" : "EmailAddress";
            model.SortFields.PhoneNumber = sortOrder == "PhoneNumber" ? "PhoneNumber_Desc" : "PhoneNumber";

            entities = sortOrder switch
            {
                "FirstName" => entities.OrderBy(s => s.FirstName),
                "LastName" => entities.OrderBy(s => s.LastName),
                "JobTitle" => entities.OrderBy(s => s.JobTitle),
                "EmailAddress" => entities.OrderBy(s => s.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress),
                "PhoneNumber" => entities.OrderBy(s => s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number),

                "FirstName_Desc" => entities.OrderByDescending(s => s.FirstName),
                "LastName_Desc" => entities.OrderByDescending(s => s.LastName),
                "JobTitle_Desc" => entities.OrderByDescending(s => s.JobTitle),
                "EmailAddress_Desc" => entities.OrderByDescending(s => s.Emails.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.Emails.FirstOrDefault(e => e.IsMain == true).EmailAddress),
                "PhoneNumber_Desc" => entities.OrderByDescending(s => s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true) == null ? string.Empty : s.PhoneNumbers.FirstOrDefault(e => e.IsMain == true).Number),

                "Id_Desc" => entities.OrderByDescending(s => s.Id),
                _ => entities.OrderBy(s => s.Id),
            };

            string ascOrderImageClass = "bi-caret-up";
            string descOrderImageClass = "bi-caret-down";

            switch (sortOrder)
            {
                case "Name":
                    model.SortFields.FirstNameImageClass = ascOrderImageClass;
                    break;
                case "Address":
                    model.SortFields.LastNameImageClass = ascOrderImageClass;
                    break;
                case "JobTitle":
                    model.SortFields.JobTitleImageClass = ascOrderImageClass;
                    break;
                case "EmailAddress":
                    model.SortFields.EmailAddressImageClass = ascOrderImageClass;
                    break;
                case "PhoneNumber":
                    model.SortFields.PhoneNumberImageClass = ascOrderImageClass;
                    break;

                case "Name_Desc":
                    model.SortFields.FirstNameImageClass = descOrderImageClass;
                    break;
                case "Address_Desc":
                    model.SortFields.LastNameImageClass = descOrderImageClass;
                    break;
                case "JobTitle_Desc":
                    model.SortFields.JobTitleImageClass = descOrderImageClass;
                    break;
                case "EmailAddress_Desc":
                    model.SortFields.EmailAddressImageClass = descOrderImageClass;
                    break;
                case "PhoneNumber_Desc":
                    model.SortFields.PhoneNumberImageClass = descOrderImageClass;
                    break;

                case "Id_Desc":
                    model.SortFields.IdImageClass = descOrderImageClass;
                    break;
                default:
                    model.SortFields.IdImageClass = ascOrderImageClass;
                    break;
            };

            model.Employees = await entities
                .Skip((currentPage - 1) * rowsPerPage)
                .Take(rowsPerPage)
                .Select(contact => new EmployeesQueryDetailModel()
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    JobTitle = contact.JobTitle.Title,
                    PhoneNumber = contact.PhoneNumbers.First(e => e.IsMain == true).Number,
                    EmailAddress = contact.Emails.First(e => e.IsMain == true).EmailAddress
                })
                .ToListAsync();

            model.TotalRowsCount = await entities.CountAsync();

            return model;
        }
    }
}
