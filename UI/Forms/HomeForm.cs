using Core.Core;
using Core.Enums;
using Core.Models;

namespace UI.Forms
{
    public partial class HomeForm : Form
    {
        private readonly ICore _core;

        public HomeForm(UserInfo userInfo, ICore core)
        {
            _core = core;

            InitializeComponent();

            // for test
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
            Grid.Rows.Add("Value1", "Value2");
        }

        private void AddNewAccountInfoButton_Click(object sender, EventArgs e)
        {
            using (var addNewAccountForm = new AddNewAccountForm())
            {
                if (addNewAccountForm.ShowDialog() == DialogResult.OK)
                {
                    string appName = addNewAccountForm.AppName;
                    string userName = addNewAccountForm.UserName;
                    string password = addNewAccountForm.Password;

                    var newAccountInfo = new AccountInfo
                    {
                        Name = appName,
                        Username = userName,
                        EncryptedPassword = password,
                    };

                    //todo: build AddAccountRequest (using newAccountInfo)

                    var addAccountResponse = _core.AddAccount(new());

                    switch (addAccountResponse.Status)
                    {
                        case AddAccountStatus.Success:
                            Grid.Rows.Add(addAccountResponse.NewlyAddedAccountInfo.Name, addAccountResponse.NewlyAddedAccountInfo.Username);
                            MessageBox.Show("New account added successfully");
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

            new LoginForm(_core).Show();
        }
    }
}
