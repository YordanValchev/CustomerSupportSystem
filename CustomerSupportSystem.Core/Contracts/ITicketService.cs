namespace CustomerSupportSystem.Core.Contracts
{
    public interface ITicketService
    {
        Task<TicketsQueryModel> QueryTickets(
            string? sortOrder, 
            string userId,
            int partnerId, 
            int typeId,
            int statusId,
            int priorityId,
            string? filter, 
            int currentPage, 
            int rowsPerPage);

        Task<IEnumerable<PartnersListModel>> AllPartnersByTicketsParticipants(string userId);

        Task<IEnumerable<UsersListModel>> TicketParticipants(int id);

        Task<IEnumerable<UsersListModel>> PartnerUsersList(int partnerId);

        Task<IEnumerable<UsersListModel>> TeamUsersList(int partnerId);
    }
}
