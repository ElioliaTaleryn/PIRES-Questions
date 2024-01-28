using Microsoft.AspNetCore.Mvc;
using IServices;

namespace PIRESQuestions.Controllers
{
    public class DataDashboardController : Controller
    {
        // model.isvalid dans les post
        // controller
        /*if (country == null ou empty)
        {
            throw new CountryRepositoryException($"Country object invalid: null.");
        }*/

        // Is valid dans les post des controller
        // controller
        /*if (gender == null || string.IsNullOrEmpty(gender.Label))
        {
            throw new GenderRepositoryException($"Gender object invalid: null or empty.");
        }*/
        private readonly IGenderService _genderService;
        private readonly ICountryService _countryService;

        public DataDashboardController(IGenderService genderService, ICountryService countryService)
        {
            _genderService = genderService;
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
