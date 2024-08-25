using Core.Enums;
using Core.Models;
using Core.Requests;
using MediatR;

namespace UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IMediator _mediator;

        public LoginForm(IMediator mediator)
        {
            _mediator = mediator;

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

            new RegistrationForm(_mediator).Show();
        }

        private async void LoginButtonClicked(object? sender, EventArgs e)
        {
            var loginRequest = new LoginRequest
            {
                Username = usernameFieldControl1.Username!,
                Password = passwordFieldControl1.Password!,
            };

            var loginResponse = await _mediator.Send(loginRequest);

            switch (loginResponse.Status)
            {
                case ResponseStatus.Success:
                    HandleSuccessfulLogin(loginResponse.Token);
                    break;
                case ResponseStatus.Fail:
                    MessageBox.Show(loginResponse.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private void HandleSuccessfulLogin(string token)
        {
            //todo: build GetUserAccountInfoRequest
        }

        private void RedirectToHomeForm(UserPasswordSystemInfo userInfo)
        {
            Close();
            Dispose();

            // new HomeForm(userInfo, _core).Show();
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            new LoginForm(_mediator).Show();
        }
    }
}