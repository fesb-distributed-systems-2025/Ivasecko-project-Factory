namespace Domain.Models
{
    public class Email
    {

        public static readonly int SubjectMaxLength = 200;
        public static readonly int SubjectMinLength = 2;
        public static readonly int MessageMaxLength = 2000;
        
        public int Id { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Subject { get; set; } = null!;
        public string? Message { get; set; }

        #region Navigation Properties
        public Worker Sender { get; set; } = null!;
        public Worker Receiver { get; set; } = null!;
        #endregion
    }
}
