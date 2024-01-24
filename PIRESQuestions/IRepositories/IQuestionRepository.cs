using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IQuestionRepository
    {
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<Question> DeleteQuestionAsync(int id);
        Task<Question> GetQuestionByIdAsync(int id);
        Task<List<Question>> GetAllQuestionsAsync();
    }
}
