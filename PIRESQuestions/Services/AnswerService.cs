using Entities;
using IRepositories;
using IServices;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AnswerService : IAnswerService
    {
        IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository) 
        {
            _answerRepository = answerRepository;
        }
        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            if (answer != null)
            {
                return await _answerRepository.CreateAnswerAsync(answer);
            }
            else throw new Exception("Impossible de créer une réponse sans données ");
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            if(id != null) 
            {
                return await _answerRepository.DeleteAnswerAsync(id);
            }
            else throw new Exception("aucune valeur permettant la suppression de la réponse");
        }

        public async Task<List<Answer>> GetAllAnswerAsync()
        {
            return await _answerRepository.GetAllAnswerAsync();
        }

        public async Task<List<Answer>> GetAnswerByChoiceAsync(int idChoice)
        {
            if (idChoice != null && idChoice != 0)
            {
                return await _answerRepository.GetAnswerByChoiceAsync(idChoice);
            }
            else throw new Exception("Soucis avec l'id du choix selectionné");
        }

        public async Task<List<Answer>> GetAnswerByGenderAsync(int idGender)
        {
            if (idGender != null && idGender != 0)
            {
                return await _answerRepository.GetAnswerByGenderAsync(idGender);
            }
            else throw new Exception("Soucis avec l'id du genre selectionné");
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            if (id != 0)
            {
                return await _answerRepository.GetAnswerByIdAsync(id);
            }
            else throw new Exception("L'id saisie ne permet par la recherche d'une réponse");         
        }
        public async Task<List<Answer>> GetAnswerByFormIdAsync(int formId) 
        {
            if(formId != 0) 
            {
                return await _answerRepository.GetAnswerByFormAsync(formId);
            }
            else
            {
                throw new Exception("Aucune réponse trouvé pour le formulaire");
            }
        }
    }
}
