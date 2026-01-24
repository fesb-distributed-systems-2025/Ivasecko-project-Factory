using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly IApplicationDbContext _context;

        public ShiftRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shift> GetAll()
        {
            return _context.Shifts
                .Include(s => s.Worker)
                .ToList();
        }

        public Shift? GetById(int id)
        {
            return _context.Shifts
                .Include(s => s.Worker)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Shift> GetShiftsForWorker(int workerId, DateOnly date)
        {
            return _context.Shifts
                .Where(s => s.WorkerId == workerId && s.Date == date)
                .ToList();
        }

        public void Add(Shift shift)
        {
            _context.Shifts.Add(shift);
        }

        public void Update(Shift shift)
        {
            _context.Shifts.Update(shift);
        }

        public void Delete(Shift shift)
        {
            _context.Shifts.Remove(shift);
        }
    }
}
