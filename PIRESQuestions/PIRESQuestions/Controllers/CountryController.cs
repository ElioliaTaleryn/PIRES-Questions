using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class CountryController : Controller
    {
        // model.isvalid dans les post
        // controller
        /*if (country == null)
        {
            throw new CountryRepositoryException($"Country object invalid: null.");
        }*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
