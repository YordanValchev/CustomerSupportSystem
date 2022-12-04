namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketParticipantConfiguration : IEntityTypeConfiguration<TicketParticipant>
    {
        public void Configure(EntityTypeBuilder<TicketParticipant> builder)
        {
            builder.HasKey(e => new { e.TicketId, e.UserId });

            builder.HasOne(d => d.Ticket)
                .WithMany(p => p.Participants)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketParticipants_Tickets");

            builder.HasOne(d => d.User)
                .WithMany(p => p.TicketParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketParticipants_Users");
        }
    }
}
