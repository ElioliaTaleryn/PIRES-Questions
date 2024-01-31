using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IGenderRepository
    {
        Task<Gender> CreateGenderAsync(Gender gender);
        Task<Gender> GetByIdGenderAsync(int id);
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        Task<int> UpdateGenderAsync(Gender gender);
        Task<bool> DeleteGenderAsync(Gender gender);
    }
}
