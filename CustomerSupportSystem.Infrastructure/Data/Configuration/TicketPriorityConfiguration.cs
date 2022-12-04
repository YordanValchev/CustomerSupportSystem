namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketPriorityConfiguration : IEntityTypeConfiguration<TicketPriority>
    {
        public void Configure(EntityTypeBuilder<TicketPriority> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<TicketPriority> GetEntityData()
        {
            var entityData = new List<TicketPriority>()
            {
                new TicketPriority() 
                {
                    Id = 1,
                    Title = "Normal" 
                },
                new TicketPriority() 
                {
                    Id = 2,
                    Title = "High" 
                }
            };

            return entityData;
        }
    }
}
