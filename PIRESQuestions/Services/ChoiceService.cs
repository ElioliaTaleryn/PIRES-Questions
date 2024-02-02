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
    public class ChoiceService : IChoiceService
    {
        IChoiceRepository _choiceRepository;
        public ChoiceService(IChoiceRepository choiceRepository)
        {
            _choiceRepository = choiceRepository;
        }

        public async Task<Choice> CreateChoiceAsync(Choice choice)
        {
            return await _choiceRepository.CreateChoiceAsync(choice);
        }

        public async Task<Choice> UpdateChoiceAsync(Choice choice)
        {
           return await _choiceRepository.UpdateChoiceAsync(choice);
        }
        public async Task<bool> DeleteChoiceAsync(int id)
        {
            return await _choiceRepository.DeleteChoiceAsync(id);
        }

        public async Task<List<Choice>> GetAllChoicesAsync()
        {
            return await _choiceRepository.GetAllChoiceAsync();
        }

        public async Task<Choice> GetChoiceByIdAsync(int id)
        {
            return await _choiceRepository.GetChoiceByIdAsync(id);
        }
        public async Task<List<Choice>> GetChoicesByIdsAsync(List<int> choiceIds) 
        {
            return await _choiceRepository.GetChoicesByIdsAsync(choiceIds); 
        }

        public async Task<List<Choice>> GetChoicesByIdQuestionAsync(int id) 
        {
            return await _choiceRepository.GetChoicesByIdQuestionAsync(id);
        }


        public async Task<Choice> GetChoiceByNumberAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
