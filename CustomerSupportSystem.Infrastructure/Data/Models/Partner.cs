namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.PartnerNameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(DataTypesConstants.AddressMaxLenght)]
        public string? Address { get; set; }

        [StringLength(DataTypesConstants.CityMaxLenght)]
        public string? City { get; set; }

        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }

        [StringLength(DataTypesConstants.PostcodeMaxLenght)]
        public string? Postcode { get; set; }

        [StringLength(DataTypesConstants.PartnerRegistrationNumberMaxLenght)]
        public string? RegistrationNumber { get; set; }

        [StringLength(DataTypesConstants.PartnerTaxNumberMaxLenght)]
        public string? TaxNumber { get; set; }

        [StringLength(DataTypesConstants.WebsiteMaxLenght)]
        public string? Website { get; set; }

        public int? ConsultantId { get; set; }

        [ForeignKey(nameof(ConsultantId))]
        public Employee? Consultant { get; set; }

        [StringLength(DataTypesConstants.SubscriptionContractNumberMaxLenght)]
        public string? SubscriptionContractNumber { get; set; }

        public bool? IsSubscriptionActive { get; set; }

        public bool? IsActive { get; set; } = true;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<PartnerContact> PartnerContacts { get; set; } = new HashSet<PartnerContact>();
    }
}
