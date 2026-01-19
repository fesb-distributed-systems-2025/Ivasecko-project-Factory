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

    public async Task Add(Position position)  
     {
            
        }

    public async Task<string> Update(Position position)
        {
            var existing = await _positionRepository.GetById(position.Id);
            if (existing == null)
                return $"Position with Id {position.Id} not found.";

            existing.Title = position.Title;
            await _positionRepository.Update(position);

            return $"Position '{position.Title}' successfully updated.";
        }

        public async Task<string> Delete(int id)
        {
            var existing = await _positionRepository.GetById(id);
            if (existing == null)
                return $"Position with Id {id} not found.";

            await _positionRepository.Delete(id);
            return $"Position '{existing.Title}' successfully deleted.";
        }
}

}
