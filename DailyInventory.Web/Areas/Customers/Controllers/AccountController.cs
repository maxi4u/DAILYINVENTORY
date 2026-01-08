using Microsoft.AspNetCore.Mvc;

namespace DailyInventory.Web.Areas.Customers.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}