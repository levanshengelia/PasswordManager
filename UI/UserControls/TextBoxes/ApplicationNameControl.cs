using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserControls.TextBoxes
{
    public partial class ApplicationNameControl : UserControl
    {
        public string? AppName => ApplicationNameTextBox?.Text;
        
        public ApplicationNameControl()
        {
            InitializeComponent();
        }

    }
}
