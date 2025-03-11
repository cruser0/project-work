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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostToTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.CostFromTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(585, 361);
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
            this.SupplierInvoiceCostDgv.Size = new System.Drawing.Size(585, 336);
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
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            this.panel2.Location = new System.Drawing.Point(585, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 461);
            this.panel2.TabIndex = 1;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.NameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CostFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostLbl);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 103);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 358);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(4, 174);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 23);
            this.NameTxt.TabIndex = 15;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameLbl.Location = new System.Drawing.Point(4, 153);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(119, 17);
            this.NameLbl.TabIndex = 16;
            this.NameLbl.Text = "Description Name";
            // 
            // CostToTxt
            // 
            this.CostToTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostToTxt.Location = new System.Drawing.Point(4, 122);
            this.CostToTxt.Name = "CostToTxt";
            this.CostToTxt.Size = new System.Drawing.Size(180, 23);
            this.CostToTxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(4, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cost To";
            // 
            // CostFromTxt
            // 
            this.CostFromTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostFromTxt.Location = new System.Drawing.Point(3, 68);
            this.CostFromTxt.Name = "CostFromTxt";
            this.CostFromTxt.Size = new System.Drawing.Size(180, 23);
            this.CostFromTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceIDTxt.Location = new System.Drawing.Point(3, 21);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(180, 23);
            this.InvoiceIDTxt.TabIndex = 11;
            // 
            // InvoiceIDLbl
            // 
            this.InvoiceIDLbl.AutoSize = true;
            this.InvoiceIDLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InvoiceIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceIDLbl.Location = new System.Drawing.Point(3, 0);
            this.InvoiceIDLbl.Name = "InvoiceIDLbl";
            this.InvoiceIDLbl.Size = new System.Drawing.Size(70, 17);
            this.InvoiceIDLbl.TabIndex = 3;
            this.InvoiceIDLbl.Text = "Invoice ID";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CostLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostLbl.Location = new System.Drawing.Point(3, 47);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(71, 17);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost From";
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
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.PaginationPanel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 361);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(585, 100);
            this.BottomPanel.TabIndex = 2;
            // 
            // PaginationPanel
            // 
            this.PaginationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.PaginationPanel.Controls.Add(this.PaginationUserControl);
            this.PaginationPanel.Location = new System.Drawing.Point(87, 0);
            this.PaginationPanel.Name = "PaginationPanel";
            this.PaginationPanel.Size = new System.Drawing.Size(407, 100);
            this.PaginationPanel.TabIndex = 1;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(35, 28);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(313, 50);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 461);
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
            this.TextBoxesRightPanel.PerformLayout();
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
        private control.IntegerTextBoxUserControl CostFromTxt;
        private control.IntegerTextBoxUserControl InvoiceIDTxt;
        private Label InvoiceIDLbl;
        private Label CostLbl;
        public Panel panel1;
        private control.IntegerTextBoxUserControl CostToTxt;
        private Label label1;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private TextBox NameTxt;
        private Label NameLbl;
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
    }
}