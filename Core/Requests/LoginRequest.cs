using Core.Models;

namespace Core.Requests
{
    public record LoginRequest
    {
        public UserLoginInfo UserInfo { get; set; } = null!;
    }
}
