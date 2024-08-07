using Core.Enums;

namespace Core.Responses
{
    public record LoginResponse
    {
        public LoginStatus Status { get; set; }
        public string Token { get; set; } = null!;
    }
}
