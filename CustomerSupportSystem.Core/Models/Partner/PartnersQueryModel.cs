namespace CustomerSupportSystem.Core.Models.Partner
{
    public class PartnersQueryModel
    {
        public IEnumerable<PartnersQueryDetailModel> Partners { get; set; } = new List<PartnersQueryDetailModel>();
    }
}
