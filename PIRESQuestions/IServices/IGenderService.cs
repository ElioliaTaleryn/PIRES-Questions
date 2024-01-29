using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IGenderService
    {
        Task<Gender> CreateGenderAsync(Gender gender);
        Task<Gender> GetByIdGenderAsync(int id);
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        //Task<Gender> UpdateGenderAsync(Gender gender);
        Task<bool> DeleteGenderAsync(Gender gender);
    }
}
