using Core.Enums;
using Core.Requests;
using Core.Responses;

namespace Core.Core
{
    public class CoreService : ICore
    {
        public RegisterResponse Register(RegisterRequest request)
        {
            return new RegisterResponse
            {
                Status = RegisterStatus.Success,
            };
        }
        
        public LoginResponse Login(LoginRequest request)
        {
            return new LoginResponse
            {
                Status = LoginStatus.Success,
            };
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
    }
}
