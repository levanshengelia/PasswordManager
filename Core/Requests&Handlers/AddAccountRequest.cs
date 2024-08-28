using Core.Enums;
using Core.Responses;
using Core.Services.IServices;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests_Handlers
{
    public class AddAccountRequest : IRequest<AddAccountResponse>
    {
        public string Token { get; set; } = null!;
        public string WebsiteName { get; set; } = null!;
        public string Username { get; set; } = null!; 
        public string Password { get; set; } = null!;
    }

    public class AddAccountRequestHandler : IRequestHandler<AddAccountRequest, AddAccountResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AddAccountRequestHandler> _logger;
        private readonly ICryptographyService _cryptographyService;

        public AddAccountRequestHandler(IUserRepository userRepository, IAccountRepository accountRepository, 
            ILogger<AddAccountRequestHandler> logger, ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _logger = logger;
            _cryptographyService = cryptographyService;
        }

        public async Task<AddAccountResponse> Handle(AddAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _userRepository.IsTokenValid(request.Token))
                {
                    return new AddAccountResponse
                    {
                        Status = ResponseStatus.InvalidToken,
                        ErrorMessage = "Your session expired, login and try again",
                    };
                }

                var userId = await _userRepository.GetUserIdByToken(request.Token);

                var encryptedPassword = _cryptographyService.Encrypt(request.Password);

                var doesAccountAlreadyExist = (await _accountRepository.GetAccount(userId!.Value, request.WebsiteName, request.Username)) is not null;

                if (doesAccountAlreadyExist) 
                {
                    return new AddAccountResponse
                    {
                        Status = ResponseStatus.Fail,
                        ErrorMessage = "This account already exists",
                    };
                }

                await _accountRepository.AddAccount(userId!.Value, request.WebsiteName, request.Username, encryptedPassword);

                return new AddAccountResponse
                {
                    Status = ResponseStatus.Success,
                };
            }
            catch (Exception ex)
            {
                var errorMassage = "Internal error during adding account";
                _logger.LogError(ex, errorMassage);

                return new AddAccountResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMassage,
                };
            }
        }
    }
}
