using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAll();
        Task<Position?> GetById(int id);
        void Add(Position position);
        Task Update(Position position);
        Task Delete(int id);
    }
}
