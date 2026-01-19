using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetAll();
        Shift? GetById(int id);

        IEnumerable<Shift> GetShiftsForWorker(int workerId, DateOnly date);

        void Add(Shift shift);
        void Update(Shift shift);
        void Delete(Shift shift);
    }
}
