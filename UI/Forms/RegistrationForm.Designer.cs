namespace UI
{
    partial class RegistrationForm
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
            passwordFieldControl1 = new PasswordFieldControl();
            emailUserControl1 = new UserControls.EmailUserControl();
            usernameFieldControl1 = new UserControls.UsernameFieldControl();
            registrationButtonControl1 = new UserControls.Buttons.RegistrationButtonControl();
            loginButtonControl1 = new UserControls.Buttons.LoginButtonControl();
            confirmPasswordControl1 = new UserControls.TextBoxes.ConfirmPasswordControl();
            SuspendLayout();
            // 
            // passwordFieldControl1
            // 
            passwordFieldControl1.Location = new Point(32, 103);
            passwordFieldControl1.Name = "passwordFieldControl1";
            passwordFieldControl1.Size = new Size(329, 51);
            passwordFieldControl1.TabIndex = 0;
            // 
            // emailUserControl1
            // 
            emailUserControl1.Location = new Point(32, 12);
            emailUserControl1.Name = "emailUserControl1";
            emailUserControl1.Size = new Size(343, 51);
            emailUserControl1.TabIndex = 1;
            // 
            // usernameFieldControl1
            // 
            usernameFieldControl1.Location = new Point(32, 58);
            usernameFieldControl1.Name = "usernameFieldControl1";
            usernameFieldControl1.Size = new Size(341, 51);
            usernameFieldControl1.TabIndex = 2;
            // 
            // registrationButtonControl1
            // 
            registrationButtonControl1.Location = new Point(104, 202);
            registrationButtonControl1.Name = "registrationButtonControl1";
            registrationButtonControl1.Size = new Size(219, 64);
            registrationButtonControl1.TabIndex = 3;
            // 
            // loginButtonControl1
            // 
            loginButtonControl1.Location = new Point(104, 254);
            loginButtonControl1.Name = "loginButtonControl1";
            loginButtonControl1.Size = new Size(219, 64);
            loginButtonControl1.TabIndex = 4;
            // 
            // confirmPasswordControl1
            // 
            confirmPasswordControl1.Location = new Point(-15, 145);
            confirmPasswordControl1.Name = "confirmPasswordControl1";
            confirmPasswordControl1.Size = new Size(378, 51);
            confirmPasswordControl1.TabIndex = 5;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 321);
            Controls.Add(confirmPasswordControl1);
            Controls.Add(loginButtonControl1);
            Controls.Add(registrationButtonControl1);
            Controls.Add(usernameFieldControl1);
            Controls.Add(emailUserControl1);
            Controls.Add(passwordFieldControl1);
            Name = "RegistrationForm";
            Text = "RegistrationFrom";
            ResumeLayout(false);
        }

        #endregion

        private PasswordFieldControl passwordFieldControl1;
        private UserControls.EmailUserControl emailUserControl1;
        private UserControls.UsernameFieldControl usernameFieldControl1;
        private UserControls.Buttons.RegistrationButtonControl registrationButtonControl1;
        private UserControls.Buttons.LoginButtonControl loginButtonControl1;
        private UserControls.TextBoxes.ConfirmPasswordControl confirmPasswordControl1;
    }
}