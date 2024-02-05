using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Services.Exceptions;

namespace Services
{
    public class FormService(IFormRepository formRepository) : IFormService
    {
        public async Task<Form> CreateFormAsync(Form form)
        {
            return await formRepository.CreateFormAsync(form);
        }

        public async Task<bool> DeleteFormAsync(Form form)
        {
            return await formRepository.DeleteFormAsync(form);
        }

        public async Task<IEnumerable<Form>> GetAllFormAsync()
        {
            return await formRepository.GetAllFormsAsync();
        }

        public async Task<Form> GetByIdFormAsync(int id)
        {
            return await formRepository.GetByIdFormAsync(id);
        }
        public async Task<List<Form>> GetFormByUserIdAsync(string userId) 
        {
            if (!string.IsNullOrEmpty(userId)) 
            {
                return await formRepository.GetFormByUserIdAsync(userId);
            }
            else throw new Exception("Impossible de rechercher les formulaires sans la personne");
        }

        public async Task<int> UpdateFormAsync(Form form)
        {
            return await formRepository.UpdateFormAsync(form);
        }
    }
}
