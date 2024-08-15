using Core.Enums;
using Core.Responses;
using Db.Models;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests
{
    public record LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public UserLoginInfo ConvertToUserLoginInfo()
        {
            return new UserLoginInfo
            {
                Username = Username,
                Password = Password,
            };
        }
    }

    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ILogger<LoginRequestHandler> _logger;
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(ILogger<LoginRequestHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userRegistartionInfo = request.ConvertToUserLoginInfo();

                var token = await _userRepository.Login(userRegistartionInfo);

                _logger.LogInformation("{Username} has logged in", request.Username);

                return new LoginResponse
                {
                    Status = ResponseStatus.Success,
                    Token = token,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Internal error during the Login of new user";

                _logger.LogError(ex, errorMessage);

                return new LoginResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }
}
