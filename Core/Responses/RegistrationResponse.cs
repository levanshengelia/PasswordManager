using Core.Enums;
using Core.Responses.Contracts;

namespace Core.Responses
{
    public record RegistrationResponse : IResponseResult
    {
        public ResponseStatus Status { get; set;}
        public string? ErrorMessage { get; set; }
    }
}
