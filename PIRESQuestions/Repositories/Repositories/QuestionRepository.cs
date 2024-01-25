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
            return await appContext.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await appContext.Questions.FindAsync(id);
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = appContext.Questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                appContext.Questions.Remove(question);
                await appContext.SaveChangesAsync();
                return true;
            }
            else return false;        
        }



        public async Task<Question> UpdateQuestionAsync(Question question)
        {

            var questionUpdate = appContext.Questions.FirstOrDefault(q => q.Id == question.Id);

            if (questionUpdate != null)
            {
                questionUpdate.Label = question.Label;
                questionUpdate.Description = question.Description;
                await appContext.SaveChangesAsync();

                return question;
            }
            else
            {
                throw new InvalidOperationException("La mise à jour a échoué");
            }
        }
    }
}

