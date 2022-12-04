namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<TicketType> GetEntityData()
        {
            var entityData = new List<TicketType>()
            {
                new TicketType() 
                { 
                    Id = 1,
                    Title = "Service Request" 
                },
                new TicketType() 
                {
                    Id = 2,
                    Title = "Bug" 
                },
                new TicketType() 
                {
                    Id = 3,
                    Title = "Change request" 
                }
            };

            return entityData;
        }
    }
}
