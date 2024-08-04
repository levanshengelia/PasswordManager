using Core.Core;
using Core.Models;
using UI.Forms;

namespace UI
{
    public partial class RegistrationForm : Form
    {
        private readonly ICore _core;

        public RegistrationForm(ICore core)
        {
            _core = core;

            InitializeComponent();
            SetEventHandlers();
        }

        private void SetEventHandlers()
        {
            loginButtonControl1.LoginButtonClicked += LoginButtonClicked;
            registrationButtonControl1.RegisterButtonClicked += RegisterButtonClicked;
        }

        private void LoginButtonClicked(object? sender, EventArgs e)
        {
            Close();
            Dispose();

            new LoginForm(_core).Show();
        }

        private void RegisterButtonClicked(object? sender, EventArgs e)
        {
            var userInfo = GetUserInfoFromTextBoxes();

            var registrationRequestResult = _core.Register(userInfo);

            if (registrationRequestResult is Core.Enums.RegistrationStatus.Success)
            {
                RedirectToLoginForm();
            }
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            new LoginForm(_core).Show();
        }

        private UserRegistrationInfo GetUserInfoFromTextBoxes()
        {
            var email = emailUserControl1.Email!;
            var username = usernameFieldControl1.Username!;
            var password = passwordFieldControl1.Password!;
            var confirmedPassword = "alkjfsd";//confirmPassword?.Text!;

            return new UserRegistrationInfo
            {
                Email = email,
                Username = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
            };
        }
    }
}
