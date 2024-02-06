using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Entities;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using ViewModels;
using IServices;

namespace PIRESQuestions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserPerson> _signInManager;
        private readonly UserManager<UserPerson> _userManager;
        private readonly IFormService _formService;

        public HomeController(ILogger<HomeController> logger, SignInManager<UserPerson> signInManager, UserManager<UserPerson> userManager, IFormService formService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _formService = formService;
        }

        public async Task<IActionResult> Index()
        {
            UserPerson userBdd = await _userManager.GetUserAsync(User);
            if(userBdd != null) 
            {
                TempData["UserId"] = userBdd.Id;
            }         
            return View(await _formService.GetAllFormAsync());
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
