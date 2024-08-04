namespace Core.Enums
{
    public class LoginResult
    {
        public string Token { get; internal set; } = null!;
        public LoginStatus Status { get; internal set; }
    }

    public enum LoginStatus
    {
        Success = 1,
        InvalidCredentials = 2,
        Unknown = 3,
    }
}
