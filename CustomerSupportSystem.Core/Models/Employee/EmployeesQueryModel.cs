namespace CustomerSupportSystem.Core.Models.Employee
{
    public class EmployeesQueryModel
    {
        public string? SortOrder { get; set; }

        public EmployeesQuerySortFieldsModel SortFields { get; set; } = new EmployeesQuerySortFieldsModel();

        public int PartnerId { get; set; } = -1;

        public string? Filter { get; set; }

        public int CurrentPage { get; set; } = 1;

        public static int RowsPerPage { get; } = 15;

        public int TotalRowsCount { get; set; }

        public IEnumerable<EmployeesQueryDetailModel> Employees { get; set; } = new List<EmployeesQueryDetailModel>();

        public IEnumerable<PartnersListModel> Partners { get; set; } = new List<PartnersListModel>();
    }
}
