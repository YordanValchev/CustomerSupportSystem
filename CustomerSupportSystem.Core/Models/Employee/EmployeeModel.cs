namespace CustomerSupportSystem.Core.Models.Employee
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(DataTypesConstants.PersonFirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last name")]
        [StringLength(DataTypesConstants.PersonLastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Job title")]
        public int? JobTitleId { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [StringLength(DataTypesConstants.EmailAddressMaxLenght)]
        [RegularExpression(DataTypesConstants.EmailAddressRegex, ErrorMessage = DataTypesConstants.EmailAddressRegexErrorMsg)]
        public string EmailAddress { get; set; } = null!;

        public string? CurrentEmailAddress { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [StringLength(DataTypesConstants.PhoneNumberMaxLenght)]
        [RegularExpression(DataTypesConstants.PhoneNumberRegex, ErrorMessage = DataTypesConstants.PhoneNumberRegexErrorMsg)]
        public string PhoneNumber { get; set; } = null!;

        public string? CurrentPhoneNumber { get; set; }

        public string? UserId { get; set; }

        public IEnumerable<JobTitleModel> JobTitles { get; set; } = new List<JobTitleModel>();
    }
}
