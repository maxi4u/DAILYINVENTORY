using System.Diagnostics;
using DailyInventory.DataAccess.IRepository;
using DailyInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyInventory.Web.Areas.Customers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork iUnitOfWork)
        {
            _logger = logger;
            _IUnitOfWork = iUnitOfWork;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Error", _logger);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            var model = new Login();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                if (model.LoginID.ToUpper() == "ADMIN" && model.Password.ToUpper() == "ADMIN")
                {
                    model.isLoggedIn = true;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError(model.Password, "Invalid ID and Password");
                }
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("oo", "Please Enter ID and Password");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}