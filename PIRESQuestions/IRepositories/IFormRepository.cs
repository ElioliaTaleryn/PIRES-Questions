using Entities;
using ViewModels;

namespace IRepositories
{
    public interface IFormRepository
    {
        Task<Form> CreateFormAsync(Form form);
        Task<Form> GetByIdFormAsync(int id);
        Task<IEnumerable<Form>> GetAllFormsAsync();
        Task<List<Form>> GetFormByUserIdAsync(string userId);
        Task<FormResultViewModel> GetFormWithQuestionsAndAnswersAsync(int formId);
        Task<int> UpdateFormAsync(Form form);
        Task<bool> DeleteFormAsync(Form form);
    }
}
