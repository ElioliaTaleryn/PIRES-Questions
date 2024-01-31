using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IAnswerRepository
    {
        Task<Answer> CreateAnswerAsync(Answer answer);
        Task<List<Answer>> GetAllAnswerAsync();
        Task<Answer> GetAnswerByIdAsync(int id);
        Task<List<Answer>> GetAnswerByChoiceAsync(int idChoice);
        Task<List<Answer>> GetAnswerByGenderAsync(int idGender);
        Task<bool> DeleteAnswerAsync(int id);
    }
}
