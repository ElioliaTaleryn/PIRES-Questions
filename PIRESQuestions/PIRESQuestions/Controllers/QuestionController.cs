using Entities;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.SqlServer.Server;
using Services;
using ViewModels;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        IFormService _formService;
        IChoiceService _choiceService;
        public QuestionController(IQuestionService questionService, IChoiceService choiceService, IFormService formService)
        {
            _questionService = questionService;
            _formService = formService;
            _choiceService = choiceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return View(questions);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateQuestion(Question question , List<int>choiceIds)
        {
            if(!ModelState.IsValid && string.IsNullOrEmpty(question.Label) && question.FormId == null && choiceIds.Any() ) 
            {
                ModelState.AddModelError("Label", "Le champ Label est obligatoire.");
                ModelState.AddModelError("FormId", "La question doit appartenir à un formulaire");
                ModelState.AddModelError("Choices", "Au moins un choix de réponse doit être sélectionné");
           
                return View(question);
            }
            else
            {
                question.Choices = await _choiceService.GetChoicesByIdsAsync(choiceIds);

                question = await _questionService.CreateQuestionAsync(question);
                var questionCreate = await _questionService.GetQuestionByIdAsync(question.Id);
                Form form = await _formService.GetByIdFormAsync(question.FormId);
                return PartialView("_showForm", form);
            }
        }
       
        [HttpGet]
        [Authorize]

        public async Task<IActionResult> UpdateQuestion(int id)
        {
            if(id > 0) 
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                
                return View(question);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> UpdateQuestion(Question question, List<int> choiceIds)
        {
            if (!ModelState.IsValid && string.IsNullOrEmpty(question.Label) && question.FormId == null && choiceIds.Count() <= 0)
            {
                ModelState.AddModelError("Label", "Le champ Label est obligatoire.");
                ModelState.AddModelError("FormId", "La question doit appartenir à un formulaire");
                ModelState.AddModelError("Choices", "Au moins un choix de réponse doit être sélectionné");

                return View(question);
            }
            else 
            {
                question.Choices = await _choiceService.GetChoicesByIdsAsync(choiceIds);

                await _questionService.UpdateQuestionAsync(question);

                return RedirectToAction("Detail", "Form", new { Id = question.FormId });
            }            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteQuestion(int id, int formId) 
        {
            //TODO : List Questions 
           await _questionService.DeleteQuestionAsync(id);
           var questions = await _questionService.GetQuestionByFormIdAsync(formId);
            Form form = await _formService.GetByIdFormAsync(formId);
            return PartialView("_showForm", form);
        }       
    }
}
