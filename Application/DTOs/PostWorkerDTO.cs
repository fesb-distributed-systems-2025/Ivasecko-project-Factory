using Domain.Models;

namespace Application.DTOs
{
    public class PostWorkerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PositionId { get; set; }

        public Worker ToModel()
        {
            return new Worker
            {
                Name = Name,
                Surname = Surname,
                Age = Age,
                EmailAddress = EmailAddress,
                BirthDate = BirthDate,
            };
        }
    }

}
