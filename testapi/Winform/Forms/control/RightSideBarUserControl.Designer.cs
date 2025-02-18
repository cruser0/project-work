namespace Winform.Forms.control
{
    partial class RightSideBarUserControl
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.CloseWindowBtn = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.LightGray;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SearchButton.Location = new System.Drawing.Point(0, 58);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(200, 45);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            this.SearchButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchButton_KeyPress);
            // 
            // CloseWindowBtn
            // 
            this.CloseWindowBtn.BackColor = System.Drawing.Color.DarkGray;
            this.CloseWindowBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseWindowBtn.FlatAppearance.BorderSize = 0;
            this.CloseWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseWindowBtn.Location = new System.Drawing.Point(160, 0);
            this.CloseWindowBtn.Name = "CloseWindowBtn";
            this.CloseWindowBtn.Size = new System.Drawing.Size(40, 38);
            this.CloseWindowBtn.TabIndex = 1;
            this.CloseWindowBtn.Text = "X";
            this.CloseWindowBtn.UseVisualStyleBackColor = false;
            this.CloseWindowBtn.Click += new System.EventHandler(this.CloseWindowBtn_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.CloseWindowBtn);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(200, 38);
            this.TopPanel.TabIndex = 2;
            // 
            // RightSideBarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SearchButton);
            this.Name = "RightSideBarUserControl";
            this.Size = new System.Drawing.Size(200, 600);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button SearchButton;
        private Button CloseWindowBtn;
        private Panel TopPanel;
    }
}
