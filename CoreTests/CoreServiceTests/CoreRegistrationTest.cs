using Core.Core;
using Core.Db;
using Core.Enums;
using Core.Models;
using Core.Requests;
using Moq;
using System.Runtime.CompilerServices;

namespace Tests.CoreServiceTests
{
    public class CoreRegistrationTest
    {
        [Fact]
        public void Register_ValidRequest_RegisteredSuccessfully()
        {
            var userDb = new List<string>();
            var dbMock = new Mock<IDb>();

            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationInfo>()))
                .Callback<UserRegistrationInfo>(userInfo => userDb.Add(userInfo.Username));

            var core = new CoreService(dbMock.Object);

            var registerResponse = core.Register(new RegisterRequest
            {
                UserInfo = new UserRegistrationInfo
                {
                    Username = "levani",
                    Email = "lshen20@freeuni.edu.ge",
                    Password = "Levani123$%",
                    ConfirmedPassword = "Levani123$%",
                }
            });

            Assert.Equal(RegisterStatus.Success, registerResponse.Status);

            Assert.Equal("levani", userDb.First());
        }

        [Fact]
        public void Register_PasswordsDontMatch_RegisteredUnsuccessfully()
        {
            var userInfo = new UserRegistrationInfo
            {
                Username = "levani",
                Email = "lshen20@freeuni.edu.ge",
                Password = "kukaracha",
                ConfirmedPassword = "Levani123$%",
            };

            InvalidTestHelper(RegisterStatus.PasswordsDontMatch, userInfo);
        }

        [Theory]
        [InlineData("")]
        [InlineData("lshen20freeuni.edu.ge")]
        [InlineData("@lshen20freeuni.edu.ge")]
        [InlineData("lshen20freeuni.edu.ge@")]
        public void Register_InvalidEmail_RegisteredUnsuccessfully(string invalidEmail)
        {
            var userInfo = new UserRegistrationInfo
            {
                Username = "levani",
                Email = invalidEmail,
                Password = "Levani123$%",
                ConfirmedPassword = "Levani123$%",
            };

            InvalidTestHelper(RegisterStatus.InvalidEmail, userInfo);
        }

        [Theory]
        [InlineData("")]
        [InlineData("L1%e")]
        [InlineData("levanilevani")]
        [InlineData("LevaniLevani")]
        public void Register_WeakPassword_RegisteredUnsuccessfully(string weakPassword)
        {
            var userInfo = new UserRegistrationInfo
            {
                Username = "levani",
                Email = "lshen20@freeuni.edu.ge",
                Password = weakPassword,
                ConfirmedPassword = weakPassword,
            };

            InvalidTestHelper(RegisterStatus.WeakPassword, userInfo);
        }

        [Fact]
        public void Register_UsernameAlreadyTaken_RegisteredUnsuccessfully()
        {
            var userDb = new List<string>();
            var dbMock = new Mock<IDb>();

            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationInfo>()))
                .Callback<UserRegistrationInfo>(userInfo => userDb.Add(userInfo.Username));

            dbMock.Setup(x => x.ContainsUser(It.IsAny<string>())).Returns<string>(userDb.Contains);

            var core = new CoreService(dbMock.Object);

            _ = core.Register(new RegisterRequest
            {
                UserInfo = new UserRegistrationInfo
                {
                    Username = "levani",
                    Email = "lshen20@freeuni.edu.ge",
                    Password = "Levani123$%",
                    ConfirmedPassword = "Levani123$%",
                }
            });

            var registerResponse = core.Register(new RegisterRequest
            {
                UserInfo = new UserRegistrationInfo
                {
                    Username = "levani",
                    Email = "lshen20@freeuni.edu.ge",
                    Password = "Levani123$%",
                    ConfirmedPassword = "Levani123$%",
                }
            });

            Assert.Equal(RegisterStatus.UsernameAlreadyTaken, registerResponse.Status);
        }

        private static void InvalidTestHelper(RegisterStatus expectedStatus, UserRegistrationInfo userInfo)
        {
            var userDb = new List<string>();
            var dbMock = new Mock<IDb>();

            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationInfo>()))
                .Callback<UserRegistrationInfo>(userInfo => userDb.Add(userInfo.Username));

            var core = new CoreService(dbMock.Object);

            var registerResponse = core.Register(new RegisterRequest
            {
                UserInfo = userInfo
            });

            Assert.Equal(expectedStatus, registerResponse.Status);
            Assert.True(userDb.Count is 0);
        }
    }
}