using Entities;
using IRepositories;
using IServices;

namespace Services
{
    public class GenderService(IGenderRepository genderRepository) : IGenderService
    {
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            return await genderRepository.CreateGenderAsync(gender);
        }
    }
}
