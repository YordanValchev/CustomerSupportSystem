namespace CustomerSupportSystem.Core.Models.Ticket
{
    public class TicketsQuerySortFieldsModel
    {
        public string Id { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public string DeteFinished { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string WorkedTime { get; set; } = string.Empty;
        public string WorkedTimeBillable { get; set; } = string.Empty;

        public string IdImageClass { get; set; } = string.Empty;
        public string DateCreatedImageClass { get; set; } = string.Empty;
        public string DeteFinishedImageClass { get; set; } = string.Empty;
        public string SubjectImageClass { get; set; } = string.Empty;
        public string TypeImageClass { get; set; } = string.Empty;
        public string PriorityImageClass { get; set; } = string.Empty;
        public string StatusImageClass { get; set; } = string.Empty;
        public string WorkedTimeImageClass { get; set; } = string.Empty;
        public string WorkedTimeBillableImageClass { get; set; } = string.Empty;
    }
}
