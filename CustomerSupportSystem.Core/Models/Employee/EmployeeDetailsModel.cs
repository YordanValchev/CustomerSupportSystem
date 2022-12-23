namespace CustomerSupportSystem.Core.Models.Employee
{
    public class EmployeeDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        public int? JobTitleId { get; set; }

        [Display(Name = "Job title")]
        public string? JobTitle { get; set; }

        public string? UserId { get; set; }

        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        public string? FormName { get; set; }

        [Display(Name = "Confirm")]
        public bool ConfirmDelete { get; set; } = false;

        public int? PartnerId { get; set; }

        public IEnumerable<PartnersListModel> Partners { get; set; } = new List<PartnersListModel>();

        public IEnumerable<PartnersListModel> AllPartners { get; set; } = new List<PartnersListModel>();
    }
}
