//using Core.Requests;
//using Moq;

//namespace Tests.CoreServiceTests
//{
//    public class RegistrationTest
//    {
//        [Fact]
//        public void Register_ValidRequest_RegisteredSuccessfully()
//        {
//            var userDb = new List<string>();
//            var dbMock = new Mock<IDb>();
//            var tokenService = new Mock<ITokenService>();

//            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationModel>()))
//                .Callback<UserRegistrationModel>(userInfo => userDb.Add(userInfo.Username));

//            var core = new CoreService(dbMock.Object, tokenService.Object);

//            var registerResponse = core.Register(new RegistrationRequest
//            {
//                UserInfo = new UserRegistrationModel
//                {
//                    Username = "levani",
//                    Email = "lshen20@freeuni.edu.ge",
//                    Password = "Levani123$%",
//                    ConfirmedPassword = "Levani123$%",
//                }
//            });

//            Assert.Equal(RegistrationStatus.Success, registerResponse.Status);

//            Assert.Equal("levani", userDb.First());
//        }

//        [Fact]
//        public void Register_PasswordsDontMatch_RegisteredUnsuccessfully()
//        {
//            var userInfo = new UserRegistrationModel
//            {
//                Username = "levani",
//                Email = "lshen20@freeuni.edu.ge",
//                Password = "kukaracha",
//                ConfirmedPassword = "Levani123$%",
//            };

//            InvalidTestHelper(RegistrationStatus.PasswordsDontMatch, userInfo);
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData("lshen20freeuni.edu.ge")]
//        [InlineData("@lshen20freeuni.edu.ge")]
//        [InlineData("lshen20freeuni.edu.ge@")]
//        public void Register_InvalidEmail_RegisteredUnsuccessfully(string invalidEmail)
//        {
//            var userInfo = new UserRegistrationModel
//            {
//                Username = "levani",
//                Email = invalidEmail,
//                Password = "Levani123$%",
//                ConfirmedPassword = "Levani123$%",
//            };

//            InvalidTestHelper(RegistrationStatus.InvalidEmail, userInfo);
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData("L1%e")]
//        [InlineData("levanilevani")]
//        [InlineData("LevaniLevani")]
//        public void Register_WeakPassword_RegisteredUnsuccessfully(string weakPassword)
//        {
//            var userInfo = new UserRegistrationModel
//            {
//                Username = "levani",
//                Email = "lshen20@freeuni.edu.ge",
//                Password = weakPassword,
//                ConfirmedPassword = weakPassword,
//            };

//            InvalidTestHelper(RegistrationStatus.WeakPassword, userInfo);
//        }

//        [Fact]
//        public void Register_UsernameAlreadyTaken_RegisteredUnsuccessfully()
//        {
//            var userDb = new List<string>();
//            var dbMock = new Mock<IDb>();
//            var tokenService = new Mock<ITokenService>();

//            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationModel>()))
//                .Callback<UserRegistrationModel>(userInfo => userDb.Add(userInfo.Username));

//            dbMock.Setup(x => x.ContainsUser(It.IsAny<string>())).Returns<string>(userDb.Contains);

//            var core = new CoreService(dbMock.Object, tokenService.Object);

//            _ = core.Register(new RegistrationRequest
//            {
//                UserInfo = new UserRegistrationModel
//                {
//                    Username = "levani",
//                    Email = "lshen20@freeuni.edu.ge",
//                    Password = "Levani123$%",
//                    ConfirmedPassword = "Levani123$%",
//                }
//            });

//            var registerResponse = core.Register(new RegistrationRequest
//            {
//                UserInfo = new UserRegistrationModel
//                {
//                    Username = "levani",
//                    Email = "lshen20@freeuni.edu.ge",
//                    Password = "Levani123$%",
//                    ConfirmedPassword = "Levani123$%",
//                }
//            });

//            Assert.Equal(RegistrationStatus.UsernameAlreadyTaken, registerResponse.Status);
//        }

//        private static void InvalidTestHelper(RegistrationStatus expectedStatus, UserRegistrationModel userInfo)
//        {
//            var userDb = new List<string>();
//            var dbMock = new Mock<IDb>();
//            var tokenService = new Mock<ITokenService>();

//            dbMock.Setup(x => x.AddNewUser(It.IsAny<UserRegistrationModel>()))
//                .Callback<UserRegistrationModel>(userInfo => userDb.Add(userInfo.Username));

//            var core = new CoreService(dbMock.Object, tokenService.Object);

//            var registerResponse = core.Register(new RegistrationRequest
//            {
//                UserInfo = userInfo
//            });

//            Assert.Equal(expectedStatus, registerResponse.Status);
//            Assert.True(userDb.Count is 0);
//        }
//    }
//}