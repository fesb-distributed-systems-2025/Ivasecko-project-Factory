using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetEmails();
        Task<Email> GetEmailById(int id);
        void CreateEmail(Email email);
        Task UpdateEmail(Email email);
        Task DeleteEmail(int id);
    }
}