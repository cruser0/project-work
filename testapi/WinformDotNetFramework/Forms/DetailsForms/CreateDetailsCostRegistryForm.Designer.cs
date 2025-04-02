namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsCostRegistryForm
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
            this.SaveQuitBtn = new System.Windows.Forms.Button();
            this.QuantityCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CostCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.DescriptionCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CodeCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.SaveQuitBtn);
            this.panel1.Controls.Add(this.QuantityCtb);
            this.panel1.Controls.Add(this.CostCtb);
            this.panel1.Controls.Add(this.DescriptionCtb);
            this.panel1.Controls.Add(this.CodeCtb);
            this.panel1.Controls.Add(this.SaveEditCustomerBtn);
            this.panel1.Controls.Add(this.EditCustomerCbx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 416);
            this.panel1.TabIndex = 29;
            // 
            // SaveQuitBtn
            // 
            this.SaveQuitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitBtn.Location = new System.Drawing.Point(367, 354);
            this.SaveQuitBtn.Name = "SaveQuitBtn";
            this.SaveQuitBtn.Size = new System.Drawing.Size(102, 23);
            this.SaveQuitBtn.TabIndex = 39;
            this.SaveQuitBtn.Text = "Save and Quit";
            this.SaveQuitBtn.UseVisualStyleBackColor = true;
            this.SaveQuitBtn.Click += new System.EventHandler(this.SaveQuitButton_Click);
            // 
            // QuantityCtb
            // 
            this.QuantityCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityCtb.Location = new System.Drawing.Point(269, 242);
            this.QuantityCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.QuantityCtb.Name = "QuantityCtb";
            this.QuantityCtb.Size = new System.Drawing.Size(200, 47);
            this.QuantityCtb.TabIndex = 38;
            this.QuantityCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CostCtb
            // 
            this.CostCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostCtb.Location = new System.Drawing.Point(269, 190);
            this.CostCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CostCtb.Name = "CostCtb";
            this.CostCtb.Size = new System.Drawing.Size(200, 47);
            this.CostCtb.TabIndex = 37;
            this.CostCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // DescriptionCtb
            // 
            this.DescriptionCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescriptionCtb.Location = new System.Drawing.Point(269, 138);
            this.DescriptionCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.DescriptionCtb.Name = "DescriptionCtb";
            this.DescriptionCtb.Size = new System.Drawing.Size(200, 47);
            this.DescriptionCtb.TabIndex = 36;
            this.DescriptionCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // CodeCtb
            // 
            this.CodeCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CodeCtb.Location = new System.Drawing.Point(269, 86);
            this.CodeCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CodeCtb.Name = "CodeCtb";
            this.CodeCtb.Size = new System.Drawing.Size(200, 47);
            this.CodeCtb.TabIndex = 35;
            this.CodeCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveEditCustomerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(377, 323);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(92, 25);
            this.SaveEditCustomerBtn.TabIndex = 8;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCostRegistryBtn_Click);
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerCbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.EditCustomerCbx.Location = new System.Drawing.Point(423, 298);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 7;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            this.EditCustomerCbx.CheckedChanged += new System.EventHandler(this.EditCostRegistryCbx_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(17, 433);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(766, 17);
            this.panel5.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(17, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 17);
            this.panel4.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(783, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 450);
            this.panel3.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 450);
            this.panel2.TabIndex = 30;
            // 
            // CreateDetailsCostRegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "CreateDetailsCostRegistryForm";
            this.Text = "CreateCostRegistry";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveEditCustomerBtn;
        private System.Windows.Forms.CheckBox EditCustomerCbx;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private control.CustomTextBoxUserControl QuantityCtb;
        private control.CustomTextBoxUserControl CostCtb;
        private control.CustomTextBoxUserControl DescriptionCtb;
        private control.CustomTextBoxUserControl CodeCtb;
        private System.Windows.Forms.Button SaveQuitBtn;
    }
}