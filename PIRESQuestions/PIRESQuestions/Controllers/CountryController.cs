using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
