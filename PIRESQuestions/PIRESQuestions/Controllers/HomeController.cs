using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ViewModels;

namespace PIRESQuestions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserPerson> _signInManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<UserPerson> signInManager)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var result = await _signInManager.PasswordSignInAsync("bob", "Ab1234%", true, lockoutOnFailure: false);

            return View();
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
