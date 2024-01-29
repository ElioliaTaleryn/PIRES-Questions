using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IUserPersonRepository
    {
        Task<UserPerson> CreateUserPersonAsync(UserPerson userPerson);
        // Task<UserPerson> GetByIdUserPersonAsync(int id);
        // Task<IEnumerable<UserPerson>> GetAllUserPersonAsync();
        // Task<int> UpdateUserPersonAsync(UserPerson userPerson);
        // Task<bool> DeleteUserPersonAsync(UserPerson userPerson);
    }
}
