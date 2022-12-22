namespace CustomerSupportSystem.Core.Contracts
{
    public interface IJobTitleService
    {
        Task<IEnumerable<JobTitleModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(JobTitleModel model);

        Task Edit(JobTitleModel model);
    }
}
