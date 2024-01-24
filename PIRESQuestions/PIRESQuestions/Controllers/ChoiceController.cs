using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class ChoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
