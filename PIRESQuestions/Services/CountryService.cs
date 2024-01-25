using Entities;
using IRepositories;
using IServices;

namespace Services
{
    public class CountryService(ICountryRepository countryRepository) : ICountryService
    {
        public async Task<Country> CreateCountryAsync(Country country)
        {
            return await countryRepository.CreateCountryAsync(country);
        }
    }
}
