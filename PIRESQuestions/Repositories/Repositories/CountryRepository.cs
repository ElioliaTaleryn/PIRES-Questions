using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class CountryRepository(ApplicationDbContext _context) : ICountryRepository
    {
        private readonly ApplicationDbContext context = _context;
        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (country.Id != 0)
            {
                throw new CountryRepositoryException($"Country id value invalid: must be 0.");
            }
            context.Countries.Add(country);
            await context.SaveChangesAsync();
            return country;
        }

    }
}
