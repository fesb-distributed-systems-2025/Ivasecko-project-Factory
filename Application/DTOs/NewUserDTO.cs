using Domain.Models;

namespace Application.DTOs
{
    public class NewUserDTO
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public User ToModel()
        {
            return new User
            {
                Email = Email,
                Name = Name,
                Password = Password,
                RoleId = RoleId,
            };
        }
    }

    public class UserDTO : NewUserDTO
    {
        public int Id { get; set; }

        public static UserDTO FromModel(User model)
        {
            return new UserDTO
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                RoleId = model.RoleId,
            };
        }
    }
}