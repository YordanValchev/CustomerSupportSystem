namespace CustomerSupportSystem.Core.Models.Contact
{
    public class ContactsQueryModel
    {
        public string? SortOrder { get; set; }

        public ContactsQuerySortFieldsModel SortFields { get; set; } = new ContactsQuerySortFieldsModel();

        public int PartnerId { get; set; } = -1;

        public string? Filter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public static int RowsPerPage { get; } = 15;

        public int TotalRowsCount { get; set; }

        public IEnumerable<ContactsQueryDetailModel> Contacts { get; set; } = new List<ContactsQueryDetailModel>();

        public IEnumerable<PartnersListModel> Partners { get; set; } = new List<PartnersListModel>();
    }
}
