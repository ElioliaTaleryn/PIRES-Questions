using Entities;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class FormController : Controller
    {
        IFormService _formService;
        UserManager<UserPerson> _userManager;

        public FormController(IFormService formService, UserManager<UserPerson> userManager) {
            _formService = formService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _formService.GetAllFormAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id) {
            return View(await _formService.GetByIdFormAsync(Id));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() 
        {
            UserPerson userBdd = await _userManager.GetUserAsync(User);
            TempData["UserId"] = userBdd.Id;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Form form) {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            else 
            {
                form = await _formService.CreateFormAsync(form);
                return RedirectToAction("Detail", new { Id = form.Id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Form form = await _formService.GetByIdFormAsync(id);
            return View(form);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Form form)
        {
            int nbFormModif = await _formService.UpdateFormAsync(form);
            return RedirectToAction("Detail", new { Id = form.Id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            Form formToDelete = await _formService.GetByIdFormAsync(id);
            await _formService.DeleteFormAsync(formToDelete);
            return RedirectToAction("Index");
        }

    }
}
