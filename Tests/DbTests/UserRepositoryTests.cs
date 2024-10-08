﻿using Dapper;
using Db.DbModels;
using Db.Models;
using Db.Repositories;
using Microsoft.Data.Sqlite;

namespace Tests.DbTests
{
    public class UserRepositoryTests
    {
        private const string _connectionString = "Data Source=dbForUserRepo;Mode=Memory;Cache=Shared";
        private const string _tableCreationQuery = @"
                    CREATE TABLE Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        PasswordHash TEXT NOT NULL,
                        RegisteredOn TEXT NOT NULL
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

            connection.Execute("INSERT INTO Users (Username, Email, PasswordHash, RegisteredOn) " +
                "VALUES (@Username, @Email, @PasswordHash, @RegisteredOn);",
                new { Username = testUsername, Email = "levani@gmail.com", PasswordHash = "bla", RegisteredOn = DateTime.Now });

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

            for (var i = 0; i < 10; i++)
            {
                userRepository.Register(new User
                {
                    Username = $"test {i}",
                    Email = "test@gmail.com",
                    PasswordHash = "bla",
                });
            }

            var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users");

            Assert.Equal(10, count);
        }

        [Fact]
        public async Task Login_With_Invalid_Credentials_Should_Return_Null_Token()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            var userLoginInfo = new UserLoginInfo
            {
                Username = "test",
                PasswordHash = "test"
            };

            var token = await userRepository.Login(userLoginInfo);

            Assert.Null(token);
        }

        [Fact]
        public async Task Login_With_Valid_Credentials_Should_Return_Token()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            _ = userRepository.Register(new User
            {
                Username = "test",
                Email = "test@gmail.com",
                PasswordHash = "test",
            });

            var userLoginInfo = new UserLoginInfo
            {
                Username = "test",
                PasswordHash = "test"
            };

            var token = await userRepository.Login(userLoginInfo);

            Assert.NotNull(token);
        }
        
        [Fact]
        public async Task With_Valid_Token_IsValidToken_Should_Return_True()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            _ = userRepository.Register(new User
            {
                Username = "test",
                Email = "test@gmail.com",
                PasswordHash = "test",
            });

            var userLoginInfo = new UserLoginInfo
            {
                Username = "test",
                PasswordHash = "test"
            };

            var token = await userRepository.Login(userLoginInfo);

            Assert.True(await userRepository.IsTokenValid(token!));
        } 
        
        [Fact]
        public async Task With_Non_Existent_Token_IsValidToken_Should_Return_False()
        {
            using var connection = new SqliteConnection(_connectionString);

            connection.Open();
            connection.Execute(_tableCreationQuery);

            var userRepository = new UserRepository(_connectionString);

            Assert.False(await userRepository.IsTokenValid("token"));
        }
    }
}
