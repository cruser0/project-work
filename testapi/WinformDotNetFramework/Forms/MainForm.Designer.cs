﻿using System.Windows.Forms;

namespace WinformDotNetFramework.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ShowTP = new System.Windows.Forms.TabPage();
            this.Show = new System.Windows.Forms.ToolStrip();
            this.CustomerShowTS = new System.Windows.Forms.ToolStripButton();
            this.CustomerInvoiceShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierShowTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaleShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.RegistryCostShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.UserShowTS = new System.Windows.Forms.ToolStripButton();
            this.AddTP = new System.Windows.Forms.TabPage();
            this.Create = new System.Windows.Forms.ToolStrip();
            this.CustomerCreateTS = new System.Windows.Forms.ToolStripButton();
            this.CustomerInvoiceCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierCreateTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SaleCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.RegistryCostCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.UserCreateTS = new System.Windows.Forms.ToolStripButton();
            this.GroupTP = new System.Windows.Forms.TabPage();
            this.Group = new System.Windows.Forms.ToolStrip();
            this.CustomerGroupTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierGroupTS = new System.Windows.Forms.ToolStripButton();
            this.ReportTP = new System.Windows.Forms.TabPage();
            this.Report = new System.Windows.Forms.ToolStrip();
            this.CustomerInvoiceReportTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierInvoiceReportTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SaleReportTS = new System.Windows.Forms.ToolStripButton();
            this.TS = new System.Windows.Forms.ToolStrip();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.UserProfile = new System.Windows.Forms.ToolStripButton();
            this.AddFavoriteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFormDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ShowTP.SuspendLayout();
            this.Show.SuspendLayout();
            this.AddTP.SuspendLayout();
            this.Create.SuspendLayout();
            this.GroupTP.SuspendLayout();
            this.Group.SuspendLayout();
            this.ReportTP.SuspendLayout();
            this.Report.SuspendLayout();
            this.TS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.TS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 87);
            this.panel1.TabIndex = 8;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ShowTP);
            this.tabControl.Controls.Add(this.AddTP);
            this.tabControl.Controls.Add(this.GroupTP);
            this.tabControl.Controls.Add(this.ReportTP);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1077, 64);
            this.tabControl.TabIndex = 0;
            // 
            // ShowTP
            // 
            this.ShowTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.ShowTP.Controls.Add(this.Show);
            this.ShowTP.Location = new System.Drawing.Point(4, 24);
            this.ShowTP.Name = "ShowTP";
            this.ShowTP.Padding = new System.Windows.Forms.Padding(3);
            this.ShowTP.Size = new System.Drawing.Size(1069, 36);
            this.ShowTP.TabIndex = 0;
            this.ShowTP.Text = "Show";
            // 
            // Show
            // 
            this.Show.AutoSize = false;
            this.Show.BackColor = System.Drawing.Color.Transparent;
            this.Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Show.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Show.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerShowTS,
            this.CustomerInvoiceShowTS,
            this.toolStripSeparator1,
            this.SupplierShowTS,
            this.SupplierInvoiceShowTS,
            this.toolStripSeparator2,
            this.SaleShowTS,
            this.toolStripSeparator13,
            this.RegistryCostShowTS,
            this.toolStripButton1,
            this.UserShowTS});
            this.Show.Location = new System.Drawing.Point(3, 3);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(1063, 30);
            this.Show.TabIndex = 0;
            this.Show.Text = "Show";
            // 
            // CustomerShowTS
            // 
            this.CustomerShowTS.AutoSize = false;
            this.CustomerShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerShowTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerShowTS.Image")));
            this.CustomerShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerShowTS.Name = "CustomerShowTS";
            this.CustomerShowTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerShowTS.Text = "Customer";
            this.CustomerShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // CustomerInvoiceShowTS
            // 
            this.CustomerInvoiceShowTS.AutoSize = false;
            this.CustomerInvoiceShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerInvoiceShowTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerInvoiceShowTS.Image")));
            this.CustomerInvoiceShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerInvoiceShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerInvoiceShowTS.Name = "CustomerInvoiceShowTS";
            this.CustomerInvoiceShowTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerInvoiceShowTS.Text = "Customer Invoice";
            this.CustomerInvoiceShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // SupplierShowTS
            // 
            this.SupplierShowTS.AutoSize = false;
            this.SupplierShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierShowTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierShowTS.Image")));
            this.SupplierShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierShowTS.Name = "SupplierShowTS";
            this.SupplierShowTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierShowTS.Text = "Supplier";
            this.SupplierShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // SupplierInvoiceShowTS
            // 
            this.SupplierInvoiceShowTS.AutoSize = false;
            this.SupplierInvoiceShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierInvoiceShowTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierInvoiceShowTS.Image")));
            this.SupplierInvoiceShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierInvoiceShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierInvoiceShowTS.Name = "SupplierInvoiceShowTS";
            this.SupplierInvoiceShowTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierInvoiceShowTS.Text = "Supplier Invoice";
            this.SupplierInvoiceShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // SaleShowTS
            // 
            this.SaleShowTS.AutoSize = false;
            this.SaleShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaleShowTS.Image = ((System.Drawing.Image)(resources.GetObject("SaleShowTS.Image")));
            this.SaleShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaleShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SaleShowTS.Name = "SaleShowTS";
            this.SaleShowTS.Size = new System.Drawing.Size(100, 27);
            this.SaleShowTS.Text = "Sale";
            this.SaleShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 30);
            // 
            // RegistryCostShowTS
            // 
            this.RegistryCostShowTS.AutoSize = false;
            this.RegistryCostShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RegistryCostShowTS.Image = ((System.Drawing.Image)(resources.GetObject("RegistryCostShowTS.Image")));
            this.RegistryCostShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RegistryCostShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.RegistryCostShowTS.Name = "RegistryCostShowTS";
            this.RegistryCostShowTS.Size = new System.Drawing.Size(100, 27);
            this.RegistryCostShowTS.Text = "Registry Cost";
            this.RegistryCostShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 30);
            // 
            // UserShowTS
            // 
            this.UserShowTS.AutoSize = false;
            this.UserShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserShowTS.Image = ((System.Drawing.Image)(resources.GetObject("UserShowTS.Image")));
            this.UserShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.UserShowTS.Name = "UserShowTS";
            this.UserShowTS.Size = new System.Drawing.Size(100, 27);
            this.UserShowTS.Text = "User";
            this.UserShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddTP
            // 
            this.AddTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(204)))), ((int)(((byte)(214)))));
            this.AddTP.Controls.Add(this.Create);
            this.AddTP.Location = new System.Drawing.Point(4, 24);
            this.AddTP.Name = "AddTP";
            this.AddTP.Padding = new System.Windows.Forms.Padding(3);
            this.AddTP.Size = new System.Drawing.Size(1069, 36);
            this.AddTP.TabIndex = 2;
            this.AddTP.Text = "Create";
            // 
            // Create
            // 
            this.Create.AutoSize = false;
            this.Create.BackColor = System.Drawing.Color.Transparent;
            this.Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Create.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Create.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerCreateTS,
            this.CustomerInvoiceCreateTS,
            this.toolStripSeparator7,
            this.SupplierCreateTS,
            this.SupplierInvoiceCreateTS,
            this.toolStripSeparator8,
            this.SaleCreateTS,
            this.toolStripSeparator10,
            this.RegistryCostCreateTS,
            this.toolStripSeparator9,
            this.UserCreateTS});
            this.Create.Location = new System.Drawing.Point(3, 3);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(1063, 30);
            this.Create.TabIndex = 1;
            this.Create.Text = "Show";
            // 
            // CustomerCreateTS
            // 
            this.CustomerCreateTS.AutoSize = false;
            this.CustomerCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerCreateTS.Image")));
            this.CustomerCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerCreateTS.Name = "CustomerCreateTS";
            this.CustomerCreateTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerCreateTS.Text = "Customer";
            this.CustomerCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // CustomerInvoiceCreateTS
            // 
            this.CustomerInvoiceCreateTS.AutoSize = false;
            this.CustomerInvoiceCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerInvoiceCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerInvoiceCreateTS.Image")));
            this.CustomerInvoiceCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerInvoiceCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerInvoiceCreateTS.Name = "CustomerInvoiceCreateTS";
            this.CustomerInvoiceCreateTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerInvoiceCreateTS.Text = "Customer Invoice";
            this.CustomerInvoiceCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 30);
            // 
            // SupplierCreateTS
            // 
            this.SupplierCreateTS.AutoSize = false;
            this.SupplierCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierCreateTS.Image")));
            this.SupplierCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierCreateTS.Name = "SupplierCreateTS";
            this.SupplierCreateTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierCreateTS.Text = "Supplier";
            this.SupplierCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // SupplierInvoiceCreateTS
            // 
            this.SupplierInvoiceCreateTS.AutoSize = false;
            this.SupplierInvoiceCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierInvoiceCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierInvoiceCreateTS.Image")));
            this.SupplierInvoiceCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierInvoiceCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierInvoiceCreateTS.Name = "SupplierInvoiceCreateTS";
            this.SupplierInvoiceCreateTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierInvoiceCreateTS.Text = "Supplier Invoice";
            this.SupplierInvoiceCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 30);
            // 
            // SaleCreateTS
            // 
            this.SaleCreateTS.AutoSize = false;
            this.SaleCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaleCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("SaleCreateTS.Image")));
            this.SaleCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaleCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SaleCreateTS.Name = "SaleCreateTS";
            this.SaleCreateTS.Size = new System.Drawing.Size(100, 27);
            this.SaleCreateTS.Text = "Sale";
            this.SaleCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 30);
            // 
            // RegistryCostCreateTS
            // 
            this.RegistryCostCreateTS.AutoSize = false;
            this.RegistryCostCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RegistryCostCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("RegistryCostCreateTS.Image")));
            this.RegistryCostCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RegistryCostCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.RegistryCostCreateTS.Name = "RegistryCostCreateTS";
            this.RegistryCostCreateTS.Size = new System.Drawing.Size(100, 27);
            this.RegistryCostCreateTS.Text = "Registry Cost";
            this.RegistryCostCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 30);
            // 
            // UserCreateTS
            // 
            this.UserCreateTS.AutoSize = false;
            this.UserCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("UserCreateTS.Image")));
            this.UserCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.UserCreateTS.Name = "UserCreateTS";
            this.UserCreateTS.Size = new System.Drawing.Size(100, 27);
            this.UserCreateTS.Text = "User";
            this.UserCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // GroupTP
            // 
            this.GroupTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(194)))), ((int)(((byte)(204)))));
            this.GroupTP.Controls.Add(this.Group);
            this.GroupTP.Location = new System.Drawing.Point(4, 24);
            this.GroupTP.Name = "GroupTP";
            this.GroupTP.Padding = new System.Windows.Forms.Padding(3);
            this.GroupTP.Size = new System.Drawing.Size(1069, 36);
            this.GroupTP.TabIndex = 3;
            this.GroupTP.Text = "Group";
            // 
            // Group
            // 
            this.Group.AutoSize = false;
            this.Group.BackColor = System.Drawing.Color.Transparent;
            this.Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Group.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Group.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerGroupTS,
            this.toolStripSeparator12,
            this.SupplierGroupTS});
            this.Group.Location = new System.Drawing.Point(3, 3);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(1063, 30);
            this.Group.TabIndex = 1;
            this.Group.Text = "Customer";
            // 
            // CustomerGroupTS
            // 
            this.CustomerGroupTS.AutoSize = false;
            this.CustomerGroupTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerGroupTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerGroupTS.Image")));
            this.CustomerGroupTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerGroupTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerGroupTS.Name = "CustomerGroupTS";
            this.CustomerGroupTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerGroupTS.Text = "Customer";
            this.CustomerGroupTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 30);
            // 
            // SupplierGroupTS
            // 
            this.SupplierGroupTS.AutoSize = false;
            this.SupplierGroupTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierGroupTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierGroupTS.Image")));
            this.SupplierGroupTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierGroupTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierGroupTS.Name = "SupplierGroupTS";
            this.SupplierGroupTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierGroupTS.Text = "Supplier";
            this.SupplierGroupTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // ReportTP
            // 
            this.ReportTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.ReportTP.Controls.Add(this.Report);
            this.ReportTP.Location = new System.Drawing.Point(4, 24);
            this.ReportTP.Name = "ReportTP";
            this.ReportTP.Padding = new System.Windows.Forms.Padding(3);
            this.ReportTP.Size = new System.Drawing.Size(1069, 36);
            this.ReportTP.TabIndex = 4;
            this.ReportTP.Text = "Report";
            // 
            // Report
            // 
            this.Report.AutoSize = false;
            this.Report.BackColor = System.Drawing.Color.Transparent;
            this.Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Report.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerInvoiceReportTS,
            this.toolStripSeparator4,
            this.SupplierInvoiceReportTS,
            this.toolStripSeparator5,
            this.SaleReportTS});
            this.Report.Location = new System.Drawing.Point(3, 3);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(1063, 30);
            this.Report.TabIndex = 3;
            this.Report.Text = "Customer";
            // 
            // CustomerInvoiceReportTS
            // 
            this.CustomerInvoiceReportTS.AutoSize = false;
            this.CustomerInvoiceReportTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerInvoiceReportTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerInvoiceReportTS.Image")));
            this.CustomerInvoiceReportTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerInvoiceReportTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerInvoiceReportTS.Name = "CustomerInvoiceReportTS";
            this.CustomerInvoiceReportTS.Size = new System.Drawing.Size(100, 27);
            this.CustomerInvoiceReportTS.Text = "Customer Invoice";
            this.CustomerInvoiceReportTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // SupplierInvoiceReportTS
            // 
            this.SupplierInvoiceReportTS.AutoSize = false;
            this.SupplierInvoiceReportTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierInvoiceReportTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierInvoiceReportTS.Image")));
            this.SupplierInvoiceReportTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierInvoiceReportTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierInvoiceReportTS.Name = "SupplierInvoiceReportTS";
            this.SupplierInvoiceReportTS.Size = new System.Drawing.Size(100, 27);
            this.SupplierInvoiceReportTS.Text = "Supplier Invoice";
            this.SupplierInvoiceReportTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // SaleReportTS
            // 
            this.SaleReportTS.AutoSize = false;
            this.SaleReportTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaleReportTS.Image = ((System.Drawing.Image)(resources.GetObject("SaleReportTS.Image")));
            this.SaleReportTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaleReportTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SaleReportTS.Name = "SaleReportTS";
            this.SaleReportTS.Size = new System.Drawing.Size(100, 27);
            this.SaleReportTS.Text = "Sale";
            this.SaleReportTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // TS
            // 
            this.TS.AutoSize = false;
            this.TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Logout,
            this.UserProfile,
            this.AddFavoriteButton,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator6,
            this.OpenFormDropDown});
            this.TS.Location = new System.Drawing.Point(0, 0);
            this.TS.Name = "TS";
            this.TS.Size = new System.Drawing.Size(1077, 23);
            this.TS.TabIndex = 0;
            this.TS.Text = "toolStrip1";
            // 
            // Logout
            // 
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(49, 20);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // UserProfile
            // 
            this.UserProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserProfile.Image = global::WinformDotNetFramework.Properties.Resources.User_Icon;
            this.UserProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserProfile.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.UserProfile.Name = "UserProfile";
            this.UserProfile.Size = new System.Drawing.Size(114, 20);
            this.UserProfile.Text = "toolStripButton4";
            this.UserProfile.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddFavoriteButton
            // 
            this.AddFavoriteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddFavoriteButton.AutoSize = false;
            this.AddFavoriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFavoriteButton.Image = global::WinformDotNetFramework.Properties.Resources.star_yellow_removebg;
            this.AddFavoriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFavoriteButton.Name = "AddFavoriteButton";
            this.AddFavoriteButton.Size = new System.Drawing.Size(22, 22);
            this.AddFavoriteButton.Text = "toolStripButton1";
            this.AddFavoriteButton.ToolTipText = "Add to Favorites";
            this.AddFavoriteButton.Click += new System.EventHandler(this.AddFavoriteButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(93, 20);
            this.toolStripButton2.Text = "Close All Forms";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(89, 20);
            this.toolStripButton3.Text = "Hide All Forms";
            this.toolStripButton3.ToolTipText = "Hide All";
            this.toolStripButton3.Click += new System.EventHandler(this.MinimizeAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // OpenFormDropDown
            // 
            this.OpenFormDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenFormDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFormDropDown.Name = "OpenFormDropDown";
            this.OpenFormDropDown.Size = new System.Drawing.Size(134, 20);
            this.OpenFormDropDown.Text = "Show All Open Forms";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1077, 585);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ShowTP.ResumeLayout(false);
            this.Show.ResumeLayout(false);
            this.Show.PerformLayout();
            this.AddTP.ResumeLayout(false);
            this.Create.ResumeLayout(false);
            this.Create.PerformLayout();
            this.GroupTP.ResumeLayout(false);
            this.Group.ResumeLayout(false);
            this.Group.PerformLayout();
            this.ReportTP.ResumeLayout(false);
            this.Report.ResumeLayout(false);
            this.Report.PerformLayout();
            this.TS.ResumeLayout(false);
            this.TS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ToolStrip TS;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private Panel panel2;
        private ToolStripButton Logout;
        private TabPage ShowTP;
        private TabPage AddTP;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private TabPage GroupTP;
        private ToolStripSeparator toolStripSeparator12;
        public ToolStripButton UserProfile;
        public TabControl tabControl;
        public ToolStrip Create;
        public ToolStripButton CustomerCreateTS;
        public ToolStripButton CustomerInvoiceCreateTS;
        public ToolStripButton SupplierCreateTS;
        public ToolStripButton SupplierInvoiceCreateTS;
        public ToolStripButton SaleCreateTS;
        public ToolStripButton UserCreateTS;
        public ToolStrip Group;
        public ToolStripButton CustomerGroupTS;
        public ToolStripButton SupplierGroupTS;
        public ToolStripButton AddFavoriteButton;
        private TabPage ReportTP;
        public ToolStrip Show;
        public ToolStripButton CustomerShowTS;
        public ToolStripButton CustomerInvoiceShowTS;
        private ToolStripSeparator toolStripSeparator1;
        public ToolStripButton SupplierShowTS;
        public ToolStripButton SupplierInvoiceShowTS;
        private ToolStripSeparator toolStripSeparator2;
        public ToolStripButton SaleShowTS;
        private ToolStripSeparator toolStripSeparator13;
        public ToolStripButton UserShowTS;
        public ToolStrip Report;
        public ToolStripButton CustomerInvoiceReportTS;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripButton SupplierInvoiceReportTS;
        private ToolStripSeparator toolStripSeparator5;
        public ToolStripButton SaleReportTS;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator6;
        public ToolStripDropDownButton OpenFormDropDown;
        public ToolStripButton RegistryCostShowTS;
        private ToolStripSeparator toolStripButton1;
        private ToolStripSeparator toolStripSeparator10;
        public ToolStripButton RegistryCostCreateTS;
    }
}