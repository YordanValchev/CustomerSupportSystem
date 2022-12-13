namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnersQueryDetailModel
    {
        public int Id { get; set; }

        [Display(Name = "Partner name")]
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Postcode { get; set; }

        [Display(Name = "Registration number")]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "Tax number")]
        public string? TaxNumber { get; set; }

        public string? Website { get; set; }

        public string? Consultant { get; set; }
    }
}
