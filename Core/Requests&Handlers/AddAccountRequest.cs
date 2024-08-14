using Core.Models;

namespace Core.Requests
{
    public record AddAccountRequest
    {
        public AccountInfo AccountInfo { get; init; } = null!;
    }
}
