using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserLoginInfo
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
