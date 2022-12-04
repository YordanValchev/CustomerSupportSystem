namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketFileConfiguration : IEntityTypeConfiguration<TicketFile>
    {
        public void Configure(EntityTypeBuilder<TicketFile> builder)
        {
            builder.HasOne(d => d.Ticket)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketFiles_Tickets");
        }
    }
}
