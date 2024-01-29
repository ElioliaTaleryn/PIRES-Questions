using Entities;

namespace IServices
{
    public interface IGenderService
    {
        Task<Gender> CreateGenderAsync(Gender gender);
        Task<Gender> GetByIdGenderAsync(int id);
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        Task<int> UpdateGenderAsync(Gender gender);
        Task<bool> DeleteGenderAsync(Gender gender);
    }
}