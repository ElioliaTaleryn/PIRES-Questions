using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IChoiceRepository
    {
        Task<Choice> CreateChoiceAsync(Choice choice);
        Task<Choice> UpdateChoiceAsync(Choice choice);
        Task<bool> DeleteChoiceAsync(int id);
        Task<Choice> GetChoiceByIdAsync(int id);
        Task<List<Choice>> GetChoicesByIdsAsync(List<int> choiceIds);
        Task<List<Choice>> GetChoicesByIdQuestionAsync(int id);
        Task<List<Choice>> GetAllChoiceAsync();
    }
}
