namespace CustomerSupportSystem.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Tickets");
            }

            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }
    }
}
