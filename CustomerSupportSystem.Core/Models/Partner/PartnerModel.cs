namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnerModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Partner name")]
        [StringLength(DataTypesConstants.PartnerNameMaxLenght,MinimumLength = DataTypesConstants.PartnerNameMinLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataTypesConstants.AddressMaxLenght, MinimumLength = DataTypesConstants.AddressMinLenght)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DataTypesConstants.CityMaxLenght)]
        public string City { get; set; } = null!;

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required]
        [StringLength(DataTypesConstants.PostcodeMaxLenght)]
        public string Postcode { get; set; } = null!;

        [Display(Name = "Registration number")]
        [StringLength(DataTypesConstants.PartnerRegistrationNumberMaxLenght, MinimumLength = DataTypesConstants.PartnerRegistrationNumberMinLenght)]
        public string? RegistrationNumber { get; set; }

        [Display(Name = "Tax number")]
        [StringLength(DataTypesConstants.PartnerTaxNumberMaxLenght, MinimumLength = DataTypesConstants.PartnerTaxNumberMinLenght)]
        public string? TaxNumber { get; set; }

        [StringLength(DataTypesConstants.WebsiteMaxLenght)]
        public string? Website { get; set; }

        [Display(Name = "Consultant")]
        public int? ConsultantId { get; set; }

        [Display(Name = "Subscription contract number")]
        [StringLength(DataTypesConstants.SubscriptionContractNumberMaxLenght)]
        public string? SubscriptionContractNumber { get; set; }

        [Display(Name = "Is client's sunscription active?")]
        public bool IsSubscriptionActive { get; set; } = false;

        [Display(Name = "Is partner active?")]
        public bool IsActive { get; set; } = true;

        public IEnumerable<PartnerCountriesModel> Countries { get; set; } = new List<PartnerCountriesModel>();

        public IEnumerable<PartnerConsultantsModel> Consultants { get; set; } = new List<PartnerConsultantsModel>();
    }
}
