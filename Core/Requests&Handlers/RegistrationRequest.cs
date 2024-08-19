using Core.Enums;
using Core.Responses;
using Core.Services.IServices;
using Db.DbModels;
using Db.Models;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests
{
    public record RegistrationRequest : IRequest<RegistrationResponse>
    {
        public string Email { get; set; } = null!;
        
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmedPassword { get; set; } = null!;
    }

    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly ILogger<RegistrationRequestHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptoService;

        public RegistrationRequestHandler(ILogger<RegistrationRequestHandler> logger, IUserRepository userRepository, ICryptographyService cryptoService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _userRepository.GetUserByUsername(request.Username) is not null)
                {
                    return new RegistrationResponse
                    {
                        Status = ResponseStatus.Fail,
                        ErrorMessage = "User already exists",
                    };
                }

                var encryptedPassword = _cryptoService.HashWithSHA256(request.Password);

                var newUser = new User
                {
                    Email = request.Email,
                    Username = request.Username,
                    EncryptedPassword = encryptedPassword,
                };

                await _userRepository.Register(newUser);

                _logger.LogInformation("New user named {Username} has registered", request.Username);

                return new RegistrationResponse
                {
                    Status = ResponseStatus.Success,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Internal error during the registration of new user";

                _logger.LogError(ex, errorMessage);
                
                return new RegistrationResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }
}
