namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketStatusTitleMaxLenght)]
        public string Title { get; set; } = null!; 
        
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<TicketPost> TicketPosts { get; set; } = new List<TicketPost>();
    }
}
