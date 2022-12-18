using CustomerSupportSystem.Core.Models.Partner;
using CustomerSupportSystem.Infrastructure.Data.Models;
using Microsoft.Data.SqlClient;

namespace CustomerSupportSystem.Controllers
{
    [Authorize(Roles = "Administrator,Support")]
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

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PartnersQueryModel query)
        {
            var result = await partnerService.QueryPartners(
                query.SortOrder,
                query.ConsultantId,
                query.Filter,
                query.CurrentPage,
                PartnersQueryModel.RowsPerPage
                );

            query.TotalPartnersCount = result.TotalPartnersCount;
            query.Consultants = await partnerService.AllConsultants();
            query.Partners = result.Partners;
            query.SortFields = result.SortFields;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if ((await partnerService.PartnerExists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = await partnerService.PartnerDetails(id);
            var contacts = await partnerService.PartnerDetailsContacts(id);

            model.Contacts = contacts;

            return View(model);
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
                ModelState.AddModelError(nameof(model.CountryId), "The country does not exists");
            }

            if ((await partnerService.ConsultantExists(model.ConsultantId)) == false)
            {
                ModelState.AddModelError(nameof(model.ConsultantId), "The consultant does not exists");
            }

            int id = await partnerService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await partnerService.PartnerExists(id)) == false)
            {
                return RedirectToAction(nameof(Index));
            }

            var partnerDetails = await partnerService.PartnerDetails(id);

            var model = new PartnerModel()
            {
                Id = partnerDetails.Id,
                Name = partnerDetails.Name,
                Address = partnerDetails.Address ?? string.Empty,
                City = partnerDetails.City ?? string.Empty,
                CountryId = partnerDetails.CountryId ?? -1,
                Postcode = partnerDetails.Postcode ?? string.Empty,
                RegistrationNumber = partnerDetails.RegistrationNumber,
                TaxNumber = partnerDetails.TaxNumber,
                Website = partnerDetails.Website,
                ConsultantId = partnerDetails.ConsultantId ?? -1,
                SubscriptionContractNumber = partnerDetails.SubscriptionContractNumber,
                IsSubscriptionActive = partnerDetails.IsSubscriptionActive,
                Countries = await partnerService.AllCountries(),
                Consultants = await partnerService.AllConsultants()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartnerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = await partnerService.AllCountries();
                model.Consultants = await partnerService.AllConsultants();

                return View(model);
            }

            if ((await partnerService.CountryExists(model.CountryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CountryId), "The country does not exists");
            }

            if ((await partnerService.ConsultantExists(model.ConsultantId)) == false)
            {
                ModelState.AddModelError(nameof(model.ConsultantId), "The consultant does not exists");
            }

            await partnerService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
}
