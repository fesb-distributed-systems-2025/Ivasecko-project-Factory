using Domain.Models;

namespace Application.DTOs
{
    public class PutEmailDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string? Message { get; set; }

        public Email ToModel()
        {
            return new Email
            {
                Id = Id,
                SenderId = SenderId,
                ReceiverId = ReceiverId,
                Message = Message,
                Subject = Subject
            };
        }
    }
}