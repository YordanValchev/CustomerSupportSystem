namespace CustomerSupportSystem.Core.Models.Ticket
{
    public class TicketsQueryModel
    {
        public string? SortOrder { get; set; }

        public TicketsQuerySortFieldsModel SortFields { get; set; } = new TicketsQuerySortFieldsModel();

        public string? UserId { get; set; }

        public int PartnerId { get; set; } = -1;

        public int TypeId { get; set; } = -1;

        public int StatusId { get; set; } = -1;

        public int PriorityId { get; set; } = -1;

        public string? Filter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public static int RowsPerPage { get; } = 15;

        public int TotalRowsCount { get; set; }

        public IEnumerable<TicketsQueryDetailModel> Tickets { get; set; } = new List<TicketsQueryDetailModel>();

        public IEnumerable<PartnersListModel> Partners { get; set; } = new List<PartnersListModel>();

        public IEnumerable<TicketTypeModel> TicketTypes { get; set; } = new List<TicketTypeModel>();

        public IEnumerable<TicketStatusModel> TicketStatuses { get; set; } = new List<TicketStatusModel>();

        public IEnumerable<TicketPriorityModel> TicketPriorities { get; set; } = new List<TicketPriorityModel>();

        public IEnumerable<UsersListModel> Users { get; set; } = new List<UsersListModel>();
    }
}
