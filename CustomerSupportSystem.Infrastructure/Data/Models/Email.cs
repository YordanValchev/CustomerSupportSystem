namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [StringLength(DataTypesConstants.EmailAddressMaxLenght)]
        public string? EmailAddress { get; set; }

        public int? ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public Contact? Contact { get; set; }

        public int? EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        public bool? IsMain { get; set; }
    }
}
