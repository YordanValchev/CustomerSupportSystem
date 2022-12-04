namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class PartnerContact
    {
        [Required]
        public int PartnerId { get; set; }

        [ForeignKey(nameof(PartnerId))]
        public Partner Partner { get; set; } = null!;

        [Required]
        public int ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public Contact Contact { get; set; } = null!;
    }
}
