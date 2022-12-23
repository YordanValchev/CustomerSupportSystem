namespace CustomerSupportSystem.Core.Models.Enums
{
    public class TicketPriorityModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketPriorityTitleMaxLenght)]
        public string Title { get; set; } = null!;
    }
}
