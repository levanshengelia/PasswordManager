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

        public Task Register(User newUser)
        {
            var query = @"INSERT INTO 
                                Users (Username, Email, EncryptedPassword)  
                                VALUES (@Username, @Email, @EncryptedPassword);";

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                int rowsAffected = connection.Execute(query, newUser);

                if (rowsAffected != 1)
                {
                    throw new Exception("Error during inserting new user in database");
                }
            }

            return Task.CompletedTask;
        }

        public Task<string> Login(UserLoginInfo request)
        {
            throw new NotImplementedException();
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
    }
}
