using Core.Enums;
using Core.Models;
namespace Core.Core
{
    public interface ICore
    {
        public RegistrationStatus Register(UserRegistrationInfo info);
        public LoginResult Login(UserLoginInfo info);
        public UserInfo GetUserAccountInfo(string token);
    }
}