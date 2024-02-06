using Microsoft.AspNetCore.Mvc;
using IServices;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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
        UserManager<UserPerson> _userManager;

        public DashboardController(IGenderService genderService, ICountryService countryService, IFormService formService, UserManager<UserPerson> userManager)
        {
            _genderService = genderService;
            _countryService = countryService;
            _formService = formService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserPerson userBdd = await _userManager.GetUserAsync(User);
            TempData["UserId"] = userBdd.Id;
            var forms = await _formService.GetFormByUserIdAsync(userBdd.Id);
            return View(forms);
        }
    }
}
