﻿using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class UserGridForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGridForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rolesListBox = new System.Windows.Forms.CheckedListBox();
            this.Emailtxt = new System.Windows.Forms.TextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaginationPanel = new System.Windows.Forms.Panel();
            this.paginationControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UserIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.UserNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.UserLastNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.UserEmailTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.UserRoleTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.Roles1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PaginationPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FilterPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 0;
            // 
            // FilterPanel
            // 
            this.FilterPanel.AutoScroll = true;
            this.FilterPanel.AutoScrollMargin = new System.Drawing.Size(0, 30);
            this.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.FilterPanel.Controls.Add(this.label4);
            this.FilterPanel.Controls.Add(this.label3);
            this.FilterPanel.Controls.Add(this.label2);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Controls.Add(this.rolesListBox);
            this.FilterPanel.Controls.Add(this.Emailtxt);
            this.FilterPanel.Controls.Add(this.lastNameTxt);
            this.FilterPanel.Controls.Add(this.nameTxt);
            this.FilterPanel.Location = new System.Drawing.Point(0, 89);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(200, 369);
            this.FilterPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(0, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Roles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(0, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(0, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name";
            // 
            // rolesListBox
            // 
            this.rolesListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.rolesListBox.FormattingEnabled = true;
            this.rolesListBox.HorizontalScrollbar = true;
            this.rolesListBox.Items.AddRange(new object[] {
            "All",
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
            this.rolesListBox.Location = new System.Drawing.Point(3, 164);
            this.rolesListBox.MinimumSize = new System.Drawing.Size(4, 378);
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(177, 364);
            this.rolesListBox.TabIndex = 4;
            this.rolesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rolesListBox_ItemCheck);
            this.rolesListBox.Click += new System.EventHandler(this.rolesListBox_Click);
            // 
            // Emailtxt
            // 
            this.Emailtxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.Emailtxt.Location = new System.Drawing.Point(3, 114);
            this.Emailtxt.Name = "Emailtxt";
            this.Emailtxt.Size = new System.Drawing.Size(177, 20);
            this.Emailtxt.TabIndex = 2;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.lastNameTxt.Location = new System.Drawing.Point(3, 72);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(177, 20);
            this.lastNameTxt.TabIndex = 1;
            // 
            // nameTxt
            // 
            this.nameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.nameTxt.Location = new System.Drawing.Point(3, 24);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(177, 20);
            this.nameTxt.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 461);
            this.RightSideBar.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.panel2.Controls.Add(this.PaginationPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 87);
            this.panel2.TabIndex = 1;
            // 
            // PaginationPanel
            // 
            this.PaginationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.PaginationPanel.Controls.Add(this.paginationControl);
            this.PaginationPanel.Location = new System.Drawing.Point(82, 0);
            this.PaginationPanel.Name = "PaginationPanel";
            this.PaginationPanel.Size = new System.Drawing.Size(349, 87);
            this.PaginationPanel.TabIndex = 0;
            // 
            // paginationControl
            // 
            this.paginationControl.CurrentPage = 0;
            this.paginationControl.Location = new System.Drawing.Point(39, 20);
            this.paginationControl.Name = "paginationControl";
            this.paginationControl.Size = new System.Drawing.Size(271, 43);
            this.paginationControl.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.userDgv);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 374);
            this.panel3.TabIndex = 2;
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.AllowUserToOrderColumns = true;
            this.userDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDgv.Location = new System.Drawing.Point(0, 25);
            this.userDgv.Name = "userDgv";
            this.userDgv.ReadOnly = true;
            this.userDgv.RowTemplate.Height = 25;
            this.userDgv.Size = new System.Drawing.Size(584, 349);
            this.userDgv.TabIndex = 0;
            this.userDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.userDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDgv_RightClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleEditButton,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToggleEditButton
            // 
            this.ToggleEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToggleEditButton.Image = ((System.Drawing.Image)(resources.GetObject("ToggleEditButton.Image")));
            this.ToggleEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToggleEditButton.Name = "ToggleEditButton";
            this.ToggleEditButton.Size = new System.Drawing.Size(69, 22);
            this.ToggleEditButton.Text = "Toggle Edit";
            this.ToggleEditButton.ToolTipText = "Toggle Edit Mode";
            this.ToggleEditButton.Click += new System.EventHandler(this.ToggleEditButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WinformDotNetFramework.Properties.Resources.save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton1";
            this.toolStripButton2.ToolTipText = "Save Changes";
            this.toolStripButton2.Click += new System.EventHandler(this.MassUpdateTSB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WinformDotNetFramework.Properties.Resources.trash;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "<";
            this.toolStripButton1.ToolTipText = "Delete Selected Items";
            this.toolStripButton1.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserIDTsmi,
            this.UserNameTsmi,
            this.UserLastNameTsmi,
            this.UserEmailTsmi,
            this.UserRoleTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(163, 114);
            // 
            // UserIDTsmi
            // 
            this.UserIDTsmi.CheckOnClick = true;
            this.UserIDTsmi.Name = "UserIDTsmi";
            this.UserIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.UserIDTsmi.Text = "Show ID";
            this.UserIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // UserNameTsmi
            // 
            this.UserNameTsmi.Checked = true;
            this.UserNameTsmi.CheckOnClick = true;
            this.UserNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserNameTsmi.Name = "UserNameTsmi";
            this.UserNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.UserNameTsmi.Text = "Show Name";
            this.UserNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // UserLastNameTsmi
            // 
            this.UserLastNameTsmi.Checked = true;
            this.UserLastNameTsmi.CheckOnClick = true;
            this.UserLastNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserLastNameTsmi.Name = "UserLastNameTsmi";
            this.UserLastNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.UserLastNameTsmi.Text = "Show Last Name";
            this.UserLastNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // UserEmailTsmi
            // 
            this.UserEmailTsmi.Checked = true;
            this.UserEmailTsmi.CheckOnClick = true;
            this.UserEmailTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserEmailTsmi.Name = "UserEmailTsmi";
            this.UserEmailTsmi.Size = new System.Drawing.Size(162, 22);
            this.UserEmailTsmi.Text = "Show Email";
            this.UserEmailTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // UserRoleTsmi
            // 
            this.UserRoleTsmi.Checked = true;
            this.UserRoleTsmi.CheckOnClick = true;
            this.UserRoleTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserRoleTsmi.Name = "UserRoleTsmi";
            this.UserRoleTsmi.Size = new System.Drawing.Size(162, 22);
            this.UserRoleTsmi.Text = "Show Roles";
            this.UserRoleTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // Roles1
            // 
            this.Roles1.DataPropertyName = "Roles";
            this.Roles1.HeaderText = "Roles";
            this.Roles1.Name = "Roles1";
            // 
            // UserID1
            // 
            this.UserID1.DataPropertyName = "UserID";
            this.UserID1.HeaderText = "UserID";
            this.UserID1.Name = "UserID1";
            // 
            // UserGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "UserGridForm";
            this.Text = "UserGridForm";
            this.Load += new System.EventHandler(this.UserGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PaginationPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel FilterPanel;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckedListBox rolesListBox;
        private TextBox Emailtxt;
        private TextBox lastNameTxt;
        private TextBox nameTxt;
        private control.RightSideBarUserControl RightSideBar;
        private Panel panel2;
        private Panel PaginationPanel;
        private control.PaginationUserControl paginationControl;
        private DataGridView userDgv;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem UserIDTsmi;
        private ToolStripMenuItem UserNameTsmi;
        private ToolStripMenuItem UserLastNameTsmi;
        private ToolStripMenuItem UserEmailTsmi;
        private ToolStripMenuItem UserRoleTsmi;
        public Panel panel3;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton ToggleEditButton;
        private DataGridViewTextBoxColumn Roles1;
        private DataGridViewTextBoxColumn UserID1;
    }
}