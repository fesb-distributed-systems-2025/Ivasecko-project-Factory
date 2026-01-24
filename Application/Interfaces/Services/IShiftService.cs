using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IShiftService
    {
        IEnumerable<Shift> GetAll();
        Shift? GetById(int id);

        string Create(Shift shift);
        string Update(int id, Shift shift);
        string Delete(int id);
    }
}
