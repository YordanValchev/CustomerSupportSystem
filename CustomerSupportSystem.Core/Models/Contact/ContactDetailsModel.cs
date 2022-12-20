namespace CustomerSupportSystem.Core.Models.Contact
{
    public class ContactDetailsModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? JobTitleId { get; set; }

        public string? UserId { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
