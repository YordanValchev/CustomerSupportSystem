using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Controllers
{
    [Authorize]
    public class PartnersController : Controller
    {
        private readonly IPartnerService partnerService;

        private readonly ILogger logger;

        public PartnersController(
            IPartnerService _partnerService,
            ILogger<PartnersController> _logger)
        {
            partnerService = _partnerService;
            logger = _logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new PartnerModel()
            {
                Countries = await partnerService.AllCountries(),
                Consultants = await partnerService.AllConsultants()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PartnerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = await partnerService.AllCountries();
                model.Consultants = await partnerService.AllConsultants();

                return View(model);
            }

            if ((await partnerService.CountryExists(model.CountryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CountryId), "Country does not exists");
            }

            if ((await partnerService.ConsultantExists(model.ConsultantId)) == false)
            {
                ModelState.AddModelError(nameof(model.ConsultantId), "Country does not exists");
            }

            int id = await partnerService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
