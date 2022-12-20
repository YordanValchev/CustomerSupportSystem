using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace CustomerSupportSystem.Controllers
{
    [Authorize(Roles = "Administrator,Support")]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        private readonly IPartnerService partnerService;

        private readonly IJobTitleService jobTitleService;

        private readonly IUserService userService;

        private readonly ILogger logger;

        public ContactsController(
            IContactService _contactService,
            IPartnerService _partnerService,
            IJobTitleService _JobTitleService,
            IUserService _userService,
            ILogger<ContactsController> _logger)
        {
            contactService = _contactService;
            partnerService = _partnerService;
            jobTitleService = _JobTitleService;
            userService = _userService;
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var model = new ContactModel()
        //    {
        //        JobTitles = await jobTitleService.All()
        //    };

        //    return View(model);
        //}

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
            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
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
        public IActionResult Details(int id)
        {
            return View();
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
            if (!ModelState.IsValid)
            {
                model.JobTitles = await jobTitleService.All();

                return View(model);
            }

            if ((await jobTitleService.Exists(model.JobTitleId ?? -1)) == false)
            {
                ModelState.AddModelError(nameof(model.JobTitleId), "The job title does not exists");
            }

            if(string.IsNullOrWhiteSpace(model.EmailAddress) && !string.IsNullOrWhiteSpace(model.UserId) && model.IsUser)
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

            await contactService.Edit(model.Id, model);

            int partnerId = model.PartnerId ?? -1;

            if (partnerId > 0)
            {
                return RedirectToAction("Details", "Partners", new { id = partnerId });
            }

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
}
