using Application.DTOs;
using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
   public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IPositionRepository _positionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WorkerService(IWorkerRepository workerRepository, IPositionRepository positionRepository, IUnitOfWork unitOfWork)
    {
        _workerRepository = workerRepository;
        _positionRepository = positionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Worker>>> GetAllWorkers()
    {
        var workers = await _workerRepository.GetAllWorkers();
            return Result<IEnumerable<Worker>>.Success(workers);
    }

    public async Task<Result<Worker>> GetWorkerById(int id)
    {
        var worker = await _workerRepository.GetWorkerById(id);
        if (worker == null)
            return Result<Worker>.Failure(new List<string> { "Worker not found" });

            return Result<Worker>.Success(worker);
    }

    public async Task<Result<object>> AddWorker(PostWorkerDTO workerDto)
        {
            var workerEntity = workerDto.ToModel();
            var validation = ValidateWorker(workerEntity);

            // Validacija pozicije
            if (!validation.IsSuccess)
                return Result<object>.Failure(validation.ValidationItems);

            _workerRepository.CreateWorker(workerEntity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success(workerEntity);
        }

    public async Task<Result<object>> UpdateWorker(PutWorkerDTO dto)
{
    var worker = dto.ToModel(); // mapira DTO u Worker model

    // validacija
    var validation = ValidateWorker(worker);
    if (!validation.IsSuccess)
        return Result<object>.Failure(validation.ValidationItems);

    // provjera position
    if (dto.PositionId.HasValue)
{
    var position = await _positionRepository.GetById(dto.PositionId.Value);
    if (position == null)
        return Result<object>.Failure(new List<string> { "Position not found" });

    worker.Position = position; // ✅ veza preko navigation propertyja
}
    // update u repo
    await _workerRepository.UpdateWorker(worker);
    await _unitOfWork.SaveChangesAsync();

    return Result<object>.Success(worker);
    }   


    public async Task<Result<object>> DeleteWorker(int id)
    {
        await _workerRepository.DeleteWorker(id);
        return Result<object>.Success();
    }

    private ValidationResult ValidateWorker(Worker worker)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(worker.Name))
                result.ValidationItems.Add("Name is required.");
            if (string.IsNullOrWhiteSpace(worker.Surname))
                result.ValidationItems.Add("Surname is required.");
            if (string.IsNullOrWhiteSpace(worker.EmailAddress))
                result.ValidationItems.Add("EmailAddress is required.");

            return result;
        }
}


}
