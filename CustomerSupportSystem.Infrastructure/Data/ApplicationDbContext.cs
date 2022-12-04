using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CustomerSupportSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new EmailConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            builder.ApplyConfiguration(new JobTitleConfiguration());
            builder.ApplyConfiguration(new PartnerConfiguration());
            builder.ApplyConfiguration(new PartnerContactConfiguration());
            builder.ApplyConfiguration(new PhoneNumberConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TicketFileConfiguration());
            builder.ApplyConfiguration(new TicketParticipantConfiguration());
            builder.ApplyConfiguration(new TicketPostConfiguration());
            builder.ApplyConfiguration(new TicketPriorityConfiguration());
            builder.ApplyConfiguration(new TicketStatusConfiguration());
            builder.ApplyConfiguration(new TicketTypeConfiguration());

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketPost> TicketPosts { get; set; } = null!;
        public virtual DbSet<TicketParticipant> TicketParticipants { get; set; } = null!;
        public virtual DbSet<TicketFile> Files { get; set; } = null!;
        public virtual DbSet<TicketPriority> TicketPriorities { get; set; } = null!;
        public virtual DbSet<TicketType> TicketTypes { get; set; } = null!;
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<PartnerContact> PartnerContacts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;
        public virtual DbSet<JobTitle> JobTitles { get; set; } = null!;
    }
}