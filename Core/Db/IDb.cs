using Core.Models;

namespace Core.Db
{
    public interface IDb
    {
        public void AddNewUser(UserRegistrationInfo userInfo);
        public bool IsCredentialsValid(UserLoginInfo userInfo);
        public bool ContainsUser(string username);
        public void SaveToken(string userName, string newToken);
    }
}
