using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> DeleteGenderAsync(Gender gender)
        {
            return await context.Genders.Where(g => g.Id == gender.Id).ExecuteDeleteAsync() == 1;
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await context.Genders.ToListAsync();
        }

        public async Task<Gender> GetByIdGenderAsync(int id)
        {
            var gender = await context.Genders.FindAsync(id);
            if (gender == null)
            {
                throw new GenderRepositoryException($"Gender Id value invalid: doesn't exists in DB.");
            }
            return gender;
        }
    }
}
