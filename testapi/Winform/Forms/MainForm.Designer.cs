namespace Winform
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
            this.CustomerInvoiceCostShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierShowTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceShowTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceCostShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaleShowTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UserShowTS = new System.Windows.Forms.ToolStripButton();
            this.EditTP = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.AddTP = new System.Windows.Forms.TabPage();
            this.Create = new System.Windows.Forms.ToolStrip();
            this.CustomerCreateTS = new System.Windows.Forms.ToolStripButton();
            this.CustomerInvoiceCreateTS = new System.Windows.Forms.ToolStripButton();
            this.CustomerInvoiceCostCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierCreateTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceCreateTS = new System.Windows.Forms.ToolStripButton();
            this.SupplierInvoiceCostCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SaleCreateTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.UserCreateTS = new System.Windows.Forms.ToolStripButton();
            this.GroupTP = new System.Windows.Forms.TabPage();
            this.Group = new System.Windows.Forms.ToolStrip();
            this.CustomerGroupTS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.SupplierGroupTS = new System.Windows.Forms.ToolStripButton();
            this.TS = new System.Windows.Forms.ToolStrip();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.UserProfile = new System.Windows.Forms.ToolStripButton();
            this.AddFavoriteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ShowTP.SuspendLayout();
            this.Show.SuspendLayout();
            this.EditTP.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.AddTP.SuspendLayout();
            this.Create.SuspendLayout();
            this.GroupTP.SuspendLayout();
            this.Group.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1159, 89);
            this.panel1.TabIndex = 8;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ShowTP);
            this.tabControl.Controls.Add(this.EditTP);
            this.tabControl.Controls.Add(this.AddTP);
            this.tabControl.Controls.Add(this.GroupTP);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1159, 64);
            this.tabControl.TabIndex = 0;
            // 
            // ShowTP
            // 
            this.ShowTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.ShowTP.Controls.Add(this.Show);
            this.ShowTP.Location = new System.Drawing.Point(4, 24);
            this.ShowTP.Name = "ShowTP";
            this.ShowTP.Padding = new System.Windows.Forms.Padding(3);
            this.ShowTP.Size = new System.Drawing.Size(1151, 36);
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
            this.CustomerInvoiceCostShowTS,
            this.toolStripSeparator1,
            this.SupplierShowTS,
            this.SupplierInvoiceShowTS,
            this.SupplierInvoiceCostShowTS,
            this.toolStripSeparator2,
            this.SaleShowTS,
            this.toolStripSeparator3,
            this.UserShowTS});
            this.Show.Location = new System.Drawing.Point(3, 3);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(1145, 30);
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
            // CustomerInvoiceCostShowTS
            // 
            this.CustomerInvoiceCostShowTS.AutoSize = false;
            this.CustomerInvoiceCostShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerInvoiceCostShowTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerInvoiceCostShowTS.Image")));
            this.CustomerInvoiceCostShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerInvoiceCostShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerInvoiceCostShowTS.Name = "CustomerInvoiceCostShowTS";
            this.CustomerInvoiceCostShowTS.Size = new System.Drawing.Size(125, 27);
            this.CustomerInvoiceCostShowTS.Text = "Customer Invoice Cost";
            this.CustomerInvoiceCostShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
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
            // SupplierInvoiceCostShowTS
            // 
            this.SupplierInvoiceCostShowTS.AutoSize = false;
            this.SupplierInvoiceCostShowTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierInvoiceCostShowTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierInvoiceCostShowTS.Image")));
            this.SupplierInvoiceCostShowTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierInvoiceCostShowTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierInvoiceCostShowTS.Name = "SupplierInvoiceCostShowTS";
            this.SupplierInvoiceCostShowTS.Size = new System.Drawing.Size(125, 27);
            this.SupplierInvoiceCostShowTS.Text = "Supplier Invoice Cost";
            this.SupplierInvoiceCostShowTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
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
            // EditTP
            // 
            this.EditTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(222)))));
            this.EditTP.Controls.Add(this.toolStrip3);
            this.EditTP.Location = new System.Drawing.Point(4, 24);
            this.EditTP.Name = "EditTP";
            this.EditTP.Padding = new System.Windows.Forms.Padding(3);
            this.EditTP.Size = new System.Drawing.Size(1151, 36);
            this.EditTP.TabIndex = 1;
            this.EditTP.Text = "Edit";
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator4,
            this.toolStripButton15,
            this.toolStripButton16,
            this.toolStripButton17,
            this.toolStripSeparator5,
            this.toolStripButton18,
            this.toolStripSeparator6,
            this.toolStripButton19});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1145, 30);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.AutoSize = false;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton12.Text = "toolStripButton4";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.AutoSize = false;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton13.Text = "toolStripButton5";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.AutoSize = false;
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton14.Text = "toolStripButton6";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.AutoSize = false;
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton15.Text = "toolStripButton7";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.AutoSize = false;
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton16.Text = "toolStripButton8";
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.AutoSize = false;
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton17.Text = "toolStripButton9";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.AutoSize = false;
            this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton18.Text = "toolStripButton10";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.AutoSize = false;
            this.toolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(100, 27);
            this.toolStripButton19.Text = "toolStripButton11";
            // 
            // AddTP
            // 
            this.AddTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(204)))), ((int)(((byte)(214)))));
            this.AddTP.Controls.Add(this.Create);
            this.AddTP.Location = new System.Drawing.Point(4, 24);
            this.AddTP.Name = "AddTP";
            this.AddTP.Padding = new System.Windows.Forms.Padding(3);
            this.AddTP.Size = new System.Drawing.Size(1151, 36);
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
            this.CustomerInvoiceCostCreateTS,
            this.toolStripSeparator7,
            this.SupplierCreateTS,
            this.SupplierInvoiceCreateTS,
            this.SupplierInvoiceCostCreateTS,
            this.toolStripSeparator8,
            this.SaleCreateTS,
            this.toolStripSeparator9,
            this.UserCreateTS});
            this.Create.Location = new System.Drawing.Point(3, 3);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(1145, 30);
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
            // CustomerInvoiceCostCreateTS
            // 
            this.CustomerInvoiceCostCreateTS.AutoSize = false;
            this.CustomerInvoiceCostCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomerInvoiceCostCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("CustomerInvoiceCostCreateTS.Image")));
            this.CustomerInvoiceCostCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CustomerInvoiceCostCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.CustomerInvoiceCostCreateTS.Name = "CustomerInvoiceCostCreateTS";
            this.CustomerInvoiceCostCreateTS.Size = new System.Drawing.Size(125, 27);
            this.CustomerInvoiceCostCreateTS.Text = "Customer Invoice Cost";
            this.CustomerInvoiceCostCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
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
            // SupplierInvoiceCostCreateTS
            // 
            this.SupplierInvoiceCostCreateTS.AutoSize = false;
            this.SupplierInvoiceCostCreateTS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SupplierInvoiceCostCreateTS.Image = ((System.Drawing.Image)(resources.GetObject("SupplierInvoiceCostCreateTS.Image")));
            this.SupplierInvoiceCostCreateTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SupplierInvoiceCostCreateTS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.SupplierInvoiceCostCreateTS.Name = "SupplierInvoiceCostCreateTS";
            this.SupplierInvoiceCostCreateTS.Size = new System.Drawing.Size(125, 27);
            this.SupplierInvoiceCostCreateTS.Text = "Supplier Invoice Cost";
            this.SupplierInvoiceCostCreateTS.Click += new System.EventHandler(this.buttonOpenChild_Click);
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
            this.GroupTP.Size = new System.Drawing.Size(1151, 36);
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
            this.Group.Size = new System.Drawing.Size(1145, 30);
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
            // TS
            // 
            this.TS.AutoSize = false;
            this.TS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Logout,
            this.UserProfile,
            this.AddFavoriteButton,
            this.toolStripButton2,
            this.toolStripButton3});
            this.TS.Location = new System.Drawing.Point(0, 0);
            this.TS.Name = "TS";
            this.TS.Size = new System.Drawing.Size(1159, 25);
            this.TS.TabIndex = 0;
            this.TS.Text = "toolStrip1";
            // 
            // Logout
            // 
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = global::Winform.Properties.Resources.User_Icon;
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(49, 22);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // UserProfile
            // 
            this.UserProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserProfile.Image = global::Winform.Properties.Resources.User_Icon;
            this.UserProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserProfile.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.UserProfile.Name = "UserProfile";
            this.UserProfile.Size = new System.Drawing.Size(114, 22);
            this.UserProfile.Text = "toolStripButton4";
            this.UserProfile.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddFavoriteButton
            // 
            this.AddFavoriteButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddFavoriteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFavoriteButton.Image = global::Winform.Properties.Resources.star25x25;
            this.AddFavoriteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFavoriteButton.Name = "AddFavoriteButton";
            this.AddFavoriteButton.Size = new System.Drawing.Size(23, 22);
            this.AddFavoriteButton.Text = "toolStripButton1";
            this.AddFavoriteButton.ToolTipText = "Add to Favorites";
            this.AddFavoriteButton.Click += new System.EventHandler(this.AddFavoriteButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(89, 22);
            this.toolStripButton3.Text = "Hide All Forms";
            this.toolStripButton3.ToolTipText = "Hide All";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 89);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1159, 586);
            this.MainPanel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1159, 675);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ShowTP.ResumeLayout(false);
            this.Show.ResumeLayout(false);
            this.Show.PerformLayout();
            this.EditTP.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.AddTP.ResumeLayout(false);
            this.Create.ResumeLayout(false);
            this.Create.PerformLayout();
            this.GroupTP.ResumeLayout(false);
            this.Group.ResumeLayout(false);
            this.Group.PerformLayout();
            this.TS.ResumeLayout(false);
            this.TS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ToolStrip TS;
        private ToolStripButton AddFavoriteButton;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton UserProfile;
        private Panel panel2;
        private ToolStripButton Logout;
        private Panel MainPanel;
        private TabControl tabControl;
        private TabPage ShowTP;
        private ToolStrip Show;
        private ToolStripButton CustomerShowTS;
        private ToolStripButton CustomerInvoiceShowTS;
        private ToolStripButton CustomerInvoiceCostShowTS;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SupplierShowTS;
        private ToolStripButton SupplierInvoiceShowTS;
        private ToolStripButton SupplierInvoiceCostShowTS;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton SaleShowTS;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton UserShowTS;
        private TabPage EditTP;
        private ToolStrip toolStrip3;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton13;
        private ToolStripButton toolStripButton14;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButton15;
        private ToolStripButton toolStripButton16;
        private ToolStripButton toolStripButton17;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButton18;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButton19;
        private TabPage AddTP;
        private ToolStrip Create;
        private ToolStripButton CustomerCreateTS;
        private ToolStripButton CustomerInvoiceCreateTS;
        private ToolStripButton CustomerInvoiceCostCreateTS;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton SupplierCreateTS;
        private ToolStripButton SupplierInvoiceCreateTS;
        private ToolStripButton SupplierInvoiceCostCreateTS;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton SaleCreateTS;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton UserCreateTS;
        private TabPage GroupTP;
        private ToolStrip Group;
        private ToolStripButton CustomerGroupTS;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton SupplierGroupTS;
    }
}