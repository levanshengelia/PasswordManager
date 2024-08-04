using UI.UserControls.Buttons;
using UI.UserControls;

namespace UI.Forms
{
    partial class LoginForm
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
            usernameFieldControl1 = new UsernameFieldControl();
            loginButtonControl1 = new LoginButtonControl();
            registrationButtonControl1 = new RegistrationButtonControl();
            SuspendLayout();
            // 
            // passwordFieldControl1
            // 
            passwordFieldControl1.Location = new Point(12, 47);
            passwordFieldControl1.Name = "passwordFieldControl1";
            passwordFieldControl1.Size = new Size(341, 51);
            passwordFieldControl1.TabIndex = 0;
            // 
            // usernameFieldControl1
            // 
            usernameFieldControl1.Location = new Point(12, 3);
            usernameFieldControl1.Name = "usernameFieldControl1";
            usernameFieldControl1.Size = new Size(341, 51);
            usernameFieldControl1.TabIndex = 1;
            // 
            // loginButtonControl1
            // 
            loginButtonControl1.Location = new Point(90, 90);
            loginButtonControl1.Name = "loginButtonControl1";
            loginButtonControl1.Size = new Size(219, 64);
            loginButtonControl1.TabIndex = 2;
            // 
            // registrationButtonControl1
            // 
            registrationButtonControl1.Location = new Point(90, 141);
            registrationButtonControl1.Name = "registrationButtonControl1";
            registrationButtonControl1.Size = new Size(219, 64);
            registrationButtonControl1.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 217);
            Controls.Add(registrationButtonControl1);
            Controls.Add(loginButtonControl1);
            Controls.Add(usernameFieldControl1);
            Controls.Add(passwordFieldControl1);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
        }

        private PasswordFieldControl passwordFieldControl1;
        private UsernameFieldControl usernameFieldControl1;
        private LoginButtonControl loginButtonControl1;
        private RegistrationButtonControl registrationButtonControl1;

        #endregion Windows Form Designer generated code
    }
}