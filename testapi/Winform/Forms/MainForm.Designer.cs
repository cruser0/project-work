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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CustomerStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCustomersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCustomersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.customerInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCustomerInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerInvoiceCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCustomerInvoicesCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSupplierInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplierInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierInvoiceCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSupplierInvoicesCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerStripButton,
            this.customerInvoicesToolStripMenuItem,
            this.customerInvoiceCostsToolStripMenuItem,
            this.SuppliersStripToolButton,
            this.supplierInvoicesToolStripMenuItem,
            this.supplierInvoiceCostsToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(50, 12, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1159, 34);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CustomerStripButton
            // 
            this.CustomerStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowCustomersStripToolButton,
            this.AddCustomersStripToolButton});
            this.CustomerStripButton.ForeColor = System.Drawing.Color.Black;
            this.CustomerStripButton.Image = global::Winform.Properties.Resources.User_Icon;
            this.CustomerStripButton.Name = "CustomerStripButton";
            this.CustomerStripButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CustomerStripButton.Size = new System.Drawing.Size(92, 20);
            this.CustomerStripButton.Text = "Customers";
            // 
            // ShowCustomersStripToolButton
            // 
            this.ShowCustomersStripToolButton.Name = "ShowCustomersStripToolButton";
            this.ShowCustomersStripToolButton.Size = new System.Drawing.Size(163, 22);
            this.ShowCustomersStripToolButton.Tag = "Show Customers";
            this.ShowCustomersStripToolButton.Text = "Show Customers";
            this.ShowCustomersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddCustomersStripToolButton
            // 
            this.AddCustomersStripToolButton.Name = "AddCustomersStripToolButton";
            this.AddCustomersStripToolButton.Size = new System.Drawing.Size(163, 22);
            this.AddCustomersStripToolButton.Text = "Add Customer";
            this.AddCustomersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // customerInvoicesToolStripMenuItem
            // 
            this.customerInvoicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCustomerInvoicesToolStripMenuItem,
            this.addCustomerInvoiceToolStripMenuItem});
            this.customerInvoicesToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.customerInvoicesToolStripMenuItem.Name = "customerInvoicesToolStripMenuItem";
            this.customerInvoicesToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.customerInvoicesToolStripMenuItem.Text = "Customer Invoices";
            // 
            // showCustomerInvoicesToolStripMenuItem
            // 
            this.showCustomerInvoicesToolStripMenuItem.Name = "showCustomerInvoicesToolStripMenuItem";
            this.showCustomerInvoicesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showCustomerInvoicesToolStripMenuItem.Text = "Show Customer Invoices";
            this.showCustomerInvoicesToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // addCustomerInvoiceToolStripMenuItem
            // 
            this.addCustomerInvoiceToolStripMenuItem.Name = "addCustomerInvoiceToolStripMenuItem";
            this.addCustomerInvoiceToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addCustomerInvoiceToolStripMenuItem.Text = "Add Customer Invoice";
            this.addCustomerInvoiceToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // customerInvoiceCostsToolStripMenuItem
            // 
            this.customerInvoiceCostsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCustomerInvoicesCostsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.customerInvoiceCostsToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.customerInvoiceCostsToolStripMenuItem.Name = "customerInvoiceCostsToolStripMenuItem";
            this.customerInvoiceCostsToolStripMenuItem.Size = new System.Drawing.Size(160, 20);
            this.customerInvoiceCostsToolStripMenuItem.Text = "Customer Invoice Costs";
            // 
            // showCustomerInvoicesCostsToolStripMenuItem
            // 
            this.showCustomerInvoicesCostsToolStripMenuItem.Name = "showCustomerInvoicesCostsToolStripMenuItem";
            this.showCustomerInvoicesCostsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.showCustomerInvoicesCostsToolStripMenuItem.Text = "Show Customer Invoices Costs";
            this.showCustomerInvoicesCostsToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem2.Text = "Add Customer Invoice Cost";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // SuppliersStripToolButton
            // 
            this.SuppliersStripToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowSuppliersStripToolButton,
            this.AddSuppliersStripToolButton});
            this.SuppliersStripToolButton.Image = global::Winform.Properties.Resources.Supplier_Icon;
            this.SuppliersStripToolButton.Name = "SuppliersStripToolButton";
            this.SuppliersStripToolButton.Size = new System.Drawing.Size(83, 20);
            this.SuppliersStripToolButton.Text = "Suppliers";
            // 
            // ShowSuppliersStripToolButton
            // 
            this.ShowSuppliersStripToolButton.Name = "ShowSuppliersStripToolButton";
            this.ShowSuppliersStripToolButton.Size = new System.Drawing.Size(154, 22);
            this.ShowSuppliersStripToolButton.Tag = "Show Suppliers";
            this.ShowSuppliersStripToolButton.Text = "Show Suppliers";
            this.ShowSuppliersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // AddSuppliersStripToolButton
            // 
            this.AddSuppliersStripToolButton.Name = "AddSuppliersStripToolButton";
            this.AddSuppliersStripToolButton.Size = new System.Drawing.Size(154, 22);
            this.AddSuppliersStripToolButton.Text = "Add Supplier";
            this.AddSuppliersStripToolButton.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // supplierInvoicesToolStripMenuItem
            // 
            this.supplierInvoicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSupplierInvoicesToolStripMenuItem,
            this.addSupplierInvoiceToolStripMenuItem});
            this.supplierInvoicesToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.supplierInvoicesToolStripMenuItem.Name = "supplierInvoicesToolStripMenuItem";
            this.supplierInvoicesToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.supplierInvoicesToolStripMenuItem.Text = "Supplier Invoices";
            // 
            // showSupplierInvoicesToolStripMenuItem
            // 
            this.showSupplierInvoicesToolStripMenuItem.Name = "showSupplierInvoicesToolStripMenuItem";
            this.showSupplierInvoicesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.showSupplierInvoicesToolStripMenuItem.Text = "Show Supplier Invoices";
            this.showSupplierInvoicesToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // addSupplierInvoiceToolStripMenuItem
            // 
            this.addSupplierInvoiceToolStripMenuItem.Name = "addSupplierInvoiceToolStripMenuItem";
            this.addSupplierInvoiceToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addSupplierInvoiceToolStripMenuItem.Text = "Add Supplier Invoice";
            this.addSupplierInvoiceToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // supplierInvoiceCostsToolStripMenuItem
            // 
            this.supplierInvoiceCostsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSupplierInvoicesCostsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.supplierInvoiceCostsToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.supplierInvoiceCostsToolStripMenuItem.Name = "supplierInvoiceCostsToolStripMenuItem";
            this.supplierInvoiceCostsToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.supplierInvoiceCostsToolStripMenuItem.Text = "Supplier Invoice Costs";
            // 
            // showSupplierInvoicesCostsToolStripMenuItem
            // 
            this.showSupplierInvoicesCostsToolStripMenuItem.Name = "showSupplierInvoicesCostsToolStripMenuItem";
            this.showSupplierInvoicesCostsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.showSupplierInvoicesCostsToolStripMenuItem.Text = "Show Supplier Invoices Costs";
            this.showSupplierInvoicesCostsToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem1.Text = "Add Supplier Invoices Cost";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSalesToolStripMenuItem,
            this.addSalesToolStripMenuItem});
            this.salesToolStripMenuItem.Image = global::Winform.Properties.Resources.Sale_Icon;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // showSalesToolStripMenuItem
            // 
            this.showSalesToolStripMenuItem.Name = "showSalesToolStripMenuItem";
            this.showSalesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.showSalesToolStripMenuItem.Text = "Show Sales";
            this.showSalesToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // addSalesToolStripMenuItem
            // 
            this.addSalesToolStripMenuItem.Name = "addSalesToolStripMenuItem";
            this.addSalesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addSalesToolStripMenuItem.Text = "Add Sale";
            this.addSalesToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUsersToolStripMenuItem,
            this.addUserToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // showUsersToolStripMenuItem
            // 
            this.showUsersToolStripMenuItem.Name = "showUsersToolStripMenuItem";
            this.showUsersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.showUsersToolStripMenuItem.Text = "Show Users";
            this.showUsersToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.buttonOpenChild_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MenuPanel.Controls.Add(this.Logo);
            this.MenuPanel.Controls.Add(this.menuStrip1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1159, 46);
            this.MenuPanel.TabIndex = 6;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(50, 50);
            this.Logo.TabIndex = 7;
            this.Logo.TabStop = false;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.Connection = null;
            this.sqlCommand1.Notification = null;
            this.sqlCommand1.Transaction = null;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1159, 675);
            this.Controls.Add(this.MenuPanel);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem CustomerStripButton;
        private ToolStripMenuItem ShowCustomersStripToolButton;
        private ToolStripMenuItem AddCustomersStripToolButton;
        private ToolStripMenuItem SuppliersStripToolButton;
        private ToolStripMenuItem ShowSuppliersStripToolButton;
        private ToolStripMenuItem AddSuppliersStripToolButton;
        private ToolStripMenuItem supplierInvoicesToolStripMenuItem;
        private ToolStripMenuItem showSupplierInvoicesToolStripMenuItem;
        private ToolStripMenuItem addSupplierInvoiceToolStripMenuItem;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem showSalesToolStripMenuItem;
        private ToolStripMenuItem addSalesToolStripMenuItem;
        private Panel MenuPanel;
        private PictureBox Logo;
        private ToolStripMenuItem customerInvoicesToolStripMenuItem;
        private ToolStripMenuItem showCustomerInvoicesToolStripMenuItem;
        private ToolStripMenuItem addCustomerInvoiceToolStripMenuItem;
        private ToolStripMenuItem supplierInvoiceCostsToolStripMenuItem;
        private ToolStripMenuItem showSupplierInvoicesCostsToolStripMenuItem;
        private ToolStripMenuItem customerInvoiceCostsToolStripMenuItem;
        private ToolStripMenuItem showCustomerInvoicesCostsToolStripMenuItem;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem showUsersToolStripMenuItem;
        private ToolStripMenuItem addUserToolStripMenuItem;
    }
}