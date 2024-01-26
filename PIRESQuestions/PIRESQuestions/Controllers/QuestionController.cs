using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Abstractions;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService QuestionService { get; }
        public QuestionController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var questions = await QuestionService.GetAllQuestionsAsync();
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
                question = await QuestionService.CreateQuestionAsync(question);
                var questionCreate = await QuestionService.GetQuestionByFormIdAsync(question.FormId);
                return PartialView("_showQuestions", questionCreate);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            return View(await QuestionService.GetQuestionByIdAsync(id));
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
                await QuestionService.UpdateQuestionAsync(question);
                return RedirectToAction("Index");
            }            
        }

        [HttpGet]
        public async Task<IActionResult> DeleteQuestion(int id, int formId) 
        {
            await QuestionService.DeleteQuestionAsync(id);
            var question = await QuestionService.GetQuestionByFormIdAsync(formId);
            return PartialView("_showQuestions", question);
        }
        
    }
}
