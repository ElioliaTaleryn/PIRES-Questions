using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class GenderRepository(ApplicationDbContext context) : IGenderRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            
            if (gender == null)
            {
                throw new GenderRepositoryException($"Gender object invalid: null.");
            }

            bool val = _context.Genders.Contains(gender);
            if (string.IsNullOrEmpty(gender.Label) || val)
            {
                throw new GenderRepositoryException($"Gender label value invalid: null, empty or mismatch.");
            }
            else {
                _context.Genders.Add(gender);
                await _context.SaveChangesAsync();
                return gender;
            }
        }
    }
}
