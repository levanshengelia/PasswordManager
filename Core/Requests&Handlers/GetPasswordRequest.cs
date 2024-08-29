using Core.Enums;
using Core.Responses;
using Core.Services.IServices;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests_Handlers
{
    public record GetPasswordRequest : IRequest<GetPasswordResponse>
    {
        public string Token { get; init; } = null!;
        public string WebsiteName { get; init; } = null!;
        public string Username { get; init; } = null!;
    }

    public class GetPasswordRequestHandler : IRequestHandler<GetPasswordRequest, GetPasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<DeleteAccountRequestHandler> _logger;
        private readonly ICryptographyService _cryptographyService;

        public GetPasswordRequestHandler(IUserRepository userRepository,
            IAccountRepository accountRepository, ILogger<DeleteAccountRequestHandler> logger,
            ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _logger = logger;
            _cryptographyService = cryptographyService;
        }

        public async Task<GetPasswordResponse> Handle(GetPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _userRepository.IsTokenValid(request.Token))
                {
                    return new GetPasswordResponse
                    {
                        Status = ResponseStatus.InvalidToken,
                        ErrorMessage = "Your session expired, login and try again",
                    };
                }

                var userId = await _userRepository.GetUserIdByToken(request.Token);

                var encryptedPassword = await _accountRepository.GetEncryptedPassword(userId!.Value, request.WebsiteName, request.Username);

                var password = _cryptographyService.Decrypt(encryptedPassword);

                return new GetPasswordResponse
                {
                    Status = ResponseStatus.Success,
                    Password = password,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error during getting account password";

                _logger.LogError(ex, errorMessage);

                return new GetPasswordResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }
}
