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
            if (country.Id != 0)
            {
                throw new CountryRepositoryException($"Country id value invalid: must be 0.");
            }
            context.Countries.Add(country);
            await context.SaveChangesAsync();
            return country;

            // controller
            /*if (country == null)
            {
                throw new CountryRepositoryException($"Country object invalid: null.");
            }*/
        }

    }
}
