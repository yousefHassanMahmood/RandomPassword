using business;
using Microsoft.AspNetCore.Mvc;
using RandomPasswordWeb.Models;
using System.Diagnostics;

namespace RandomPasswordWeb.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetPassword(int passLength)
        {
            var _randomsPass = new RandomsPass(passLength);
            string password = _randomsPass.GetPassword();
            ViewData["GeneratedPassword"] = password;

            return View("GeneratedPassword");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}