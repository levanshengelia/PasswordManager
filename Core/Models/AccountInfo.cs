namespace Core.Models
{
    public record AccountInfo
    {
        public string Name { get; init; } = null!;
        
        public string Username { get; init; } = null!;
        
        public string EncryptedPassword { get; init; } = null!;
    }
}
