namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class TicketFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.FileNameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataTypesConstants.FileExtensionMaxLenght)]
        public string FileExtension { get; set; } = null!;

        public int? TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket? Ticket { get; set; }
    }
}
