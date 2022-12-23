using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupportSystem.Core.Models.Ticket
{
    public class TicketModel
    {
        [Display(Name = "Number")]
        public int Id { get; set; }

        [Display(Name = "Created on")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Display(Name = "Finished on")]
        public DateTime? DeteFinished { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketSubjectMaxLenght)]
        public string Subject { get; set; } = null!;

        [Required]
        [Display(Name = "Type")]
        public int TypeId { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int PartnerId { get; set; }

        [Required]
        [StringLength(DataTypesConstants.TicketPostTextMaxLenght)]
        [Display(Name = "New post")]
        public string PostingText { get; set; } = null!;

        public int? WorkedTime { get; set; }

        public bool? IsTimeBillable { get; set; }

        public string UserId { get; set; } = null!;

        public string? FormName { get; set; }

        public IEnumerable<TicketPostsModel> Posts { get; set; } = new List<TicketPostsModel>();

        public IEnumerable<UsersListModel> Participants { get; set; } = new List<UsersListModel>();

        public IEnumerable<UsersListModel> PartnerUsersList { get; set; } = new List<UsersListModel>();

        public IEnumerable<UsersListModel> TeamUsersList { get; set; } = new List<UsersListModel>();

        public IEnumerable<PartnersListModel> Partners { get; set; } = new List<PartnersListModel>();

        public IEnumerable<TicketTypeModel> TicketTypes { get; set; } = new List<TicketTypeModel>();

        public IEnumerable<TicketStatusModel> TicketStatuses { get; set; } = new List<TicketStatusModel>();

        public IEnumerable<TicketPriorityModel> TicketPriorities { get; set; } = new List<TicketPriorityModel>();
    }
}
