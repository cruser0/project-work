namespace Winform
{
    partial class mainformtest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainformtest));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CustomerStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.customerInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerInvoiceCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuppliersStripToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierInvoiceCostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 60);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 34);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1157, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton1.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton3.Text = "Add";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            this.menuStrip1.Size = new System.Drawing.Size(1157, 34);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CustomerStripButton
            // 
            this.CustomerStripButton.ForeColor = System.Drawing.Color.Black;
            this.CustomerStripButton.Image = global::Winform.Properties.Resources.User_Icon;
            this.CustomerStripButton.Name = "CustomerStripButton";
            this.CustomerStripButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CustomerStripButton.Size = new System.Drawing.Size(92, 20);
            this.CustomerStripButton.Text = "Customers";
            // 
            // customerInvoicesToolStripMenuItem
            // 
            this.customerInvoicesToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.customerInvoicesToolStripMenuItem.Name = "customerInvoicesToolStripMenuItem";
            this.customerInvoicesToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.customerInvoicesToolStripMenuItem.Text = "Customer Invoices";
            // 
            // customerInvoiceCostsToolStripMenuItem
            // 
            this.customerInvoiceCostsToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.customerInvoiceCostsToolStripMenuItem.Name = "customerInvoiceCostsToolStripMenuItem";
            this.customerInvoiceCostsToolStripMenuItem.Size = new System.Drawing.Size(160, 20);
            this.customerInvoiceCostsToolStripMenuItem.Text = "Customer Invoice Costs";
            // 
            // SuppliersStripToolButton
            // 
            this.SuppliersStripToolButton.Image = global::Winform.Properties.Resources.Supplier_Icon;
            this.SuppliersStripToolButton.Name = "SuppliersStripToolButton";
            this.SuppliersStripToolButton.Size = new System.Drawing.Size(83, 20);
            this.SuppliersStripToolButton.Text = "Suppliers";
            // 
            // supplierInvoicesToolStripMenuItem
            // 
            this.supplierInvoicesToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.supplierInvoicesToolStripMenuItem.Name = "supplierInvoicesToolStripMenuItem";
            this.supplierInvoicesToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.supplierInvoicesToolStripMenuItem.Text = "Supplier Invoices";
            // 
            // supplierInvoiceCostsToolStripMenuItem
            // 
            this.supplierInvoiceCostsToolStripMenuItem.Image = global::Winform.Properties.Resources.Invoice_Icon;
            this.supplierInvoiceCostsToolStripMenuItem.Name = "supplierInvoiceCostsToolStripMenuItem";
            this.supplierInvoiceCostsToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.supplierInvoiceCostsToolStripMenuItem.Text = "Supplier Invoice Costs";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Image = global::Winform.Properties.Resources.Sale_Icon;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // mainformtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 838);
            this.Controls.Add(this.panel1);
            this.Name = "mainformtest";
            this.Text = "mainformtest";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton3;
        private ToolStripSeparator toolStripSeparator3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem CustomerStripButton;
        private ToolStripMenuItem customerInvoicesToolStripMenuItem;
        private ToolStripMenuItem customerInvoiceCostsToolStripMenuItem;
        private ToolStripMenuItem SuppliersStripToolButton;
        private ToolStripMenuItem supplierInvoicesToolStripMenuItem;
        private ToolStripMenuItem supplierInvoiceCostsToolStripMenuItem;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem adminToolStripMenuItem;
    }
}