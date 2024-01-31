using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
