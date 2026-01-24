using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAll();
        Task<Position?> GetById(int id);
        Task Add(Position position);
        Task Update(Position position);
        Task Delete(int id);
    }
}
