using Core.Enums;
using Core.Requests;
using Core.Responses;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests_Handlers
{
    public record GetUserAccountsRequest : IRequest<GetUserAccountsResponse>
    {
        public string Token { get; init; } = null!;
    }

    public class GetUserAccountsRequestHandler : IRequestHandler<GetUserAccountsRequest, GetUserAccountsResponse>
    {
        private readonly ILogger<GetUserAccountsRequestHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public GetUserAccountsRequestHandler(ILogger<GetUserAccountsRequestHandler> logger, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetUserAccountsResponse> Handle(GetUserAccountsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _userRepository.IsTokenValid(request.Token))
                {
                    return new GetUserAccountsResponse
                    {
                        Status = ResponseStatus.InvalidToken,
                        ErrorMessage = "Your session expired, login and try again",
                    };
                }

                var userId = (await _userRepository.GetUserIdByToken(request.Token))!.Value;

                var accounts = await _accountRepository.GetAllAccountsByUserId(userId);

                return new GetUserAccountsResponse
                {
                    Status = ResponseStatus.Success,
                    Accounts = accounts,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Internal error during getting accounts of the user";

                _logger.LogError(ex, errorMessage);

                return new GetUserAccountsResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }
}

