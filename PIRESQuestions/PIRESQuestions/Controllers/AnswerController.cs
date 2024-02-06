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
        IAnonymousService _anonymousService;

        public AnswerController(IFormService formService, IAnswerService answerService, IQuestionService questionService, IAnonymousService anonymousService)
        {
            _formService = formService;
            _answerService = answerService;
            _questionService = questionService;
            _anonymousService = anonymousService;
        }

        [HttpGet]
        public async Task<IActionResult> Reply(int id)
        {
            Form form = await _formService.GetByIdFormAsync(id);
            List<Question> questions = await _questionService.GetQuestionByFormIdAsync(form.Id);
            List<Answer> answers = new List<Answer>();
            foreach (Question question in questions)
            {
                Answer answer = new() { AnonymousId=0, Horodatage=DateTime.Now, QuestionId=question.Id, ChoiceId=0};
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
        public async Task<IActionResult> Reply(List<Answer>listAnswers, Anonymous anonymous, int formId) {

           
                var anonymousCreate = await _anonymousService.CreateAnonymousAsync(anonymous);

                foreach (var answer in listAnswers)
                {
                    answer.AnonymousId = anonymousCreate.Id;
                    await _answerService.CreateAnswerAsync(answer);
                }
                return RedirectToAction("Index", "Home");
   
           
        }

    }
}

