using Entities;

namespace IServices
{
    public interface ICountryService
    {
        Task<Country> CreateCountryAsync(Country country);
        /*Task<Country> GetByIdCountryAsync(int id);
        Task<IEnumerable<Country>> GetAllCountryAsync();
        Task<Country> UpdateCountryAsync(Country country);
        Task<bool> DeleteCountryAsync(Country country);
        Task<bool> DeleteAllCountryAsync(Country country);*/
    }
}
