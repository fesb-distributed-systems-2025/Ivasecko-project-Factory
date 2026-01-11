using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public IEnumerable<Worker> GetAll()
        {
            return _workerRepository.GetAll();
        }

        public Worker? GetById(int id)
        {
            return _workerRepository.GetById(id);
        }

        public void Create(Worker worker)
        {
            _workerRepository.Add(worker);
        }

        public void Update(int id, Worker worker)
        {
            var existingWorker = _workerRepository.GetById(id);
            if (existingWorker == null)
                throw new Exception("Worker not found");

            existingWorker.FirstName = worker.FirstName;
            existingWorker.LastName = worker.LastName;
            existingWorker.Email = worker.Email;

            _workerRepository.Update(existingWorker);
        }

        public void Delete(int id)
        {
            var worker = _workerRepository.GetById(id);
            if (worker == null)
                throw new Exception("Worker not found");

            _workerRepository.Delete(worker);
        }
    }
}
