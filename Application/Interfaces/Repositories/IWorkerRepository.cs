using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IWorkerRepository
    {
        Task<Worker> GetWorkerById(int id);
    }
}