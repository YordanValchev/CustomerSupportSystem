namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>()
            {
                UserId = "c80cb755-6247-4474-aa26-43a41d78691a",
                RoleId = "c838fb22-a99a-42d7-9c00-9bae1b092cfd"
            });
        }
    }
}
