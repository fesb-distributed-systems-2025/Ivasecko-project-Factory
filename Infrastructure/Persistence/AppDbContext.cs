using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet = table in database
        public DbSet<Worker> Workers { get; set; }
    }
}
