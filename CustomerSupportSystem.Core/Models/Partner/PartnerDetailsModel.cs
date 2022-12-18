namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnerDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = "Partner name")]
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }

        public int? CountryId { get; set; }

        public string? Country { get; set; }

        public string? Postcode { get; set; }

        [Display(Name = "Registration number")]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "Tax number")]
        public string? TaxNumber { get; set; }

        public string? Website { get; set; }

        public int? ConsultantId { get; set; }

        public string? Consultant { get; set; }

        [Display(Name = "Subscription contract number")]
        public string? SubscriptionContractNumber { get; set; }

        [Display(Name = "Is client's sunscription active?")]
        public bool IsSubscriptionActive { get; set; }

        public IEnumerable<PartnerDetailsContactsModel> Contacts { get; set; } = new List<PartnerDetailsContactsModel>();
    }
}
