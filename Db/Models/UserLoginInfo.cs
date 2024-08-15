using System.ComponentModel.DataAnnotations;

namespace Db.Models;

public class UserLoginInfo
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
