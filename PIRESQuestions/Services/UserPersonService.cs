using Entities;
using IRepositories;
using IServices;

namespace Services
{
    public class UserPersonService(IUserPersonRepository userRepository) : IUserPersonService
    {
        public async Task<UserPerson> CreateUserPersonAsync(UserPerson userPerson)
        {
            return await userRepository.CreateUserPersonAsync(userPerson);
        }
    }
}
