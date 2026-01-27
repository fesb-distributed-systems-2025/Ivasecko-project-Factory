using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Worker> Workers { get; }
        //DbSet<User> Users { get; }
        DbSet<Email> Emails { get; }
        DbSet<Position> Positions { get; } 
        DbSet<Shift> Shifts { get; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
