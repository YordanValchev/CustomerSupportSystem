namespace CustomerSupportSystem.Core.Models.Employee
{
    public class EmployeesQueryDetailModel
    {
        [Display(Name = "#")]
        public int Id { get; set; }

        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [Display(Name = "Job title")]
        public string? JobTitle { get; set; }

        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
