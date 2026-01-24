namespace Domain.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string EmailAddress { get; set; }

        #region Navigation Properties
        public Position? Position { get; set; } // nova klasa Position za pozicije radnika
        #endregion

        #region Reverse Navigation Properties
        public ICollection<Email> SentEmails { get; set; }
        public ICollection<Email> ReceivedEmails { get; set; }
        #endregion
    }
}
