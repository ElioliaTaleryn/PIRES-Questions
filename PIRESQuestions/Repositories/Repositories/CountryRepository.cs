using Entities;
using IRepositories;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class CountryRepository(ApplicationDbContext context) : ICountryRepository
    {
        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (country == null)
            {
                throw new CountryRepositoryException($"Country object invalid: null.");
            }

            bool contains = context.Countries.Contains(country);
            if (string.IsNullOrEmpty(country.Name) || contains)
            {
                throw new GenderRepositoryException($"Country name value invalid: null, empty or mismatch.");
            }
            else
            {
                context.Countries.Add(country);
                await context.SaveChangesAsync();
                return country;
            }
        }

    }
}
