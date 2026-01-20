using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class PositionService : IPositionService
{
    private readonly IPositionRepository _positionRepository;

    public PositionService(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<IEnumerable<Position>> GetAll()
    {
        return await _positionRepository.GetAll();
    }

    public async Task<Position?> GetById(int id)
    {
        return await _positionRepository.GetById(id);
    }

    public Task Add(Position position)  
     {
            _positionRepository.Add(position);
            return Task.CompletedTask;
        }

    public async Task Update(Position position)
        {
            var existing = await _positionRepository.GetById(position.Id);

            existing.Title = position.Title;
            await _positionRepository.Update(position);
        }

        public async Task Delete(int id)
        {
            var existing = await _positionRepository.GetById(id);

            await _positionRepository.Delete(id);
        }
}

}
