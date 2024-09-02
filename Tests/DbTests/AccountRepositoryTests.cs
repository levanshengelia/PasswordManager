using Dapper;
using Db.Repositories;
using Microsoft.Data.Sqlite;

namespace Tests.DbTests
{
    public class AccountRepositoryTests
    {
        private const string _connectionString = "Data Source=dbForAccountRepo;Mode=Memory;Cache=Shared";
        private const string _tableCreationQuery = @"
                    CREATE TABLE Accounts (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        WebsiteName TEXT NOT NULL,
                        Username TEXT NOT NULL,
                        EncryptedPassword TEXT NOT NULL,
                        CreatedOn TEXT NOT NULL
                    );";

        [Fact]
        public async Task GetAllAccountsByUserId_Should_Throw_Exception_If_UserId_Does_Not_Exist()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var accountRepository = new AccountRepository(_connectionString);

            Assert.Empty(await accountRepository.GetAllAccountsByUserId(1));
        }
        
        [Fact]
        public async Task GetAllAccountsByUserId_Should_Return_Accounts_With_Valid_UserId()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var insertQuery = @"INSERT INTO
                                Accounts (UserId, WebsiteName, Username, EncryptedPassword, CreatedOn)  
                                VALUES (@UserId, @WebsiteName, @Username, @EncryptedPassword, @CreatedOn);";

            connection.Execute(insertQuery,
                new { UserId = 1, WebsiteName = "facebook", Username = "levani32", EncryptedPassword = "bla", CreatedOn = DateTime.Now });
            connection.Execute(insertQuery,
                new { UserId = 1, WebsiteName = "youtube", Username = "levani123", EncryptedPassword = "blu", CreatedOn = DateTime.Now });

            var accountRepository = new AccountRepository(_connectionString);

            var response = await accountRepository.GetAllAccountsByUserId(1);

            Assert.Equal(2, response.Count);
        }
    }
}
