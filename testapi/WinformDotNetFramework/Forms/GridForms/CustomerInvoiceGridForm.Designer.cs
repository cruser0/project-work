using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class CustomerInvoiceGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInvoiceGridForm));
            this.RightPanel = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchCustomerInvoice1 = new WinformDotNetFramework.Forms.control.SearchCustomerInvoice();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.CenterDgv = new System.Windows.Forms.DataGridView();
            this.customerInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CustomerInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceSaleIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceInvoiceAmountTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.customerInvoiceCostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerInvoiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleBookingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleBoL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightPanel.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CenterDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.TextBoxesRightPanel);
            this.RightPanel.Controls.Add(this.RightSideBar);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(584, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(200, 461);
            this.RightPanel.TabIndex = 0;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchCustomerInvoice1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 409);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // searchCustomerInvoice1
            // 
            this.searchCustomerInvoice1.Location = new System.Drawing.Point(0, 0);
            this.searchCustomerInvoice1.Name = "searchCustomerInvoice1";
            this.searchCustomerInvoice1.Size = new System.Drawing.Size(197, 385);
            this.searchCustomerInvoice1.TabIndex = 0;
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
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.CenterDgv);
            this.CenterPanel.Controls.Add(this.toolStrip1);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(584, 374);
            this.CenterPanel.TabIndex = 1;
            // 
            // CenterDgv
            // 
            this.CenterDgv.AllowUserToAddRows = false;
            this.CenterDgv.AllowUserToDeleteRows = false;
            this.CenterDgv.AllowUserToOrderColumns = true;
            this.CenterDgv.AutoGenerateColumns = false;
            this.CenterDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CenterDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.CenterDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CenterDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerInvoiceCode,
            this.SaleBookingNumber,
            this.SaleBoL,
            this.InvoiceAmount,
            this.Status,
            this.InvoiceDate,
            this.CustomerInvoiceID,
            this.SaleID});
            this.CenterDgv.DataSource = this.customerInvoiceBindingSource;
            this.CenterDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterDgv.Location = new System.Drawing.Point(0, 25);
            this.CenterDgv.Name = "CenterDgv";
            this.CenterDgv.ReadOnly = true;
            this.CenterDgv.RowTemplate.Height = 25;
            this.CenterDgv.Size = new System.Drawing.Size(584, 349);
            this.CenterDgv.TabIndex = 0;
            this.CenterDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CenterDgv_CellDoubleClick);
            this.CenterDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDhvEvent);
            // 
            // customerInvoiceBindingSource
            // 
            this.customerInvoiceBindingSource.DataSource = typeof(WinformDotNetFramework.Entities.CustomerInvoice);
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
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 374);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(584, 87);
            this.BottomPanel.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.PaginationUserControl);
            this.panel5.Location = new System.Drawing.Point(187, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 87);
            this.panel5.TabIndex = 2;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(15, 23);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(265, 38);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(584, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 87);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 87);
            this.panel3.TabIndex = 0;
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerInvoiceIDTsmi,
            this.CustomerInvoiceSaleIDTsmi,
            this.CustomerInvoiceInvoiceAmountTsmi,
            this.CustomerInvoiceDateTsmi,
            this.CustomerInvoiceStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(192, 114);
            // 
            // CustomerInvoiceIDTsmi
            // 
            this.CustomerInvoiceIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceIDTsmi.Name = "CustomerInvoiceIDTsmi";
            this.CustomerInvoiceIDTsmi.Size = new System.Drawing.Size(191, 22);
            this.CustomerInvoiceIDTsmi.Text = "Show ID";
            this.CustomerInvoiceIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceSaleIDTsmi
            // 
            this.CustomerInvoiceSaleIDTsmi.Checked = true;
            this.CustomerInvoiceSaleIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceSaleIDTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceSaleIDTsmi.Name = "CustomerInvoiceSaleIDTsmi";
            this.CustomerInvoiceSaleIDTsmi.Size = new System.Drawing.Size(191, 22);
            this.CustomerInvoiceSaleIDTsmi.Text = "Show Sale ID";
            this.CustomerInvoiceSaleIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceInvoiceAmountTsmi
            // 
            this.CustomerInvoiceInvoiceAmountTsmi.Checked = true;
            this.CustomerInvoiceInvoiceAmountTsmi.CheckOnClick = true;
            this.CustomerInvoiceInvoiceAmountTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceInvoiceAmountTsmi.Name = "CustomerInvoiceInvoiceAmountTsmi";
            this.CustomerInvoiceInvoiceAmountTsmi.Size = new System.Drawing.Size(191, 22);
            this.CustomerInvoiceInvoiceAmountTsmi.Text = "Show Invoice Amount";
            this.CustomerInvoiceInvoiceAmountTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceDateTsmi
            // 
            this.CustomerInvoiceDateTsmi.Checked = true;
            this.CustomerInvoiceDateTsmi.CheckOnClick = true;
            this.CustomerInvoiceDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceDateTsmi.Name = "CustomerInvoiceDateTsmi";
            this.CustomerInvoiceDateTsmi.Size = new System.Drawing.Size(191, 22);
            this.CustomerInvoiceDateTsmi.Text = "Show Invoice Date";
            this.CustomerInvoiceDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceStatusTsmi
            // 
            this.CustomerInvoiceStatusTsmi.Checked = true;
            this.CustomerInvoiceStatusTsmi.CheckOnClick = true;
            this.CustomerInvoiceStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceStatusTsmi.Name = "CustomerInvoiceStatusTsmi";
            this.CustomerInvoiceStatusTsmi.Size = new System.Drawing.Size(191, 22);
            this.CustomerInvoiceStatusTsmi.Text = "Show Status";
            this.CustomerInvoiceStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // customerInvoiceCostBindingSource
            // 
            this.customerInvoiceCostBindingSource.DataSource = typeof(WinformDotNetFramework.Entities.CustomerInvoiceCost);
            // 
            // CustomerInvoiceCode
            // 
            this.CustomerInvoiceCode.DataPropertyName = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.HeaderText = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.Name = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.ReadOnly = true;
            // 
            // SaleBookingNumber
            // 
            this.SaleBookingNumber.DataPropertyName = "SaleBookingNumber";
            this.SaleBookingNumber.HeaderText = "SaleBookingNumber";
            this.SaleBookingNumber.Name = "SaleBookingNumber";
            this.SaleBookingNumber.ReadOnly = true;
            // 
            // SaleBoL
            // 
            this.SaleBoL.DataPropertyName = "SaleBoL";
            this.SaleBoL.HeaderText = "SaleBoL";
            this.SaleBoL.Name = "SaleBoL";
            this.SaleBoL.ReadOnly = true;
            // 
            // InvoiceAmount
            // 
            this.InvoiceAmount.DataPropertyName = "InvoiceAmount";
            this.InvoiceAmount.HeaderText = "InvoiceAmount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "InvoiceDate";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // CustomerInvoiceID
            // 
            this.CustomerInvoiceID.DataPropertyName = "CustomerInvoiceId";
            this.CustomerInvoiceID.HeaderText = "CustomerInvoiceID";
            this.CustomerInvoiceID.Name = "CustomerInvoiceID";
            this.CustomerInvoiceID.ReadOnly = true;
            this.CustomerInvoiceID.Visible = false;
            // 
            // SaleID
            // 
            this.SaleID.DataPropertyName = "SaleId";
            this.SaleID.HeaderText = "SaleID";
            this.SaleID.Name = "SaleID";
            this.SaleID.ReadOnly = true;
            this.SaleID.Visible = false;
            // 
            // CustomerInvoiceGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.RightPanel);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CustomerInvoiceGridForm";
            this.Text = "CustomerInvoiceGridForm";
            this.Load += new System.EventHandler(this.CustomerInvoiceGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.RightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CenterDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel RightPanel;
        private control.RightSideBarUserControl RightSideBar;
        private Panel TextBoxesRightPanel;
        public Panel CenterPanel;
        private DataGridView CenterDgv;
        private Panel BottomPanel;
        private Panel panel5;
        private control.PaginationUserControl PaginationUserControl;
        private Panel panel4;
        private Panel panel3;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem CustomerInvoiceIDTsmi;
        private ToolStripMenuItem CustomerInvoiceSaleIDTsmi;
        private ToolStripMenuItem CustomerInvoiceInvoiceAmountTsmi;
        private ToolStripMenuItem CustomerInvoiceDateTsmi;
        private ToolStripMenuItem CustomerInvoiceStatusTsmi;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private control.SearchCustomerInvoice searchCustomerInvoice1;
        private ToolStripButton ToggleEditButton;
        private BindingSource customerInvoiceBindingSource;
        private BindingSource customerInvoiceCostBindingSource;
        private DataGridViewTextBoxColumn CustomerInvoiceCode;
        private DataGridViewTextBoxColumn SaleBookingNumber;
        private DataGridViewTextBoxColumn SaleBoL;
        private DataGridViewTextBoxColumn InvoiceAmount;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn InvoiceDate;
        private DataGridViewTextBoxColumn CustomerInvoiceID;
        private DataGridViewTextBoxColumn SaleID;
    }
}