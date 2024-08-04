namespace UI.UserControls.Buttons
{
    public partial class RegistrationButtonControl : UserControl
    {
        public RegistrationButtonControl()
        {
            InitializeComponent();
        }

        public event EventHandler RegisterButtonClicked = null!;

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterButtonClicked?.Invoke(sender, e);
        }
    }
}
