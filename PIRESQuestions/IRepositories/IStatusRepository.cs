using Entities;

namespace IRepositories
{
    public interface IStatusRepository
    {
        Task<Status> CreateStatusAsync(Status status);
        Task<Status> GetByIdStatusAsync(int id);
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<int> UpdateStatusAsync(Status status);
        Task<bool> DeleteStatusAsync(Status status);
    }
}
