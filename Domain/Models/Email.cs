namespace Domain.Models
{
    public class Email
    {
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
