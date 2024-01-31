using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Repositories.Repositories;
using Services.Exceptions;
using System.Reflection;

namespace Services
{
    public class CountryService(ICountryRepository countryRepository) : ICountryService
    {
        public async Task<Country> CreateCountryAsync(Country country)
        {
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

        public async Task<int> UpdateCountryAsync(Country country)
        {
            return await countryRepository.UpdateCountryAsync(country);
        }
    }
}
