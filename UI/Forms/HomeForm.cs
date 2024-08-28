using Core.Enums;
using Core.Requests_Handlers;
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

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Grid.Columns["ApplicationName"].Index ||
                e.ColumnIndex == Grid.Columns["Username"].Index)
            {
                return;
            }

            var websiteName = (string)Grid[1, e.RowIndex].Value;

            //if (e.ColumnIndex == Grid.Columns["PasswordCopyOption"].Index)
            //{
            //    var getPasswordResponse = _core.GetPassword(new GetPasswordRequest
            //    {
            //        ApplicationName = websiteName
            //    });

            //    switch (getPasswordResponse.Status)
            //    {
            //        case GetPasswordStatus.Success:
            //            Clipboard.SetText(getPasswordResponse.PasswordHash);
            //            _ = Task.Run(() =>
            //            {
            //                Thread.Sleep(10_000);
            //                Clipboard.Clear();
            //            });
            //            break;
            //        case GetPasswordStatus.ApplicationDoesNotExist:
            //            MessageBox.Show("Application does not exist, try again");
            //            break;
            //        case GetPasswordStatus.InvalidToken:
            //            MessageBox.Show("Your session expired, log in again");
            //            RedirectToLoginForm();
            //            break;
            //        case GetPasswordStatus.ServerError:
            //            MessageBox.Show("Internal error, try again");
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException("Invalid status value");
            //    }
            //}

            if (e.ColumnIndex == Grid.Columns["DeleteOption"].Index)
            {
                var deleteAccountResponse = _mediator.Send(new DeleteAccountRequest
                {
                    AccountName = applicationName,
                });

                switch (deleteAccountResponse.Status)
                {
                    case DeleteAccountStatus.Success:
                        Grid.Rows.Remove(Grid.Rows[e.RowIndex]);
                        break;
                    case DeleteAccountStatus.AccountDoesNotExist:
                        MessageBox.Show("Application does not exist, try again");
                        break;
                    case DeleteAccountStatus.InvalidToken:
                        MessageBox.Show("Your session expired, log in again");
                        RedirectToLoginForm();
                        break;
                    case DeleteAccountStatus.ServerError:
                        MessageBox.Show("Internal error, try again");
                        break;
                }
            }
        }
    }
}
