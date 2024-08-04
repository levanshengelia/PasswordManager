namespace UI.UserControls.Buttons
{
    public partial class LoginButtonControl : UserControl
    {
        public LoginButtonControl()
        {
            InitializeComponent();
        }

        public event EventHandler LoginButtonClicked = null!;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButtonClicked?.Invoke(sender, e);
        }
    }
}
