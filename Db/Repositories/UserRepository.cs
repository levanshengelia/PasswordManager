using Db.Models;
using Db.Repositories.IRepositories;

namespace Db.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<string> Login(UserLoginInfo request)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserRegistrationInfo request)
        {
            throw new NotImplementedException();
        }
}
