namespace Winform.Forms.DetailsForms
{
    partial class UserDetails
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
            this.UserIDLbl = new System.Windows.Forms.Label();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.UserLastNameLbl = new System.Windows.Forms.Label();
            this.UserLastNameTxt = new System.Windows.Forms.TextBox();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserEmailTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.PasswordSeeBtn = new System.Windows.Forms.Button();
            this.UserIDTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Roles";
            // 
            // rolesListBox
            // 
            this.rolesListBox.ColumnWidth = 200;
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
            this.rolesListBox.Location = new System.Drawing.Point(405, 101);
            this.rolesListBox.MultiColumn = true;
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(404, 202);
            this.rolesListBox.TabIndex = 9;
            // 
            // UserIDLbl
            // 
            this.UserIDLbl.AutoSize = true;
            this.UserIDLbl.Location = new System.Drawing.Point(175, 83);
            this.UserIDLbl.Name = "UserIDLbl";
            this.UserIDLbl.Size = new System.Drawing.Size(44, 15);
            this.UserIDLbl.TabIndex = 26;
            this.UserIDLbl.Text = "User ID";
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(175, 129);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(39, 15);
            this.UserNameLbl.TabIndex = 28;
            this.UserNameLbl.Text = "Name";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(174, 147);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(194, 23);
            this.UserNameTxt.TabIndex = 27;
            // 
            // UserLastNameLbl
            // 
            this.UserLastNameLbl.AutoSize = true;
            this.UserLastNameLbl.Location = new System.Drawing.Point(175, 176);
            this.UserLastNameLbl.Name = "UserLastNameLbl";
            this.UserLastNameLbl.Size = new System.Drawing.Size(58, 15);
            this.UserLastNameLbl.TabIndex = 30;
            this.UserLastNameLbl.Text = "Lastname";
            // 
            // UserLastNameTxt
            // 
            this.UserLastNameTxt.Location = new System.Drawing.Point(174, 194);
            this.UserLastNameTxt.Name = "UserLastNameTxt";
            this.UserLastNameTxt.Size = new System.Drawing.Size(194, 23);
            this.UserLastNameTxt.TabIndex = 29;
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.Location = new System.Drawing.Point(176, 222);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(36, 15);
            this.UserEmailLbl.TabIndex = 32;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserEmailTxt
            // 
            this.UserEmailTxt.Location = new System.Drawing.Point(174, 240);
            this.UserEmailTxt.Name = "UserEmailTxt";
            this.UserEmailTxt.Size = new System.Drawing.Size(194, 23);
            this.UserEmailTxt.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(296, 386);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(175, 275);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(101, 15);
            this.PasswordLbl.TabIndex = 36;
            this.PasswordLbl.Text = "Change Password";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(174, 293);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '•';
            this.PasswordTxt.PlaceholderText = "•••••••••";
            this.PasswordTxt.Size = new System.Drawing.Size(194, 23);
            this.PasswordTxt.TabIndex = 35;
            // 
            // PasswordSeeBtn
            // 
            this.PasswordSeeBtn.FlatAppearance.BorderSize = 0;
            this.PasswordSeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordSeeBtn.Image = global::Winform.Properties.Resources.eye_ri;
            this.PasswordSeeBtn.Location = new System.Drawing.Point(374, 292);
            this.PasswordSeeBtn.Name = "PasswordSeeBtn";
            this.PasswordSeeBtn.Size = new System.Drawing.Size(25, 23);
            this.PasswordSeeBtn.TabIndex = 37;
            this.PasswordSeeBtn.UseVisualStyleBackColor = true;
            this.PasswordSeeBtn.Click += new System.EventHandler(this.PasswordSeeBtn_Click);
            // 
            // UserIDTxt
            // 
            this.UserIDTxt.Location = new System.Drawing.Point(174, 101);
            this.UserIDTxt.Name = "UserIDTxt";
            this.UserIDTxt.Size = new System.Drawing.Size(194, 23);
            this.UserIDTxt.TabIndex = 38;
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 460);
            this.Controls.Add(this.UserIDTxt);
            this.Controls.Add(this.PasswordSeeBtn);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.UserEmailLbl);
            this.Controls.Add(this.UserEmailTxt);
            this.Controls.Add(this.UserLastNameLbl);
            this.Controls.Add(this.UserLastNameTxt);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.UserIDLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rolesListBox);
            this.Name = "UserDetails";
            this.Text = "UserDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private CheckedListBox rolesListBox;
        private Label UserIDLbl;
        private Label UserNameLbl;
        private TextBox UserNameTxt;
        private Label UserLastNameLbl;
        private TextBox UserLastNameTxt;
        private Label UserEmailLbl;
        private TextBox UserEmailTxt;
        private Button button1;
        private CheckBox checkBox1;
        private Label PasswordLbl;
        private TextBox PasswordTxt;
        private Button PasswordSeeBtn;
        private TextBox UserIDTxt;
    }
}