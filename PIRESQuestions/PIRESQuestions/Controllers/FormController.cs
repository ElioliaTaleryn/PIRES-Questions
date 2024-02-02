using Entities;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PIRESQuestions.Controllers
{
    public class FormController : Controller
    {
        IFormService _formService;
        IQuestionService _questionService;
        UserManager<UserPerson> _userManager;

        public FormController(IFormService formService, IQuestionService questionService, UserManager<UserPerson> userManager) {
            _formService = formService;
            _questionService = questionService;
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
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            Form form = await _formService.GetByIdFormAsync(id);
            return View(form);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Form form)
        {
            await _formService.UpdateFormAsync(form);
            Form formView = await _formService.GetByIdFormAsync(form.Id);
            return View("Detail", formView);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Form formToDelete = await _formService.GetByIdFormAsync(id);
            await _formService.DeleteFormAsync(formToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddQuestion(int id) {
            var model = new AddQuestionToForm() { IdForm = id, QuestionId=0};
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddQuestion(AddQuestionToForm addQuestionToForm) {
            Form form = await _formService.GetByIdFormAsync(addQuestionToForm.IdForm);
            Question question = await _questionService.GetQuestionByIdAsync(addQuestionToForm.QuestionId);
            question.FormId = form.Id;
            form.Questions.Add(question);

            int ajout = await _formService.UpdateFormAsync(form);
            var ajout2 = await _questionService.UpdateQuestionAsync(question);
            return RedirectToAction("Detail", new { Id = form.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Validate(int id) {
            Form form = await _formService.GetByIdFormAsync(id);
            if (form.StatusId == 1)
            {
                form.StatusId = 2;
            }
            await _formService.UpdateFormAsync(form);
            return RedirectToAction("Detail", new { Id = form.Id });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Close(int id)
        {
            Form form = await _formService.GetByIdFormAsync(id);
            if (form.StatusId == 2)
            {
                form.StatusId = 3;
            }
            await _formService.UpdateFormAsync(form);
            return RedirectToAction("Detail", new { Id = form.Id });
        }

    }
}
