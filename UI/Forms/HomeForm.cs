using Core.Core;
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

            dataGridView1.Rows.Add("Value1", "Value2");
            dataGridView1.Rows.Add("Value1", "Value2");
            dataGridView1.Rows.Add("Value1", "Value2");
            dataGridView1.Rows.Add("Value1", "Value2");
            dataGridView1.Rows.Add("Value1", "Value2");
            dataGridView1.Rows.Add("Value1", "Value2");
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

                    var addAccountRequestResult = _core.AddNewAccount(AddNewAccountInfo, token);

                    if (addAccountRequestResult)
                    {
                        MessageBox.Show("New account added successfully");
                    }
                }
            }
        }
    }
}
