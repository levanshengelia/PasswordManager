using Core.Enums;
using Core.Requests;
using Core.Services.IServices;
using Db.DbModels;
using Db.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.CoreTests.RequestHandlerTests
{
    public class RegistrationRequestHandlerTests
    {
        [Fact]
        public async Task Valid_Request_Should_Add_User_In_Db()
        {
            var cryptographyServiceMock = new Mock<ICryptographyService>();
            cryptographyServiceMock.Setup(x => x.HashWithSHA256(It.IsAny<string>())).Returns("EncryptedPassword");
            
            var loggerMock = new Mock<ILogger<RegistrationRequestHandler>>();

            var dbList = new List<User>();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Register(It.IsAny<User>())).Callback(dbList.Add);
            userRepositoryMock.Setup(x => x.GetUserByUsername(It.IsAny<string>()))
                .Returns<string>(x => Task.FromResult(dbList.FirstOrDefault(xx => xx.Username == x)));

            var handler = new RegistrationRequestHandler(loggerMock.Object, userRepositoryMock.Object, cryptographyServiceMock.Object);

            var request = new RegistrationRequest
            {
                Email = "levani@gmail.com",
                Username = "Levani",
                Password = "Levani123!@#",
                ConfirmedPassword = "Levani123!@#"
            };

            var result = await handler.Handle(request, new CancellationTokenSource().Token);

            Assert.Equal(ResponseStatus.Success, result.Status);
            var newUser = Assert.Single(dbList);
            Assert.Equal("EncryptedPassword", newUser.EncryptedPassword);
        }

        [Fact]
        public async Task Request_Should_Fail_When_User_Already_Exists()
        {
            var cryptographyServiceMock = new Mock<ICryptographyService>();
            cryptographyServiceMock.Setup(x => x.HashWithSHA256(It.IsAny<string>())).Returns("EncryptedPassword");
            
            var loggerMock = new Mock<ILogger<RegistrationRequestHandler>>();

            var dbList = new List<User>();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Register(It.IsAny<User>())).Callback(dbList.Add);
            userRepositoryMock.Setup(x => x.GetUserByUsername(It.IsAny<string>()))
                .Returns<string>(x => Task.FromResult(dbList.FirstOrDefault(xx => xx.Username == x)));

            var handler = new RegistrationRequestHandler(loggerMock.Object, userRepositoryMock.Object, cryptographyServiceMock.Object);

            var request = new RegistrationRequest
            {
                Email = "levani@gmail.com",
                Username = "Levani",
                Password = "Levani123!@#",
                ConfirmedPassword = "Levani123!@#"
            };

            _ = await handler.Handle(request, new CancellationTokenSource().Token);
            var result = await handler.Handle(request, new CancellationTokenSource().Token);

            Assert.Equal(ResponseStatus.Fail, result.Status);
            Assert.Single(dbList);
        }
    }
}