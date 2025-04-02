using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsUserForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.rolesListBox = new System.Windows.Forms.CheckedListBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PasswordSeeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LastNameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.PasswordCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.EmailCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.NameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SaveQuitButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ListBoxErrorLbl = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(273, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Roles";
            // 
            // rolesListBox
            // 
            this.rolesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rolesListBox.ColumnWidth = 200;
            this.rolesListBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolesListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.rolesListBox.FormattingEnabled = true;
            this.rolesListBox.HorizontalScrollbar = true;
            this.rolesListBox.Items.AddRange(new object[] {
            "Admin",
            "CustomerRead",
            "CustomerWrite",
            "CustomerAdmin",
            "CustomerInvoiceRead",
            "CustomerInvoiceWrite",
            "CustomerInvoiceAdmin",
            "CustomerInvoiceCostRead",
            "CustomerInvoiceCostWrite",
            "CustomerInvoiceCostAdmin",
            "SupplierRead",
            "SupplierWrite",
            "SupplierAdmin",
            "SupplierInvoiceRead",
            "SupplierInvoiceWrite",
            "SupplierInvoiceAdmin",
            "SupplierInvoiceCostRead",
            "SupplierInvoiceCostWrite",
            "SupplierInvoiceCostAdmin",
            "SaleRead",
            "SaleWrite",
            "SaleAdmin"});
            this.rolesListBox.Location = new System.Drawing.Point(274, 62);
            this.rolesListBox.MultiColumn = true;
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(404, 202);
            this.rolesListBox.TabIndex = 9;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(571, 295);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(107, 25);
            this.SaveBtn.TabIndex = 34;
            this.SaveBtn.Text = "Save Changes";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.checkBox1.Location = new System.Drawing.Point(632, 270);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PasswordSeeBtn
            // 
            this.PasswordSeeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordSeeBtn.FlatAppearance.BorderSize = 0;
            this.PasswordSeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordSeeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.PasswordSeeBtn.Image = global::WinformDotNetFramework.Properties.Resources.eye_ri;
            this.PasswordSeeBtn.Location = new System.Drawing.Point(247, 226);
            this.PasswordSeeBtn.Name = "PasswordSeeBtn";
            this.PasswordSeeBtn.Size = new System.Drawing.Size(21, 20);
            this.PasswordSeeBtn.TabIndex = 37;
            this.PasswordSeeBtn.UseVisualStyleBackColor = true;
            this.PasswordSeeBtn.Click += new System.EventHandler(this.PasswordSeeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(767, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 427);
            this.panel1.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 17);
            this.panel2.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel3.Controls.Add(this.ListBoxErrorLbl);
            this.panel3.Controls.Add(this.LastNameCtb);
            this.panel3.Controls.Add(this.PasswordCtb);
            this.panel3.Controls.Add(this.EmailCtb);
            this.panel3.Controls.Add(this.NameCtb);
            this.panel3.Controls.Add(this.SaveQuitButton);
            this.panel3.Controls.Add(this.rolesListBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.PasswordSeeBtn);
            this.panel3.Controls.Add(this.SaveBtn);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(17, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 427);
            this.panel3.TabIndex = 41;
            // 
            // LastNameCtb
            // 
            this.LastNameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LastNameCtb.Location = new System.Drawing.Point(43, 100);
            this.LastNameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.LastNameCtb.Name = "LastNameCtb";
            this.LastNameCtb.Size = new System.Drawing.Size(200, 47);
            this.LastNameCtb.TabIndex = 43;
            this.LastNameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // PasswordCtb
            // 
            this.PasswordCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordCtb.Location = new System.Drawing.Point(43, 206);
            this.PasswordCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.PasswordCtb.Name = "PasswordCtb";
            this.PasswordCtb.Size = new System.Drawing.Size(200, 47);
            this.PasswordCtb.TabIndex = 42;
            this.PasswordCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // EmailCtb
            // 
            this.EmailCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailCtb.Location = new System.Drawing.Point(43, 153);
            this.EmailCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.EmailCtb.Name = "EmailCtb";
            this.EmailCtb.Size = new System.Drawing.Size(200, 47);
            this.EmailCtb.TabIndex = 41;
            this.EmailCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // NameCtb
            // 
            this.NameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCtb.Location = new System.Drawing.Point(43, 47);
            this.NameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.NameCtb.Name = "NameCtb";
            this.NameCtb.Size = new System.Drawing.Size(200, 47);
            this.NameCtb.TabIndex = 40;
            this.NameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // SaveQuitButton
            // 
            this.SaveQuitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveQuitButton.Location = new System.Drawing.Point(571, 326);
            this.SaveQuitButton.Name = "SaveQuitButton";
            this.SaveQuitButton.Size = new System.Drawing.Size(107, 25);
            this.SaveQuitButton.TabIndex = 39;
            this.SaveQuitButton.Text = "Save and Quit";
            this.SaveQuitButton.UseVisualStyleBackColor = false;
            this.SaveQuitButton.Click += new System.EventHandler(this.SaveQuitButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 427);
            this.panel4.TabIndex = 42;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 444);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 17);
            this.panel5.TabIndex = 43;
            // 
            // ListBoxErrorLbl
            // 
            this.ListBoxErrorLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListBoxErrorLbl.AutoSize = true;
            this.ListBoxErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.ListBoxErrorLbl.Location = new System.Drawing.Point(273, 272);
            this.ListBoxErrorLbl.Name = "ListBoxErrorLbl";
            this.ListBoxErrorLbl.Size = new System.Drawing.Size(106, 13);
            this.ListBoxErrorLbl.TabIndex = 44;
            this.ListBoxErrorLbl.Text = "Select at least 1 role.";
            this.ListBoxErrorLbl.Visible = false;
            // 
            // CreateDetailsUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsUserForm";
            this.Text = "UserDetails";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private CheckedListBox rolesListBox;
        private Button SaveBtn;
        private CheckBox checkBox1;
        private Button PasswordSeeBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button SaveQuitButton;
        private control.CustomTextBoxUserControl LastNameCtb;
        private control.CustomTextBoxUserControl PasswordCtb;
        private control.CustomTextBoxUserControl EmailCtb;
        private control.CustomTextBoxUserControl NameCtb;
        private Label ListBoxErrorLbl;
    }
}