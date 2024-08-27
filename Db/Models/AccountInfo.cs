using Db.DbModels;

namespace Db.Models
{
    public record AccountInfo
    {
        public string WebsiteName { get; init; } = null!;
        public string Username { get; init; } = null!;

        public AccountInfo(Account account)
        {
            WebsiteName = account.WebsiteName;
            Username = account.Username;
        }

        public AccountInfo()
        {
        }
    }
}
