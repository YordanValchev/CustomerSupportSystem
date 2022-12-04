namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<IdentityRole> GetEntityData()
        {
            var entityData = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "c838fb22-a99a-42d7-9c00-9bae1b092cfd",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "361c7033-86bb-42e0-a264-3f560e1da74d",
                    Name = "Support",
                    NormalizedName = "SUPPORT"
                },
                new IdentityRole()
                {
                    Id = "5b35eb07-6f63-41eb-8a44-5178055f3019",
                    Name = "Client",
                    NormalizedName = "CLIENT"
                }
            };

            return entityData;
        }
    }
}
