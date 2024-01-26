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
                throw new CountryServiceException($"Country name value invalid: doesn't exists in DB.");
            }
            return await countryRepository.CreateCountryAsync(country);
        }

        public async Task<bool> DeleteCountryAsync(Country country)
        {
            return await countryRepository.DeleteCountryAsync(country);
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await countryRepository.GetAllCountriesAsync();
        }

        public async Task<Country> GetByIdCountryAsync(int id)
        {
            return await countryRepository.GetByIdCountryAsync(id);
        }
    }
}
