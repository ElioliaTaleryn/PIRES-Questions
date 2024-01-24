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
        /*Task<Gender> GetByIdGenderAsync(int id);
        Task<IEnumerable<Gender>> GetAllGenderAsync();
        Task<Gender> UpdateGenderAsync(Gender gender);
        Task<bool> DeleteGenderAsync(Gender gender);
        Task<bool> DeleteAllGenderAsync(Gender gender);*/
    }
}
