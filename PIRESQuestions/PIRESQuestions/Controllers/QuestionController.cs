using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService QuestionService { get; }
        public QuestionController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
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

                return View("Index");
            }
        }
    }
}
