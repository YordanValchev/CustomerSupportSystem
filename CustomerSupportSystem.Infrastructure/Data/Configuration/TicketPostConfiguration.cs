namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketPostConfiguration : IEntityTypeConfiguration<TicketPost>
    {
        public void Configure(EntityTypeBuilder<TicketPost> builder)
        {
            builder
                .Property(t => t.PostingDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(d => d.Ticket)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketPosts_Tickets");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.TicketPosts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketPosts_Statuses");

            builder.HasOne(d => d.User)
                .WithMany(p => p.TicketPosts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TicketPosts_Users");
        }
    }
}
