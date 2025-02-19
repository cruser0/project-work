namespace Winform.Forms
{
    partial class SupplierInvoiceForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RigtPanel = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.SupplierIDTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SaleIDTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToLbl = new System.Windows.Forms.Label();
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Supplier = new System.Windows.Forms.Label();
            this.leftSideBarUserControl = new Winform.Forms.control.LeftSideBarUSerControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SupplierInvoiceDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.RigtPanel.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RigtPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1047, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 647);
            this.panel1.TabIndex = 16;
            // 
            // RigtPanel
            // 
            this.RigtPanel.Controls.Add(this.TextBoxesRightPanel);
            this.RigtPanel.Controls.Add(this.RightSideBar);
            this.RigtPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RigtPanel.Location = new System.Drawing.Point(0, 0);
            this.RigtPanel.Name = "RigtPanel";
            this.RigtPanel.Size = new System.Drawing.Size(200, 647);
            this.RigtPanel.TabIndex = 16;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.SupplierIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.SaleIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusCmb);
            this.TextBoxesRightPanel.Controls.Add(this.DateToClnd);
            this.TextBoxesRightPanel.Controls.Add(this.SaleIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.SupplierIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromClnd);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 141);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 529);
            this.TextBoxesRightPanel.TabIndex = 7;
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.Location = new System.Drawing.Point(3, 68);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(194, 23);
            this.SupplierIDTxt.TabIndex = 12;
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.Location = new System.Drawing.Point(3, 21);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(194, 23);
            this.SaleIDTxt.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateFromLbl.Location = new System.Drawing.Point(3, 94);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(71, 18);
            this.DateFromLbl.TabIndex = 9;
            this.DateFromLbl.Text = "Date From";
            // 
            // DateToLbl
            // 
            this.DateToLbl.AutoSize = true;
            this.DateToLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateToLbl.Location = new System.Drawing.Point(3, 188);
            this.DateToLbl.Name = "DateToLbl";
            this.DateToLbl.Size = new System.Drawing.Size(45, 18);
            this.DateToLbl.TabIndex = 6;
            this.DateToLbl.Text = "Status";
            // 
            // StatusCmb
            // 
            this.StatusCmb.BackColor = System.Drawing.Color.Gainsboro;
            this.StatusCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusCmb.ForeColor = System.Drawing.Color.Black;
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Approved",
            "Unapproved"});
            this.StatusCmb.Location = new System.Drawing.Point(3, 209);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(194, 23);
            this.StatusCmb.TabIndex = 5;
            // 
            // DateToClnd
            // 
            this.DateToClnd.Checked = false;
            this.DateToClnd.CustomFormat = "ddMMMMyyyy";
            this.DateToClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToClnd.Location = new System.Drawing.Point(3, 162);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(193, 23);
            this.DateToClnd.TabIndex = 6;
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaleIDLbl.Location = new System.Drawing.Point(3, 0);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(53, 18);
            this.SaleIDLbl.TabIndex = 3;
            this.SaleIDLbl.Text = "Sale ID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SupplierIDLbl.Location = new System.Drawing.Point(3, 47);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(79, 18);
            this.SupplierIDLbl.TabIndex = 4;
            this.SupplierIDLbl.Text = "Supplier ID";
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(3, 115);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(193, 23);
            this.DateFromClnd.TabIndex = 5;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 647);
            this.RightSideBar.TabIndex = 1;
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.Supplier);
            this.LeftPanel.Controls.Add(this.leftSideBarUserControl);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 647);
            this.LeftPanel.TabIndex = 17;
            // 
            // Supplier
            // 
            this.Supplier.AutoSize = true;
            this.Supplier.BackColor = System.Drawing.Color.DarkGray;
            this.Supplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.Supplier.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Supplier.Location = new System.Drawing.Point(0, 0);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(156, 25);
            this.Supplier.TabIndex = 10;
            this.Supplier.Text = "Supplier Invoice";
            // 
            // leftSideBarUserControl
            // 
            this.leftSideBarUserControl.BackColor = System.Drawing.Color.DarkGray;
            this.leftSideBarUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideBarUserControl.Location = new System.Drawing.Point(0, 0);
            this.leftSideBarUserControl.Name = "leftSideBarUserControl";
            this.leftSideBarUserControl.Size = new System.Drawing.Size(200, 647);
            this.leftSideBarUserControl.TabIndex = 2;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierInvoiceDgv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(200, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(847, 647);
            this.CenterPanel.TabIndex = 18;
            // 
            // SupplierInvoiceDgv
            // 
            this.SupplierInvoiceDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierInvoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceDgv.Location = new System.Drawing.Point(0, 0);
            this.SupplierInvoiceDgv.Name = "SupplierInvoiceDgv";
            this.SupplierInvoiceDgv.ReadOnly = true;
            this.SupplierInvoiceDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceDgv.Size = new System.Drawing.Size(847, 647);
            this.SupplierInvoiceDgv.TabIndex = 9;
            this.SupplierInvoiceDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            // 
            // SupplierInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 647);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierInvoiceForm";
            this.Text = "SupplierInvoiceForm";
            this.panel1.ResumeLayout(false);
            this.RigtPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel RigtPanel;
        private Panel TextBoxesRightPanel;
        private Label label1;
        private Label DateFromLbl;
        private Label DateToLbl;
        private ComboBox StatusCmb;
        private DateTimePicker DateToClnd;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private DateTimePicker DateFromClnd;
        private control.RightSideBarUserControl RightSideBar;
        private Panel LeftPanel;
        private Panel CenterPanel;
        private DataGridView SupplierInvoiceDgv;
        private control.LeftSideBarUSerControl leftSideBarUserControl;
        private Label Supplier;
        private control.IntegerTextBoxUserControl SaleIDTxt;
        private control.IntegerTextBoxUserControl SupplierIDTxt;
    }
}