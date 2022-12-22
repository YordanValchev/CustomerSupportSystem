using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;

namespace CustomerSupportSystem.Controllers
{
    [Authorize(Roles = "Administrator,Support")]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        private readonly IPartnerService partnerService;

        private readonly IJobTitleService jobTitleService;

        private readonly IUserService userService;

        private readonly IEmailAddressService emailAddressService;

        private readonly IPhoneNumberService phoneNumberService;

        private readonly ILogger logger;

        public ContactsController(
            IContactService _contactService,
            IPartnerService _partnerService,
            IJobTitleService _JobTitleService,
            IUserService _userService,
            IEmailAddressService _emailAddressService,
            IPhoneNumberService _phoneNumberService,
            ILogger<ContactsController> _logger)
        {
            contactService = _contactService;
            partnerService = _partnerService;
            jobTitleService = _JobTitleService;
            userService = _userService;
            emailAddressService = _emailAddressService;
            phoneNumberService = _phoneNumberService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] ContactsQueryModel query)
        {
            var result = await contactService.QueryContacts(
                query.SortOrder,
                query.PartnerId,
                query.Filter,
                query.CurrentPage,
                PartnersQueryModel.RowsPerPage
                );

            query.TotalRowsCount = result.TotalRowsCount;
            query.Partners = await contactService.AllPartners();
            query.Contacts = result.Contacts;
            query.SortFields = result.SortFields;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int? partnerId)
        {
            var model = new ContactModel()
            {
                JobTitles = await jobTitleService.All(),
                PartnerId = partnerId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactModel model)
        {
            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
            }

            if (await emailAddressService.EmailExists(model.EmailAddress))
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The email address already exists");
            }

            if (await phoneNumberService.PhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number already exists");
            }

            if (model.IsUser && !string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                try
                {
                    model.UserId = await userService.Create(model.EmailAddress, model.PhoneNumber, "n3w_Us3r!", "Client");
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.IsUser), "New user error");
                }
            }

            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            int id = await contactService.Create(model);

            int partnerId = model.PartnerId ?? -1;

            if (partnerId > 0)
            {
                await partnerService.CreatePartnerContact(partnerId, id);

                return RedirectToAction("Details", "Partners", new { id = partnerId });
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if ((await contactService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var contactDetails = await contactService.ContactDetails(id);
            
            var model = new ContactDetailsModel()
            {
                Id = contactDetails.Id,
                FirstName = contactDetails.FirstName ?? string.Empty,
                LastName = contactDetails.LastName ?? string.Empty,
                JobTitleId = contactDetails.JobTitleId,
                EmailAddress = contactDetails.EmailAddress ?? string.Empty,
                PhoneNumber = contactDetails.PhoneNumber ?? string.Empty,
                IsUser = contactDetails.UserId != null,
                UserId = contactDetails.UserId
            };

            model.Partners = await contactService.ContactDetailsPartners(id);
            model.AllPartners = await contactService.AllPartnersByContactId(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ContactDetailsModel model)
        {
            if ((await contactService.Exists(model.Id)) == false)
            {
                model.Partners = await contactService.ContactDetailsPartners(model.Id);
                model.AllPartners = await contactService.AllPartnersByContactId(model.Id);

                ModelState.AddModelError(nameof(model.PartnerId), "Error loading contact");
                return View(model);
            }

            if (model.PartnerId == null || !await partnerService.PartnerExists(model.PartnerId ?? -1))
            {
                model.Partners = await contactService.ContactDetailsPartners(model.Id);
                model.AllPartners = await contactService.AllPartnersByContactId(model.Id);

                ModelState.AddModelError(nameof(model.PartnerId), "Invalid partner!");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.FormName) && model.FormName == "AddPartner")
            {
                await contactService.AddPartner(model.Id, model.PartnerId ?? -1);
            }
            else if (!string.IsNullOrWhiteSpace(model.FormName) && model.FormName == "RemovePartner")
            {
                await contactService.RemovePartner(model.Id, model.PartnerId ?? -1);
            }

            model.PartnerId = null;
            model.Partners = await contactService.ContactDetailsPartners(model.Id);
            model.AllPartners = await contactService.AllPartnersByContactId(model.Id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id,int? partnerId)
        {
            if ((await contactService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var contactDetails = await contactService.ContactDetails(id);

            var model = new ContactModel()
            {
                Id = contactDetails.Id,
                FirstName = contactDetails.FirstName ?? string.Empty,
                LastName = contactDetails.LastName ?? string.Empty,
                JobTitleId = contactDetails.JobTitleId,
                EmailAddress = contactDetails.EmailAddress ?? string.Empty,
                CurrentEmailAddress = contactDetails.EmailAddress ?? string.Empty,
                PhoneNumber = contactDetails.PhoneNumber ?? string.Empty,
                CurrentPhoneNumber = contactDetails.PhoneNumber ?? string.Empty,
                IsUser = contactDetails.UserId != null,
                UserId = contactDetails.UserId,
                PartnerId = partnerId,
                JobTitles = await jobTitleService.All()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactModel model)
        {
            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
            }

            if (!string.IsNullOrWhiteSpace(model.EmailAddress) && model.EmailAddress != model.CurrentEmailAddress && (await emailAddressService.EmailExists(model.EmailAddress)))
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The email address already exists");
            }

            if (!string.IsNullOrWhiteSpace(model.PhoneNumber) && model.PhoneNumber != model.CurrentPhoneNumber && (await phoneNumberService.PhoneNumberExists(model.PhoneNumber)))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number already exists");
            }

            if (string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.UserId) && model.IsUser)
            {
                ModelState.AddModelError(nameof(model.EmailAddress), "The contact has active user! The email address can not be empty!");
            }

            if (!string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.UserId) && model.IsUser && model.EmailAddress != model.CurrentEmailAddress)
            {
                try
                {
                    await userService.ChangeUserEmail(model.UserId, model.EmailAddress);
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.IsUser), "Change user email error");
                }
            }

            if (!string.IsNullOrWhiteSpace(model.UserId) && model.IsUser && model.PhoneNumber != model.CurrentPhoneNumber)
            {
                try
                {
                    await userService.ChangeUserPhoneNumber(model.UserId, model.PhoneNumber);
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.IsUser), "Change user phone number error");
                }
            }

            if (string.IsNullOrWhiteSpace(model.UserId) && model.IsUser && !string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                try
                {
                    model.UserId = await userService.Create(model.EmailAddress, model.PhoneNumber, "n3w_Us3r!", "Client");
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.IsUser), "New user error");
                }
            }

            if (!string.IsNullOrWhiteSpace(model.UserId) && !model.IsUser)
            {
                try
                {
                    await userService.DeactivateUser(model.UserId);
                }
                catch
                {
                    ModelState.AddModelError(nameof(model.IsUser), "Deactivate user error");
                }

                model.UserId = null;
            }

            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            await contactService.Edit(model.Id, model);

            int partnerId = model.PartnerId ?? -1;

            if (partnerId > 0)
            {
                return RedirectToAction("Details", "Partners", new { id = partnerId });
            }

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int? partnerId)
        {
            if ((await contactService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var contactDetails = await contactService.ContactDetails(id);

            var model = new ContactDetailsModel()
            {
                Id = contactDetails.Id,
                FirstName = contactDetails.FirstName ?? string.Empty,
                LastName = contactDetails.LastName ?? string.Empty,
                JobTitleId = contactDetails.JobTitleId,
                EmailAddress = contactDetails.EmailAddress ?? string.Empty,
                PhoneNumber = contactDetails.PhoneNumber ?? string.Empty,
                IsUser = contactDetails.UserId != null,
                UserId = contactDetails.UserId,
                PartnerId = partnerId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ContactDetailsModel model)
        {
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
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await contactService.Delete(model.Id, model);

            int partnerId = model.PartnerId ?? -1;

            if (partnerId > 0)
            {
                return RedirectToAction("Details", "Partners", new { id = partnerId });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
