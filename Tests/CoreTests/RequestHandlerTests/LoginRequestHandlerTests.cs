using Core.Enums;
using Core.Requests;
using Core.Services.IServices;
using Db.DbModels;
using Db.Models;
using Db.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.CoreTests.RequestHandlerTests
{
    public class LoginRequestHandlerTests
    {
        [Fact]
        public async Task Valid_Request_Should_Return_Token()
        {
            var cryptographyServiceMock = new Mock<ICryptographyService>();
            cryptographyServiceMock.Setup(x => x.HashWithSHA256(It.IsAny<string>())).Returns("EncryptedPassword");

            var loggerMock = new Mock<ILogger<LoginRequestHandler>>();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Login(It.IsAny<UserLoginInfo>())).Returns(Task.FromResult<string?>("Token"));

            var handler = new LoginRequestHandler(loggerMock.Object, userRepositoryMock.Object, cryptographyServiceMock.Object);

            var request = new LoginRequest
            {
                Username = "test",
                Password = "test"
            };

            var result = await handler.Handle(request, new CancellationTokenSource().Token);

            Assert.Equal(ResponseStatus.Success, result.Status);
            Assert.Equal("Token", result.Token);
        }
        
        [Fact]
        public async Task Invalid_Request_Should_Return_Null_Token()
        {
            var cryptographyServiceMock = new Mock<ICryptographyService>();
            cryptographyServiceMock.Setup(x => x.HashWithSHA256(It.IsAny<string>())).Returns("EncryptedPassword");

            var loggerMock = new Mock<ILogger<LoginRequestHandler>>();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Login(It.IsAny<UserLoginInfo>())).Returns(Task.FromResult<string?>(null));

            var handler = new LoginRequestHandler(loggerMock.Object, userRepositoryMock.Object, cryptographyServiceMock.Object);

            var request = new LoginRequest
            {
                Username = "test",
                Password = "test"
            };

            var result = await handler.Handle(request, new CancellationTokenSource().Token);

            Assert.Equal(ResponseStatus.Fail, result.Status);
            Assert.Null(result.Token);
        }
    }
}
