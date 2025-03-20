using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    partial class SearchSupplierInvoice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.InvoiceAmountToTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceAmountFromTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SupplierIDTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.SaleIDTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToLbl = new System.Windows.Forms.Label();
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.SupplierNameLbl = new System.Windows.Forms.Label();
            this.SupplierCountryLbl = new System.Windows.Forms.Label();
            this.CountrySupplierTxt = new System.Windows.Forms.TextBox();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.NameSupplierTxt);
            this.TextBoxesRightPanel.Controls.Add(this.SupplierNameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.SupplierCountryLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CountrySupplierTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label4);
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
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(180, 418);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Supplier Invoice";
            // 
            // InvoiceAmountToTxt
            // 
            this.InvoiceAmountToTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceAmountToTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceAmountToTxt.Location = new System.Drawing.Point(0, 286);
            this.InvoiceAmountToTxt.Name = "InvoiceAmountToTxt";
            this.InvoiceAmountToTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceAmountToTxt.TabIndex = 16;
            // 
            // InvoiceAmountFromTxt
            // 
            this.InvoiceAmountFromTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceAmountFromTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceAmountFromTxt.Location = new System.Drawing.Point(0, 245);
            this.InvoiceAmountFromTxt.Name = "InvoiceAmountFromTxt";
            this.InvoiceAmountFromTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceAmountFromTxt.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(3, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Invoice Amount From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(3, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Invoice Amount To";
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.BackColor = System.Drawing.SystemColors.Window;
            this.SupplierIDTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierIDTxt.Location = new System.Drawing.Point(0, 82);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(180, 20);
            this.SupplierIDTxt.TabIndex = 12;
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.BackColor = System.Drawing.SystemColors.Window;
            this.SaleIDTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIDTxt.Location = new System.Drawing.Point(0, 42);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(180, 20);
            this.SaleIDTxt.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(3, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateFromLbl.Location = new System.Drawing.Point(3, 105);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(73, 17);
            this.DateFromLbl.TabIndex = 9;
            this.DateFromLbl.Text = "Date From";
            // 
            // DateToLbl
            // 
            this.DateToLbl.AutoSize = true;
            this.DateToLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateToLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateToLbl.Location = new System.Drawing.Point(3, 186);
            this.DateToLbl.Name = "DateToLbl";
            this.DateToLbl.Size = new System.Drawing.Size(46, 17);
            this.DateToLbl.TabIndex = 6;
            this.DateToLbl.Text = "Status";
            // 
            // StatusCmb
            // 
            this.StatusCmb.BackColor = System.Drawing.SystemColors.Window;
            this.StatusCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Approved",
            "Unapproved"});
            this.StatusCmb.Location = new System.Drawing.Point(0, 205);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(180, 21);
            this.StatusCmb.TabIndex = 5;
            // 
            // DateToClnd
            // 
            this.DateToClnd.Checked = false;
            this.DateToClnd.CustomFormat = "ddMMMMyyyy";
            this.DateToClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToClnd.Location = new System.Drawing.Point(0, 164);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(180, 20);
            this.DateToClnd.TabIndex = 6;
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaleIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIDLbl.Location = new System.Drawing.Point(3, 23);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(51, 17);
            this.SaleIDLbl.TabIndex = 3;
            this.SaleIDLbl.Text = "Sale ID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupplierIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierIDLbl.Location = new System.Drawing.Point(3, 64);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(77, 17);
            this.SupplierIDLbl.TabIndex = 4;
            this.SupplierIDLbl.Text = "Supplier ID";
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(0, 123);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(180, 20);
            this.DateFromClnd.TabIndex = 5;
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameSupplierTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameSupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameSupplierTxt.Location = new System.Drawing.Point(0, 328);
            this.NameSupplierTxt.MaxLength = 100;
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(180, 20);
            this.NameSupplierTxt.TabIndex = 19;
            // 
            // SupplierNameLbl
            // 
            this.SupplierNameLbl.AutoSize = true;
            this.SupplierNameLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupplierNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierNameLbl.Location = new System.Drawing.Point(3, 310);
            this.SupplierNameLbl.Name = "SupplierNameLbl";
            this.SupplierNameLbl.Size = new System.Drawing.Size(99, 17);
            this.SupplierNameLbl.TabIndex = 21;
            this.SupplierNameLbl.Text = "Supplier Name";
            // 
            // SupplierCountryLbl
            // 
            this.SupplierCountryLbl.AutoSize = true;
            this.SupplierCountryLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupplierCountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierCountryLbl.Location = new System.Drawing.Point(3, 351);
            this.SupplierCountryLbl.Name = "SupplierCountryLbl";
            this.SupplierCountryLbl.Size = new System.Drawing.Size(113, 17);
            this.SupplierCountryLbl.TabIndex = 22;
            this.SupplierCountryLbl.Text = "Supplier Country";
            // 
            // CountrySupplierTxt
            // 
            this.CountrySupplierTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CountrySupplierTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountrySupplierTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountrySupplierTxt.Location = new System.Drawing.Point(0, 369);
            this.CountrySupplierTxt.MaxLength = 50;
            this.CountrySupplierTxt.Name = "CountrySupplierTxt";
            this.CountrySupplierTxt.Size = new System.Drawing.Size(180, 20);
            this.CountrySupplierTxt.TabIndex = 20;
            // 
            // SearchSupplierInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchSupplierInvoice";
            this.Size = new System.Drawing.Size(180, 418);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TextBoxesRightPanel;
        private IntegerTextBoxUserControl InvoiceAmountToTxt;
        private IntegerTextBoxUserControl InvoiceAmountFromTxt;
        private Label label2;
        private Label label3;
        private IntegerTextBoxUserControl SaleIDTxt;
        private Label label1;
        private Label DateFromLbl;
        private Label DateToLbl;
        private ComboBox StatusCmb;
        private DateTimePicker DateToClnd;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private DateTimePicker DateFromClnd;
        private Label label4;
        public IntegerTextBoxUserControl SupplierIDTxt;
        public TextBox NameSupplierTxt;
        public Label SupplierNameLbl;
        public Label SupplierCountryLbl;
        public TextBox CountrySupplierTxt;
    }
}
