using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PIRESQuestions.Controllers
{
    public class AnswerController : Controller
    {
        IFormService _formService;
        IAnswerService _answerService;
        IQuestionService _questionService;

        public AnswerController(IFormService formService, IAnswerService answerService, IQuestionService questionService)
        {
            _formService = formService;
            _answerService = answerService;
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Reply(int id)
        {

            Form form = await _formService.GetByIdFormAsync(id);
            List<Question> questions = await _questionService.GetQuestionByFormIdAsync(form.Id);
            List<Answer> answers = new List<Answer>();
            foreach (Question question in questions)
            {
                Answer answer = new() { AnonymousId=0, Horodatage=DateTime.Now, QuestionId=question.Id, ChoiceId=0 };
                answers.Add(answer);
            }
            var model = new FormViewModel
            {
                Form = form,
                Questions = questions,
                Answers = answers
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(FormViewModel formViewModel) {
            foreach(Answer answer in formViewModel.Answers) {
                await _answerService.CreateAnswerAsync(answer);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}

