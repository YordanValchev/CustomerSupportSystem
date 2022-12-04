namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class TicketPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [Required]
        public DateTime PostingDate { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketPostTextMaxLenght)]
        public string PostingText { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public TicketStatus Status { get; set; } = null!;

        public int? WorkedTime { get; set; }

        public bool? IsTimeBillable { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
