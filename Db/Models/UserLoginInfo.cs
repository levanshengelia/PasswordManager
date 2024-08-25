namespace Db.Models;

public class UserLoginInfo
{
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
