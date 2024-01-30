using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ChoiceRepository : IChoiceRepository
    {
        ApplicationDbContext _appContext;
        public ChoiceRepository(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }

        public async Task<Choice> CreateChoiceAsync(Choice choice)
        {
            _appContext.Choices.Add(choice);
            await _appContext.SaveChangesAsync();
            return choice;
        }

        public async Task<bool> DeleteChoiceAsync(int id)
        {
            var choice = _appContext.Choices.FirstOrDefault(c => c.Id == id);
            if (choice != null)
            {
                _appContext.Choices.Remove(choice);
                await _appContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Choice>> GetAllChoiceAsync()
        {
            List<Choice> listChoices = new List<Choice>();
            listChoices = await _appContext.Choices.ToListAsync();
            if (listChoices.Any())
            {
                return listChoices;
            }
            else throw new Exception("Aucun choix de réponse trouvé");
        }

        public async Task<Choice> GetChoiceByIdAsync(int id)
        {
            Choice choice = await _appContext.Choices.FindAsync(id);
            if (choice != null)
            {
                return choice;
            }
            else throw new Exception($"Aucun choix de réponse trouvé avec l'id {id} ");
        }

        public async Task<Choice> UpdateChoiceAsync(Choice choice)
        {
            Choice choiceUpdate = _appContext.Choices.FirstOrDefault(c => c.Id == choice.Id);
            if (choiceUpdate != null) 
            {
                choiceUpdate.Label = choice.Label;
                choiceUpdate.QuestionId = choice.QuestionId;
                await _appContext.SaveChangesAsync();
                return choice;
            }
            else
            {
                throw new InvalidOperationException("La mise à jour a échoué");
            }
        }

    }
}
