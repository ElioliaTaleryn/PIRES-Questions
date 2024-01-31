using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity_Framework;
using Repositories.Exceptions;

namespace Repositories.Repositories
{
    public class StatusRepository(ApplicationDbContext _context) : IStatusRepository
    {
        public async Task<Status> CreateStatusAsync(Status status)
        {
            if (status.Id != 0) {
                throw new StatusRepositoryException($"Status id value: must be 0.");
            }
            if (string.IsNullOrWhiteSpace(status.Label)) {
                throw new StatusRepositoryException($"Status Label value invalid: null, empty or whitespace");
            }
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<bool> DeleteStatusAsync(Status status)
        {
            return await _context.Statuses.Where(s => s.Id == status.Id).ExecuteDeleteAsync() == 1;
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetByIdStatusAsync(int id)
        {
            var status = await _context.Statuses.FindAsync(id) ?? throw new StatusRepositoryException($"Status Id value: doesn't exist in DB.");
            return status;
        }

        public async Task<int> UpdateStatusAsync(Status status)
        {
            if (string.IsNullOrWhiteSpace(status.Label)) 
            {
                throw new StatusRepositoryException($"Status Label value invalid: null, empty or whitespace");
            }

            return await _context.Statuses
                .Where(s => s.Id == status.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(s => s.Label, s => status.Label));
        }
    }
}
