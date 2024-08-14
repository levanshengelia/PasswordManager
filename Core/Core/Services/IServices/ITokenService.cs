namespace Core.Core.Services.IServices
{
    public interface ITokenService
    {
        public string RegenerateToken();
        public bool IsTokenValid();
    }
}
