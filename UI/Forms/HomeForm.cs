using Db.Models;
using MediatR;

namespace UI.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IMediator _mediator;

        public HomeForm(IMediator mediator, List<AccountInfo> accounts)
        {
            InitializeComponent();

            _mediator = mediator;

            AddAccountsInGrid(accounts);

            // for test
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
        }

        private void AddAccountsInGrid(List<AccountInfo> accounts)
        {
            foreach (var account in accounts)
            {
                Grid.Rows.Add(account.WebsiteName, account.Username);
            }
        }

        private void AddNewAccountInfoButton_Click(object sender, EventArgs e)
        {
            using (var addNewAccountForm = new AddNewAccountForm())
            {
                if (addNewAccountForm.ShowDialog() == DialogResult.OK)
                {
                    var addAccountRequest = new AddAccountRequest
                    {
                        AccountInfo = new AccountInfo
                        {
                            Name = addNewAccountForm.AppName,
                            Username = addNewAccountForm.UserName,
                            PasswordHash = addNewAccountForm.PasswordHash,
                        },
                    };

                    var addAccountResponse = _core.AddAccount(addAccountRequest);

                    switch (addAccountResponse.Status)
                    {
                        case AddAccountStatus.Success:
                            Grid.Rows.Add(addAccountResponse.NewlyAddedAccountInfo.Name, addAccountResponse.NewlyAddedAccountInfo.Username);
                            MessageBox.Show("New account added successfully");
                            break;
                        case AddAccountStatus.InvalidToken:
                            MessageBox.Show("Your session expired, log in again");
                            RedirectToLoginForm();
                            break;
                        case AddAccountStatus.AccountUsernamePairAlreadyExists:
                            MessageBox.Show("Account with that username is already exists");
                            break;
                        case AddAccountStatus.ServerError:
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

            //var applicationName = (string)Grid[1, e.RowIndex].Value;

            //if (e.ColumnIndex == Grid.Columns["PasswordCopyOption"].Index)
            //{
            //    var getPasswordResponse = _core.GetPassword(new GetPasswordRequest
            //    {
            //        ApplicationName = applicationName
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

            //if (e.ColumnIndex == Grid.Columns["DeleteOption"].Index)
            //{
            //    var deleteAccountResponse = _core.DeleteAccount(new DeleteAccountRequest
            //    {
            //        AccountName = applicationName,
            //    });

            //    switch (deleteAccountResponse.Status)
            //    {
            //        case DeleteAccountStatus.Success:
            //            Grid.Rows.Remove(Grid.Rows[e.RowIndex]); 
            //            break;
            //        case DeleteAccountStatus.AccountDoesNotExist:
            //            MessageBox.Show("Application does not exist, try again");
            //            break;
            //        case DeleteAccountStatus.InvalidToken:
            //            MessageBox.Show("Your session expired, log in again");
            //            RedirectToLoginForm();
            //            break;
            //        case DeleteAccountStatus.ServerError:
            //            MessageBox.Show("Internal error, try again");
            //            break;
            //    }
            //}
        }
    }
}
