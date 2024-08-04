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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            ApplicationName = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            PasswordCopyOption = new DataGridViewButtonColumn();
            DeleteOption = new DataGridViewButtonColumn();
            AddNewAccountInfoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ApplicationName, Username, PasswordCopyOption, DeleteOption });
            dataGridView1.Location = new Point(1, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ShowCellErrors = false;
            dataGridView1.Size = new Size(850, 496);
            dataGridView1.TabIndex = 0;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(128, 255, 128);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            PasswordCopyOption.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.Red;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.Red;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            DeleteOption.DefaultCellStyle = dataGridViewCellStyle4;
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
            AddNewAccountInfoButton.Location = new Point(289, 528);
            AddNewAccountInfoButton.Name = "AddNewAccountInfoButton";
            AddNewAccountInfoButton.Size = new Size(277, 59);
            AddNewAccountInfoButton.TabIndex = 1;
            AddNewAccountInfoButton.Text = "Add new account info";
            AddNewAccountInfoButton.UseVisualStyleBackColor = false;
            AddNewAccountInfoButton.Click += AddNewAccountInfoButton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 616);
            Controls.Add(AddNewAccountInfoButton);
            Controls.Add(dataGridView1);
            Name = "HomeForm";
            Text = "HomeForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ApplicationName;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewButtonColumn PasswordCopyOption;
        private DataGridViewButtonColumn DeleteOption;
        private Button AddNewAccountInfoButton;
    }
}