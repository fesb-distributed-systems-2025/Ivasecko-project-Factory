namespace Domain.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Age { get; set; }
        public string EmailAddress { get; set; }

        public string? Position { get; set; }
        public DateTime? BirthDate { get; set; }

        #region Reverse Navigation Properties
        public ICollection<Email> SentEmails { get; set; }
        public ICollection<Email> ReceivedEmails { get; set; }
        #endregion
    }
}