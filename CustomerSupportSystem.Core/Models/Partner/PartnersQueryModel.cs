namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnersQueryModel
    {
        public string? SortOrder { get; set; }

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

        public string? IdSortImageClass { get; set; }
        public string? NameSortImageClass { get; set; }
        public string? AddressSortImageClass { get; set; }
        public string? CitySortImageClass { get; set; }
        public string? CountrySortImageClass { get; set; }
        public string? PostcodeSortImageClass { get; set; }
        public string? RegistrationNumberSortImageClass { get; set; }
        public string? TaxNumberSortImageClass { get; set; }
        public string? WebsiteSortImageClass { get; set; }
        public string? ConsultantSortImageClass { get; set; }

        public int ConsultantId { get; set; } = -1;

        public string? Filter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public static int RowsPerPage { get; } = 20;

        public int TotalPartnersCount { get; set; }

        public IEnumerable<PartnersQueryDetailModel> Partners { get; set; } = new List<PartnersQueryDetailModel>();

        public IEnumerable<PartnerConsultantsModel> Consultants { get; set; } = new List<PartnerConsultantsModel>();
    }
}
