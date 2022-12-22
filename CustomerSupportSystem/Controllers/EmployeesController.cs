namespace CustomerSupportSystem.Controllers
{
    [Authorize(Roles = "Administrator,Support")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        private readonly IPartnerService partnerService;

        private readonly IJobTitleService jobTitleService;

        private readonly IUserService userService;

        private readonly IEmailAddressService emailAddressService;

        private readonly IPhoneNumberService phoneNumberService;

        private readonly ILogger logger;

        public EmployeesController(
            IEmployeeService _employeeService,
            IPartnerService _partnerService,
            IJobTitleService _JobTitleService,
            IUserService _userService,
            IEmailAddressService _emailAddressService,
            IPhoneNumberService _phoneNumberService,
            ILogger<EmployeesController> _logger)
        {
            employeeService = _employeeService;
            partnerService = _partnerService;
            jobTitleService = _JobTitleService;
            userService = _userService;
            emailAddressService = _emailAddressService;
            phoneNumberService = _phoneNumberService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] EmployeesQueryModel query)
        {
            var result = await employeeService.QueryEmployees(
                query.SortOrder,
                query.PartnerId,
                query.Filter,
                query.CurrentPage,
                PartnersQueryModel.RowsPerPage
                );

            query.TotalRowsCount = result.TotalRowsCount;
            query.Partners = await employeeService.AllPartners();
            query.Employees = result.Employees;
            query.SortFields = result.SortFields;

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add()
        {
            var model = new EmployeeModel()
            {
                JobTitles = await jobTitleService.All()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (await emailAddressService.EmailExists(model.EmailAddress))
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The email address already exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (await phoneNumberService.PhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number already exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            try
            {
                model.UserId = await userService.Create(model.EmailAddress, model.PhoneNumber, "n3w_Us3r!", "Support");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "New user error");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            int id = await employeeService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if ((await employeeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var employeeDetails = await employeeService.EmployeeDetails(id);

            var model = new EmployeeDetailsModel()
            {
                Id = employeeDetails.Id,
                FirstName = employeeDetails.FirstName ?? string.Empty,
                LastName = employeeDetails.LastName ?? string.Empty,
                JobTitleId = employeeDetails.JobTitleId,
                JobTitle = employeeDetails.JobTitle,
                EmailAddress = employeeDetails.EmailAddress ?? string.Empty,
                PhoneNumber = employeeDetails.PhoneNumber ?? string.Empty,
                UserId = employeeDetails.UserId
            };

            model.Partners = await employeeService.EmployeeDetailsPartners(id);
            model.AllPartners = await employeeService.AllPartnersWithoutConsultant();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(EmployeeDetailsModel model)
        {
            if ((await employeeService.Exists(model.Id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            if (model.PartnerId == null || !await partnerService.PartnerExists(model.PartnerId ?? -1))
            {
                model.Partners = await employeeService.EmployeeDetailsPartners(model.Id);
                model.AllPartners = await employeeService.AllPartnersWithoutConsultant();

                ModelState.AddModelError(nameof(model.PartnerId), "Invalid partner!");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.FormName) && model.FormName == "AddPartner")
            {
                await employeeService.AddPartner(model.Id, model.PartnerId ?? -1);
            }
            else if (!string.IsNullOrWhiteSpace(model.FormName) && model.FormName == "RemovePartner")
            {
                await employeeService.RemovePartner(model.Id, model.PartnerId ?? -1);
            }

            model.PartnerId = null;
            model.Partners = await employeeService.EmployeeDetailsPartners(model.Id);
            model.AllPartners = await employeeService.AllPartnersWithoutConsultant();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await employeeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var employeeDetails = await employeeService.EmployeeDetails(id);

            var model = new EmployeeModel()
            {
                Id = employeeDetails.Id,
                FirstName = employeeDetails.FirstName ?? string.Empty,
                LastName = employeeDetails.LastName ?? string.Empty,
                JobTitleId = employeeDetails.JobTitleId,
                EmailAddress = employeeDetails.EmailAddress ?? string.Empty,
                CurrentEmailAddress = employeeDetails.EmailAddress ?? string.Empty,
                PhoneNumber = employeeDetails.PhoneNumber ?? string.Empty,
                CurrentPhoneNumber = employeeDetails.PhoneNumber ?? string.Empty,
                UserId = employeeDetails.UserId,
                JobTitles = await jobTitleService.All()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.EmailAddress) && model.EmailAddress != model.CurrentEmailAddress && (await emailAddressService.EmailExists(model.EmailAddress)))
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The email address already exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber) && model.PhoneNumber != model.CurrentPhoneNumber && (await phoneNumberService.PhoneNumberExists(model.PhoneNumber)))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number already exists");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.UserId))
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The employee has active user! The email address can not be empty!");
                model.JobTitles = await jobTitleService.All();
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.UserId) && model.EmailAddress != model.CurrentEmailAddress)
            {
                try
                {
                    await userService.ChangeUserEmail(model.UserId, model.EmailAddress);
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.EmailAddress), "Change user email error");
                    model.JobTitles = await jobTitleService.All();
                    return View(model);
                }
            }

            if (!string.IsNullOrWhiteSpace(model.UserId) && model.PhoneNumber != model.CurrentPhoneNumber)
            {
                try
                {
                    await userService.ChangeUserPhoneNumber(model.UserId, model.PhoneNumber);
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.PhoneNumber), "Change user phone number error");
                    model.JobTitles = await jobTitleService.All();
                    return View(model);
                }
            }

            if (string.IsNullOrWhiteSpace(model.UserId) && !string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                try
                {
                    model.UserId = await userService.Create(model.EmailAddress, model.PhoneNumber, "n3w_Us3r!", "Support");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "New user error");
                    model.JobTitles = await jobTitleService.All();
                    return View(model);
                }
            }

            await employeeService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await employeeService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var employeeDetails = await employeeService.EmployeeDetails(id);

            var model = new EmployeeDetailsModel()
            {
                Id = employeeDetails.Id,
                FirstName = employeeDetails.FirstName ?? string.Empty,
                LastName = employeeDetails.LastName ?? string.Empty,
                JobTitleId = employeeDetails.JobTitleId,
                JobTitle = employeeDetails.JobTitle,
                EmailAddress = employeeDetails.EmailAddress ?? string.Empty,
                PhoneNumber = employeeDetails.PhoneNumber ?? string.Empty,
                UserId = employeeDetails.UserId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(EmployeeDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!model.ConfirmDelete)
            {
                ModelState.AddModelError(nameof(model.ConfirmDelete), "Please, confirm the task!");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.UserId))
            {
                try
                {
                    await userService.DeactivateUser(model.UserId);
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Delete user error");
                    return View(model);
                }
            }

            await employeeService.Delete(model.Id, model);

            return RedirectToAction(nameof(Index));
        }
    }
}
