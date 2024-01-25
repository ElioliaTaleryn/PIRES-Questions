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
        ApplicationDbContext appContext;
        public ChoiceRepository(ApplicationDbContext applicationDbContext)
        {
            appContext = applicationDbContext;
        }

        public async Task<Choice> CreateChoiceAsync(Choice choice)
        {
            appContext.Choices.Add(choice);
            await appContext.SaveChangesAsync();
            return choice;
        }

        public async Task<bool> DeleteChoiceAsync(int id)
        {
            var choice = appContext.Choices.FirstOrDefault(c => c.Id == id);
            if (choice != null)
            {
                appContext.Choices.Remove(choice);
                await appContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<List<Choice>> GetAllChoiceAsync()
        {
            List<Choice> listChoices = new List<Choice>();
            listChoices = await appContext.Choices.ToListAsync();
            if (listChoices.Any())
            {
                return listChoices;
            }
            else throw new Exception("Aucun choix de réponse trouvé");
        }

        public async Task<Choice> GetChoiceByIdAsync(int id)
        {
            Choice choice = await appContext.Choices.FindAsync(id);
            if (choice != null)
            {
                return choice;
            }
            else throw new Exception($"Aucun choix de réponse trouvé avec l'id {id} ");
        }

        public async Task<Choice> UpdateChoiceAsync(Choice choice)
        {
            Choice choiceUpdate = appContext.Choices.FirstOrDefault(c => c.Id == choice.Id);
            if (choiceUpdate != null) 
            {
                choiceUpdate.Label = choice.Label;
                choiceUpdate.QuestionId = choice.QuestionId;
                await appContext.SaveChangesAsync();
                return choice;
            }
            else
            {
                throw new InvalidOperationException("La mise à jour a échoué");
            }
        }

    }
}
