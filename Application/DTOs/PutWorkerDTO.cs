using Domain.Models;

namespace Application.DTOs
{
    public class PutWorkerDTO
    {
        public int Id { get; set; }                 // Id workera koji update-amo
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }  
        public DateTime? BirthDate { get; set; }
        public int? PositionId { get; set; }

        // Pretvorba DTO-a u Worker model
        public Worker ToModel()
        {
            return new Worker
			{
				Id = this.Id,
				Name = this.Name,
				Surname = this.Surname,
				Age = this.Age,
				EmailAddress = this.EmailAddress,
				BirthDate = this.BirthDate,
			};
        }
    }
}
