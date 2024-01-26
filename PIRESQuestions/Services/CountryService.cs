using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Repositories.Repositories;
using Services.Exceptions;
using System.Reflection;

namespace Services
{
    public class CountryService(ICountryRepository _countryRepository, ApplicationDbContext _context) : ICountryService
    {
        private readonly ICountryRepository countryRepository = _countryRepository;
        private readonly ApplicationDbContext context = _context;

        public async Task<Country> CreateCountryAsync(Country country)
        {
            if (!context.Countries.Contains(country))
            {
                throw new CountryServiceException($"Country name value invalid: doesn't exists in BDD.");
            }
            return await countryRepository.CreateCountryAsync(country);
        }

        public async Task<bool> DeleteCountryAsync(Country country)
        {
            return await _countryRepository.DeleteCountryAsync(country);
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
