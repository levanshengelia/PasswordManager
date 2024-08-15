using Core.Core;
using Core.Enums;
using Core.Models;
using System.ComponentModel;

namespace UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly ICore _core;

        public LoginForm(ICore core)
        {
            _core = core;

            InitializeComponent();
            SetEventHandlers();
        }

        private void SetEventHandlers()
        {
            registrationButtonControl1.RegisterButtonClicked += RegisterButtonClicked;
            loginButtonControl1.LoginButtonClicked += LoginButtonClicked;
        }

        private void RegisterButtonClicked(object? sender, EventArgs e)
        {
            RedirectToRegisterForm();
        }

        private void RedirectToRegisterForm()
        {
            Close();
            Dispose();

            new RegistrationForm(_core).Show();
        }

        private void LoginButtonClicked(object? sender, EventArgs e)
        {
            var userInfo = GetUserInfoFromTextBoxes();

            //todo: build LoginRequest (using userInfo)

            var loginResponse = _core.Login(new());

            switch (loginResponse.Status)
            {
                case LoginStatus.Success:
                    HandleSuccessfulLogin(loginResponse.Token);
                    break;
                case LoginStatus.InvalidCredentials:
                    MessageBox.Show("Invalid credentials, try again");
                    break;
                case LoginStatus.ServerError:
                    MessageBox.Show("Internal server error, try again");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private void HandleSuccessfulLogin(string token)
        {
            //todo: build GetUserAccountInfoRequest

            var getUserAccountInfoResponse = _core.GetUserAccountInfo(new());

            switch (getUserAccountInfoResponse.Status)
            {
                case GetUserAccountInfoStatus.Success:
                    RedirectToHomeForm(getUserAccountInfoResponse.UserInfo);
                    break;
                case GetUserAccountInfoStatus.InvalidToken:
                    MessageBox.Show("Your token is expired or is invalid, log in and try again");
                    RedirectToLoginForm();
                    break;
                case GetUserAccountInfoStatus.ServerError:
                    MessageBox.Show("Internal server error, log in and try again");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private void RedirectToHomeForm(UserPasswordSystemInfo userInfo)
        {
            Close();
            Dispose();

            new HomeForm(userInfo, _core).Show();
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            new LoginForm(_core).Show();
        }

        private UserLoginInfo GetUserInfoFromTextBoxes()
        {
            var username = usernameFieldControl1.Username!;
            var password = passwordFieldControl1.Password!;

            return new UserLoginInfo
            {
                Username = username,
                Password = password,
            };
        }
    }
}