using Core.Db;
using Core.Enums;
using Core.Responses;
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

        public UserRegistrationInfo ConvertToUserRegistartionInfo()
        {
            return new UserRegistrationInfo
            {
                Email = Email,
                Username = Username,
                Password = Password,
            };
        }
    }

    public class RegistrationRequestHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly ILogger<RegistrationRequestHandler> _logger;
        private readonly IUserRepository _userRepository;

        public RegistrationRequestHandler(ILogger<RegistrationRequestHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userRegistartionInfo = request.ConvertToUserRegistartionInfo();

                await _userRepository.Register(userRegistartionInfo);

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
