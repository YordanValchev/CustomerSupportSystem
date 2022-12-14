namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnersQueryModel
    {
        public string? IdSort { get; set; }
        public string? NameSort { get; set; }
        public string? AddressSort { get; set; }
        public string? CitySort { get; set; }
        public string? CountrySort { get; set; }
        public string? PostcodeSort { get; set; }
        public string? RegistrationNumberSort { get; set; }
        public string? TaxNumberSort { get; set; }
        public string? WebsiteSort { get; set; }
        public string? ConsultantSort { get; set; }

        public IEnumerable<PartnersQueryDetailModel> Partners { get; set; } = new List<PartnersQueryDetailModel>();
    }
}
