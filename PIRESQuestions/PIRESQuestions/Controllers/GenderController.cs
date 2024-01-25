using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class GenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
