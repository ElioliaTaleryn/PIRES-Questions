using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Services.Exceptions;

namespace Services
{
    public class GenderService(ApplicationDbContext context, IGenderRepository genderRepository) : IGenderService
    {
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            if (!context.Genders.Contains(gender))
            {
                throw new GenderServiceException($"Gender label value invalid: doesn't exists in BDD.");
            }
            return await genderRepository.CreateGenderAsync(gender);
        }
    }
}
