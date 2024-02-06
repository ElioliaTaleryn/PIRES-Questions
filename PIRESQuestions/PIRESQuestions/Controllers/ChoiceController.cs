using Entities;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Abstractions;

namespace PIRESQuestions.Controllers
{
    public class ChoiceController : Controller
    {
        IChoiceService _choiceService;
        public ChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> CreateChoice()
        {
            return View();
        }
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CreateChoice(Choice choice) 
        {
            if(!ModelState.IsValid && string.IsNullOrEmpty(choice.Label)) 
            {
                ModelState.AddModelError("Label", "Le champ est obligatoire.");
                return View(choice);
            }
            else 
            { 
                choice = await _choiceService.CreateChoiceAsync(choice);
                var choiceCreate = await _choiceService.GetChoiceByIdAsync(choice.Id);
                return PartialView("_showChoice", choice);
            }
        }
    }
}
