namespace CustomerSupportSystem.Core.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public TicketTypeService(
            IRepository _repo,
            ILogger<TicketTypeService> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        public async Task<IEnumerable<TicketTypeModel>> All()
        {
            return await repo.AllReadonly<TicketType>()
                .OrderBy(e => e.Title)
                .Select(e => new TicketTypeModel()
                {
                    Id = e.Id,
                    Title = e.Title
                })
                .ToListAsync();
        }

        public async Task<int> Create(TicketTypeModel model)
        {
            var entity = new TicketTypeModel()
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

        public async Task Edit(TicketTypeModel model)
        {
            var entity = await repo.GetByIdAsync<TicketType>(model.Id);

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
            return await repo.AllReadonly<TicketType>()
                .AnyAsync(e => e.Id == id);
        }
    }
}
