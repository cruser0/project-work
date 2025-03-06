namespace Winform.Forms
{
    partial class UserProfileForm
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
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.FlowPanelRoles = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RoleLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PasswordConfirmLbl = new System.Windows.Forms.Label();
            this.ConfirmPasswordTxt = new System.Windows.Forms.TextBox();
            this.UserIDTxt = new System.Windows.Forms.TextBox();
            this.PasswordSeeBtn = new System.Windows.Forms.Button();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserEmailTxt = new System.Windows.Forms.TextBox();
            this.UserLastNameLbl = new System.Windows.Forms.Label();
            this.UserLastNameTxt = new System.Windows.Forms.TextBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.UserIDLbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LeftPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CenterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 441);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(784, 20);
            this.BottomPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(784, 20);
            this.TopPanel.TabIndex = 1;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Controls.Add(this.FlowPanelRoles);
            this.LeftPanel.Controls.Add(this.panel3);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(20, 20);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 421);
            this.LeftPanel.TabIndex = 2;
            // 
            // FlowPanelRoles
            // 
            this.FlowPanelRoles.AutoScroll = true;
            this.FlowPanelRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.FlowPanelRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanelRoles.Location = new System.Drawing.Point(0, 111);
            this.FlowPanelRoles.Name = "FlowPanelRoles";
            this.FlowPanelRoles.Size = new System.Drawing.Size(198, 308);
            this.FlowPanelRoles.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel3.Controls.Add(this.RoleLbl);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 111);
            this.panel3.TabIndex = 4;
            // 
            // RoleLbl
            // 
            this.RoleLbl.AutoSize = true;
            this.RoleLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RoleLbl.Location = new System.Drawing.Point(0, 96);
            this.RoleLbl.Name = "RoleLbl";
            this.RoleLbl.Size = new System.Drawing.Size(40, 15);
            this.RoleLbl.TabIndex = 0;
            this.RoleLbl.Text = "Roles:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Winform.Properties.Resources.cropped_logo_removebg_preview_50x50;
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 53);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 421);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(220, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 421);
            this.panel1.TabIndex = 1;
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.RightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(564, 20);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(200, 421);
            this.RightPanel.TabIndex = 3;
            // 
            // CenterPanel
            // 
            this.CenterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.CenterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CenterPanel.Controls.Add(this.button1);
            this.CenterPanel.Controls.Add(this.checkBox1);
            this.CenterPanel.Controls.Add(this.PasswordConfirmLbl);
            this.CenterPanel.Controls.Add(this.ConfirmPasswordTxt);
            this.CenterPanel.Controls.Add(this.UserIDTxt);
            this.CenterPanel.Controls.Add(this.PasswordSeeBtn);
            this.CenterPanel.Controls.Add(this.PasswordLbl);
            this.CenterPanel.Controls.Add(this.PasswordTxt);
            this.CenterPanel.Controls.Add(this.UserEmailLbl);
            this.CenterPanel.Controls.Add(this.UserEmailTxt);
            this.CenterPanel.Controls.Add(this.UserLastNameLbl);
            this.CenterPanel.Controls.Add(this.UserLastNameTxt);
            this.CenterPanel.Controls.Add(this.UserNameLbl);
            this.CenterPanel.Controls.Add(this.UserNameTxt);
            this.CenterPanel.Controls.Add(this.UserIDLbl);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(230, 20);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(324, 421);
            this.CenterPanel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(170, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(62, 323);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PasswordConfirmLbl
            // 
            this.PasswordConfirmLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordConfirmLbl.AutoSize = true;
            this.PasswordConfirmLbl.Enabled = false;
            this.PasswordConfirmLbl.Location = new System.Drawing.Point(62, 265);
            this.PasswordConfirmLbl.Name = "PasswordConfirmLbl";
            this.PasswordConfirmLbl.Size = new System.Drawing.Size(104, 15);
            this.PasswordConfirmLbl.TabIndex = 51;
            this.PasswordConfirmLbl.Text = "Confirm Password";
            this.PasswordConfirmLbl.Visible = false;
            // 
            // ConfirmPasswordTxt
            // 
            this.ConfirmPasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmPasswordTxt.Location = new System.Drawing.Point(62, 283);
            this.ConfirmPasswordTxt.Name = "ConfirmPasswordTxt";
            this.ConfirmPasswordTxt.PasswordChar = '•';
            this.ConfirmPasswordTxt.PlaceholderText = "•••••••••";
            this.ConfirmPasswordTxt.Size = new System.Drawing.Size(200, 23);
            this.ConfirmPasswordTxt.TabIndex = 50;
            this.ConfirmPasswordTxt.Visible = false;
            // 
            // UserIDTxt
            // 
            this.UserIDTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserIDTxt.Enabled = false;
            this.UserIDTxt.Location = new System.Drawing.Point(62, 44);
            this.UserIDTxt.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.UserIDTxt.Name = "UserIDTxt";
            this.UserIDTxt.Size = new System.Drawing.Size(200, 23);
            this.UserIDTxt.TabIndex = 49;
            // 
            // PasswordSeeBtn
            // 
            this.PasswordSeeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordSeeBtn.FlatAppearance.BorderSize = 0;
            this.PasswordSeeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordSeeBtn.Image = global::Winform.Properties.Resources.eye_ri;
            this.PasswordSeeBtn.Location = new System.Drawing.Point(268, 235);
            this.PasswordSeeBtn.Name = "PasswordSeeBtn";
            this.PasswordSeeBtn.Size = new System.Drawing.Size(25, 23);
            this.PasswordSeeBtn.TabIndex = 48;
            this.PasswordSeeBtn.UseVisualStyleBackColor = true;
            this.PasswordSeeBtn.Visible = false;
            this.PasswordSeeBtn.Click += new System.EventHandler(this.PasswordSeeBtn_Click);
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Enabled = false;
            this.PasswordLbl.Location = new System.Drawing.Point(62, 218);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(57, 15);
            this.PasswordLbl.TabIndex = 47;
            this.PasswordLbl.Text = "Password";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTxt.Enabled = false;
            this.PasswordTxt.Location = new System.Drawing.Point(62, 236);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '•';
            this.PasswordTxt.PlaceholderText = "•••••••••";
            this.PasswordTxt.Size = new System.Drawing.Size(200, 23);
            this.PasswordTxt.TabIndex = 46;
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailLbl.AutoSize = true;
            this.UserEmailLbl.Location = new System.Drawing.Point(62, 165);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(36, 15);
            this.UserEmailLbl.TabIndex = 45;
            this.UserEmailLbl.Text = "Email";
            // 
            // UserEmailTxt
            // 
            this.UserEmailTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserEmailTxt.Enabled = false;
            this.UserEmailTxt.Location = new System.Drawing.Point(62, 183);
            this.UserEmailTxt.Name = "UserEmailTxt";
            this.UserEmailTxt.Size = new System.Drawing.Size(200, 23);
            this.UserEmailTxt.TabIndex = 44;
            // 
            // UserLastNameLbl
            // 
            this.UserLastNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameLbl.AutoSize = true;
            this.UserLastNameLbl.Location = new System.Drawing.Point(62, 119);
            this.UserLastNameLbl.Name = "UserLastNameLbl";
            this.UserLastNameLbl.Size = new System.Drawing.Size(58, 15);
            this.UserLastNameLbl.TabIndex = 43;
            this.UserLastNameLbl.Text = "Lastname";
            // 
            // UserLastNameTxt
            // 
            this.UserLastNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserLastNameTxt.Enabled = false;
            this.UserLastNameTxt.Location = new System.Drawing.Point(62, 137);
            this.UserLastNameTxt.Name = "UserLastNameTxt";
            this.UserLastNameTxt.Size = new System.Drawing.Size(200, 23);
            this.UserLastNameTxt.TabIndex = 42;
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Location = new System.Drawing.Point(62, 72);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(39, 15);
            this.UserNameLbl.TabIndex = 41;
            this.UserNameLbl.Text = "Name";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameTxt.Enabled = false;
            this.UserNameTxt.Location = new System.Drawing.Point(62, 90);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(200, 23);
            this.UserNameTxt.TabIndex = 40;
            // 
            // UserIDLbl
            // 
            this.UserIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserIDLbl.AutoSize = true;
            this.UserIDLbl.Location = new System.Drawing.Point(62, 26);
            this.UserIDLbl.Name = "UserIDLbl";
            this.UserIDLbl.Size = new System.Drawing.Size(44, 15);
            this.UserIDLbl.TabIndex = 39;
            this.UserIDLbl.Text = "User ID";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 421);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(554, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 421);
            this.panel6.TabIndex = 6;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.BottomPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UserProfileForm";
            this.Text = "UserProfileForm";
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            this.LeftPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel BottomPanel;
        private Panel TopPanel;
        private Panel LeftPanel;
        private Panel RightPanel;
        private Label RoleLbl;
        private PictureBox pictureBox1;
        private Panel CenterPanel;
        private FlowLayoutPanel FlowPanelRoles;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        private TextBox UserIDTxt;
        private Label PasswordLbl;
        private Label UserEmailLbl;
        private TextBox UserEmailTxt;
        private Label UserLastNameLbl;
        private TextBox UserLastNameTxt;
        private Label UserNameLbl;
        private TextBox UserNameTxt;
        private Label UserIDLbl;
        private TextBox PasswordTxt;
        private Label PasswordConfirmLbl;
        private TextBox ConfirmPasswordTxt;
        private Button PasswordSeeBtn;
        private Button button1;
        private CheckBox checkBox1;
        private Panel panel5;
        private Panel panel6;
    }
}