namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnersQueryModel
    {
        public string? SortOrder { get; set; }

        public PartnersQuerySortFieldsModel SortFields { get; set; } = new PartnersQuerySortFieldsModel();

        public int ConsultantId { get; set; } = -1;

        public int ActiveType { get; set; } = 1;

        public string? Filter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public static int RowsPerPage { get; } = 15;

        public int TotalPartnersCount { get; set; }

        public IEnumerable<PartnersQueryDetailModel> Partners { get; set; } = new List<PartnersQueryDetailModel>();

        public IEnumerable<PartnerConsultantsModel> Consultants { get; set; } = new List<PartnerConsultantsModel>();
    }
}
