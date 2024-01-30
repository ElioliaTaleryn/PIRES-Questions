using Entities;
using IRepositories;
using IServices;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AnonymousService(IAnonymousRepository anonymousRepository) : IAnonymousService
    {
        public async Task<Anonymous> CreateAnonymousAsync(Anonymous anonymous)
        {
            return await anonymousRepository.CreateAnonymousAsync(anonymous);
        }
        public async Task<bool> DeleteAnonymousAsync(Anonymous anonymous)
        {
            return await anonymousRepository.DeleteAnonymousAsync(anonymous);
        }
        public async Task<IEnumerable<Anonymous>> GetAllAnonymousesAsync()
        {
            return await anonymousRepository.GetAllAnonymousesAsync();
        }
        public async Task<Anonymous> GetByIdAnonymousAsync(int id)
        {
            return await anonymousRepository.GetByIdAnonymousAsync(id);
        }
        public async Task<int> UpdateAnonymousAsync(Anonymous anonymous)
        {
            return await anonymousRepository.UpdateAnonymousAsync(anonymous);
        }
    }
}
