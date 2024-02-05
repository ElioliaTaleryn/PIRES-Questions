using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using Repositories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class AnonymousRepository(ApplicationDbContext _context) : IAnonymousRepository
    {
        public async Task<Anonymous> CreateAnonymousAsync(Anonymous anonymous)
        {
                    
            if (anonymous.Id != 0)
            {
                throw new AnonymousRepositoryException($"Anonymous id value invalid: must be 0.");
            }
            if (anonymous.Age == int.MinValue || (anonymous.Age < 0 || anonymous.Age > 125))
            {
                throw new AnonymousRepositoryException($"Anonymous Age value invalid: must be higher than 0 and lower than 125.");
            }

            //var anonymousExist = await _context.Anonymouses.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
            //anonymous.Id = anonymousExist.Id + 1;

            _context.Anonymouses.Add(anonymous);
            await _context.SaveChangesAsync();
            return anonymous;
        }
        public async Task<Anonymous> GetByIdAnonymousAsync(int id)
        {
            var anonymous = await _context.Anonymouses.FindAsync(id) ?? throw new AnonymousRepositoryException($"Anonymous Id value invalid: doesn't exists in DB.");
            return anonymous;
        }
        public async Task<IEnumerable<Anonymous>> GetAllAnonymousesAsync()
        {
            return await _context.Anonymouses.ToListAsync();
        } 
        public async Task<bool> DeleteAnonymousAsync(Anonymous anonymous)
        {
            return await _context.Anonymouses.Where(a => a.Id == anonymous.Id).ExecuteDeleteAsync() == 1;
        }
    }
}
