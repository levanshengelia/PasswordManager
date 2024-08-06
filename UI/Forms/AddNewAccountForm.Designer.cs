namespace UI.Forms
{
    partial class AddNewAccountForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            applicationNameControl1 = new UserControls.TextBoxes.ApplicationNameControl();
            usernameFieldControl1 = new UserControls.UsernameFieldControl();
            passwordFieldControl1 = new PasswordFieldControl();
            confirmPasswordControl1 = new UserControls.TextBoxes.ConfirmPasswordControl();
            AddAccountButton = new Button();
            SuspendLayout();
            // 
            // applicationNameControl1
            // 
            applicationNameControl1.Location = new Point(48, 12);
            applicationNameControl1.Name = "applicationNameControl1";
            applicationNameControl1.Size = new Size(357, 51);
            applicationNameControl1.TabIndex = 2;
            // 
            // usernameFieldControl1
            // 
            usernameFieldControl1.Location = new Point(86, 69);
            usernameFieldControl1.Name = "usernameFieldControl1";
            usernameFieldControl1.Size = new Size(341, 51);
            usernameFieldControl1.TabIndex = 0;
            // 
            // passwordFieldControl1
            // 
            passwordFieldControl1.Location = new Point(86, 128);
            passwordFieldControl1.Name = "passwordFieldControl1";
            passwordFieldControl1.Size = new Size(341, 51);
            passwordFieldControl1.TabIndex = 3;
            // 
            // confirmPasswordControl1
            // 
            confirmPasswordControl1.Location = new Point(38, 194);
            confirmPasswordControl1.Name = "confirmPasswordControl1";
            confirmPasswordControl1.Size = new Size(378, 51);
            confirmPasswordControl1.TabIndex = 1;
            // 
            // AddAccountButton
            // 
            AddAccountButton.Location = new Point(172, 267);
            AddAccountButton.Name = "AddAccountButton";
            AddAccountButton.Size = new Size(145, 38);
            AddAccountButton.TabIndex = 4;
            AddAccountButton.TabStop = false;
            AddAccountButton.Text = "Add account";
            AddAccountButton.UseVisualStyleBackColor = true;
            AddAccountButton.Click += AddAccountButton_Click;
            // 
            // AddNewAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 340);
            Controls.Add(AddAccountButton);
            Controls.Add(applicationNameControl1);
            Controls.Add(usernameFieldControl1);
            Controls.Add(passwordFieldControl1);
            Controls.Add(confirmPasswordControl1);
            Name = "AddNewAccountForm";
            Text = "AddNewAccountForm";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.TextBoxes.ApplicationNameControl applicationNameControl1;
        private UserControls.UsernameFieldControl usernameFieldControl1;
        private PasswordFieldControl passwordFieldControl1;
        private UserControls.TextBoxes.ConfirmPasswordControl confirmPasswordControl1;
        private Button AddAccountButton;
    }
}