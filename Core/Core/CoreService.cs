using Core.Core.Helpers;
using Core.Core.Services.IServices;
using Core.Db;
using Core.Enums;
using Core.Requests;
using Core.Responses;

namespace Core.Core
{
    public class CoreService(IDb db, ITokenService tokenService, ICryptoService cryptoService) : ICore
    {
        // Move to safer place
        private const string Key = "bla";

        private readonly IDb _db = db;
        private readonly ITokenService _tokenService = tokenService;
        private readonly ICryptoService _cryptoService = cryptoService;

        private string _username = null!;

        //public RegistrationResponse Register(RegistrationRequest request)
        //{
        //    try
        //    {
        //        var userInfo = request.UserInfo;
        //        var validationResult = PasswordValidator.ValidateUserRegistrationInfo(userInfo, _db);

        //        var response = new RegistrationResponse
        //        {
        //            Status = validationResult,
        //        };

        //        if (validationResult == RegistrationStatus.Success)
        //        {
        //            _db.AddNewUser(userInfo);
        //        }

        //        return response;
        //    }
        //    catch
        //    {
        //        //log
        //        return new RegistrationResponse
        //        {
        //            Status = RegistrationStatus.ServerError,
        //        };
        //    }
        //}

        public LoginResponse Login(LoginRequest request)
        {
            try
            {
                var userInfo = request.UserInfo;

                if (!_db.IsCredentialsValid(userInfo))
                {
                    return new LoginResponse
                    {
                        Status = LoginStatus.InvalidCredentials,
                        Token = null!,
                    };
                }

                var newToken = Guid.NewGuid().ToString();
                _username = userInfo.UserName;

                return new LoginResponse
                {
                    Status = LoginStatus.Success,
                    Token = newToken,
                };
            }
            catch
            {
                //log
                return new LoginResponse
                {
                    Status = LoginStatus.ServerError,
                    Token = null!,
                };
            }
        }

        public GetUserAccountInfoResponse GetUserAccountInfo(GetUserAccountInfoRequest request)
        {
            try
            {
                if (!_tokenService.IsTokenValid())
                {
                    return new GetUserAccountInfoResponse
                    {
                        Status = GetUserAccountInfoStatus.InvalidToken,
                        UserInfo = null!
                    };
                }

                return new GetUserAccountInfoResponse
                {
                    Status = GetUserAccountInfoStatus.Success,
                    UserInfo = _db.GetUserInfo(_username)
                };
            }
            catch
            {
                //log
                return new GetUserAccountInfoResponse
                {
                    Status = GetUserAccountInfoStatus.ServerError,
                    UserInfo = null!
                };
            }
        }

        public AddAccountResponse AddAccount(AddAccountRequest request)
        {
            try
            {
                if (!_tokenService.IsTokenValid())
                {
                    return new AddAccountResponse
                    {
                        Status = AddAccountStatus.InvalidToken,
                        NewlyAddedAccountInfo = null!,
                    };
                }

                if (_db.ContainsAccount(_username, request.AccountInfo.Name))
                {
                    return new AddAccountResponse
                    {
                        Status = AddAccountStatus.AccountUsernamePairAlreadyExists,
                        NewlyAddedAccountInfo = null!,
                    };
                }

                var added = _db.AddAccount(_username, request.AccountInfo);

                if (!added)
                {
                    throw new Exception("Cannot add an account in Db");
                }

                return new AddAccountResponse
                {
                    Status = AddAccountStatus.Success,
                    NewlyAddedAccountInfo = request.AccountInfo,
                };
            }
            catch
            {
                //log
                return new AddAccountResponse
                {
                    Status = AddAccountStatus.ServerError,
                    NewlyAddedAccountInfo = null!,
                };
            }
        }

        public DeleteAccountResponse DeleteAccount(DeleteAccountRequest request)
        {
            try
            {
                if (!_tokenService.IsTokenValid())
                {
                    return new DeleteAccountResponse
                    {
                        Status = DeleteAccountStatus.InvalidToken
                    };
                }

                if (!_db.ContainsAccount(_username, request.AccountName))
                {
                    return new DeleteAccountResponse
                    {
                        Status = DeleteAccountStatus.AccountDoesNotExist
                    };
                }

                var deleted = _db.DeleteAccount(_username, request.AccountName);

                if (!deleted)
                {
                    throw new Exception("Account cannot be removed from db");
                }

                return new DeleteAccountResponse
                {
                    Status = DeleteAccountStatus.Success
                };
            }
            catch
            {
                //log
                return new DeleteAccountResponse
                {
                    Status = DeleteAccountStatus.ServerError
                };
            }
        }

        public GetPasswordResponse GetPassword(GetPasswordRequest request)
        {
            try
            {
                if (!_tokenService.IsTokenValid())
                {
                    return new GetPasswordResponse
                    {
                        Status = GetPasswordStatus.InvalidToken
                    };
                }

                if (!_db.ContainsAccount(_username, request.ApplicationName))
                {
                    return new GetPasswordResponse
                    {
                        Status = GetPasswordStatus.ApplicationDoesNotExist
                    };
                }

                var encryptedPassword = _db.GetEncryptedPassword(_username, request.ApplicationName);

                return new GetPasswordResponse
                {
                    Status = GetPasswordStatus.Success,
                    Password = _cryptoService.Decrypt(encryptedPassword, Key)
                };
            }
            catch
            {
                //log
                return new GetPasswordResponse
                {
                    Status = GetPasswordStatus.ServerError
                };
            }
        }
    }
}
