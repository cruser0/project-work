namespace Winform.Forms.AddForms
{
    partial class CreateUserForm
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
            this.PasswordSeeBtn = new System.Windows.Forms.Button();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserEmailTxt = new System.Windows.Forms.TextBox();
            this.UserLastNameLbl = new System.Windows.Forms.Label();
            this.UserLastNameTxt = new System.Windows.Forms.TextBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rolesListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // PasswordSeeBtn
            // 
            this.PasswordSeeBtn.FlatAppearance.BorderSize = 0;
            this.PasswordSeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordSeeBtn.Image = global::Winform.Properties.Resources.eye_ri;
            this.PasswordSeeBtn.Location = new System.Drawing.Point(286, 227);
            this.PasswordSeeBtn.Name = "PasswordSeeBtn";
            this.PasswordSeeBtn.Size = new System.Drawing.Size(25, 23);
            this.PasswordSeeBtn.TabIndex = 52;
            this.PasswordSeeBtn.UseVisualStyleBackColor = true;
            this.PasswordSeeBtn.Click += new System.EventHandler(this.PasswordSeeBtn_Click);
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(87, 210);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(57, 15);
            this.PasswordLbl.TabIndex = 51;
            this.PasswordLbl.Text = "Password";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(86, 228);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.PlaceholderText = "************";
            this.PasswordTxt.Size = new System.Drawing.Size(194, 23);
            this.PasswordTxt.TabIndex = 50;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(257, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Create User";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.Location = new System.Drawing.Point(88, 157);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(36, 15);
            this.UserEmailLbl.TabIndex = 47;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserEmailTxt
            // 
            this.UserEmailTxt.Location = new System.Drawing.Point(86, 175);
            this.UserEmailTxt.Name = "UserEmailTxt";
            this.UserEmailTxt.Size = new System.Drawing.Size(194, 23);
            this.UserEmailTxt.TabIndex = 46;
            this.UserEmailTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // UserLastNameLbl
            // 
            this.UserLastNameLbl.AutoSize = true;
            this.UserLastNameLbl.Location = new System.Drawing.Point(87, 111);
            this.UserLastNameLbl.Name = "UserLastNameLbl";
            this.UserLastNameLbl.Size = new System.Drawing.Size(58, 15);
            this.UserLastNameLbl.TabIndex = 45;
            this.UserLastNameLbl.Text = "Lastname";
            // 
            // UserLastNameTxt
            // 
            this.UserLastNameTxt.Location = new System.Drawing.Point(86, 129);
            this.UserLastNameTxt.Name = "UserLastNameTxt";
            this.UserLastNameTxt.Size = new System.Drawing.Size(194, 23);
            this.UserLastNameTxt.TabIndex = 44;
            this.UserLastNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(87, 64);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(39, 15);
            this.UserNameLbl.TabIndex = 43;
            this.UserNameLbl.Text = "Name";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(86, 82);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(194, 23);
            this.UserNameTxt.TabIndex = 42;
            this.UserNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 40;
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
            "CustomerDelete",
            "CustomerInvoiceRead",
            "CustomerInvoiceWrite",
            "CustomerInvoiceDelete",
            "CustomerInvoiceCostRead",
            "CustomerInvoiceCostWrite",
            "CustomerInvoiceCostDelete",
            "SupplierRead",
            "SupplierWrite",
            "SupplierDelete",
            "SupplierInvoiceRead",
            "SupplierInvoiceWrite",
            "SupplierInvoiceDelete",
            "SupplierInvoiceCostRead",
            "SupplierInvoiceCostWrite",
            "SupplierInvoiceCostDelete",
            "SaleRead",
            "SaleWrite",
            "SaleDelete"});
            this.rolesListBox.Location = new System.Drawing.Point(314, 82);
            this.rolesListBox.MultiColumn = true;
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(404, 202);
            this.rolesListBox.TabIndex = 39;
            this.rolesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rolesListBox_CheckedItems);
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PasswordSeeBtn);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserEmailLbl);
            this.Controls.Add(this.UserEmailTxt);
            this.Controls.Add(this.UserLastNameLbl);
            this.Controls.Add(this.UserLastNameTxt);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rolesListBox);
            this.Name = "CreateUserForm";
            this.Text = "CreateUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button PasswordSeeBtn;
        private Label PasswordLbl;
        private TextBox PasswordTxt;
        private Button button1;
        private Label UserEmailLbl;
        private TextBox UserEmailTxt;
        private Label UserLastNameLbl;
        private TextBox UserLastNameTxt;
        private Label UserNameLbl;
        private TextBox UserNameTxt;
        private Label label4;
        private CheckedListBox rolesListBox;
    }
}