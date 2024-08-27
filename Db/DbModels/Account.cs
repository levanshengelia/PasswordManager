namespace Db.DbModels
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string WebsiteName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
    }
}
