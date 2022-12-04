namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DeteFinished { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketSubjectMaxLenght)]
        public string Subject { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public TicketType Type { get; set; } = null!;

        [Required]
        public int PriorityId { get; set; }

        [ForeignKey(nameof(PriorityId))]
        public TicketPriority Priority { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public TicketStatus Status { get; set; } = null!;

        [Required]
        public int PartnerId { get; set; }

        [ForeignKey(nameof(PartnerId))]
        public Partner Partner { get; set; } = null!;

        public virtual ICollection<TicketPost> Posts { get; set; } = new List<TicketPost>();

        public virtual ICollection<TicketFile> Files { get; set; } = new List<TicketFile>();

        public virtual ICollection<TicketParticipant> Participants { get; set; } = new HashSet<TicketParticipant>();
    }
}
