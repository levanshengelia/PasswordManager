using Core.Enums;
using Core.Requests_Handlers;
using Core.Responses;
using Db.Models;
using MediatR;

namespace UI.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IMediator _mediator;
        private readonly string _token;

        public HomeForm(IMediator mediator, List<AccountInfo> accounts, string token)
        {
            InitializeComponent();

            _mediator = mediator;
            _token = token;

            AddAccountsInGrid(accounts);
        }

        private void AddAccountsInGrid(List<AccountInfo> accounts)
        {
            foreach (var account in accounts)
            {
                Grid.Rows.Add(account.WebsiteName, account.Username);
            }
        }

        private async void AddNewAccountInfoButton_Click(object sender, EventArgs e)
        {
            using (var addNewAccountForm = new AddNewAccountForm())
            {
                if (addNewAccountForm.ShowDialog() == DialogResult.OK)
                {
                    if (addNewAccountForm.Password != addNewAccountForm.ConfirmedPassword)
                    {
                        MessageBox.Show("Password don't match");
                        return;
                    }

                    var addAccountRequest = new AddAccountRequest
                    {
                        Token = _token,
                        WebsiteName = addNewAccountForm.WebsiteName,
                        Username = addNewAccountForm.UserName,
                        Password = addNewAccountForm.Password,
                    };

                    var addAccountResponse = await _mediator.Send(addAccountRequest);

                    switch (addAccountResponse.Status)
                    {
                        case ResponseStatus.Success:
                            Grid.Rows.Add(addAccountRequest.WebsiteName, addAccountRequest.Username);
                            MessageBox.Show("New account added successfully");
                            break;
                        case ResponseStatus.InvalidToken:
                            MessageBox.Show("Your session expired, log in again");
                            RedirectToLoginForm();
                            break;
                        case ResponseStatus.Fail:
                            MessageBox.Show("Internal server error, try again");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Invalid status value");
                    }
                }
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            RedirectToLoginForm();
        }

        private void RedirectToLoginForm()
        {
            Close();
            Dispose();

            new LoginForm(_mediator).Show();
        }

        private async void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Grid.Columns["ApplicationName"].Index ||
                e.ColumnIndex == Grid.Columns["Username"].Index)
            {
                return;
            }

            var websiteName = (string)Grid[0, e.RowIndex].Value;
            var username = (string)Grid[1, e.RowIndex].Value;

            if (e.ColumnIndex == Grid.Columns["PasswordCopyOption"].Index)
            {
                var getPasswordRequest = new GetPasswordRequest
                {
                    Token = _token,
                    WebsiteName = websiteName,
                    Username = username,
                };

                var getPasswordResponse = await _mediator.Send(getPasswordRequest);

                switch (getPasswordResponse.Status)
                {
                    case ResponseStatus.Success:
                        CopyPasswordToClipboard(getPasswordResponse);
                        break;
                    case ResponseStatus.InvalidToken:
                        MessageBox.Show("Your session expired, log in again");
                        RedirectToLoginForm();
                        break;
                    case ResponseStatus.Fail:
                        MessageBox.Show("Your session expired, log in again");
                        RedirectToLoginForm();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid status value");
                }
            }

            if (e.ColumnIndex == Grid.Columns["DeleteOption"].Index)
            {
                var deleteAccountRequest = new DeleteAccountRequest
                {
                    Token = _token,
                    WebsiteName = websiteName,
                    Username = username,
                };

                var deleteAccountResponse = await _mediator.Send(deleteAccountRequest);

                switch (deleteAccountResponse.Status)
                {
                    case ResponseStatus.Success:
                        Grid.Rows.Remove(Grid.Rows[e.RowIndex]);
                        break;
                    case ResponseStatus.InvalidToken:
                        MessageBox.Show("Your session expired, log in again");
                        RedirectToLoginForm();
                        break;
                    case ResponseStatus.Fail:
                        MessageBox.Show("Internal error, try again");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid status value");
                }
            }
        }

        private static void CopyPasswordToClipboard(GetPasswordResponse getPasswordResponse)
        {
            _ = Task.Run(() =>
            {
                var thread = new Thread(() =>
                {
                    Clipboard.SetText(getPasswordResponse.Password);
                    Thread.Sleep(10_000);
                    Clipboard.Clear();
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            });
        }
    }
}
