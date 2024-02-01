using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Abstractions;
using Services;
using ViewModels;

namespace PIRESQuestions.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        IChoiceService _choiceService;
        public QuestionController(IQuestionService questionService, IChoiceService choiceService)
        {
            _questionService = questionService;
            _choiceService = choiceService;
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
                return PartialView("_showQuestion", questionCreate);
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(int id)
        {
            if(id > 0) 
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                
                //var model = new UpdateQuestionViewModel
                //{
                //    Question = question,
                //    Choices = question.Choices
                //};
                return View(question);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
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
