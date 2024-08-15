using Core.Enums;
using Core.Responses.Contracts;

namespace Core.Responses
{
    public class LoginResponse : IResponseResult
    {
        public ResponseStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public string Token { get; set; } = null!;
    }
}
