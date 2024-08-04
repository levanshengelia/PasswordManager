namespace UI.UserControls
{
    public partial class EmailUserControl : UserControl
    {
        public string? Email => EmailTextBox?.Text;

        public EmailUserControl()
        {
            InitializeComponent();
        }

    }
}
