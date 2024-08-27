using Dapper;
using Db.DbModels;
using Db.Models;
using Db.Repositories.IRepositories;
using Microsoft.Data.Sqlite;

namespace Db.Repositories
{
    public class UserRepository(string connectionString) : IUserRepository
    {
        private readonly string _connectionString = connectionString;
        private Dictionary<int, TokenContainer> _tokenContainers = [];

        public Task Register(User newUser)
        {
            var query = @"INSERT INTO 
                                Users (Username, Email, PasswordHash, RegisteredOn)  
                                VALUES (@Username, @Email, @PasswordHash, @RegisteredOn);";

            var userInfo = new
            {
                newUser.Username,
                newUser.Email,
                newUser.PasswordHash,
                RegisteredOn = DateTime.Now,
            };

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = connection.Execute(query, userInfo);

                if (rowsAffected != 1)
                {
                    throw new Exception("Error during inserting new user in database");
                }
            }

            return Task.CompletedTask;
        }

        public async Task<string?> Login(UserLoginInfo userLoginInfo)
        {
            var query = @"SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash LIMIT 1";

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var user = await connection.QueryFirstOrDefaultAsync<User>(query, userLoginInfo);

                if (user is not null)
                {
                    if (!_tokenContainers.ContainsKey(user.Id))
                    {
                        _tokenContainers.Add(user.Id, new TokenContainer
                        {
                            Token = Guid.NewGuid().ToString(),
                        });
                    }

                    _tokenContainers[user.Id].ExpirationDateTime = DateTime.Now + TimeSpan.FromMinutes(5);

                    return _tokenContainers[user.Id].Token;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var query = @"SELECT * FROM Users WHERE Username = @Username LIMIT 1";

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });
            }
        }

        public Task<bool> IsTokenValid(string token)
        {
            var tokenContainer = _tokenContainers.FirstOrDefault(x => x.Value.Token == token);

            if (tokenContainer.Value is null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(tokenContainer.Value.ExpirationDateTime > DateTime.Now);
        }

        public Task<int?> GetUserIdByToken(string token)
        {
            var tokenContainer = _tokenContainers.FirstOrDefault(x => x.Value.Token == token);

            if (tokenContainer.Value is null)
            {
                return Task.FromResult<int?>(null);
            }

            return Task.FromResult<int?>(tokenContainer.Key);
        }
    }
}