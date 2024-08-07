using Core.Db;
using Core.Enums;
using Core.Requests;
using Core.Responses;
using Core.Validations;

//TODO: server error handling and SeriLog
namespace Core.Core
{
    public class CoreService(IDb db) : ICore
    {
        private readonly IDb _db = db;

        public RegisterResponse Register(RegisterRequest request)
        {
            var userInfo = request.UserInfo;
            var validationResult = ModelValidator.ValidateUserRegistrationInfo(userInfo, _db);

            var response = new RegisterResponse
            {
                Status = validationResult,
            };

            if (validationResult == RegisterStatus.Success)
            {
                _db.AddNewUser(userInfo);
            }

            return response;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var userInfo = request.UserInfo;

            if (_db.IsCredentialsValid(userInfo))
            {
                var newToken = Guid.NewGuid().ToString();

                _db.SaveToken(userInfo.UserName, newToken);

                return new LoginResponse
                {
                    Status = LoginStatus.Success,
                    Token = newToken,
                };
            }
            else
            {
                return new LoginResponse
                {
                    Status = LoginStatus.InvalidCredentials,
                    Token = null!,
                };
            }
        }

        public GetUserAccountInfoResponse GetUserAccountInfo(GetUserAccountInfoRequest request)
        {
            return new GetUserAccountInfoResponse
            {
                Status = GetUserAccountInfoStatus.Success,
                UserInfo = new()
            };
        }

        public AddAccountResponse AddAccount(AddAccountRequest request)
        {
            return new AddAccountResponse
            {
                Status = AddAccountStatus.ServerError,
                NewlyAddedAccountInfo = new()
                {
                    Name = "Twitter",
                    Username = "Leo",
                    EncryptedPassword = "blabla"
                },
            };
        }
        
        //Todo: DeleteAccount
    }
}
