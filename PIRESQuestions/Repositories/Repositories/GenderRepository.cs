using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class GenderRepository(ApplicationDbContext context) : IGenderRepository
    {
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            if(gender.Id != 0) {
                throw new GenderRepositoryException($"Gender id value invalid: must be 0.");
            }
            context.Genders.Add(gender);
            await context.SaveChangesAsync();
            return gender;

            // controller
            /*if (gender == null || string.IsNullOrEmpty(gender.Label))
            {
                throw new GenderRepositoryException($"Gender object invalid: null or empty.");
            }*/
        }
    }
}
