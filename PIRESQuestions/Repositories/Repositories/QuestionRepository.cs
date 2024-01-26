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
        ApplicationDbContext appContext;

        public QuestionRepository(ApplicationDbContext applicationDbContext)
        {
            appContext = applicationDbContext;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            appContext.Questions.Add(question);
            await appContext.SaveChangesAsync();
            return question;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            List<Question> listQuestions = await appContext.Questions.Include(q => q.Choices).Include(q => q.Form).ToListAsync();
            if (listQuestions.Any())
            {
                return listQuestions;
            }
            else throw new Exception("Aucune questions trouvées");
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            var question = await appContext.Questions.Include(q => q.Choices).Include(q => q.Form).FirstOrDefaultAsync(q => q.Id == id);
            if (question != null)
            {
                return question;
            }
            else throw new Exception($"Aucune question trouvé avec l'id {id} ");
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var question = appContext.Questions.Include(q => q.Choices).SingleOrDefault(q => q.Id == id);
            if (question != null)
            {
                appContext.Choices.RemoveRange(question.Choices);

                appContext.Questions.Remove(question);

                await appContext.SaveChangesAsync();
                
            }
            else throw new Exception("Echec de la suppression");
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            var questionUpdate = appContext.Questions.FirstOrDefault(q => q.Id == question.Id);

            if (questionUpdate != null)
            {
                questionUpdate.Label = question.Label;
                questionUpdate.Description = question.Description;
                questionUpdate.Choices = question.Choices;
                questionUpdate.FormId = question.FormId;
                questionUpdate.TimerCDId = question.TimerCDId;
                await appContext.SaveChangesAsync();

                return question;
            }
            else
            {
                throw new InvalidOperationException("La mise à jour a échoué");
            }
        }

        public async Task<List<Question>> GetQuestionByFormIdAsync(int formId)
        {
            var questions = await appContext.Questions.Include(q => q.Choices).Include(q => q.Form).Where(q => q.FormId == formId).ToListAsync(); ;
            return questions;
            //if (questions != null)
            //{
            //    return questions;
            //}
            //else throw new Exception($"Aucune question(s) trouvée(s) pour le formulaire {formId} ");
        }
    }
}

