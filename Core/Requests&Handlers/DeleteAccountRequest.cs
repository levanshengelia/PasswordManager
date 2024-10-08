﻿using Core.Enums;
using Core.Responses;
using Db.Repositories.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Requests_Handlers
{
    public record DeleteAccountRequest : IRequest<DeleteAccountResponse>
    {
        public string Token { get; init; } = null!;
        public string WebsiteName { get; init; } = null!;
        public string Username { get; init; } = null!;
    }

    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<DeleteAccountRequestHandler> _logger; 

        public DeleteAccountRequestHandler(IUserRepository userRepository, 
            IAccountRepository accountRepository, ILogger<DeleteAccountRequestHandler> logger)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _userRepository.IsTokenValid(request.Token))
                {
                    return new DeleteAccountResponse
                    {
                        Status = ResponseStatus.InvalidToken,
                        ErrorMessage = "Your session expired, login and try again",
                    };
                }

                var userId = await _userRepository.GetUserIdByToken(request.Token);

                await _accountRepository.DeleteAccount(userId!.Value, request.WebsiteName, request.Username);

                return new DeleteAccountResponse
                {
                    Status = ResponseStatus.Success,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = "Error during deleting account";

                _logger.LogError(ex, errorMessage);

                return new DeleteAccountResponse
                {
                    Status = ResponseStatus.Fail,
                    ErrorMessage = errorMessage,
                };
            }
        }
    }

}
