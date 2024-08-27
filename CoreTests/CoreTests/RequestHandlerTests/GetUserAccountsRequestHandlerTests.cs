using Core.Enums;
using Core.Requests;
using Core.Requests_Handlers;
using Db.Models;
using Db.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.CoreTests.RequestHandlerTests
{
    public class GetUserAccountsRequestHandlerTests
    {
        [Fact]
        public async Task Valid_Request_Should_Return_Account_List()
        {
            var loggerMock = new Mock<ILogger<GetUserAccountsRequestHandler>>();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.IsTokenValid(It.IsAny<string>())).Returns(Task.FromResult(true));
            userRepositoryMock.Setup(x => x.GetUserIdByToken(It.IsAny<string>())).Returns(Task.FromResult<int?>(1));
            
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(x => x.GetAllAccountsByUserId(It.IsAny<int>()))
                .Returns(Task.FromResult<List<AccountInfo>>([new AccountInfo { WebsiteName = "facebook", Username = "FbUser"}]));

            var handler = new GetUserAccountsRequestHandler(loggerMock.Object, userRepositoryMock.Object, accountRepositoryMock.Object);

            var request = new GetUserAccountsRequest
            {
                Token = "token",
            };

            var result = await handler.Handle(request, new CancellationTokenSource().Token);

            Assert.Equal(ResponseStatus.Success, result.Status);
            var account = Assert.Single(result.Accounts);
            Assert.Equal("facebook", account.WebsiteName);
            Assert.Equal("FbUser", account.Username);
        }
    }
}
