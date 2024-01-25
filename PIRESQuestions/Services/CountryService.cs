using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Services.Exceptions;

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
    }
}
