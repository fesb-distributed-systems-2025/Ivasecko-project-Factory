using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
    }
}