namespace CustomerSupportSystem.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<bool> Exists(int id);

        Task<int> Create(EmployeeModel model);

        Task Edit(int employeeId, EmployeeModel model);

        Task Delete(int employeeId, EmployeeDetailsModel model);

        Task<EmployeeDetailsModel> EmployeeDetails(int id);

        Task<EmployeeDetailsModel> EmployeeDetailsByUserId(string id);

        Task<IEnumerable<PartnersListModel>> EmployeeDetailsPartners(int id);

        Task<IEnumerable<PartnersListModel>> AllPartners();

        Task<IEnumerable<PartnersListModel>> AllPartnersWithoutConsultant();

        Task AddPartner(int employeeId, int partnerId);

        Task RemovePartner(int employeeId, int partnerId);

        Task<EmployeesQueryModel> QueryEmployees(string? sortOrder, int partnerId, string? filter, int currentPage, int rowsPerPage);

        Task<IEnumerable<UsersListModel>> GetUsersList();
    }
}
