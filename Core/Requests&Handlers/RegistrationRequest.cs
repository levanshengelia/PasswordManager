using Core.Db;
using Core.Enums;
using Core.Responses;
using MediatR;
using Serilog;

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
        private readonly ILogger _logger;
        private readonly IDb _db;

        public RegistrationRequestHandler(ILogger logger, IDb db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _db.RegisterUser(request);

                _logger.Information($"New user named {request.Username} has registered");

                return new RegistrationResponse
                {
                    Status = ResponseStatus.Success,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Internal error during the registration of new user";

                _logger.Error(ex, errorMessage);
                
                return new RegistrationResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }
}
