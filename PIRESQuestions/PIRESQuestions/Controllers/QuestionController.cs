using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
