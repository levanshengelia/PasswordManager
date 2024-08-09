using Core.Enums;
using Core.Models;

namespace Core.Responses
{
    public record GetUserAccountInfoResponse
    {
        public GetUserAccountInfoStatus Status { get; set; }
        public UserPasswordSystemInfo UserInfo { get; set; } = null!;
    }
}
