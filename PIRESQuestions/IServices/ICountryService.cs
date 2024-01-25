using Entities;

namespace IServices
{
    public interface ICountryService
    {
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetByIdCountryAsync(int id);
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        //Task<Country> UpdateCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(Country country);
    }
}
