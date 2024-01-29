using Entities;

namespace IServices
{
    public interface IUserPersonService
    {
        Task<UserPerson> CreateUserPersonAsync(UserPerson userPerson);
        // Task<UserPerson> GetByIdUserPersonAsync(int id);
        // Task<IEnumerable<UserPerson>> GetAllUserPersonAsync();
        // Task<int> UpdateUserPersonAsync(UserPerson userPerson);
        // Task<bool> DeleteUserPersonAsync(UserPerson userPerson);
    }
}
