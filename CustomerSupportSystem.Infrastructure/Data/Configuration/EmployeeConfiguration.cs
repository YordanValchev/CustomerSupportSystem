namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(d => d.JobTitle)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Employees_JobTitles");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Employees_Users");

            builder.HasData(new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                JobTitleId = 1,
                UserId = "c80cb755-6247-4474-aa26-43a41d78691a"
            });
        }
    }
}
