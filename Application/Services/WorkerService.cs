using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
   public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IPositionRepository _positionRepository;

    public WorkerService(IWorkerRepository workerRepository, IPositionRepository positionRepository)
    {
        _workerRepository = workerRepository;
        _positionRepository = positionRepository;
    }

    public async Task<IEnumerable<Worker>> GetAllWorkers()
    {
        return await _workerRepository.GetAllWorkers();
    }

    public async Task<Worker?> GetWorkerById(int id)
    {
        return await _workerRepository.GetWorkerById(id);
    }

    public async Task<string> AddWorker(PostWorkerDTO workerDto)
        {
            var workerEntity = workerDto.ToModel();

            // Validacija pozicije
            if (workerDto.PositionId != null)
            {
                var position = await _positionRepository.GetById(workerDto.PositionId.Value);
                if (position == null)
                    return "Position not found.";

                workerEntity.PositionId = position.Id;
            }

            _workerRepository.CreateWorker(workerEntity);
            return $"Worker successfully created with Id: {workerEntity.Id}";
        }

        public async Task<string> UpdateWorker(PutWorkerDTO workerDto)
        {
             var workerEntity = workerDto.ToModel();

        if (workerDto.PositionId != null)
            {
                var position = await _positionRepository.GetById(workerDto.PositionId.Value);
                if (position == null)
                    return "Position not found.";

                workerEntity.PositionId = position.Id;
            }

            await _workerRepository.UpdateWorker(workerEntity);
           
    
    return $"Worker with Id: {workerEntity.Id} successfully updated.";
        }
    public async Task<string> DeleteWorker(int id)
    {
        await _workerRepository.DeleteWorker(id);
        return $"Worker successfully deleted with Id: {id}";
    }
}


}
