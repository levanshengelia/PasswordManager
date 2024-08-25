namespace Db.Models
{
    internal record TokenContainer
    {
        internal string Token { get; init; } = null!;
        internal DateTime ExpirationDateTime { get; set; }
    }
}
