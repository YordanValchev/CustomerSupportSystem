namespace CustomerSupportSystem.Core.Models
{
    public class TicketTypeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketTypeTitleMaxLenght)]
        public string Title { get; set; } = null!;
    }
}
