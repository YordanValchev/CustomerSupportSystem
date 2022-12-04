namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class TicketPriority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketPriorityTitleMaxLenght)]
        public string Title { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
