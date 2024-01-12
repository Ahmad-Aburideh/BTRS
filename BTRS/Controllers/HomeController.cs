using BTRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BTRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult SelectRole(RoleSelection model)
        {
            if (ModelState.IsValid)
            {
                if (model.SelectedRole == "Administrator")
                {
                    return RedirectToAction("adminHome", "administrator");
                }
                else if (model.SelectedRole == "Passenger")
                {
                    return RedirectToAction("passengerHome", "passenger");
                }
            }

            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
