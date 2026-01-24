using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IEmailService _emailService;

        public ShiftService(
            IShiftRepository shiftRepository,
            IWorkerRepository workerRepository,
            IEmailService emailService)
        {
            _shiftRepository = shiftRepository;
            _workerRepository = workerRepository;
            _emailService = emailService;
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftRepository.GetAll();
        }

        public Shift? GetById(int id)
        {
            return _shiftRepository.GetById(id);
        }

        public string Create(Shift shift)
        {
            var validation = ValidateShift(shift);
            if (validation != null)
                return validation;

            _shiftRepository.Add(shift);

            return "Shift successfully created.";
        }

        public string Update(int id, Shift shift)
        {
            var existing = _shiftRepository.GetById(id);
            if (existing == null)
                return "Shift not found.";

            shift.Id = id;

            var validation = ValidateShift(shift);
            if (validation != null)
                return validation;

            _shiftRepository.Update(shift);
            return "Shift updated successfully.";
        }

        public string Delete(int id)
        {
            var shift = _shiftRepository.GetById(id);
            if (shift == null)
                return "Shift not found.";

            _shiftRepository.Delete(shift);
            return "Shift deleted successfully.";
        }

        // 🔒 PRIVATE BUSINESS RULES
        private string? ValidateShift(Shift shift)
        {
            if (_workerRepository.GetWorkerById(shift.WorkerId) == null)
                return "Worker does not exist.";

            if (shift.StartTime >= shift.EndTime)
                return "Shift end time must be after start time.";

            var overlapping = _shiftRepository
                .GetShiftsForWorker(shift.WorkerId, shift.Date)
                .Any(s =>
                    shift.StartTime < s.EndTime &&
                    shift.EndTime > s.StartTime &&
                    s.Id != shift.Id);

            if (overlapping)
                return "Worker already has a shift in this time range.";

            return null;
        }
    }
}
