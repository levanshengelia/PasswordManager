using Core.Core;
using Core.Enums;
using Core.Models;
using Core.Requests;
using MediatR;
using System.Runtime.CompilerServices;
using UI.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UI
{
    public partial class RegistrationForm : Form
    {
        private readonly IMediator _mediator;

        public RegistrationForm(IMediator mediator)
        {
            _mediator = mediator;

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

        private async void RegisterButtonClicked(object? sender, EventArgs e)
        {
            var registerRequest = new RegistrationRequest
            {
                Email = emailUserControl1.Email!,
                Username = usernameFieldControl1.Username!,
                Password = passwordFieldControl1.Password!,
                ConfirmedPassword = confirmPasswordControl1.ConfirmedPassword!,
            };

            var registerResponse = await _mediator.Send(registerRequest);

            switch (registerResponse.Status)
            {
                case ResponseStatus.Success:
                    MessageBox.Show("You registered successfully");
                    RedirectToLoginForm();
                    break;
                case ResponseStatus.Fail:
                    MessageBox.Show(registerResponse.ErrorMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid status value");
            }
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            //new LoginForm(_core).Show();
        }
    }
}
