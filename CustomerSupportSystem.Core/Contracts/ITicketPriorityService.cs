namespace CustomerSupportSystem.Core.Contracts
{
    public interface ITicketPriorityService
    {
        Task<IEnumerable<TicketPriorityModel>> All();

        Task<bool> Exists(int id);

        Task<int> Create(TicketPriorityModel model);

        Task Edit(TicketPriorityModel model);
    }
}
