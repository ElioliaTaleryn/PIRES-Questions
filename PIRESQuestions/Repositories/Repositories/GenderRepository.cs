using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class GenderRepository(ApplicationDbContext _context) : IGenderRepository
    {
        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            if(gender.Id != 0) {
                throw new GenderRepositoryException($"Gender id value invalid: must be 0.");
            }
            if (string.IsNullOrWhiteSpace(gender.Label))
            {
                throw new GenderRepositoryException($"Gender Label value invalid: null, empty or whitespace.");
            }
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();
            return gender;
        }
        public async Task<bool> DeleteGenderAsync(Gender gender)
        {
            return await _context.Genders.Where(g => g.Id == gender.Id).ExecuteDeleteAsync() == 1;
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> GetByIdGenderAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id) ?? throw new GenderRepositoryException($"Gender Id value invalid: doesn't exists in DB.");
            return gender;
        }

        public async Task<int> UpdateGenderAsync(Gender gender)
        {
            if (string.IsNullOrWhiteSpace(gender.Label))
            {
                throw new GenderRepositoryException($"Gender Label value invalid: null, empty or whitespace.");
            }

            return await _context.Genders
                .Where(g => g.Id == gender.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(g => g.Label, g => gender.Label));
        }
    }
}
