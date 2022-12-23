using CustomerSupportSystem.Core.Models.Ticket;
using CustomerSupportSystem.Core.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CustomerSupportSystem.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ILogger<TicketsController> logger;
        private readonly ITicketService ticketService;
        private readonly IUserService userService;
        private readonly ITicketTypeService ticketTypeService;
        private readonly ITicketStatusService ticketStatusService;
        private readonly ITicketPriorityService ticketPriorityService;
        private readonly IEmployeeService employeeService;

        public TicketsController(
            ILogger<TicketsController> _logger,
            ITicketService _ticketService,
            IUserService _userService,
            ITicketTypeService _ticketTypeService,
            ITicketStatusService _ticketStatusService,
            ITicketPriorityService _ticketPriorityService,
            IEmployeeService _employeeService)
        {
            logger = _logger;
            ticketService = _ticketService;
            userService = _userService;
            ticketTypeService = _ticketTypeService;
            ticketStatusService = _ticketStatusService;
            ticketPriorityService = _ticketPriorityService;
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] TicketsQueryModel query)
        {
            string userID = userService.UserId(User);
            bool isClient = await userService.IsClient(User);

            if (isClient && query.UserId == "All")
            {
                query.UserId = userID;
            }

            var result = await ticketService.QueryTickets(
                query.SortOrder,
                query.UserId ?? "All",
                query.PartnerId,
                query.TypeId,
                query.PriorityId,
                query.StatusId,
                query.Filter,
                query.CurrentPage,
                TicketsQueryModel.RowsPerPage
                );

            query.TotalRowsCount = result.TotalRowsCount;
            query.SortFields = result.SortFields;
            query.Tickets = result.Tickets;
            query.Partners = await ticketService.AllPartnersByTicketsParticipants(result.UserId ?? "All");
            query.TicketTypes = await ticketTypeService.All();
            query.TicketPriorities = await ticketPriorityService.All();
            query.TicketStatuses = await ticketStatusService.All();
            query.Users = await employeeService.GetUsersList();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = userService.UserId(User);

            var model = new TicketModel()
            {
                StatusId = 1,
                UserId = userId
            };

            model.TeamUsersList = await employeeService.GetUsersList();
            model.Partners = await ticketService.AllPartnersByTicketsParticipants(userId);
            model.TicketTypes = await ticketTypeService.All();
            model.TicketPriorities = await ticketPriorityService.All();
            model.TicketStatuses = await ticketStatusService.All();

            return View(model);
        }
    }
}