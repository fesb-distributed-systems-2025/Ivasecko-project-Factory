using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<IEnumerable<Email?>> GetAllEmails();
        Task<Email?> GetEmailById(int id);
        Task<string> AddEmail(PostEmailDTO email);
        Task<string> UpdateEmail(PutEmailDTO email);
        Task<string> DeleteEmail(int id);
    }
}