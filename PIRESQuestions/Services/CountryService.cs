using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Services.Exceptions;

namespace Services
{
    public class CountryService(ICountryRepository countryRepository, ApplicationDbContext context) : ICountryService
    {
        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (!context.Countries.Contains(country))
            {
                throw new CountryServiceException($"Country name value invalid: doesn't exists in BDD.");
            }
            return await countryRepository.CreateCountryAsync(country);
        }
    }
}
