using Core.Models;

namespace Core.Requests
{
    public record RegisterRequest
    {
        public UserRegistrationInfo UserInfo { get; set; } = null!;
    }
}
