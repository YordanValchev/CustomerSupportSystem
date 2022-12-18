namespace CustomerSupportSystem.Core.Models.Contact
{
    public class ContactModel
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
        [RegularExpression(DataTypesConstants.EmailAddressRegex)]
        public string? EmailAddress { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [StringLength(DataTypesConstants.PhoneNumberMaxLenght)]
        [RegularExpression(DataTypesConstants.PhoneNumberRegex)]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Create support system user?")]
        public bool IsUser { get; set; } = false;

        public int? PartnerId { get; set; }

        public IEnumerable<JobTitleModel> JobTitles { get; set; } = new List<JobTitleModel>();
    }
}
