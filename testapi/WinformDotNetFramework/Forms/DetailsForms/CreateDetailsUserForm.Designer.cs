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
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.UserLastNameLbl = new System.Windows.Forms.Label();
            this.UserLastNameTxt = new System.Windows.Forms.TextBox();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserEmailTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.PasswordSeeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SaveQuitButton = new System.Windows.Forms.Button();
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
            // UserNameLbl
            // 
            this.UserNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserNameLbl.Location = new System.Drawing.Point(77, 47);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(39, 15);
            this.UserNameLbl.TabIndex = 28;
            this.UserNameLbl.Text = "Name";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserNameTxt.Location = new System.Drawing.Point(76, 69);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(167, 23);
            this.UserNameTxt.TabIndex = 27;
            // 
            // UserLastNameLbl
            // 
            this.UserLastNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameLbl.AutoSize = true;
            this.UserLastNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLastNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserLastNameLbl.Location = new System.Drawing.Point(77, 99);
            this.UserLastNameLbl.Name = "UserLastNameLbl";
            this.UserLastNameLbl.Size = new System.Drawing.Size(58, 15);
            this.UserLastNameLbl.TabIndex = 30;
            this.UserLastNameLbl.Text = "Lastname";
            // 
            // UserLastNameTxt
            // 
            this.UserLastNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLastNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserLastNameTxt.Location = new System.Drawing.Point(76, 121);
            this.UserLastNameTxt.Name = "UserLastNameTxt";
            this.UserLastNameTxt.Size = new System.Drawing.Size(167, 23);
            this.UserLastNameTxt.TabIndex = 29;
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserEmailLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserEmailLbl.Location = new System.Drawing.Point(77, 151);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(36, 15);
            this.UserEmailLbl.TabIndex = 32;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserEmailTxt
            // 
            this.UserEmailTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserEmailTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.UserEmailTxt.Location = new System.Drawing.Point(76, 173);
            this.UserEmailTxt.Name = "UserEmailTxt";
            this.UserEmailTxt.Size = new System.Drawing.Size(167, 23);
            this.UserEmailTxt.TabIndex = 31;
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
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.PasswordLbl.Location = new System.Drawing.Point(77, 203);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(101, 15);
            this.PasswordLbl.TabIndex = 36;
            this.PasswordLbl.Text = "Change Password";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.PasswordTxt.Location = new System.Drawing.Point(76, 225);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(167, 23);
            this.PasswordTxt.TabIndex = 35;
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
            this.panel3.Controls.Add(this.SaveQuitButton);
            this.panel3.Controls.Add(this.rolesListBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.UserNameTxt);
            this.panel3.Controls.Add(this.UserNameLbl);
            this.panel3.Controls.Add(this.UserLastNameTxt);
            this.panel3.Controls.Add(this.PasswordSeeBtn);
            this.panel3.Controls.Add(this.UserLastNameLbl);
            this.panel3.Controls.Add(this.PasswordLbl);
            this.panel3.Controls.Add(this.UserEmailTxt);
            this.panel3.Controls.Add(this.PasswordTxt);
            this.panel3.Controls.Add(this.UserEmailLbl);
            this.panel3.Controls.Add(this.SaveBtn);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(17, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 427);
            this.panel3.TabIndex = 41;
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
            // UserDetailsForm
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
            this.Name = "UserDetailsForm";
            this.Text = "UserDetails";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label4;
        private CheckedListBox rolesListBox;
        private Label UserNameLbl;
        private TextBox UserNameTxt;
        private Label UserLastNameLbl;
        private TextBox UserLastNameTxt;
        private Label UserEmailLbl;
        private TextBox UserEmailTxt;
        private Button SaveBtn;
        private CheckBox checkBox1;
        private Label PasswordLbl;
        private TextBox PasswordTxt;
        private Button PasswordSeeBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button SaveQuitButton;
    }
}