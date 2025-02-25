using System.Diagnostics;
using Chapter4_Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter4_Demo1.Controllers
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
            // Create HomeModel object
            HomeModel message = new HomeModel();
            // Invoke to the view with message object
            return View(message);
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

        public string Hello() => "Hello, ASP.NET Core MVC!";
    }
}
