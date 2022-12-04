namespace CustomerSupportSystem.Infrastructure.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataTypesConstants.CountryNameMaxLenght)]
        public string Name { get; set; } = null!;

        [StringLength(DataTypesConstants.IsoAlfa2CodeMaxLenght)]
        public string? IsoAlfa2Code { get; set; }

        [StringLength(DataTypesConstants.IsoAlfa3CodeMaxLenght)]
        public string? IsoAlfa3Code { get; set; }

        public int? IsoNumericCode { get; set; }

        public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
    }
}
