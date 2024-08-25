using Core.Enums;
using Core.Responses;
using Core.Services.IServices;
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
    }

    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ILogger<LoginRequestHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptoService;

        public LoginRequestHandler(ILogger<LoginRequestHandler> logger, IUserRepository userRepository, ICryptographyService cryptoService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userLoginInfo = new UserLoginInfo
                {
                    Username = request.Username,
                    PasswordHash = _cryptoService.HashWithSHA256(request.Password)
                };

                var token = await _userRepository.Login(userLoginInfo);

                if (token is null)
                {
                    return new LoginResponse
                    {
                        Status = ResponseStatus.Fail,
                        ErrorMessage = "Invalid credentials",
                    };
                }

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
