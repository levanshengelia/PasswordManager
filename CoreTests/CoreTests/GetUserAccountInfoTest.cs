//using Core.Core;
//using Core.Core.Services.IServices;
//using Core.Db;
//using Core.Enums;
//using Core.Models;
//using Core.Requests;
//using Moq;

//namespace Tests.CoreServiceTests
//{
//    public class GetUserAccountInfoTest
//    {
//        [Fact]
//        public void GetUserAccountInfo_ValidToken_GetsInfo()
//        {
//            var token = "fakeToken";
//            var db = new Mock<IDb>();
//            var tokenService = new Mock<ITokenService>();
//            tokenService.Setup(x => x.IsTokenValid()).Returns(true);
//            db.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(new UserPasswordSystemInfo
//            {
//                AccountInfos = [ new AccountInfo { Name = "facebook", Username = "levani", PasswordHash = "fakePassword" }],
//            });

//            var core = new CoreService(db.Object, tokenService.Object);

//            var getUserAccountInfoResponse = core.GetUserAccountInfo(new());

//            Assert.Equal(GetUserAccountInfoStatus.Success, getUserAccountInfoResponse.Status);
//            var userInfo = Assert.Single(getUserAccountInfoResponse.UserInfo.AccountInfos);
//            Assert.Equal("facebook", userInfo.Name);
//            Assert.Equal("levani", userInfo.Username);
//        }

//        [Fact]
//        public void GetUserAccountInfo_InvalidToken_CantGetInfo()
//        {
//            var token = "fakeToken";
//            var db = new Mock<IDb>();
//            var tokenService = new Mock<ITokenService>();

//            db.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(new UserPasswordSystemInfo
//            {
//                AccountInfos = [new AccountInfo { Name = "facebook", Username = "levani", PasswordHash = "fakePassword" }],
//            });

//            var core = new CoreService(db.Object, tokenService.Object);

//            var getUserAccountInfoResponse = core.GetUserAccountInfo(new());

//            Assert.Equal(GetUserAccountInfoStatus.InvalidToken, getUserAccountInfoResponse.Status);
//            Assert.Null(getUserAccountInfoResponse.UserInfo);
//        }
//    }
//}
