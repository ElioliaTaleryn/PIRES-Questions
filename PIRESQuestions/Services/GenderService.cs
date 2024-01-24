using Entities;
using IRepositories;
using IServices;

namespace Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            return await _genderRepository.CreateGenderAsync(gender);
        }
    }
}
