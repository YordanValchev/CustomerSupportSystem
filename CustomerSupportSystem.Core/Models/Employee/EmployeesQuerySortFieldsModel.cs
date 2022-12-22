namespace CustomerSupportSystem.Core.Models.Employee
{
    public class EmployeesQuerySortFieldsModel
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string IdImageClass { get; set; } = string.Empty;
        public string FirstNameImageClass { get; set; } = string.Empty;
        public string LastNameImageClass { get; set; } = string.Empty;
        public string JobTitleImageClass { get; set; } = string.Empty;
        public string EmailAddressImageClass { get; set; } = string.Empty;
        public string PhoneNumberImageClass { get; set; } = string.Empty;
    }
}
