namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<JobTitle> GetEntityData()
        {
            var entityData = new List<JobTitle>()
            {
                new JobTitle() 
                {
                    Id = 1,
                    Title = "Manager" 
                },
                new JobTitle() 
                {
                    Id = 2,
                    Title = "Developer" 
                },
                new JobTitle() 
                {
                    Id = 3,
                    Title = "Consultant" 
                },
                new JobTitle() 
                {
                    Id = 4,
                    Title = "Accountant" 
                }
            };

            return entityData;
        }
    }
}
