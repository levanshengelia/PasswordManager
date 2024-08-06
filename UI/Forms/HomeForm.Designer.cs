namespace UI.Forms
{
    partial class HomeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Grid = new DataGridView();
            ApplicationName = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            PasswordCopyOption = new DataGridViewButtonColumn();
            DeleteOption = new DataGridViewButtonColumn();
            AddNewAccountInfoButton = new Button();
            LogOutButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // Grid
            // 
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { ApplicationName, Username, PasswordCopyOption, DeleteOption });
            Grid.Location = new Point(1, 0);
            Grid.Name = "Grid";
            Grid.ShowCellErrors = false;
            Grid.Size = new Size(850, 496);
            Grid.TabIndex = 0;
            // 
            // ApplicationName
            // 
            ApplicationName.HeaderText = "";
            ApplicationName.Name = "ApplicationName";
            ApplicationName.Resizable = DataGridViewTriState.False;
            ApplicationName.Width = 200;
            // 
            // Username
            // 
            Username.HeaderText = "";
            Username.Name = "Username";
            Username.Width = 200;
            // 
            // PasswordCopyOption
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            PasswordCopyOption.DefaultCellStyle = dataGridViewCellStyle1;
            PasswordCopyOption.HeaderText = "";
            PasswordCopyOption.Name = "PasswordCopyOption";
            PasswordCopyOption.Resizable = DataGridViewTriState.False;
            PasswordCopyOption.SortMode = DataGridViewColumnSortMode.Automatic;
            PasswordCopyOption.Text = "Copy Password";
            PasswordCopyOption.UseColumnTextForButtonValue = true;
            PasswordCopyOption.Width = 200;
            // 
            // DeleteOption
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Red;
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Red;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            DeleteOption.DefaultCellStyle = dataGridViewCellStyle2;
            DeleteOption.HeaderText = "";
            DeleteOption.Name = "DeleteOption";
            DeleteOption.ReadOnly = true;
            DeleteOption.Text = "Delete Account Info";
            DeleteOption.UseColumnTextForButtonValue = true;
            DeleteOption.Width = 200;
            // 
            // AddNewAccountInfoButton
            // 
            AddNewAccountInfoButton.BackColor = SystemColors.ButtonFace;
            AddNewAccountInfoButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddNewAccountInfoButton.ForeColor = Color.Black;
            AddNewAccountInfoButton.Location = new Point(289, 523);
            AddNewAccountInfoButton.Name = "AddNewAccountInfoButton";
            AddNewAccountInfoButton.Size = new Size(277, 59);
            AddNewAccountInfoButton.TabIndex = 1;
            AddNewAccountInfoButton.Text = "Add new account info";
            AddNewAccountInfoButton.UseVisualStyleBackColor = false;
            AddNewAccountInfoButton.Click += AddNewAccountInfoButton_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.BackColor = SystemColors.ButtonFace;
            LogOutButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogOutButton.ForeColor = Color.Black;
            LogOutButton.Location = new Point(289, 607);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(277, 59);
            LogOutButton.TabIndex = 2;
            LogOutButton.Text = "Log out";
            LogOutButton.UseVisualStyleBackColor = false;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 691);
            Controls.Add(LogOutButton);
            Controls.Add(AddNewAccountInfoButton);
            Controls.Add(Grid);
            Name = "HomeForm";
            Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Grid;
        private DataGridViewTextBoxColumn ApplicationName;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewButtonColumn PasswordCopyOption;
        private DataGridViewButtonColumn DeleteOption;
        private Button AddNewAccountInfoButton;
        private Button LogOutButton;
    }
}