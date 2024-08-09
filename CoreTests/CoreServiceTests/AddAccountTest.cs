using Core.Core;
using Core.Core.Helpers;
using Core.Db;
using Core.Enums;
using Core.Models;
using Core.Requests;
using Moq;

namespace Tests.CoreServiceTests
{
    public class AddAccountTest
    {
        [Fact]
        public void AddAccount_ValidRequest_AddsSuccessfully()
        {
            var db = new Mock<IDb>();
            var tokenService = new Mock<ITokenService>();
            tokenService.Setup(x => x.IsTokenValid()).Returns(true);
            var fakeDb = new List<AccountInfo>();
            db.Setup(x => x.AddAccount(It.IsAny<AccountInfo>())).Callback(fakeDb.Add).Returns(true);

            var core = new CoreService(db.Object, tokenService.Object);

            var accountInfo = new AccountInfo()
            {
                Name = "facebook",
                Username = "levani",
                EncryptedPassword = "fakePassword"
            };

            var addAccountResponse = core.AddAccount(new AddAccountRequest 
            { 
                AccountInfo = accountInfo
            });

            Assert.Equal(AddAccountStatus.Success, addAccountResponse.Status);

            var storedAccountInfo = Assert.Single(fakeDb);

            Assert.Equal(accountInfo, storedAccountInfo);
        }

        [Fact]
        public void AddAccount_InValidToken_ReturnsInvalidTokenStatus()
        {
            var db = new Mock<IDb>();
            var tokenService = new Mock<ITokenService>();
            tokenService.Setup(x => x.IsTokenValid()).Returns(false);
            var fakeDb = new List<AccountInfo>();
            db.Setup(x => x.AddAccount(It.IsAny<AccountInfo>())).Callback(fakeDb.Add).Returns(true);

            var core = new CoreService(db.Object, tokenService.Object);

            var accountInfo = new AccountInfo()
            {
                Name = "facebook",
                Username = "levani",
                EncryptedPassword = "fakePassword"
            };

            var addAccountResponse = core.AddAccount(new AddAccountRequest
            {
                AccountInfo = accountInfo
            });

            Assert.Equal(AddAccountStatus.InvalidToken, addAccountResponse.Status);
            Assert.Null(addAccountResponse.NewlyAddedAccountInfo);
            Assert.Empty(fakeDb);
        }

        [Fact]
        public void AddAccount_RequestAddingAlreadyExistingAccount_ReturnsAlreadyExistsStatus()
        {
            var db = new Mock<IDb>();
            var tokenService = new Mock<ITokenService>();
            tokenService.Setup(x => x.IsTokenValid()).Returns(true);
            var fakeDb = new List<AccountInfo>();
            db.Setup(x => x.AddAccount(It.IsAny<AccountInfo>())).Callback(fakeDb.Add).Returns(true);

            var core = new CoreService(db.Object, tokenService.Object);

            var accountInfo = new AccountInfo()
            {
                Name = "facebook",
                Username = "levani",
                EncryptedPassword = "fakePassword"
            };

            db.Setup(x => x.ContainsAccount(It.IsAny<string>(), accountInfo.Name)).Returns(true);

            var addAccountResponse = core.AddAccount(new AddAccountRequest
            {
                AccountInfo = accountInfo
            });

            Assert.Equal(AddAccountStatus.AccountUsernamePairAlreadyExists, addAccountResponse.Status);
            Assert.Null(addAccountResponse.NewlyAddedAccountInfo);
            Assert.Empty(fakeDb);
        }
    }
}
