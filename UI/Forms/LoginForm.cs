using Core.Enums;
using Core.Requests;
using Core.Requests_Handlers;
using Db.Models;
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
                    await HandleSuccessfulLogin(loginResponse.Token);
                    break;
                case ResponseStatus.Fail:
                    MessageBox.Show(loginResponse.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private async Task HandleSuccessfulLogin(string token)
        {
            var getUserAccountsInfoRequest = new GetUserAccountsRequest
            {
                Token = token,
            };

            var response = await _mediator.Send(getUserAccountsInfoRequest);

            switch (response.Status)
            {
                case ResponseStatus.Success:
                    RedirectToHomeForm(response.Accounts, token);
                    break;
                case ResponseStatus.InvalidToken:
                    MessageBox.Show(response.ErrorMessage);
                    RedirectToLoginForm();
                    break;
                case ResponseStatus.Fail:
                    MessageBox.Show(response.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private void RedirectToHomeForm(List<AccountInfo> accounts, string token)
          {
            Close();
            Dispose();

            new HomeForm(_mediator, accounts, token).Show();
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            new LoginForm(_mediator).Show();
        }
    }
}