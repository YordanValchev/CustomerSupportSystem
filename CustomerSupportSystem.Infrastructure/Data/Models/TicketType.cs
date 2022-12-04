namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class TicketType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketTypeTitleMaxLenght)]
        public string Title { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
