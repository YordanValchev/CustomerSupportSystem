using CustomerSupportSystem.Infrastructure.Data.Models.BaseClasses;

namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class Employee : Person
    {
        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        public virtual ICollection<Partner> Clients { get; set; } = new List<Partner>();
    }
}
