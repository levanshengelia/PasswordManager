using Core.Enums;

namespace Core.Responses.Contracts
{
    public interface IResponseResult
    {
        public ResponseStatus Status { get; internal set; }
        public string? ErrorMessage { get; internal set; }
    }
}
