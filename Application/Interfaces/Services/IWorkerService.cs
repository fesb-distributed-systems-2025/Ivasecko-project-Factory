using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetAllWorkers();
        Task<Worker?> GetWorkerById(int id);
        Task<string> AddWorker(PostWorkerDTO worker);
        Task<string> UpdateWorker(PutWorkerDTO worker);
        Task<string> DeleteWorker(int id);
    }
}
