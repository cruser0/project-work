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
            this.SupplierInvoiceGridUserControl = new Winform.Forms.control.BaseGridUserControl();
            this.SaleIDTxt = new System.Windows.Forms.TextBox();
            this.SupplierIDTxt = new System.Windows.Forms.TextBox();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.DateClnd = new System.Windows.Forms.MonthCalendar();
            this.DateLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SupplierInvoiceGridUserControl
            // 
            this.SupplierInvoiceGridUserControl.Location = new System.Drawing.Point(12, 80);
            this.SupplierInvoiceGridUserControl.Name = "SupplierInvoiceGridUserControl";
            this.SupplierInvoiceGridUserControl.Size = new System.Drawing.Size(1223, 555);
            this.SupplierInvoiceGridUserControl.TabIndex = 0;
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.Location = new System.Drawing.Point(42, 34);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(100, 23);
            this.SaleIDTxt.TabIndex = 1;
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.Location = new System.Drawing.Point(148, 34);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(100, 23);
            this.SupplierIDTxt.TabIndex = 2;
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(42, 16);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 6;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(148, 16);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 7;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // StatusCmb
            // 
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Approved",
            "Unapproved"});
            this.StatusCmb.Location = new System.Drawing.Point(254, 34);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(121, 23);
            this.StatusCmb.TabIndex = 8;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(254, 16);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 9;
            this.StatusLbl.Text = "Status";
            // 
            // DateClnd
            // 
            this.DateClnd.Location = new System.Drawing.Point(387, 34);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.TabIndex = 10;
            this.DateClnd.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.DateClnd_DateChanged);
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Location = new System.Drawing.Point(387, 16);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(31, 15);
            this.DateLbl.TabIndex = 11;
            this.DateLbl.Text = "Date";
            // 
            // SupplierInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 647);
            this.Controls.Add(this.DateLbl);
            this.Controls.Add(this.DateClnd);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.StatusCmb);
            this.Controls.Add(this.SupplierIDLbl);
            this.Controls.Add(this.SaleIDLbl);
            this.Controls.Add(this.SupplierIDTxt);
            this.Controls.Add(this.SaleIDTxt);
            this.Controls.Add(this.SupplierInvoiceGridUserControl);
            this.Name = "SupplierInvoiceForm";
            this.Text = "SupplierInvoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private control.BaseGridUserControl SupplierInvoiceGridUserControl;
        private TextBox SaleIDTxt;
        private TextBox SupplierIDTxt;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private ComboBox StatusCmb;
        private Label StatusLbl;
        private MonthCalendar DateClnd;
        private Label DateLbl;
    }
}