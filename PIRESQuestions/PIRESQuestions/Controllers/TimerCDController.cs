using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class TimerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
