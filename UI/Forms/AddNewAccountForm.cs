namespace UI.Forms;

public partial class AddNewAccountForm : Form
{
    public string WebsiteName => applicationNameControl1.AppName!;
    public string UserName => usernameFieldControl1.Username!;
    public string Password => passwordFieldControl1.Password!;
    public string ConfirmedPassword => confirmPasswordControl1.ConfirmedPassword!;


    public AddNewAccountForm()
    {
        InitializeComponent();

        Load += new EventHandler(LoginForm_Load!);
    }


    private void AddAccountButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        applicationNameControl1.FocusOnTextField();
    }
}