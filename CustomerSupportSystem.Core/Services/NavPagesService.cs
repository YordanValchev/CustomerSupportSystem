using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerSupportSystem.Core.Services
{
    public static class NavPagesService
    {
        public static string Index => "Index";

        public static string AllPartners => "AllPartners";

        public static string IndexNavHandle(ViewContext viewContext) => NavHandle(viewContext, Index);

        public static string AllPartnersNavHandle(ViewContext viewContext) => NavHandle(viewContext, AllPartners);

        private static string NavHandle(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : "link-dark";
        }
    }
}
