namespace Winform.Forms.GridForms
{
    partial class CustomerInvoiceCostGridForm
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
            this.CustomerInvoiceCostDgv = new System.Windows.Forms.DataGridView();
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
            this.CustomerInvoiceCostIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostCostTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostQuantityTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceCostDgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CustomerInvoiceCostDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 567);
            this.panel1.TabIndex = 3;
            // 
            // CustomerInvoiceCostDgv
            // 
            this.CustomerInvoiceCostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerInvoiceCostDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustomerInvoiceCostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerInvoiceCostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerInvoiceCostDgv.Location = new System.Drawing.Point(0, 0);
            this.CustomerInvoiceCostDgv.Name = "CustomerInvoiceCostDgv";
            this.CustomerInvoiceCostDgv.ReadOnly = true;
            this.CustomerInvoiceCostDgv.RowTemplate.Height = 25;
            this.CustomerInvoiceCostDgv.Size = new System.Drawing.Size(600, 567);
            this.CustomerInvoiceCostDgv.TabIndex = 0;
            this.CustomerInvoiceCostDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.CustomerInvoiceCostDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CustomerDgv_RightClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxesRightPanel);
            this.panel2.Controls.Add(this.RightSideBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 567);
            this.panel2.TabIndex = 4;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
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
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 464);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(4, 174);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 23);
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
            this.CostToTxt.Size = new System.Drawing.Size(180, 23);
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
            this.CostFromTxt.Size = new System.Drawing.Size(180, 23);
            this.CostFromTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.Location = new System.Drawing.Point(3, 21);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(180, 23);
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
            this.RightSideBar.Size = new System.Drawing.Size(200, 567);
            this.RightSideBar.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkGray;
            this.BottomPanel.Controls.Add(this.PaginationUserControl);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 567);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(800, 100);
            this.BottomPanel.TabIndex = 5;
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
            this.CustomerInvoiceCostIDTsmi,
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi,
            this.CustomerInvoiceCostCostTsmi,
            this.CustomerInvoiceCostQuantityTsmi,
            this.CustomerInvoiceCostNameTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(214, 114);
            // 
            // CustomerInvoiceCostIDTsmi
            // 
            this.CustomerInvoiceCostIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostIDTsmi.Name = "CustomerInvoiceCostIDTsmi";
            this.CustomerInvoiceCostIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostIDTsmi.Text = "Show ID";
            this.CustomerInvoiceCostIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostCustomerInvoiceIDTsmi
            // 
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked = true;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Name = "CustomerInvoiceCostCustomerInvoiceIDTsmi";
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Text = "Show Customer Invoice ID";
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostCostTsmi
            // 
            this.CustomerInvoiceCostCostTsmi.Checked = true;
            this.CustomerInvoiceCostCostTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostCostTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostCostTsmi.Name = "CustomerInvoiceCostCostTsmi";
            this.CustomerInvoiceCostCostTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostCostTsmi.Text = "Show Cost";
            this.CustomerInvoiceCostCostTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostQuantityTsmi
            // 
            this.CustomerInvoiceCostQuantityTsmi.Checked = true;
            this.CustomerInvoiceCostQuantityTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostQuantityTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostQuantityTsmi.Name = "CustomerInvoiceCostQuantityTsmi";
            this.CustomerInvoiceCostQuantityTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostQuantityTsmi.Text = "Show Quantity";
            this.CustomerInvoiceCostQuantityTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostNameTsmi
            // 
            this.CustomerInvoiceCostNameTsmi.Checked = true;
            this.CustomerInvoiceCostNameTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostNameTsmi.Name = "CustomerInvoiceCostNameTsmi";
            this.CustomerInvoiceCostNameTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostNameTsmi.Text = "Show Description Name";
            this.CustomerInvoiceCostNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 667);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BottomPanel);
            this.Name = "CustomerInvoiceCostGridForm";
            this.Text = "CustomerInvoiceCostGrid";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceCostDgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel panel1;
        private DataGridView CustomerInvoiceCostDgv;
        private Panel panel2;
        private Panel TextBoxesRightPanel;
        private TextBox NameTxt;
        private Label NameLbl;
        private control.IntegerTextBoxUserControl CostToTxt;
        private Label label1;
        private control.IntegerTextBoxUserControl CostFromTxt;
        private control.IntegerTextBoxUserControl InvoiceIDTxt;
        private Label InvoiceIDLbl;
        private Label CostLbl;
        private control.RightSideBarUserControl RightSideBar;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem CustomerInvoiceCostIDTsmi;
        private ToolStripMenuItem CustomerInvoiceCostCustomerInvoiceIDTsmi;
        private ToolStripMenuItem CustomerInvoiceCostCostTsmi;
        private ToolStripMenuItem CustomerInvoiceCostQuantityTsmi;
        private ToolStripMenuItem CustomerInvoiceCostNameTsmi;
    }
}