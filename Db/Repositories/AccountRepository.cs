using Dapper;
using Db.DbModels;
using Db.Models;
using Db.Repositories.IRepositories;
using Microsoft.Data.Sqlite;

namespace Db.Repositories
{
    public class AccountRepository(string connectionString) : IAccountRepository
    {
        private readonly string _connectionString = connectionString;

        public Task AddAccount(int userId, string websiteName, string username, string encryptedPassword)
        {
            var query = @"INSERT INTO Accounts (UserId, WebsiteName, Username, EncryptedPassword)
                            Values (@userId, @websiteName, @username, @encryptedPassword)";

            using var connection = new SqliteConnection(_connectionString);

            connection.Open();

            connection.Execute(query, new { userId, websiteName, username, encryptedPassword });

            return Task.FromResult(true);
        }

        public Task<AccountInfo?> GetAccount(int userId, string websiteName, string username)
        {
            var query = @"SELECT * FROM Accounts WHERE UserId = @userId AND WebsiteName = @websiteName AND Username = @username LIMIT 1";

            using var connection = new SqliteConnection(_connectionString);

            connection.Open();

            var account = connection.QueryFirstOrDefault<AccountInfo?>(query, new { userId, websiteName, username });

            return Task.FromResult(account);
        }

        public Task<List<AccountInfo>> GetAllAccountsByUserId(int userId)
        {
            var query = @"SELECT * FROM Accounts WHERE UserId = @userId";

            using var connection = new SqliteConnection(_connectionString);

            connection.Open();

            var accounts = connection.Query<Account>(query, new { userId });

            return Task.FromResult(accounts.Select(x => new AccountInfo(x)).ToList());
        }
    }
}