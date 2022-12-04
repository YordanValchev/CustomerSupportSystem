namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .Property(t => t.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(d => d.Type)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tickets_Types");

            builder.HasOne(d => d.Priority)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tickets_Priorities");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tickets_Statuses");

            builder.HasOne(d => d.Partner)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tickets_Partners");
        }
    }
}
