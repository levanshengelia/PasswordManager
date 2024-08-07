using Core.Core;
using Core.Db;
using Core.Enums;
using Core.Models;
using Core.Requests;
using Moq;

namespace Tests.CoreServiceTests
{
    public class LoginTests
    {
        [Fact]
        public void Login_ValidRequest_LogedInSuccessfully()
        {
            var userDb = new List<string>();
            var dbMock = new Mock<IDb>();

            dbMock.Setup(x => x.IsCredentialsValid(It.IsAny<UserLoginInfo>())).Returns(true);

            var core = new CoreService(dbMock.Object);

            var loginResponse = core.Login(new LoginRequest
            {
                UserInfo = new UserLoginInfo
                {
                    UserName = "levani",
                    Password = "Levani123$%",
                }
            });

            Assert.Equal(LoginStatus.Success, loginResponse.Status);
            Assert.NotNull(loginResponse.Token);
        }

        [Fact]
        public void Login_InValidRequest_LogedInUnsuccessfully()
        {
            var userDb = new List<string>();
            var dbMock = new Mock<IDb>();

            dbMock.Setup(x => x.IsCredentialsValid(It.IsAny<UserLoginInfo>())).Returns(false);

            var core = new CoreService(dbMock.Object);

            var loginResponse = core.Login(new LoginRequest
            {
                UserInfo = new UserLoginInfo
                {
                    UserName = "levani",
                    Password = "Levani123$%",
                }
            });

            Assert.Equal(LoginStatus.InvalidCredentials, loginResponse.Status);
            Assert.Null(loginResponse.Token);
        }
    }
}
