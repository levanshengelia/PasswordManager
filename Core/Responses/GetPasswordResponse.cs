using Core.Enums;

namespace Core.Responses
{
    public class GetPasswordResponse
    {
        public GetPasswordStatus Status { get;set; }
        public string Password { get; set; } = null!;
    }
}
