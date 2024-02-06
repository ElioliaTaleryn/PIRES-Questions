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
    public class AnswerRepository : IAnswerRepository
    {
        ApplicationDbContext _appContext;

        public AnswerRepository(ApplicationDbContext applicationDbContext)
        {
            _appContext = applicationDbContext;
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            _appContext.Answers.Add(answer);
            await _appContext.SaveChangesAsync();
            return answer;
        }

        public async Task<List<Answer>> GetAllAnswerAsync()
        {
            List<Answer> answers = await _appContext.Answers.ToListAsync();
            if (answers.Any())
            {
                return answers;
            }
            else throw new Exception("Aucune réponse trouvées");
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            var answer = await _appContext.Answers.FindAsync(id);
            if (answer != null) 
            {
                return answer;
            }
            else throw new Exception($"Auncune réponse trouvé avec l'id : {id}");
        }
        public async Task<List<Answer>> GetAnswerByChoiceAsync(int idChoice)
        {
            List<Answer> answers = await _appContext.Answers.Where(a => a.ChoiceId == idChoice).ToListAsync();
            if (answers.Any())
            {
                return answers;
            }
            else throw new Exception("Aucune réponse trouvée avec ce choix");
        }
        public async Task<List<Answer>> GetAnswerByGenderAsync(int idGender)
        {
            List<Answer> answers = await _appContext.Answers.Where(a => a.Anonymous.GenderId == idGender).ToListAsync();
            if (answers.Any())
            {
                return answers;
            }
            else throw new Exception("Aucune réponse trouvée");
        }
        //public async Task<List<Answer>> GetAnswerByFormAsync(int formId)
        //{
        //    List<Answer> answers = await _appContext.Answers.Include(a => a.Form).Include(a => a.Question).Include(a => a.Choice).Include(a => a.Anonymous).Where(a => a.FormId == formId).ToListAsync();
        //    if (answers.Any())
        //    {
        //        return answers;
        //    }
        //    else throw new Exception("Aucune réponse trouvée");
        //}
        public async Task<bool> DeleteAnswerAsync(int id)
        {
            var answer = _appContext.Answers.FirstOrDefault(a => a.Id == id);
            if (answer != null)
            {
                _appContext.Answers.Remove(answer);
                await _appContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
