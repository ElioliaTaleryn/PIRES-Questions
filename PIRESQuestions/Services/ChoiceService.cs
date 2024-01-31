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
        IChoiceRepository ChoiceRepository;
        public ChoiceService(IChoiceRepository choiceRepository)
        {
            ChoiceRepository = choiceRepository;
        }

        public async Task<Choice> CreateChoiceAsync(Choice choice)
        {
            return await ChoiceRepository.CreateChoiceAsync(choice);
        }

        public async Task<Choice> UpdateChoiceAsync(Choice choice)
        {
           return await ChoiceRepository.UpdateChoiceAsync(choice);
        }
        public async Task<bool> DeleteChoiceAsync(int id)
        {
            return await ChoiceRepository.DeleteChoiceAsync(id);
        }

        public async Task<List<Choice>> GetAllChoicesAsync()
        {
            return await ChoiceRepository.GetAllChoiceAsync();
        }

        public async Task<Choice> GetChoiceByIdAsync(int id)
        {
            return await ChoiceRepository.GetChoiceByIdAsync(id);
        }

        public async Task<Choice> GetChoiceByNumberAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
