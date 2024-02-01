using Entities;
using IRepositories;
using IServices;
using Repositories.Repositories;
using Services.Exceptions;

namespace Services
{
    public class StatusService(IStatusRepository statusRepository) : IStatusService
    {
        public async Task<Status> CreateStatusAsync(Status status)
        {
            return await statusRepository.CreateStatusAsync(status);
        }

        public async Task<bool> DeleteStatusAsync(Status status)
        {
            return await statusRepository.DeleteStatusAsync(status);
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await statusRepository.GetAllStatusesAsync();
        }

        public async Task<Status> GetByIdStatusAsync(int id)
        {
            return await statusRepository.GetByIdStatusAsync(id);
        }

        public async Task<int> UpdateStatusAsync(Status status)
        {
            return await statusRepository.UpdateStatusAsync(status);
        }
    }
}
