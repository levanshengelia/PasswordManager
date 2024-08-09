using Core.Models;

namespace Core.Db
{
    public interface IDb
    {
        public void AddNewUser(UserRegistrationInfo userInfo);
        public bool IsCredentialsValid(UserLoginInfo userInfo);
        public bool ContainsUser(string username);
        public UserPasswordSystemInfo GetUserInfo(string username);
        public bool ContainsAccount(string username, string accountName);
        public bool AddAccount(AccountInfo accountInfo);
        public bool DeleteAccount(string username, string accountName);
    }
}
