namespace Core.Models
{
    public class UserRegistrationInfo
    {
        public string Email { get; set; } = null!;
        
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmedPassword { get; set; } = null!;
    }
}
