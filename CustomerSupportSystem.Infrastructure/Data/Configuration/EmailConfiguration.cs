namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasOne(d => d.Contact)
                .WithMany(p => p.Emails)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Emails_Contacts");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Emails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Emails_Employees");

            builder.HasData(new Email()
            {
                Id = 1,
                EmailAddress = "admin@admin.com",
                EmployeeId = 1
            });
        }
    }
}
