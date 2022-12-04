namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class PartnerContactConfiguration : IEntityTypeConfiguration<PartnerContact>
    {
        public void Configure(EntityTypeBuilder<PartnerContact> builder)
        {
            builder.HasKey(e => new { e.PartnerId, e.ContactId });

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.PartnerContacts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PartnerContacts_Partners");

            builder.HasOne(d => d.Contact)
                .WithMany(p => p.PartnerContacts)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_PartnerContacts_Contacts");
        }
    }
}
