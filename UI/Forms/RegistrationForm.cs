using Core.Core;
using Core.Enums;
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
            RedirectToLoginForm();
        }

        private void RegisterButtonClicked(object? sender, EventArgs e)
        {
            var userInfo = GetUserInfoFromTextBoxes();

            //todo: build RegisterRequest (using userInfo)

            var registerResponse = _core.Register(new());

            switch (registerResponse.Status)
            {
                case RegisterStatus.Success:
                    MessageBox.Show("You registered successfully");
                    RedirectToLoginForm();
                    break;
                case RegisterStatus.PasswordsDontMatch:
                    MessageBox.Show("Passwords don't match, try again");
                    break;
                case RegisterStatus.InvalidEmail:
                    MessageBox.Show("Invalid email");
                    break;
                case RegisterStatus.WeakPassword:
                    MessageBox.Show("Password is too weak. use at least 8 characters and at least 3 out of these 4:" +
                        " 1 uppercase letter, 1 lowercase letter, 1 special symbol, and 1 number");
                    break;
                case RegisterStatus.UsernameAlreadyTaken:
                    MessageBox.Show("The user with this name is already exists, choose different username");
                    break;
                case RegisterStatus.ServerError:
                    MessageBox.Show("Internal server error, try again");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
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
            var confirmedPassword = confirmPasswordControl1.ConfirmedPassword!;

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
