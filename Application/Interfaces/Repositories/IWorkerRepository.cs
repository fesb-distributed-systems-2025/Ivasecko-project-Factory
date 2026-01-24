using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker?> GetWorkerById(int id);
        Task<IEnumerable<Worker>> GetAllWorkers();

        void CreateWorker(Worker worker);
        Task UpdateWorker(Worker worker);
        Task DeleteWorker(int id);
    }
}
