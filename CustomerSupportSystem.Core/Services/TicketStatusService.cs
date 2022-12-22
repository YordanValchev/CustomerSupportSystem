namespace CustomerSupportSystem.Core.Services
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public TicketStatusService(
            IRepository _repo,
            ILogger<TicketStatusService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<TicketStatusModel>> All()
        {
            return await repo.AllReadonly<TicketStatus>()
                .OrderBy(e => e.Title)
                .Select(e => new TicketStatusModel()
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync();
        }

        public async Task<int> Create(TicketStatusModel model)
        {
            var entity = new TicketStatusModel()
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

        public async Task Edit(TicketStatusModel model)
        {
            var entity = await repo.GetByIdAsync<TicketStatus>(model.Id);

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
            return await repo.AllReadonly<TicketStatus>()
                .AnyAsync(e => e.Id == id);
        }
    }
}
