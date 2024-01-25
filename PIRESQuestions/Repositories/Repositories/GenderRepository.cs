using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class GenderRepository(ApplicationDbContext _context) : IGenderRepository
    {
        private readonly ApplicationDbContext context = _context;
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            if(gender.Id != 0) {
                throw new GenderRepositoryException($"Gender id value invalid: must be 0.");
            }
            context.Genders.Add(gender);
            await context.SaveChangesAsync();
            return gender;
        }
    }
}
