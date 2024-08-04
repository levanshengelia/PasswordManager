using Core.Core;
using Core.Enums;
using Core.Models;

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
            Close();
            Dispose();

            new RegistrationForm(_core).Show();
        }
    
        private void LoginButtonClicked(object? sender, EventArgs e)
        {
            var userInfo = GetUserInfoFromTextBoxes();

            var loginResult = _core.Login(userInfo);

            if (loginResult.Status is LoginStatus.Success)
            {
                RedirectToHomeForm(loginResult.Token);
            }
        }

        private void RedirectToHomeForm(string token)
        {
            Close();
            Dispose();

            var userAccountInfo = _core.GetUserAccountInfo(token);

            new HomeForm(userAccountInfo, _core).Show();
        }

        private UserLoginInfo GetUserInfoFromTextBoxes()
        {
            var username = usernameFieldControl1.Username!;
            var password = passwordFieldControl1.Password!;

            return new UserLoginInfo
            {
                UserName = username,
                Password = password,
            };
        }
    }
}