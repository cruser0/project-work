using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class SupplierInvoiceCostGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierInvoiceCostGridForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SupplierInvoiceCostDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PdfTSB = new System.Windows.Forms.ToolStripButton();
            this.ExcelTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchSupplierInvoiceCost1 = new WinformDotNetFramework.Forms.control.SearchSupplierInvoiceCost();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.PaginationPanel = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierInvoiceCostIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostCostTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostQuantityTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.PaginationPanel.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SupplierInvoiceCostDgv);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 374);
            this.panel1.TabIndex = 0;
            // 
            // SupplierInvoiceCostDgv
            // 
            this.SupplierInvoiceCostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceCostDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.SupplierInvoiceCostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceCostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceCostDgv.Location = new System.Drawing.Point(0, 25);
            this.SupplierInvoiceCostDgv.Name = "SupplierInvoiceCostDgv";
            this.SupplierInvoiceCostDgv.ReadOnly = true;
            this.SupplierInvoiceCostDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceCostDgv.Size = new System.Drawing.Size(613, 349);
            this.SupplierInvoiceCostDgv.TabIndex = 0;
            this.SupplierInvoiceCostDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.SupplierInvoiceCostDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.PdfTSB,
            this.ExcelTSB,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(613, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WinformDotNetFramework.Properties.Resources.save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton1";
            this.toolStripButton2.Click += new System.EventHandler(this.MassUpdateTSB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PdfTSB
            // 
            this.PdfTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PdfTSB.Image = ((System.Drawing.Image)(resources.GetObject("PdfTSB.Image")));
            this.PdfTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PdfTSB.Name = "PdfTSB";
            this.PdfTSB.Size = new System.Drawing.Size(32, 22);
            this.PdfTSB.Text = "PDF";
            this.PdfTSB.Click += new System.EventHandler(this.Pdf_ClickBtn);
            // 
            // ExcelTSB
            // 
            this.ExcelTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExcelTSB.Image = ((System.Drawing.Image)(resources.GetObject("ExcelTSB.Image")));
            this.ExcelTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcelTSB.Name = "ExcelTSB";
            this.ExcelTSB.Size = new System.Drawing.Size(38, 22);
            this.ExcelTSB.Text = "Excel";
            this.ExcelTSB.Click += new System.EventHandler(this.Excel_ClickBtn);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WinformDotNetFramework.Properties.Resources.trash;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton4";
            this.toolStripButton1.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxesRightPanel);
            this.panel2.Controls.Add(this.RightSideBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(613, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 461);
            this.panel2.TabIndex = 1;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchSupplierInvoiceCost1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(171, 310);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // searchSupplierInvoiceCost1
            // 
            this.searchSupplierInvoiceCost1.Location = new System.Drawing.Point(0, 0);
            this.searchSupplierInvoiceCost1.Name = "searchSupplierInvoiceCost1";
            this.searchSupplierInvoiceCost1.Size = new System.Drawing.Size(171, 215);
            this.searchSupplierInvoiceCost1.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(171, 461);
            this.RightSideBar.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.PaginationPanel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 374);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(613, 87);
            this.BottomPanel.TabIndex = 2;
            // 
            // PaginationPanel
            // 
            this.PaginationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.PaginationPanel.Controls.Add(this.PaginationUserControl);
            this.PaginationPanel.Location = new System.Drawing.Point(75, 0);
            this.PaginationPanel.Name = "PaginationPanel";
            this.PaginationPanel.Size = new System.Drawing.Size(349, 87);
            this.PaginationPanel.TabIndex = 1;
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
            this.SupplierInvoiceCostIDTsmi,
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi,
            this.SupplierInvoiceCostCostTsmi,
            this.SupplierInvoiceCostQuantityTsmi,
            this.SupplierInvoiceCostNameTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(214, 114);
            // 
            // SupplierInvoiceCostIDTsmi
            // 
            this.SupplierInvoiceCostIDTsmi.CheckOnClick = true;
            this.SupplierInvoiceCostIDTsmi.Name = "SupplierInvoiceCostIDTsmi";
            this.SupplierInvoiceCostIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.SupplierInvoiceCostIDTsmi.Text = "Show ID";
            this.SupplierInvoiceCostIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCostSupplierInvoiceIDTsmi
            // 
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.Checked = true;
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.CheckOnClick = true;
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.Name = "SupplierInvoiceCostSupplierInvoiceIDTsmi";
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.Text = "Show Customer Invoice ID";
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCostCostTsmi
            // 
            this.SupplierInvoiceCostCostTsmi.Checked = true;
            this.SupplierInvoiceCostCostTsmi.CheckOnClick = true;
            this.SupplierInvoiceCostCostTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceCostCostTsmi.Name = "SupplierInvoiceCostCostTsmi";
            this.SupplierInvoiceCostCostTsmi.Size = new System.Drawing.Size(213, 22);
            this.SupplierInvoiceCostCostTsmi.Text = "Show Cost";
            this.SupplierInvoiceCostCostTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCostQuantityTsmi
            // 
            this.SupplierInvoiceCostQuantityTsmi.Checked = true;
            this.SupplierInvoiceCostQuantityTsmi.CheckOnClick = true;
            this.SupplierInvoiceCostQuantityTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceCostQuantityTsmi.Name = "SupplierInvoiceCostQuantityTsmi";
            this.SupplierInvoiceCostQuantityTsmi.Size = new System.Drawing.Size(213, 22);
            this.SupplierInvoiceCostQuantityTsmi.Text = "Show Quantity";
            this.SupplierInvoiceCostQuantityTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCostNameTsmi
            // 
            this.SupplierInvoiceCostNameTsmi.Checked = true;
            this.SupplierInvoiceCostNameTsmi.CheckOnClick = true;
            this.SupplierInvoiceCostNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierInvoiceCostNameTsmi.Name = "SupplierInvoiceCostNameTsmi";
            this.SupplierInvoiceCostNameTsmi.Size = new System.Drawing.Size(213, 22);
            this.SupplierInvoiceCostNameTsmi.Text = "Show Description Name";
            this.SupplierInvoiceCostNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierInvoiceCostGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierInvoiceCostGridForm";
            this.Text = "SupplierInvoiceCostGridForm";
            this.Load += new System.EventHandler(this.SupplierInvoiceCostGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.PaginationPanel.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView SupplierInvoiceCostDgv;
        private Panel panel2;
        private control.RightSideBarUserControl RightSideBar;
        private Panel TextBoxesRightPanel;
        public Panel panel1;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem SupplierInvoiceCostIDTsmi;
        private ToolStripMenuItem SupplierInvoiceCostSupplierInvoiceIDTsmi;
        private ToolStripMenuItem SupplierInvoiceCostCostTsmi;
        private ToolStripMenuItem SupplierInvoiceCostQuantityTsmi;
        private ToolStripMenuItem SupplierInvoiceCostNameTsmi;
        private Panel PaginationPanel;
        public ToolStrip toolStrip1;
        private ToolStripButton PdfTSB;
        private ToolStripButton ExcelTSB;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private control.SearchSupplierInvoiceCost searchSupplierInvoiceCost1;
        private ToolStripSeparator toolStripSeparator2;
    }
}