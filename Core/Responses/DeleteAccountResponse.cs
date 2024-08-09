using Core.Enums;

namespace Core.Responses
{
    public record DeleteAccountResponse
    {
        public DeleteAccountStatus Status { get; set; }
    }
}
