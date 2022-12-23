namespace CustomerSupportSystem.Core.Models.Enums
{
    public class JobTitleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.JobTitleMaxLenght)]
        public string Title { get; set; } = null!;
    }
}
