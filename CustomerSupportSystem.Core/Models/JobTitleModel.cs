namespace CustomerSupportSystem.Core.Models
{
    public class JobTitleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.JobTitleMaxLenght)]
        public string Title { get; set; } = null!;
    }
}
