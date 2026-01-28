using Application.Common;
using Application.DTOs;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<object>> LogInUser(UserLoginDto loginData);
    }
}