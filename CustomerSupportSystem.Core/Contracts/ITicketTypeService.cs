namespace CustomerSupportSystem.Core.Contracts
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketTypeModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(TicketTypeModel model);

        Task Edit(TicketTypeModel model);
    }
}
