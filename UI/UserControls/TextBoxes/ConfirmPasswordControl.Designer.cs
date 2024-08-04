namespace UI.UserControls.TextBoxes
{
    partial class ConfirmPasswordControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConfirmPasswordTextBox = new TextBox();
            ConfirmPasswordLabel = new Label();
            SuspendLayout();
            // 
            // ConfirmPasswordTextBox
            // 
            ConfirmPasswordTextBox.Location = new Point(130, 15);
            ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            ConfirmPasswordTextBox.PasswordChar = '*';
            ConfirmPasswordTextBox.Size = new Size(214, 23);
            ConfirmPasswordTextBox.TabIndex = 0;
            // 
            // ConfirmPasswordLabel
            // 
            ConfirmPasswordLabel.AccessibleRole = AccessibleRole.Cursor;
            ConfirmPasswordLabel.AutoSize = true;
            ConfirmPasswordLabel.Location = new Point(20, 18);
            ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            ConfirmPasswordLabel.Size = new Size(104, 15);
            ConfirmPasswordLabel.TabIndex = 1;
            ConfirmPasswordLabel.Text = "Confirm Password";
            // 
            // ConfirmPasswordControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ConfirmPasswordLabel);
            Controls.Add(ConfirmPasswordTextBox);
            Name = "ConfirmPasswordControl";
            Size = new Size(378, 51);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ConfirmPasswordTextBox;
        internal Label ConfirmPasswordLabel;
    }
}
