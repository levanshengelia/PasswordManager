using Db.DbModels;
using Db.Models;

namespace Db.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public Task Register(User request);
        public Task<string> Login(UserLoginInfo request);
        public Task<User?> GetUserByUsername(string username);
    }
}