using Entities;

namespace IServices
{
    public interface IFormService
    {
        Task<Form> CreateFormAsync(Form form);
        Task<Form> GetByIdFormAsync(int id);
        Task<IEnumerable<Form>> GetAllFormAsync();
        Task<List<Form>> GetFormByUserIdAsync(string userId);
        Task<int> UpdateFormAsync(Form form);
        Task<bool> DeleteFormAsync(Form form);
    }
}
