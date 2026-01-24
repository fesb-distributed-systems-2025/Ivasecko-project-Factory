using Application.DTOs;
using Application.Common;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IWorkerService
    {
        Task<Result<IEnumerable<Worker>>> GetAllWorkers();
        Task<Result<Worker>> GetWorkerById(int id);
        Task<Result<object>> AddWorker(PostWorkerDTO dto);
        Task<Result<object>> UpdateWorker(PutWorkerDTO dto);
        Task<Result<object>> DeleteWorker(int id);
    }
}
