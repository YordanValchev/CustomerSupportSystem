namespace CustomerSupportSystem.Controllers
{
    [Authorize(Roles = "Administrator,Support")]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;

        private readonly IPartnerService partnerService;

        private readonly IJobTitleService jobTitleService;

        private readonly ILogger logger;

        public ContactsController(
            IContactService _contactService,
            IPartnerService _partnerService,
            IJobTitleService _JobTitleService,
            ILogger<ContactsController> _logger)
        {
            contactService = _contactService;
            partnerService = _partnerService;
            jobTitleService = _JobTitleService;
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
        public async Task<IActionResult> Add(int partnerId)
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
    }
}
