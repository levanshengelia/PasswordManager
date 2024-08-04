namespace UI.Forms;

public partial class AddNewAccountForm : Form
{
    public string AppName => applicationNameControl1.AppName!;
    public string UserName => usernameFieldControl1.Username!;
    public string Password => passwordFieldControl1.Password!;


    public AddNewAccountForm()
    {
        InitializeComponent();
    }


    private void AddAccountButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;

        Close();
    }
}