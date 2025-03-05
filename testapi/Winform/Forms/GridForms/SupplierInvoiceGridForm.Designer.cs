namespace Winform.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RigtPanel = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.InvoiceAmountToTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceAmountFromTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SupplierInvoiceDgv = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new Winform.Forms.control.PaginationUserControl();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSaleIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceInvoiceAmountTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSupplierIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceSupplierNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierInvoiceCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.RigtPanel.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.RigtPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(619, 0);
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
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceAmountToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceAmountFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label2);
            this.TextBoxesRightPanel.Controls.Add(this.label3);
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
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 103);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 544);
            this.TextBoxesRightPanel.TabIndex = 7;
            // 
            // InvoiceAmountToTxt
            // 
            this.InvoiceAmountToTxt.Location = new System.Drawing.Point(3, 303);
            this.InvoiceAmountToTxt.Name = "InvoiceAmountToTxt";
            this.InvoiceAmountToTxt.Size = new System.Drawing.Size(180, 23);
            this.InvoiceAmountToTxt.TabIndex = 16;
            // 
            // InvoiceAmountFromTxt
            // 
            this.InvoiceAmountFromTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceAmountFromTxt.Location = new System.Drawing.Point(3, 256);
            this.InvoiceAmountFromTxt.Name = "InvoiceAmountFromTxt";
            this.InvoiceAmountFromTxt.Size = new System.Drawing.Size(180, 23);
            this.InvoiceAmountFromTxt.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Invoice Amount From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Invoice Amount To";
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.Location = new System.Drawing.Point(3, 68);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(180, 23);
            this.SupplierIDTxt.TabIndex = 12;
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.Location = new System.Drawing.Point(3, 21);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(180, 23);
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
            this.StatusCmb.BackColor = System.Drawing.SystemColors.Window;
            this.StatusCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusCmb.ForeColor = System.Drawing.Color.Black;
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Approved",
            "Unapproved"});
            this.StatusCmb.Location = new System.Drawing.Point(3, 209);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(180, 23);
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
            this.DateToClnd.Size = new System.Drawing.Size(180, 23);
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
            this.DateFromClnd.Size = new System.Drawing.Size(180, 23);
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
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierInvoiceDgv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(619, 547);
            this.CenterPanel.TabIndex = 18;
            // 
            // SupplierInvoiceDgv
            // 
            this.SupplierInvoiceDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(180)))), ((int)(((byte)(212)))));
            this.SupplierInvoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceDgv.Location = new System.Drawing.Point(0, 0);
            this.SupplierInvoiceDgv.Name = "SupplierInvoiceDgv";
            this.SupplierInvoiceDgv.ReadOnly = true;
            this.SupplierInvoiceDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceDgv.Size = new System.Drawing.Size(619, 547);
            this.SupplierInvoiceDgv.TabIndex = 9;
            this.SupplierInvoiceDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.SupplierInvoiceDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkGray;
            this.BottomPanel.Controls.Add(this.panel2);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 547);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(619, 100);
            this.BottomPanel.TabIndex = 19;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.PaginationUserControl);
            this.panel2.Location = new System.Drawing.Point(87, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 100);
            this.panel2.TabIndex = 1;
            // 
            // SupplierInvoiceGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(819, 647);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierInvoiceGridForm";
            this.Text = "SupplierInvoiceForm";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.RigtPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private DataGridView SupplierInvoiceDgv;
        private control.IntegerTextBoxUserControl SaleIDTxt;
        private control.IntegerTextBoxUserControl SupplierIDTxt;
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
        private control.IntegerTextBoxUserControl InvoiceAmountToTxt;
        private control.IntegerTextBoxUserControl InvoiceAmountFromTxt;
        private Label label2;
        private Label label3;
        private Panel panel2;
    }
}