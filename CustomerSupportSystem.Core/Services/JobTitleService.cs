namespace CustomerSupportSystem.Core.Services
{
    public class JobTitleService : IJobTitleService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public JobTitleService(
            IRepository _repo,
            ILogger<JobTitleService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<JobTitleModel>> All()
        {
            return await repo.AllReadonly<JobTitle>()
                .OrderBy(e => e.Title)
                .Select(e => new JobTitleModel()
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync();
        }

        public async Task<int> Create(JobTitleModel model)
        {
            var jobTitle = new JobTitle()
            {
                Title = model.Title,
            };

            try
            {
                await repo.AddAsync(jobTitle);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return jobTitle.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<JobTitle>()
                .AnyAsync(e => e.Id == id);
        }
    }
}
