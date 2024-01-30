using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IAnonymousRepository
    {
        Task<Anonymous> CreateAnonymousAsync(Anonymous anonymous);
        Task<Anonymous> GetByIdAnonymousAsync(int id);
        Task<IEnumerable<Anonymous>> GetAllAnonymousesAsync();
        Task<bool> DeleteAnonymousAsync(Anonymous anonymous);
        Task<int> UpdateAnonymousAsync(Anonymous anonymous);
    }
}
