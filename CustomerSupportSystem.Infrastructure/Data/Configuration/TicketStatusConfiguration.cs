namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketStatusConfiguration : IEntityTypeConfiguration<TicketStatus>
    {
        public void Configure(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<TicketStatus> GetEntityData()
        {
            var entityData = new List<TicketStatus>()
            {
                new TicketStatus() 
                {
                    Id = 1,
                    Title = "In Progress" 
                },
                new TicketStatus() 
                {
                    Id = 2,
                    Title = "Resolved" 
                },
                new TicketStatus() 
                {
                    Id = 3,
                    Title = "Closed" 
                }
            };

            return entityData;
        }
    }
}
