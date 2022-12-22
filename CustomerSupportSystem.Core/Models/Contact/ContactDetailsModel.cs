using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Models.Contact
{
    public class ContactDetailsModel
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

        [Display(Name = "Is contact system user?")]
        public bool IsUser { get; set; } = false;

        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        public string? FormName { get; set; }

        [Display(Name = "Confirm")]
        public bool ConfirmDelete { get; set; } = false;

        public int? PartnerId { get; set; }

        public IEnumerable<ContactDetailsPartnerModel> Partners { get; set; } = new List<ContactDetailsPartnerModel>();

        public IEnumerable<ContactDetailsPartnerModel> AllPartners { get; set; } = new List<ContactDetailsPartnerModel>();
    }
}
