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
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToLbl = new System.Windows.Forms.Label();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
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
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Location = new System.Drawing.Point(387, 16);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(60, 15);
            this.DateFromLbl.TabIndex = 11;
            this.DateFromLbl.Text = "Date from";
            // 
            // DateToLbl
            // 
            this.DateToLbl.AutoSize = true;
            this.DateToLbl.Location = new System.Drawing.Point(593, 16);
            this.DateToLbl.Name = "DateToLbl";
            this.DateToLbl.Size = new System.Drawing.Size(45, 15);
            this.DateToLbl.TabIndex = 13;
            this.DateToLbl.Text = "Date to";
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(387, 34);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(200, 23);
            this.DateFromClnd.TabIndex = 14;
            // 
            // DateToClnd
            // 
            this.DateToClnd.Checked = false;
            this.DateToClnd.CustomFormat = "ddMMMMyyyy";
            this.DateToClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToClnd.Location = new System.Drawing.Point(593, 34);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(200, 23);
            this.DateToClnd.TabIndex = 15;
            // 
            // SupplierInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 647);
            this.Controls.Add(this.DateToClnd);
            this.Controls.Add(this.DateFromClnd);
            this.Controls.Add(this.DateToLbl);
            this.Controls.Add(this.DateFromLbl);
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
        private Label DateFromLbl;
        private Label DateToLbl;
        private DateTimePicker DateFromClnd;
        private DateTimePicker DateToClnd;
    }
}