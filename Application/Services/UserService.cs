using Application.Authorization;
using Application.Common;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenProvider _tokenProvider;

        public readonly string emailRegex = @"^[\w.-]+@([\w-]+\.)+[\w-]{2,5}$";

        public UserService(IUserRepository userRepository, TokenProvider tokenProvider)
        {
            _userRepository = userRepository;
            _tokenProvider = tokenProvider;
        }

        public async Task<Result<object>> LogInUser(UserLoginDto loginData)
        {
            var validationResult = LoginValidation(loginData);

            if (!validationResult.IsSuccess)
                return Result<object>.Failure(validationResult.ValidationItems);

            var user = await _userRepository.GetUserByEmail(loginData.Email);

            if (user == null || user.Password != loginData.Password)
            {
                validationResult.ValidationItems.Add("Incorrect email or password");
                return Result<object>.Failure(validationResult.ValidationItems);
            }

            var token = _tokenProvider.Create(user);
            return Result<object>.Success(token);
        }

        private ValidationResult LoginValidation(UserLoginDto loginData)
        {
            var result = new ValidationResult();

            if (!Regex.IsMatch(loginData.Email, emailRegex))
                result.ValidationItems.Add("Invalid email format!");

            if (string.IsNullOrWhiteSpace(loginData.Email))
                result.ValidationItems.Add("Email can't be empty!");

            if (string.IsNullOrWhiteSpace(loginData.Password))
                result.ValidationItems.Add("Password can't be empty!");

            return result;
        }
    }
}