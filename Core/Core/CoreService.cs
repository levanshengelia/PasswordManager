using Core.Enums;
using Core.Models;

namespace Core.Core
{
    public class CoreService : ICore
    {
        public UserInfo GetUserAccountInfo(string token)
        {
            return new UserInfo
            {
                Username = "levani",
                Passwords = [],
            };
        }

        public LoginResult Login(UserLoginInfo info)
        {
            return new LoginResult
            {
                Status = LoginStatus.Success,
                Token = "bliad"
            };
        }

        public RegistrationStatus Register(UserRegistrationInfo info)
        {
            return RegistrationStatus.Success;
        }
    }
}
