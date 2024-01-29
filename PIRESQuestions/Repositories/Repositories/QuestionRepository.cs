using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        ApplicationDbContext _appContext;

        public QuestionRepository(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            _appContext.Questions.Add(question);
            await _appContext.SaveChangesAsync();
            return question;
        }
        //public async Task<Question> CreateQuestionWithChoiceAsync(Question question)
        //{
        //    _appContext.Questions.Add(question);
        //    await _appContext.SaveChangesAsync();

        //    int questionId = question.Id;
        //    foreach (var c in question.Choices) 
        //    { 
        //        c.QuestionId = questionId;
        //        _appContext.Choices.Add(c);
        //    }
        //    await _appContext.SaveChangesAsync();
        //    return question;
        //}

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            List<Question> listQuestions = await _appContext.Questions.Include(q => q.Choices).Include(q => q.Form).ToListAsync();
            if (listQuestions.Any())
            {
                return listQuestions;
            }
            else throw new Exception("Aucune questions trouvées");
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            var question = await _appContext.Questions.Include(q => q.Choices).Include(q => q.Form).FirstOrDefaultAsync(q => q.Id == id);
            if (question != null)
            {
                return question;
            }
            else throw new Exception($"Aucune question trouvé avec l'id {id} ");
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = _appContext.Questions.Include(q => q.Choices).SingleOrDefault(q => q.Id == id);
            if (question != null)
            {
                _appContext.Choices.RemoveRange(question.Choices);

                _appContext.Questions.Remove(question);

                await _appContext.SaveChangesAsync();
                
            }
            else throw new Exception("Echec de la suppression");
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            var questionUpdate = _appContext.Questions.FirstOrDefault(q => q.Id == question.Id);

            if (questionUpdate != null)
            {
                questionUpdate.Label = question.Label;
                questionUpdate.Description = question.Description;
                questionUpdate.Choices = question.Choices;
                questionUpdate.FormId = question.FormId;
                questionUpdate.TimerCDId = question.TimerCDId;
                await _appContext.SaveChangesAsync();

                return question;
            }
            else
            {
                throw new InvalidOperationException("La mise à jour a échoué");
            }
        }

        public async Task<List<Question>> GetQuestionByFormIdAsync(int formId)
        {
            var questions = await _appContext.Questions.Include(q => q.Choices).Include(q => q.Form).Where(q => q.FormId == formId).ToListAsync(); ;
            return questions;
            //if (questions != null)
            //{
            //    return questions;
            //}
            //else throw new Exception($"Aucune question(s) trouvée(s) pour le formulaire {formId} ");
        }
    }
}

