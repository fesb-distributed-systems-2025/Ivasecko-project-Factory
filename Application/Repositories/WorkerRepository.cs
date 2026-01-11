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

        public IEnumerable<Worker> GetAll()
        {
            return _dbContext.Workers.ToList();
        }

        public Worker? GetById(int id)
        {
            return _dbContext.Workers.FirstOrDefault(w => w.Id == id);
        }

     
    }
}
