﻿using Entities;
using IRepositories;
using IServices;
using Repositories.Entity_Framework;
using Services.Exceptions;

namespace Services
{
    public class GenderService(ApplicationDbContext _context, IGenderRepository _genderRepository) : IGenderService
    {
        private readonly ApplicationDbContext context = _context;
        private readonly IGenderRepository genderRepository = _genderRepository;

        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            if (!context.Genders.Contains(gender))
            {
                throw new GenderServiceException($"Gender label value invalid: doesn't exists in BDD.");
            }
            return await genderRepository.CreateGenderAsync(gender);
        }

        public async Task<bool> DeleteGenderAsync(Gender gender)
        {
            return await _genderRepository.DeleteGenderAsync(gender);
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await genderRepository.GetAllGendersAsync();
        }

        public async Task<Gender> GetByIdGenderAsync(int id)
        {
            return await genderRepository.GetByIdGenderAsync(id);
        }
    }
}
