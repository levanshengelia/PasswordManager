using Core.Enums;
using Core.Models;
using Core.Requests;
using Core.Responses;
namespace Core.Core
{
    public interface ICore
    {
        public RegisterResponse Register(RegisterRequest request);
        public LoginResponse Login(LoginRequest request);
        public GetUserAccountInfoResponse GetUserAccountInfo(GetUserAccountInfoRequest request);
        public AddAccountResponse AddAccount(AddAccountRequest request);
    }
}