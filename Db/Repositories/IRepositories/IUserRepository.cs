using Db.Models;

namespace Db.Repositories.IRepositories
{
    public interface IUserRepository
    {
        public Task Register(UserRegistrationInfo request);
        public Task<string> Login(UserLoginInfo request);
    }
}
