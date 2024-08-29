using Core.Enums;
using Core.Responses.Contracts;

namespace Core.Responses
{
    public class GetPasswordResponse : IResponseResult
    {
        public ResponseStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public string Password { get; set; } = null!;
    }
}
