namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasData(GetEntityData());
        }

        private static List<ApplicationUser> GetEntityData()
        {
            var entityData = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "c80cb755-6247-4474-aa26-43a41d78691a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin");

            entityData.Add(user);

            return entityData;
        }

    }
}
