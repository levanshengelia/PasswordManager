namespace UI.UserControls
{
    public partial class UsernameFieldControl : UserControl
    {
        public string? Username => UsernameTextBox?.Text;

        public UsernameFieldControl()
        {
            InitializeComponent();
        }
    }
}
