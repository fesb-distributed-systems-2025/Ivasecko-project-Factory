using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IWorkerRepository _workerRepository;

        public EmailService(IEmailRepository emailRepository, IWorkerRepository WorkerRepository,) 
        {
            _emailRepository = emailRepository;
            _workerRepository = workerRepository;
        }

        public async Task<IEnumerable<Email?>> GetAllEmails()
        {
            return await _emailRepository.GetEmails();
        }

        public async Task<Email?> GetEmailById(int id)
        {
            return await _emailRepository.GetEmailById(id);
        }

        public async Task<string> AddEmail(PostEmailDTO email)
        {
            var emailEntity = email.ToModel();

            var validationResult = await CreateOrUpdateValidation(emailEntity);
            if (validationResult != null)
                return validationResult;

            _emailRepository.CreateEmail(emailEntity);
            return $"Email successfully created with Id: {emailEntity.Id}";
        }

        public async Task<string> UpdateEmail(PutEmailDTO email)
        {
            var emailEntity = email.ToModel();

            var validationResult = await CreateOrUpdateValidation(emailEntity);
            if (validationResult != null)
                return validationResult;

            await _emailRepository.UpdateEmail(emailEntity);
            return $"Successfully updated email with Id: {emailEntity.Id}";
        }

        public async Task<string> DeleteEmail(int id)
        {
            await _emailRepository.DeleteEmail(id);
            return $"Successfully deleted email with Id: {id}";
        }

        private async Task<string> CreateOrUpdateValidation(Email email)
        {
            var senderId = await _workerRepository.GetWorkerById(email.SenderId);
            if (senderId is null)
                return "Sender is not found.";

            var receiverId =await _workerRepository.GetWorkerById(email.ReceiverId);
            if (receiverId is null)
                return "Receiver is not found.";

            if (string.IsNullOrWhiteSpace(email.Subject))
                return "Subject is required.";
            else if (email.Subject.Length > Email.SubjectMaxLength)
                return $"Subject cant have more than {Email.SubjectMaxLength} characters.";
            else if (email.Subject.Length < Email.SubjectMinLength)
                return $"Subject must have more than {Email.SubjectMinLength} characters.";

            if (!string.IsNullOrWhiteSpace(email.Message) && email.Message.Length > Email.MessageMaxLength)
                return $"Message cant have more than {Email.MessageMaxLength} characters.";

            return null;
        }
    }
}