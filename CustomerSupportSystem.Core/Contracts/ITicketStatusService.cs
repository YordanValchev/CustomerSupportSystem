namespace CustomerSupportSystem.Core.Contracts
{
    public interface ITicketStatusService
    {
        Task<IEnumerable<TicketStatusModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(TicketStatusModel model);

        Task Edit(TicketStatusModel model);
    }
}
