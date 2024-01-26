using Entities;
using IRepositories;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class QuestionService : IQuestionService
    {
        IQuestionRepository QuestionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            QuestionRepository = questionRepository;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            return await QuestionRepository.CreateQuestionAsync(question);

            //if (question.Label != null && question.FormId != null)
            //{
            //    return await QuestionRepository.CreateQuestionAsync(question);
            //}
            //else
            //{
            //    string erreur = "";
            //    if (question.Label == null)
            //    {
            //        erreur = "Veuillez renseigner la question que vous souhaitez poser";
            //    }
            //    else if (question.FormId == null)
            //    { 
            //        erreur = "La question n'est assignée à aucun formulaire existant"; 
            //    }
            //    throw new Exception(erreur);
            //}
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            if (question.Label != null && question.FormId != null)
            {
                return await QuestionRepository.UpdateQuestionAsync(question);
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
                await QuestionRepository.DeleteQuestionAsync(id);
            }
            else throw new Exception("Aucune valeur permettant la suppression de la question");
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            if (id != null)
            {
                return await QuestionRepository.GetQuestionByIdAsync(id);
            }
            else throw new Exception("Aucune valeur permettant de rechercher la question");
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await QuestionRepository.GetAllQuestionsAsync();
        }
        public async Task<List<Question>> GetQuestionByFormIdAsync(int formId)
        {
            if(formId != null) 
            {
                return await QuestionRepository.GetQuestionByFormIdAsync(formId);
            }
            else throw new Exception("Aucune valeur permettant de rechercher les questions");
        }

        public Task<Question> GetQuestionByNumberAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
