using Application.DTOs;
using Application.Common;
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

    public async Task<Result<IEnumerable<Worker>>> GetAllWorkers()
    {
        var workers = await _workerRepository.GetAll();
            return Result<IEnumerable<Worker>>.Success(workers);
    }

    public async Task<Result<Worker>> GetWorkerById(int id)
    {
        var worker = await _workerRepository.GetById(id);
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
            await _workerRepository.SaveChangesAsync();

            return Result<object>.Success(workerEntity);
        }

        public async Task<Result<Worker>> UpdateWorker(PutWorkerDTO dto)
{
    var worker = dto.ToModel(); // mapira DTO u Worker model

    // validacija
    var validation = ValidateWorker(worker);
    if (!validation.IsSuccess)
        return Result<Worker>.Failure(validation.ValidationItems);

    // provjera position
    if (!string.IsNullOrEmpty(dto.Position))
    {
        var position = await _positionRepository.GetById(int.Parse(dto.Position));
        if (position == null)
            return Result<Worker>.Failure(new List<string> { "Position not found" });

        worker.PositionId = position.Id;
    }

    // update u repo
    _workerRepository.Update(worker);
    await _workerRepository.SaveChangesAsync();

    return Result<Worker>.Success(worker);
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
