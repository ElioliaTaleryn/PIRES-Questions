using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Abstractions;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return View(questions);
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            if(!ModelState.IsValid && string.IsNullOrEmpty(question.Label) && question.FormId == null ) 
            {
                ModelState.AddModelError("Label", "Le champ Label est obligatoire.");
                ModelState.AddModelError("FormId", "La question doit appartenir à un formulaire");
           
                return View(question);
            }
            else
            {
                question = await _questionService.CreateQuestionAsync(question);
                var questionCreate = await _questionService.GetQuestionByIdAsync(question.Id);
                return PartialView("_showQuestion", questionCreate);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestionWithChoiceAsync(Question question)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(question.Label) && question.FormId == null && question.Choices.Any(choice => string.IsNullOrEmpty(choice.Label)))
            {
                ModelState.AddModelError("Label", "Le champ Label est obligatoire.");
                ModelState.AddModelError("FormId", "La question doit appartenir à un formulaire");
                ModelState.AddModelError("Choices", "Le libellé du choix de réponse est obligatoire");

                return View(question);
            }
            else
            {
                question = await _questionService.CreateQuestionWithChoiceAsync(question);
                var questionCreate = await _questionService.GetQuestionByIdAsync(question.Id);
                return PartialView("_showQuestion", questionCreate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            return View(await _questionService.GetQuestionByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(question.Label) && question.FormId == null)
            {
                ModelState.AddModelError("Label", "Le champ Label est obligatoire.");
                ModelState.AddModelError("FormId", "La question doit appartenir à un formulaire");

                return View(question);
            }
            else 
            {
                await _questionService.UpdateQuestionAsync(question);
                return RedirectToAction("Index");
            }            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteQuestion(int id, int formId) 
        {
            await _questionService.DeleteQuestionAsync(id);
            var question = await _questionService.GetQuestionByFormIdAsync(formId);
            return PartialView("_showQuestion", question);
        }       
    }
}
