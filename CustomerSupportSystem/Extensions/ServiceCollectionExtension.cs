using CustomerSupportSystem.Infrastructure.Data.Common;

namespace CustomerSupportSystem.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IJobTitleService, JobTitleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailAddressService, EmailAddressService>();
            services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            services.AddScoped<ITicketPriorityService, TicketPriorityService>();
            services.AddScoped<ITicketTypeService, TicketTypeService>();
            services.AddScoped<ITicketStatusService, TicketStatusService>();

            return services;
        }
    }
}
