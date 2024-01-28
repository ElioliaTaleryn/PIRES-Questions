using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
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
            if (string.IsNullOrWhiteSpace(country.Name))
            {
                throw new CountryRepositoryException($"Country Name value invalid: null, empty or whitespace.");
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

        public async Task<Country> GetByIdCountryAsync(int id)
        {
            var country = await context.Countries.FindAsync(id) ?? throw new CountryRepositoryException($"Country Id value invalid: doesn't exists in DB.");
            return country;
        }
        public async Task<int> UpdateCountryAsync(Country country)
        {
            if (string.IsNullOrWhiteSpace(country.Name))
            {
                throw new CountryRepositoryException($"Country Name value invalid: null, empty or whitespace.");
            }

            return await context.Countries
                .Where(g => g.Id == country.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(g => g.Name, g => country.Name));
        }
    }
}
