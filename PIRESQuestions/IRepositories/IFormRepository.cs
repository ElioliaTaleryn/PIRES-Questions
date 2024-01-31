using Entities;

namespace IRepositories
{
    public interface IFormRepository
    {
        Task<Form> CreateFormAsync(Form form);
        Task<Form> GetByIdFormAsync(int id);
        Task<IEnumerable<Form>> GetAllFormsAsync();
        Task<int> UpdateFormAsync(Form form);
        Task<bool> DeleteFormAsync(Form form);
    }
}
