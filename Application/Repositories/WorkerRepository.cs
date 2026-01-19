using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public WorkerRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }   


        public async Task<IEnumerable<Worker>> GetAllWorkers()
        {
            return await _dbContext.Workers.AsNoTracking().ToListAsync();
        }

        public async Task<Worker?> GetWorkerById(int id)
        {
            var worker = await _dbContext.Workers.FindAsync(id);
            if (worker == null)
                throw new KeyNotFoundException($"Worker {id} not found.");

            return worker;
        }

        public void CreateWorker(Worker worker)
        {
            _dbContext.Workers.Add(worker);
            
        }

        public async Task UpdateWorker(Worker worker)
        {
            var oldWorker = await _dbContext.Workers.FindAsync(worker.Id)
                ?? throw new KeyNotFoundException($"Worker {worker.Id} not found.");

            oldWorker.Name = worker.Name;
            oldWorker.Surname = worker.Surname;
            oldWorker.Age = worker.Age;
            oldWorker.BirthDate = worker.BirthDate;
            oldWorker.EmailAddress = worker.EmailAddress;
            oldWorker.PositionId = worker.PositionId;
        }

        public async Task DeleteWorker(int id)
        {
            var worker = await _dbContext.Workers.FindAsync(id);
            if (worker != null)
            {
                _dbContext.Workers.Remove(worker);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
