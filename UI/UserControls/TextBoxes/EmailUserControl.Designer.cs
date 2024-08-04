namespace UI.UserControls
{
    partial class EmailUserControl
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
            EmailTextBox = new TextBox();
            EmailLabel = new Label();
            SuspendLayout();
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(83, 15);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(214, 23);
            EmailTextBox.TabIndex = 0;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(28, 16);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 1;
            EmailLabel.Text = "Email";
            // 
            // EmailUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EmailLabel);
            Controls.Add(EmailTextBox);
            Name = "EmailUserControl";
            Size = new Size(343, 51);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailTextBox;
        private Label EmailLabel;
    }
}
