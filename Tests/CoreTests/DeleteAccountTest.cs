//using Core.Core;
//using Core.Core.Services.IServices;
//using Core.Db;
//using Core.Enums;
//using Core.Requests;
//using Moq;

//namespace Tests.CoreServiceTests
//{
//    public class DeleteAccountTest
//    {
//        [Fact]
//        public void DeleteAccount_ValidRequest_DeletedSuccessfully()
//        {
//            var db = new Mock<IDb>();
//            db.Setup(x => x.DeleteAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
//            db.Setup(x => x.ContainsAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
//            var tokenService = new Mock<ITokenService>();
//            tokenService.Setup(x => x.IsTokenValid()).Returns(true);

//            SendDeleteRequest(db.Object, tokenService.Object, DeleteAccountStatus.Success);
//        }
        
//        [Fact]
//        public void DeleteAccount_InValidToken_GetInvalidToken()
//        {
//            var db = new Mock<IDb>();
//            db.Setup(x => x.DeleteAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
//            db.Setup(x => x.ContainsAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
//            var tokenService = new Mock<ITokenService>();
//            tokenService.Setup(x => x.IsTokenValid()).Returns(false);

//            SendDeleteRequest(db.Object, tokenService.Object, DeleteAccountStatus.InvalidToken);
//        }
        
//        [Fact]
//        public void DeleteAccount_InvalidAccount_GetAccountDoesNotExist()
//        {
//            var db = new Mock<IDb>();
//            db.Setup(x => x.DeleteAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
//            db.Setup(x => x.ContainsAccount(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
//            var tokenService = new Mock<ITokenService>();
//            tokenService.Setup(x => x.IsTokenValid()).Returns(true);

//            SendDeleteRequest(db.Object, tokenService.Object, DeleteAccountStatus.AccountDoesNotExist);
//        }

//        private static void SendDeleteRequest(IDb db, ITokenService tokenService, DeleteAccountStatus expectedStatus)
//        {
//            var core = new CoreService(db, tokenService);

//            var deleteAccountResponse = core.DeleteAccount(new DeleteAccountRequest
//            {
//                AccountName = "facebook",
//            });

//            Assert.Equal(expectedStatus, deleteAccountResponse.Status);
//        }
//    }
//}
