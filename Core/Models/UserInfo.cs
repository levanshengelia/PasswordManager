namespace Core.Models
{
    public class UserInfo
    {
        public string Username { get; set; } = null!;

        public TokenInfo Token { get; set; } = null!;
        
        public List<AccountInfo> AccountInfos { get; set; } = null!;
    }
}
