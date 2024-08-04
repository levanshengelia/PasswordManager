namespace UI.UserControls.TextBoxes
{
    partial class ApplicationNameControl
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
            ApplicationNameTextBox = new TextBox();
            ApplicationNameLabel = new Label();
            SuspendLayout();
            // 
            // ApplicationNameTextBox
            // 
            ApplicationNameTextBox.Location = new Point(123, 15);
            ApplicationNameTextBox.Name = "ApplicationNameTextBox";
            ApplicationNameTextBox.Size = new Size(214, 23);
            ApplicationNameTextBox.TabIndex = 0;
            // 
            // ApplicationNameLabel
            // 
            ApplicationNameLabel.AutoSize = true;
            ApplicationNameLabel.Location = new Point(17, 18);
            ApplicationNameLabel.Name = "ApplicationNameLabel";
            ApplicationNameLabel.Size = new Size(103, 15);
            ApplicationNameLabel.TabIndex = 1;
            ApplicationNameLabel.Text = "Application Name";
            // 
            // ApplicationNameControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ApplicationNameLabel);
            Controls.Add(ApplicationNameTextBox);
            Name = "ApplicationNameControl";
            Size = new Size(357, 51);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ApplicationNameTextBox;
        private Label ApplicationNameLabel;
    }
}
