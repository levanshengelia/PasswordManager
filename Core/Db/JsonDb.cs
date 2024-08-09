using Core.Models;

namespace Core.Db
{
    public class JsonDb : IDb
    {
        public bool AddAccount(AccountInfo accountInfo)
        {
            throw new NotImplementedException();
        }

        public void AddNewUser(UserRegistrationInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public bool ContainsAccount(string username, string accountName)
        {
            throw new NotImplementedException();
        }

        public bool ContainsUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(string username, string accountName)
        {
            throw new NotImplementedException();
        }

        public UserPasswordSystemInfo GetUserInfo(string username)
        {
            throw new NotImplementedException();
        }

        public bool IsCredentialsValid(UserLoginInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
