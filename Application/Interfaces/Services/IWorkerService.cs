using Application.DTOs;
using Application.Common;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IWorkerService
    {
        Task<Result<IEnumerable<Worker>>> GetAllWorkers();
        Task<Result<Worker>> GetWorkerById(int id);
        Task<Result<Worker>> AddWorker(PostWorkerDTO dto);
        Task<Result<Worker>> UpdateWorker(PutWorkerDTO dto);
        Task<Result<bool>> DeleteWorker(int id);
    }
}
