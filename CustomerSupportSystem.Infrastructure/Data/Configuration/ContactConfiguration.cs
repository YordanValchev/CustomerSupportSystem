namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(d => d.JobTitle)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Contacts_JobTitles");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Contacts_Users");
        }
    }
}
