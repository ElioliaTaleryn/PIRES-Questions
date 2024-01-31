using Entities;
using IRepositories;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class QuestionService : IQuestionService
    {
        IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            return await _questionRepository.CreateQuestionAsync(question);
        }
  
        //public async Task<Question> CreateQuestionWithChoiceAsync(Question question)
        //{
        //    var questionToCreate = new Question()
        //    {
        //        Label = question.Label,
        //        Description = question.Description,
        //        FormId = question.FormId,
        //        Choices = question.Choices.Select(question => new Choice
        //        {
        //            Label = question.Label,
        //            QuestionId = question.QuestionId,
        //        }).ToList()
        //    };
        //    return await _questionRepository.CreateQuestionWithChoiceAsync(question);
        //}
        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            if (question.Label != null && question.FormId != null)
            {
                return await _questionRepository.UpdateQuestionAsync(question);
            }
            else
            {
                string erreur = "";
                if (question.Label == null)
                {
                    erreur = "Veuillez renseigner la question que vous souhaitez poser";
                }
                else if (question.FormId == null)
                {
                    erreur = "La question n'est assignée à aucun formulaire existant";
                }
                throw new Exception(erreur);
            }
        }

        public async Task DeleteQuestionAsync(int id)
        {
            if (id != null)
            {
                await _questionRepository.DeleteQuestionAsync(id);
            }
            else throw new Exception("Aucune valeur permettant la suppression de la question");
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            if (id != null)
            {
                return await _questionRepository.GetQuestionByIdAsync(id);
            }
            else throw new Exception("Aucune valeur permettant de rechercher la question");
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllQuestionsAsync();
        }
        public async Task<List<Question>> GetQuestionByFormIdAsync(int formId)
        {
            if(formId != null) 
            {
                return await _questionRepository.GetQuestionByFormIdAsync(formId);
            }
            else throw new Exception("Aucune valeur permettant de rechercher les questions");
        }

        public Task<Question> GetQuestionByNumberAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
