using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IChoiceService
    {
        Task<Choice> CreateChoiceAsync(Choice choice);
        Task<Choice> UpdateChoiceAsync(Choice choice);
        Task<bool> DeleteChoiceAsync(int id);
        Task<Choice> GetChoiceByIdAsync(int id);
        Task<Choice> GetChoiceByNumberAsync(int id);
        Task<List<Choice>> GetAllChoicesAsync();
    }
}
