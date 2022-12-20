namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnerDetailsContactsModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }

        public string? JobTitle { get; set; }

        public bool IsUser { get; set; } = false;
    }
}
