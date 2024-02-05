using Microsoft.AspNetCore.Mvc;
using IServices;

namespace PIRESQuestions.Controllers
{
    public class DashboardController : Controller
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
        private readonly IFormService _formService;

        public DashboardController(IGenderService genderService, ICountryService countryService, IFormService formService)
        {
            _genderService = genderService;
            _countryService = countryService;
            _formService = formService;
        }
        public async Task<IActionResult> Index(string userId)
        {
            var forms = await _formService.GetFormByUserIdAsync(userId);
            return View(forms);
        }
    }
}
