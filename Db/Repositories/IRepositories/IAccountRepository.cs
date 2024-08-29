using Db.Models;

namespace Db.Repositories.IRepositories
{
    public interface IAccountRepository
    {
        public Task AddAccount(int userId, string websiteName, string username, string encryptedPassword);
        public Task DeleteAccount(int userId, string websiteName, string username);
        public Task<AccountInfo?> GetAccount(int userId, string websiteName, string username);
        public Task<List<AccountInfo>> GetAllAccountsByUserId(int userId);
        public Task<string> GetEncryptedPassword(int value, string websiteName, string username);
    }
}
