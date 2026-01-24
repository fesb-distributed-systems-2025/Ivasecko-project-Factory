using Application.Interfaces.Repositories;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public PositionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task<Position?> GetById(int id)
        {
            return await _dbContext.Positions.FindAsync(id);
        }

        public void Add(Position position)
        {
             _dbContext.Positions.Add(position);
        }

        public async Task Update(Position position)
        {
            _dbContext.Positions.Update(position);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var position = await _dbContext.Positions.FindAsync(id);
            if (position != null)
            {
                _dbContext.Positions.Remove(position);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
