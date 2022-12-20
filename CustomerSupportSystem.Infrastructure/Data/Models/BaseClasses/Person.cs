namespace CustomerSupportSystem.Infrastructure.Data.Models.BaseClasses
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [StringLength(DataTypesConstants.PersonFirstNameMaxLenght)]
        public string? FirstName { get; set; }

        [StringLength(DataTypesConstants.PersonLastNameMaxLenght)]
        public string? LastName { get; set; }

        public int? JobTitleId { get; set; }

        public JobTitle? JobTitle { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
