namespace CustomerSupportSystem.Core.Models.Enums
{
    public class TicketStatusModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketStatusTitleMaxLenght)]
        public string Title { get; set; } = null!;
    }
}
