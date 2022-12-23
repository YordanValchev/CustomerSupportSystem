using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerSupportSystem.Core.Services
{
    public static class NavPagesService
    {
        public static string Tickets => "Tickets";

        public static string Partners => "Partners";

        public static string Contacts => "Contacts";

        public static string Employees => "Employees";

        public static string TicketsNavHandle(ViewContext viewContext) => NavHandle(viewContext, Tickets);

        public static string PartnersNavHandle(ViewContext viewContext) => NavHandle(viewContext, Partners);

        public static string ContactsNavHandle(ViewContext viewContext) => NavHandle(viewContext, Contacts);

        public static string EmployeesNavHandle(ViewContext viewContext) => NavHandle(viewContext, Employees);

        private static string NavHandle(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : "link-dark";
        }
    }
}
