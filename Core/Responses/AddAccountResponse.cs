using Core.Enums;
using Core.Responses.Contracts;

namespace Core.Responses
{
    public class AddAccountResponse : IResponseResult
    {
        public ResponseStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
