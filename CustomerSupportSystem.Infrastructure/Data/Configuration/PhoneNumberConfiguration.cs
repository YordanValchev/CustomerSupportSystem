namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasOne(d => d.Contact)
                .WithMany(p => p.PhoneNumbers)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PhoneNumbers_Contacts");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.PhoneNumbers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PhoneNumbers_Employees");
        }
    }
}
