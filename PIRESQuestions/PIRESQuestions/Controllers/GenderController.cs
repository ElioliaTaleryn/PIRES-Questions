using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class GenderController : Controller
    {
        // Is valid dans les post des controller
        // controller
        /*if (gender == null || string.IsNullOrEmpty(gender.Label))
        {
            throw new GenderRepositoryException($"Gender object invalid: null or empty.");
        }*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
