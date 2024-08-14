using Core.Models;
using Core.Requests;

namespace Core.Db
{
    public interface IDb
    {
       // public void AddNewUser(UserRegistrationModel userInfo);
        public bool IsCredentialsValid(UserLoginInfo userInfo);
        public bool ContainsUser(string username);
        public UserPasswordSystemInfo GetUserInfo(string username);
        public bool ContainsAccount(string username, string accountName);
        public bool AddAccount(string username, AccountInfo accountInfo);
        public bool DeleteAccount(string username, string accountName);
        public string GetEncryptedPassword(string username, string applicationName);
        
        public Task RegisterUser(RegistrationRequest request);
    }
}
