using Core.Enums;

namespace Core.Responses
{
    public record RegisterResponse
    {
        public RegisterStatus Status { get; set; }
    }
}
