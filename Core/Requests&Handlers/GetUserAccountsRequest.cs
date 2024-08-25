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
        private readonly ILogger<LoginRequestHandler> _logger;
        private readonly IUserRepository _userRepository;

        public GetUserAccountsRequestHandler(ILogger<LoginRequestHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public Task<GetUserAccountsResponse> Handle(GetUserAccountsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

