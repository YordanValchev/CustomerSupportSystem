namespace CustomerSupportSystem.Core.Models.Ticket
{
    public class TicketsQueryDetailModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "Created on")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Finished on")]
        public DateTime? DeteFinished { get; set; }

        public string Subject { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Priority { get; set; } = null!;

        public string Status { get; set; } = null!;

        [Display(Name = "Worked time")]
        public int WorkedTime { get; set; } = 0;

        [Display(Name = "Billable time")]
        public int WorkedTimeBillable { get; set; } = 0;
    }
}
