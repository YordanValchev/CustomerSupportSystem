namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool? IsActive { get; set; } = true;

        public virtual ICollection<TicketParticipant> TicketParticipants { get; set; } = new HashSet<TicketParticipant>();

        public virtual ICollection<TicketPost> TicketPosts { get; set; } = new List<TicketPost>();

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
