using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class SupplierInvoiceGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierInvoiceGridForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.RigtPanel = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchSupplierInvoice1 = new WinformDotNetFramework.Forms.control.SearchSupplierInvoice();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SupplierInvoiceDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSaleIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceInvoiceAmountTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSupplierIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSupplierNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.RigtPanel.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.RigtPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 16;
            // 
            // RigtPanel
            // 
            this.RigtPanel.Controls.Add(this.TextBoxesRightPanel);
            this.RigtPanel.Controls.Add(this.RightSideBar);
            this.RigtPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RigtPanel.Location = new System.Drawing.Point(0, 0);
            this.RigtPanel.Name = "RigtPanel";
            this.RigtPanel.Size = new System.Drawing.Size(200, 461);
            this.RigtPanel.TabIndex = 16;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchSupplierInvoice1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 369);
            this.TextBoxesRightPanel.TabIndex = 7;
            // 
            // searchSupplierInvoice1
            // 
            this.searchSupplierInvoice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSupplierInvoice1.Location = new System.Drawing.Point(0, 0);
            this.searchSupplierInvoice1.Name = "searchSupplierInvoice1";
            this.searchSupplierInvoice1.Size = new System.Drawing.Size(200, 369);
            this.searchSupplierInvoice1.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 461);
            this.RightSideBar.TabIndex = 1;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierInvoiceDgv);
            this.CenterPanel.Controls.Add(this.toolStrip1);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(584, 374);
            this.CenterPanel.TabIndex = 18;
            // 
            // SupplierInvoiceDgv
            // 
            this.SupplierInvoiceDgv.AllowUserToAddRows = false;
            this.SupplierInvoiceDgv.AllowUserToDeleteRows = false;
            this.SupplierInvoiceDgv.AllowUserToOrderColumns = true;
            this.SupplierInvoiceDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.SupplierInvoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceDgv.Location = new System.Drawing.Point(0, 25);
            this.SupplierInvoiceDgv.Name = "SupplierInvoiceDgv";
            this.SupplierInvoiceDgv.ReadOnly = true;
            this.SupplierInvoiceDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceDgv.Size = new System.Drawing.Size(584, 349);
            this.SupplierInvoiceDgv.TabIndex = 9;
            this.SupplierInvoiceDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.SupplierInvoiceDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
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
            this.toolStripButton1.Text = "toolStripButton4";
            this.toolStripButton1.ToolTipText = "Delete Selected Items";
            this.toolStripButton1.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.panel2);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 374);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(584, 87);
            this.BottomPanel.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PaginationUserControl);
            this.panel2.Location = new System.Drawing.Point(75, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 87);
            this.panel2.TabIndex = 1;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(30, 24);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(268, 43);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SupplierInvoiceIDTsmi,
            this.SupplierInvoiceSaleIDTsmi,
            this.SupplierInvoiceInvoiceAmountTsmi,
            this.SupplierInvoiceDateTsmi,
            this.SupplierInvoiceStatusTsmi,
            this.SupplierInvoiceSupplierIDTsmi,
            this.SupplierInvoiceSupplierNameTsmi,
            this.SupplierInvoiceCountryTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(196, 180);
            // 
            // SupplierInvoiceIDTsmi
            // 
            this.SupplierInvoiceIDTsmi.CheckOnClick = true;
            this.SupplierInvoiceIDTsmi.Name = "SupplierInvoiceIDTsmi";
            this.SupplierInvoiceIDTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceIDTsmi.Text = "Show ID";
            this.SupplierInvoiceIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceSaleIDTsmi
            // 
            this.SupplierInvoiceSaleIDTsmi.Checked = true;
            this.SupplierInvoiceSaleIDTsmi.CheckOnClick = true;
            this.SupplierInvoiceSaleIDTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceSaleIDTsmi.Name = "SupplierInvoiceSaleIDTsmi";
            this.SupplierInvoiceSaleIDTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceSaleIDTsmi.Text = "Show Sale ID";
            this.SupplierInvoiceSaleIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceInvoiceAmountTsmi
            // 
            this.SupplierInvoiceInvoiceAmountTsmi.Checked = true;
            this.SupplierInvoiceInvoiceAmountTsmi.CheckOnClick = true;
            this.SupplierInvoiceInvoiceAmountTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceInvoiceAmountTsmi.Name = "SupplierInvoiceInvoiceAmountTsmi";
            this.SupplierInvoiceInvoiceAmountTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceInvoiceAmountTsmi.Text = "Show Invoice Amount";
            this.SupplierInvoiceInvoiceAmountTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceDateTsmi
            // 
            this.SupplierInvoiceDateTsmi.Checked = true;
            this.SupplierInvoiceDateTsmi.CheckOnClick = true;
            this.SupplierInvoiceDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceDateTsmi.Name = "SupplierInvoiceDateTsmi";
            this.SupplierInvoiceDateTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceDateTsmi.Text = "Show Invoice Date";
            this.SupplierInvoiceDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceStatusTsmi
            // 
            this.SupplierInvoiceStatusTsmi.Checked = true;
            this.SupplierInvoiceStatusTsmi.CheckOnClick = true;
            this.SupplierInvoiceStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceStatusTsmi.Name = "SupplierInvoiceStatusTsmi";
            this.SupplierInvoiceStatusTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceStatusTsmi.Text = "Show Status";
            this.SupplierInvoiceStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceSupplierIDTsmi
            // 
            this.SupplierInvoiceSupplierIDTsmi.CheckOnClick = true;
            this.SupplierInvoiceSupplierIDTsmi.Name = "SupplierInvoiceSupplierIDTsmi";
            this.SupplierInvoiceSupplierIDTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceSupplierIDTsmi.Text = "Show Supplier ID";
            this.SupplierInvoiceSupplierIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceSupplierNameTsmi
            // 
            this.SupplierInvoiceSupplierNameTsmi.Checked = true;
            this.SupplierInvoiceSupplierNameTsmi.CheckOnClick = true;
            this.SupplierInvoiceSupplierNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceSupplierNameTsmi.Name = "SupplierInvoiceSupplierNameTsmi";
            this.SupplierInvoiceSupplierNameTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceSupplierNameTsmi.Text = "Show Supplier Name";
            this.SupplierInvoiceSupplierNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCountryTsmi
            // 
            this.SupplierInvoiceCountryTsmi.Checked = true;
            this.SupplierInvoiceCountryTsmi.CheckOnClick = true;
            this.SupplierInvoiceCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceCountryTsmi.Name = "SupplierInvoiceCountryTsmi";
            this.SupplierInvoiceCountryTsmi.Size = new System.Drawing.Size(195, 22);
            this.SupplierInvoiceCountryTsmi.Text = "Show Supplier Country";
            this.SupplierInvoiceCountryTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierInvoiceGridForm";
            this.Text = "SupplierInvoiceForm";
            this.Load += new System.EventHandler(this.SupplierInvoiceGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.RigtPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel RigtPanel;
        private Panel TextBoxesRightPanel;
        private control.RightSideBarUserControl RightSideBar;
        private DataGridView SupplierInvoiceDgv;
        public Panel CenterPanel;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem SupplierInvoiceIDTsmi;
        private ToolStripMenuItem SupplierInvoiceSaleIDTsmi;
        private ToolStripMenuItem SupplierInvoiceInvoiceAmountTsmi;
        private ToolStripMenuItem SupplierInvoiceDateTsmi;
        private ToolStripMenuItem SupplierInvoiceStatusTsmi;
        private ToolStripMenuItem SupplierInvoiceSupplierIDTsmi;
        private ToolStripMenuItem SupplierInvoiceSupplierNameTsmi;
        private ToolStripMenuItem SupplierInvoiceCountryTsmi;
        private Panel panel2;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private control.SearchSupplierInvoice searchSupplierInvoice1;
        private ToolStripButton ToggleEditButton;
    }
}