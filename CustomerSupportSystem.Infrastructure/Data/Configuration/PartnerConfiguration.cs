namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Partners)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Partners_Countries");

            builder.HasOne(d => d.Consultant)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.ConsultantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Partners_Consultants");
        }
    }
}
