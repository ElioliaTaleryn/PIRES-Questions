using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
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
            return null;
        }

        public Task<Question> DeleteQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAllQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> UpdateQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
