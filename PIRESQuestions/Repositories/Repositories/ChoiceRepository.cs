using Entities;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ChoiceRepository : IChoiceRepository
    {
        public Task<Choice> CreateChoiceAsync(Choice choice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteChoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Choice>> GetAllChoiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Choice> GetChoiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Choice> UpdateChoiceAsync(Choice choice)
        {
            throw new NotImplementedException();
        }

    }
}
