using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System.Reflection;

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

        public async Task<bool> DeleteCountryAsync(Country country)
        {
            return await context.Countries.Where(i => i.Id == country.Id).ExecuteDeleteAsync() == 1;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await context.Countries.ToListAsync();
        }
    }
}
