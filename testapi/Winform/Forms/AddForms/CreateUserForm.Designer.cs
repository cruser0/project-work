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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordSeeBtn
            // 
            this.PasswordSeeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordSeeBtn.FlatAppearance.BorderSize = 0;
            this.PasswordSeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordSeeBtn.Image = global::Winform.Properties.Resources.eye_ri;
            this.PasswordSeeBtn.Location = new System.Drawing.Point(251, 235);
            this.PasswordSeeBtn.Name = "PasswordSeeBtn";
            this.PasswordSeeBtn.Size = new System.Drawing.Size(25, 23);
            this.PasswordSeeBtn.TabIndex = 52;
            this.PasswordSeeBtn.UseVisualStyleBackColor = true;
            this.PasswordSeeBtn.Click += new System.EventHandler(this.PasswordSeeBtn_Click);
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(45, 212);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(57, 15);
            this.PasswordLbl.TabIndex = 51;
            this.PasswordLbl.Text = "Password";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTxt.Location = new System.Drawing.Point(45, 236);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '•';
            this.PasswordTxt.PlaceholderText = "•••••••••••••";
            this.PasswordTxt.Size = new System.Drawing.Size(200, 23);
            this.PasswordTxt.TabIndex = 50;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(292, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Create User";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.Location = new System.Drawing.Point(45, 156);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(36, 15);
            this.UserEmailLbl.TabIndex = 47;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserEmailTxt
            // 
            this.UserEmailTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailTxt.Location = new System.Drawing.Point(45, 180);
            this.UserEmailTxt.Name = "UserEmailTxt";
            this.UserEmailTxt.Size = new System.Drawing.Size(200, 23);
            this.UserEmailTxt.TabIndex = 46;
            this.UserEmailTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // UserLastNameLbl
            // 
            this.UserLastNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameLbl.AutoSize = true;
            this.UserLastNameLbl.Location = new System.Drawing.Point(45, 100);
            this.UserLastNameLbl.Name = "UserLastNameLbl";
            this.UserLastNameLbl.Size = new System.Drawing.Size(58, 15);
            this.UserLastNameLbl.TabIndex = 45;
            this.UserLastNameLbl.Text = "Lastname";
            // 
            // UserLastNameTxt
            // 
            this.UserLastNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameTxt.Location = new System.Drawing.Point(45, 124);
            this.UserLastNameTxt.Name = "UserLastNameTxt";
            this.UserLastNameTxt.Size = new System.Drawing.Size(200, 23);
            this.UserLastNameTxt.TabIndex = 44;
            this.UserLastNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(45, 44);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(39, 15);
            this.UserNameLbl.TabIndex = 43;
            this.UserNameLbl.Text = "Name";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameTxt.Location = new System.Drawing.Point(45, 68);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(200, 23);
            this.UserNameTxt.TabIndex = 42;
            this.UserNameTxt.TextChanged += new System.EventHandler(this.UserNameTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "Roles";
            // 
            // rolesListBox
            // 
            this.rolesListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rolesListBox.ColumnWidth = 200;
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
            this.rolesListBox.Location = new System.Drawing.Point(292, 62);
            this.rolesListBox.MultiColumn = true;
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(404, 202);
            this.rolesListBox.TabIndex = 39;
            this.rolesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rolesListBox_CheckedItems);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UserNameLbl);
            this.panel1.Controls.Add(this.PasswordSeeBtn);
            this.panel1.Controls.Add(this.rolesListBox);
            this.panel1.Controls.Add(this.PasswordLbl);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PasswordTxt);
            this.panel1.Controls.Add(this.UserNameTxt);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UserLastNameTxt);
            this.panel1.Controls.Add(this.UserEmailLbl);
            this.panel1.Controls.Add(this.UserLastNameLbl);
            this.panel1.Controls.Add(this.UserEmailTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 421);
            this.panel1.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 20);
            this.panel2.TabIndex = 54;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 441);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 20);
            this.panel3.TabIndex = 55;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 421);
            this.panel4.TabIndex = 56;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 421);
            this.panel5.TabIndex = 57;
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateUserForm";
            this.Text = "CreateUserForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}