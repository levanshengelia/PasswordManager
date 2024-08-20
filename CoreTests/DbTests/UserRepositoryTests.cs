using Dapper;
using Db.DbModels;
using Db.Repositories;
using Microsoft.Data.Sqlite;

namespace Tests.DbTests
{
    public class UserRepositoryTests
    {
        private const string _connectionString = "Data Source=:memory:;Mode=Memory;Cache=Shared";
        private const string _tableCreationQuery = @"
                    CREATE TABLE Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        EncryptedPassword TEXT NOT NULL
                    );";

        [Fact]
        public async Task GetUserByUsername_Should_Return_Null_When_User_Does_Not_Exist()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);
            var user = await userRepository.GetUserByUsername("some-non-existent-username");
            Assert.Null(user);
        }

        [Fact]
        public async Task GetUserByUsername_Should_Return_Correct_User_When_User_Exists()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            var testUsername = "levani";

            connection.Execute("INSERT INTO Users (Username, Email, EncryptedPassword) VALUES (@Username, @Email, @EncryptedPassword);", 
                new {Username = testUsername, Email = "levani@gmail.com", EncryptedPassword = "bla"});

            var user = await userRepository.GetUserByUsername(testUsername);
            
            Assert.NotNull(user);
            Assert.Equal(testUsername, user.Username);
        }

        [Fact]
        public void Register_Should_Add_New_User_In_Db()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            for(var i = 0; i < 10; i++)
            {
                userRepository.Register(new User
                {
                    Username = $"test {i}",
                    Email = "test@gmail.com",
                    EncryptedPassword = "bla",
                });
            }

            var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users");

            Assert.Equal(10, count);
        }
    }
}
