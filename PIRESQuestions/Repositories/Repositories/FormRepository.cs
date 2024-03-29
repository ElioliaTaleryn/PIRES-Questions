﻿using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using ViewModels;

namespace Repositories.Repositories
{
    public class FormRepository(ApplicationDbContext _context) : IFormRepository
    {
        public async Task<Form> CreateFormAsync(Form form)
        {
            if (form.Id != 0)
            {
                throw new FormRepositoryException($"Form id value invalid: must be 0.");
            }
            if (string.IsNullOrWhiteSpace(form.Title))
            {
                throw new FormRepositoryException($"Form Title value invalid: null, empty or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(form.Description))
            {
                throw new FormRepositoryException($"Form Description value invalid: null, empty or whitespace.");
            }
            if (form.StatusId == 0)
            {
                throw new FormRepositoryException($"Form StatusId value invalid: shouldn't be 0");
            }
            if (string.IsNullOrWhiteSpace(form.UserPersonId))
            {
                throw new FormRepositoryException($"Form UserPersonId value invalid: null, empty or whitespace");
            }
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
            return form;

        }

        public async Task<bool> DeleteFormAsync(Form form)
        {
            //var answers = await _context.Answers.Where(a => a.FormId == form.Id).ToListAsync();
            //if (answers.Any())
            //{
            //    _context.Answers.RemoveRange(answers);
            //    await _context.SaveChangesAsync();
            //}

            return await _context.Forms.Where(f => f.Id == form.Id).ExecuteDeleteAsync() == 1;
        }

        public async Task<IEnumerable<Form>> GetAllFormsAsync()
        {
            return await _context.Forms.Include(f => f.Questions).Include(q => q.Questions).Include(f => f.UserPerson).Include(f => f.Status).ToListAsync();
        }

        public async Task<Form> GetByIdFormAsync(int id)
        {
            var form = await _context.Forms.Include(f => f.Questions).Include(q => q.Questions).Include(f => f.UserPerson).Include(f => f.Status).FirstOrDefaultAsync(f => f.Id == id) ?? throw new FormRepositoryException($"Form Id value invalid: doesn't exists in DB.");
            return form;
        }

        public async Task<int> UpdateFormAsync(Form form)
        {
            if (string.IsNullOrWhiteSpace(form.Title))
            {
                throw new FormRepositoryException($"Form Title value invalid: null, empty or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(form.Description))
            {
                throw new FormRepositoryException($"Form Description value invalid: null, empty or whitespace.");
            }
            if (form.StatusId == 0)
            {
                throw new FormRepositoryException($"Form StatusId value invalid: shouldn't be 0");
            }
            if (string.IsNullOrWhiteSpace(form.UserPersonId))
            {
                throw new FormRepositoryException($"Form UserPersonId value invalid: null, empty or whitespace");
            }

            await _context.Forms
                .Where(f => f.Id == form.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(f => f.Title, f => form.Title));
            await _context.Forms
                .Where(f => f.Id == form.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(f => f.Description, f => form.Description));
            await _context.Forms
                .Where(f => f.Id == form.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.StatusId, f => form.StatusId));
            return await _context.Forms
                .Where(f => f.Id == form.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.UserPersonId, f => form.UserPersonId));
        }

        public async Task<List<Form>> GetFormByUserIdAsync(string userId)
        {
            var form = await _context.Forms.Include(f => f.Questions).ThenInclude(q => q.Choices).Include(f => f.UserPerson).Include(f => f.Status).Where(f => f.UserPersonId == userId).ToListAsync() ?? throw new FormRepositoryException($"Pas de form avec cet UserId.");

            return form;
        }

        public async Task<FormResultViewModel> GetFormWithQuestionsAndAnswersAsync(int formId)
        {
            var formWithQuestionsAndAnswers = await _context.Forms.Where(f => f.Id == formId).Include(f => f.Questions).ThenInclude(q => q.Choices).Include(f => f.Questions).ThenInclude(q => q.Answers).ThenInclude(a => a.Anonymous).FirstOrDefaultAsync();

            if (formWithQuestionsAndAnswers == null)
            {
                throw new Exception("Aucun formulaire trouvé");
            }

            var viewModel = new FormResultViewModel
            {
                Form = formWithQuestionsAndAnswers,
                Questions = formWithQuestionsAndAnswers.Questions,
                Choices = formWithQuestionsAndAnswers.Questions.SelectMany(q => q.Choices).ToList(),
                Answers = formWithQuestionsAndAnswers.Questions.SelectMany(q => q.Answers).ToList(),
                Anonymous = formWithQuestionsAndAnswers.Questions.SelectMany(q => q.Answers).Select(a => a.Anonymous).ToList(),
            };
            return viewModel;
        }
    }
}
