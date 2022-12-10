using CustomerSupportSystem.Infrastructure.Data.Models;

namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnerModel
    {
        [Required]
        [StringLength(DataTypesConstants.PartnerNameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataTypesConstants.AddressMaxLenght)]
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

        [StringLength(DataTypesConstants.PartnerRegistrationNumberMaxLenght)]
        public string? RegistrationNumber { get; set; }

        [StringLength(DataTypesConstants.PartnerTaxNumberMaxLenght)]
        public string? TaxNumber { get; set; }

        [StringLength(DataTypesConstants.WebsiteMaxLenght)]
        public string? Website { get; set; }

        [Display(Name = "Consultant")]
        public int? ConsultantId { get; set; }

        [StringLength(DataTypesConstants.SubscriptionContractNumberMaxLenght)]
        public string? SubscriptionContractNumber { get; set; }

        public bool? IsSubscriptionActive { get; set; }

        public IEnumerable<PartnerCountriesModel> Countries { get; set; } = new List<PartnerCountriesModel>();

        public IEnumerable<PartnerConsultantsModel> Consultants { get; set; } = new List<PartnerConsultantsModel>();
    }
}
