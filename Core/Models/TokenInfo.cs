namespace Core.Models
{
    public record TokenInfo
    {
        public string Token { get; init; } = null!;
        
        public DateTime ExpirationDate { get; init; }
    }
}
