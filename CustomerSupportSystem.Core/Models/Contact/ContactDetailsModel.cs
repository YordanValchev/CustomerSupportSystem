using CustomerSupportSystem.Core.Models.Partner;

namespace CustomerSupportSystem.Core.Models.Contact
{
    public class ContactDetailsModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? JobTitleId { get; set; }

        public string? JobTitle { get; set; }

        public string? UserId { get; set; }

        [Display(Name = "Is contact system user?")]
        public bool IsUser { get; set; } = false;

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }

        [Display(Name = "Confirm")]
        public bool ConfirmDelete { get; set; } = false;

        public int? PartnerId { get; set; }

        public IEnumerable<ContactDetailsPartnerModel> Partners { get; set; } = new List<ContactDetailsPartnerModel>();

        public IEnumerable<ContactDetailsPartnerModel> AllPartners { get; set; } = new List<ContactDetailsPartnerModel>();
    }
}
