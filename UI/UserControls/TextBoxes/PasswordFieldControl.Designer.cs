namespace UI
{
    partial class PasswordFieldControl
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
            PasswordTextBox = new TextBox();
            PasswordLabel = new Label();
            SuspendLayout();
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(83, 15);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(214, 23);
            PasswordTextBox.TabIndex = 0;
            //
            // PasswordLabel
            // 
            PasswordLabel.AccessibleRole = AccessibleRole.Cursor;
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(20, 18);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(57, 15);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Password";
            // 
            // PasswordFieldControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PasswordLabel);
            Controls.Add(PasswordTextBox);
            Name = "PasswordFieldControl";
            Size = new Size(341, 51);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PasswordTextBox;
        internal Label PasswordLabel;
    }
}
