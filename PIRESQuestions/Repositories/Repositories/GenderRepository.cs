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
            
            if (gender == null)
            {
                throw new GenderRepositoryException($"Gender object invalid: null.");
            }

            bool val = context.Genders.Contains(gender);
            if (string.IsNullOrEmpty(gender.Label) || val)
            {
                throw new GenderRepositoryException($"Gender label value invalid: null, empty or mismatch.");
            }
            else {
                context.Genders.Add(gender);
                await context.SaveChangesAsync();
                return gender;
            }
        }
    }
}
