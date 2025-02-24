namespace Winform.Forms.CreateWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SupplierInvoiceCostDgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostToTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.CostFromTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new Winform.Forms.control.PaginationUserControl();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierInvoiceCostIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostSupplierInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostCostTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostQuantityTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCostNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SupplierInvoiceCostDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 464);
            this.panel1.TabIndex = 0;
            // 
            // SupplierInvoiceCostDgv
            // 
            this.SupplierInvoiceCostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceCostDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierInvoiceCostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceCostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceCostDgv.Location = new System.Drawing.Point(0, 0);
            this.SupplierInvoiceCostDgv.Name = "SupplierInvoiceCostDgv";
            this.SupplierInvoiceCostDgv.ReadOnly = true;
            this.SupplierInvoiceCostDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceCostDgv.Size = new System.Drawing.Size(600, 464);
            this.SupplierInvoiceCostDgv.TabIndex = 0;
            this.SupplierInvoiceCostDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.SupplierInvoiceCostDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxesRightPanel);
            this.panel2.Controls.Add(this.RightSideBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 464);
            this.panel2.TabIndex = 1;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.NameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CostFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostLbl);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 150);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 286);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(4, 174);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(194, 23);
            this.NameTxt.TabIndex = 15;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.Location = new System.Drawing.Point(4, 153);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(118, 18);
            this.NameLbl.TabIndex = 16;
            this.NameLbl.Text = "Description Name";
            // 
            // CostToTxt
            // 
            this.CostToTxt.Location = new System.Drawing.Point(4, 122);
            this.CostToTxt.Name = "CostToTxt";
            this.CostToTxt.Size = new System.Drawing.Size(194, 23);
            this.CostToTxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cost To";
            // 
            // CostFromTxt
            // 
            this.CostFromTxt.Location = new System.Drawing.Point(3, 68);
            this.CostFromTxt.Name = "CostFromTxt";
            this.CostFromTxt.Size = new System.Drawing.Size(194, 23);
            this.CostFromTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.Location = new System.Drawing.Point(3, 21);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(194, 23);
            this.InvoiceIDTxt.TabIndex = 11;
            // 
            // InvoiceIDLbl
            // 
            this.InvoiceIDLbl.AutoSize = true;
            this.InvoiceIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InvoiceIDLbl.Location = new System.Drawing.Point(3, 0);
            this.InvoiceIDLbl.Name = "InvoiceIDLbl";
            this.InvoiceIDLbl.Size = new System.Drawing.Size(71, 18);
            this.InvoiceIDLbl.TabIndex = 3;
            this.InvoiceIDLbl.Text = "Invoice ID";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CostLbl.Location = new System.Drawing.Point(3, 47);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(68, 18);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost From";
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 464);
            this.RightSideBar.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkGray;
            this.BottomPanel.Controls.Add(this.PaginationUserControl);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 464);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(800, 100);
            this.BottomPanel.TabIndex = 2;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(142, 25);
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
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BottomPanel);
            this.Name = "SupplierInvoiceCostGridForm";
            this.Text = "SupplierInvoiceCostGridForm";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
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
    }
}