namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class JobTitle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.JobTitleMaxLenght)]
        public string Title { get; set; } = null!;

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
