namespace UI
{
    public partial class PasswordFieldControl : UserControl
    {
        public string? Password => PasswordTextBox?.Text;

        public PasswordFieldControl()
        {
            InitializeComponent();
        }
    }
}
