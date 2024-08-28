using Core.Responses;
using MediatR;

namespace Core.Requests_Handlers
{
    public class DeleteAccountRequest : IRequest<DeleteAccountResponse>
    {
    }

    public class DeleteAccountRequestHandler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
    {
        public DeleteAccountRequestHandler()
        {
        }

        public Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
