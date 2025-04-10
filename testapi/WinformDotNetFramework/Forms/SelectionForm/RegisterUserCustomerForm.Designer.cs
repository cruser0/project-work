namespace WinformDotNetFramework.Forms.SelectionForm
{
    partial class RegisterUserCustomerForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CustomerLastNameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CustomerUserNameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CustomerPasswordCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CustomerEmailCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CountryNameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CustomerNameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CustomerLastNameCtb);
            this.panel1.Controls.Add(this.CustomerUserNameCtb);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.CustomerPasswordCtb);
            this.panel1.Controls.Add(this.CustomerEmailCtb);
            this.panel1.Controls.Add(this.CountryNameCtb);
            this.panel1.Controls.Add(this.CustomerNameCtb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(17, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 17);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(17, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 17);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 461);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(767, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 461);
            this.panel5.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.Location = new System.Drawing.Point(543, 276);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CustomerLastNameCtb
            // 
            this.CustomerLastNameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerLastNameCtb.Location = new System.Drawing.Point(418, 170);
            this.CustomerLastNameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerLastNameCtb.Name = "CustomerLastNameCtb";
            this.CustomerLastNameCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerLastNameCtb.TabIndex = 6;
            this.CustomerLastNameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CustomerUserNameCtb
            // 
            this.CustomerUserNameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerUserNameCtb.Location = new System.Drawing.Point(140, 170);
            this.CustomerUserNameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerUserNameCtb.Name = "CustomerUserNameCtb";
            this.CustomerUserNameCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerUserNameCtb.TabIndex = 5;
            this.CustomerUserNameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CustomerPasswordCtb
            // 
            this.CustomerPasswordCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerPasswordCtb.Location = new System.Drawing.Point(418, 223);
            this.CustomerPasswordCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerPasswordCtb.Name = "CustomerPasswordCtb";
            this.CustomerPasswordCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerPasswordCtb.TabIndex = 3;
            this.CustomerPasswordCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CustomerEmailCtb
            // 
            this.CustomerEmailCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerEmailCtb.Location = new System.Drawing.Point(140, 223);
            this.CustomerEmailCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerEmailCtb.Name = "CustomerEmailCtb";
            this.CustomerEmailCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerEmailCtb.TabIndex = 2;
            this.CustomerEmailCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CountryNameCtb
            // 
            this.CountryNameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CountryNameCtb.Location = new System.Drawing.Point(418, 117);
            this.CountryNameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CountryNameCtb.Name = "CountryNameCtb";
            this.CountryNameCtb.Size = new System.Drawing.Size(200, 47);
            this.CountryNameCtb.TabIndex = 1;
            this.CountryNameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CustomerNameCtb
            // 
            this.CustomerNameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerNameCtb.Location = new System.Drawing.Point(140, 117);
            this.CustomerNameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerNameCtb.Name = "CustomerNameCtb";
            this.CustomerNameCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerNameCtb.TabIndex = 0;
            this.CustomerNameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // RegisterUserCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "RegisterUserCustomerForm";
            this.Text = "RegisterUserCustomerForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button SaveBtn;
        private control.CustomTextBoxUserControl CustomerPasswordCtb;
        private control.CustomTextBoxUserControl CustomerEmailCtb;
        private control.CustomTextBoxUserControl CountryNameCtb;
        private control.CustomTextBoxUserControl CustomerNameCtb;
        private control.CustomTextBoxUserControl CustomerLastNameCtb;
        private control.CustomTextBoxUserControl CustomerUserNameCtb;
    }
}