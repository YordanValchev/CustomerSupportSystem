namespace CustomerSupportSystem.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository repo;
        private readonly IPartnerService partnerService;
        private readonly ITicketTypeService ticketTypeService;
        private readonly ITicketStatusService ticketStatusService;
        private readonly ITicketPriorityService ticketPriorityService;
        private readonly IUserService userService;
        private readonly ILogger logger;

        public TicketService(
            IRepository _repo,
            IPartnerService _partnerService,
            ITicketTypeService _ticketTypeService,
            ITicketStatusService _ticketStatusService,
            ITicketPriorityService _ticketPriorityService,
            IUserService _userService,
            ILogger<TicketService> _logger
            )
        {
            repo = _repo;
            partnerService = _partnerService;
            ticketTypeService = _ticketTypeService;
            ticketStatusService = _ticketStatusService;
            ticketPriorityService = _ticketPriorityService;
            userService = _userService;
            logger = _logger;
        }

        public async Task<IEnumerable<PartnersListModel>> AllPartnersByTicketsParticipants(string userId)
        {
            var partners = repo.AllReadonly<Partner>();

            if (userId != "All")
            {
                partners = partners
                    .Include(p => p.Tickets)
                    .ThenInclude(t => t.Participants)
                    .Where(p => p.Tickets.Select(t => t.Participants).Any(tp => tp.Any(p => p.UserId == userId)));
            }

            return await
                partners
                .Include(p => p.Tickets)
                .Where(p => p.Tickets.Any())
                .Select(p => new PartnersListModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

        public async Task<TicketsQueryModel> QueryTickets(string? sortOrder, string userId, int partnerId, int typeId, int statusId, int priorityId, string? filter, int currentPage, int rowsPerPage)
        {
            var model = new TicketsQueryModel();

            var tickets = repo.AllReadonly<Ticket>();

            if(userId != "All")
            {
                tickets = tickets
                    .Include(t => t.Participants)
                    .Where(t => t.Participants.Any(p => p.UserId == userId));
            }

            if (await partnerService.PartnerExists(partnerId))
            {
                tickets = tickets
                    .Where(t => t.PartnerId == partnerId);
            }

            if (await ticketTypeService.Exists(typeId))
            {
                tickets = tickets
                    .Where(t => t.TypeId == typeId);
            }

            if (await ticketStatusService.Exists(statusId))
            {
                tickets = tickets
                    .Where(t => t.StatusId == statusId);
            }

            if (await ticketPriorityService.Exists(priorityId))
            {
                tickets = tickets
                    .Where(t => t.PriorityId == priorityId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = $"%{filter.ToLower()}%";

                tickets = tickets
                    .Where(c =>
                        EF.Functions.Like(c.Subject == null ? string.Empty : c.Subject.ToLower(), filter) ||
                        EF.Functions.Like(c.Id.ToString().ToLower(), filter)
                        );
            }

            model.SortFields.Id = string.IsNullOrEmpty(sortOrder) ? "Id_Desc" : "";
            model.SortFields.DateCreated = sortOrder == "DateCreated" ? "DateCreated_Desc" : "DateCreated";
            model.SortFields.DeteFinished = sortOrder == "DeteFinished" ? "DeteFinished_Desc" : "DeteFinished";
            model.SortFields.Subject = sortOrder == "Subject" ? "Subject_Desc" : "Subject";
            model.SortFields.Type = sortOrder == "Type" ? "Type_Desc" : "Type";
            model.SortFields.Priority = sortOrder == "Priority" ? "Priority_Desc" : "Priority";
            model.SortFields.Status = sortOrder == "Status" ? "Status_Desc" : "Status";
            model.SortFields.WorkedTime = sortOrder == "WorkedTime" ? "WorkedTime_Desc" : "WorkedTime";
            model.SortFields.WorkedTimeBillable = sortOrder == "WorkedTimeBillable" ? "WorkedTimeBillable_Desc" : "WorkedTimeBillable";

            tickets = sortOrder switch
            {
                "DateCreated" => tickets.OrderBy(t => t.DateCreated),
                "DeteFinished" => tickets.OrderBy(t => t.DeteFinished),
                "Subject" => tickets.OrderBy(t => t.Subject),
                "Type" => tickets.OrderBy(t => t.Type.Title),
                "Priority" => tickets.OrderBy(t => t.Priority.Title),
                "Status" => tickets.OrderBy(t => t.Status.Title),
                "WorkedTime" => tickets.OrderBy(t => t.Posts.Sum(p => p.WorkedTime)),
                "WorkedTimeBillable" => tickets.OrderBy(t => t.Posts.Where(p => p.IsTimeBillable ?? false).Sum(p => p.WorkedTime)),

                "DateCreated_Desc" => tickets.OrderByDescending(t => t.DateCreated),
                "DeteFinished_Desc" => tickets.OrderByDescending(t => t.DeteFinished),
                "Subject_Desc" => tickets.OrderByDescending(t => t.Subject),
                "Type_Desc" => tickets.OrderByDescending(t => t.Type.Title),
                "Priority_Desc" => tickets.OrderByDescending(t => t.Priority.Title),
                "Status_Desc" => tickets.OrderByDescending(t => t.Status.Title),
                "WorkedTime_Desc" => tickets.OrderByDescending(t => t.Posts.Sum(p => p.WorkedTime)),
                "WorkedTimeBillable_Desc" => tickets.OrderByDescending(t => t.Posts.Where(p => p.IsTimeBillable ?? false).Sum(p => p.WorkedTime)),

                "Id_Desc" => tickets.OrderByDescending(t => t.Id),
                _ => tickets.OrderBy(t => t.Id),
            };

            string ascOrderImageClass = "bi-caret-up";
            string descOrderImageClass = "bi-caret-down";

            switch (sortOrder)
            {
                case "Name":
                    model.SortFields.DateCreatedImageClass = ascOrderImageClass;
                    break;
                case "Address":
                    model.SortFields.DeteFinishedImageClass = ascOrderImageClass;
                    break;
                case "Subject":
                    model.SortFields.SubjectImageClass = ascOrderImageClass;
                    break;
                case "Type":
                    model.SortFields.TypeImageClass = ascOrderImageClass;
                    break;
                case "Priority":
                    model.SortFields.PriorityImageClass = ascOrderImageClass;
                    break;
                case "Status":
                    model.SortFields.StatusImageClass = ascOrderImageClass;
                    break;
                case "WorkedTime":
                    model.SortFields.WorkedTimeImageClass = ascOrderImageClass;
                    break;
                case "WorkedTimeBillable":
                    model.SortFields.WorkedTimeBillableImageClass = ascOrderImageClass;
                    break;

                case "Name_Desc":
                    model.SortFields.DateCreatedImageClass = descOrderImageClass;
                    break;
                case "Address_Desc":
                    model.SortFields.DeteFinishedImageClass = descOrderImageClass;
                    break;
                case "Subject_Desc":
                    model.SortFields.SubjectImageClass = descOrderImageClass;
                    break;
                case "Type_Desc":
                    model.SortFields.TypeImageClass = descOrderImageClass;
                    break;
                case "Priority_Desc":
                    model.SortFields.PriorityImageClass = descOrderImageClass;
                    break;
                case "Status_Desc":
                    model.SortFields.StatusImageClass = descOrderImageClass;
                    break;
                case "WorkedTime_Desc":
                    model.SortFields.WorkedTimeImageClass = descOrderImageClass;
                    break;
                case "WorkedTimeBillable_Desc":
                    model.SortFields.WorkedTimeBillableImageClass = descOrderImageClass;
                    break;

                case "Id_Desc":
                    model.SortFields.IdImageClass = descOrderImageClass;
                    break;
                default:
                    model.SortFields.IdImageClass = ascOrderImageClass;
                    break;
            };

            model.Tickets = await tickets
                .Skip((currentPage - 1) * rowsPerPage)
                .Take(rowsPerPage)
                .Select(ticket => new TicketsQueryDetailModel()
                {
                    Id = ticket.Id,
                    DateCreated = ticket.DateCreated,
                    DeteFinished = ticket.DeteFinished,
                    Subject = ticket.Subject,
                    Type = ticket.Type.Title,
                    Priority = ticket.Priority.Title,
                    Status = ticket.Status.Title,
                    WorkedTime = ticket.Posts.Sum(p => p.WorkedTime) ?? 0,
                    WorkedTimeBillable = ticket.Posts.Where(p => p.IsTimeBillable ?? false).Sum(p => p.WorkedTime) ?? 0
                })
                .ToListAsync();

            model.TotalRowsCount = await tickets.CountAsync();

            return model;
        }

        public async Task<IEnumerable<UsersListModel>> TicketParticipants(int id)
        {
            var participants = 
                await repo.AllReadonly<TicketParticipant>()
                    .Where(tp => tp.TicketId == id)
                    .Select(tp => new UsersListModel()
                    {
                        Id = tp.UserId
                    })
                    .ToListAsync();

            foreach(var participant in participants)
            {
                participant.Name = await userService.UserNameByUserId(participant.Id ?? string.Empty);
            }

            return participants;
        }

        public async Task<IEnumerable<UsersListModel>> PartnerUsersList(int partnerId)
        {
            return await repo.AllReadonly<PartnerContact>()
                .Where(pc => pc.PartnerId == partnerId)
                .Include(pc => pc.Contact)
                .Select(pc => new UsersListModel()
                {
                    Id = pc.Contact.UserId,
                    Name = $"{pc.Contact.FirstName} {pc.Contact.LastName}"
                })
                .ToListAsync();
        }

        public Task<IEnumerable<UsersListModel>> TeamUsersList(int partnerId)
        {
            throw new NotImplementedException();
        }
    }
}
