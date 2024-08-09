namespace Core.Core.Helpers
{
    public interface ITokenService
    {
        public string RegenerateToken();
        public bool IsTokenValid();
    }
}
