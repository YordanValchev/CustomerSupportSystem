namespace CustomerSupportSystem.Core.Services
{
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public TicketPriorityService(
            IRepository _repo,
            ILogger<TicketPriorityService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<TicketPriorityModel>> All()
        {
            return await repo.AllReadonly<TicketPriority>()
                .OrderBy(e => e.Title)
                .Select(e => new TicketPriorityModel()
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync();
        }

        public async Task<int> Create(TicketPriorityModel model)
        {
            var entity = new TicketPriority()
            {
                Title = model.Title
            };

            try
            {
                await repo.AddAsync(entity);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return entity.Id;
        }

        public async Task Edit(TicketPriorityModel model)
        {
            var entity = await repo.GetByIdAsync<TicketPriority>(model.Id);

            entity.Title = model.Title;

            try
            {
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Edit), ex);
                throw new ApplicationException("Database failed to edit info", ex);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<TicketPriority>()
                .AnyAsync(e => e.Id == id);
        }
    }
}
