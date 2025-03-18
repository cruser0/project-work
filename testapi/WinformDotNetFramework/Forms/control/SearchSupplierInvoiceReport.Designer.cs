namespace WinformDotNetFramework.Forms.control
{
    partial class SearchSupplierInvoiceReport
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
            this.GraphLbl = new System.Windows.Forms.Label();
            this.GrapCBL = new System.Windows.Forms.CheckedListBox();
            this.SpentToLbl = new System.Windows.Forms.Label();
            this.SpentFromLbl = new System.Windows.Forms.Label();
            this.SpentToIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.SpentFromIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.SupplierNameLbl = new System.Windows.Forms.Label();
            this.CountryLbl = new System.Windows.Forms.Label();
            this.CountryTxt = new System.Windows.Forms.TextBox();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.GraphLbl);
            this.TextBoxesRightPanel.Controls.Add(this.GrapCBL);
            this.TextBoxesRightPanel.Controls.Add(this.SpentToLbl);
            this.TextBoxesRightPanel.Controls.Add(this.SpentFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.SpentToIntegerTxt);
            this.TextBoxesRightPanel.Controls.Add(this.SpentFromIntegerTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label2);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToClnd);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromClnd);
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.comboBox1);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.SupplierNameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryTxt);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 434);
            this.TextBoxesRightPanel.TabIndex = 10;
            // 
            // GraphLbl
            // 
            this.GraphLbl.AutoSize = true;
            this.GraphLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.GraphLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GraphLbl.Location = new System.Drawing.Point(4, 288);
            this.GraphLbl.Name = "GraphLbl";
            this.GraphLbl.Size = new System.Drawing.Size(51, 17);
            this.GraphLbl.TabIndex = 39;
            this.GraphLbl.Text = "Graphs";
            // 
            // GrapCBL
            // 
            this.GrapCBL.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrapCBL.FormattingEnabled = true;
            this.GrapCBL.Items.AddRange(new object[] {
            "Total supplier invoices per status",
            "Total supplier invoices per country",
            "Total supplier invoices per date",
            "Total spent per date",
            "Total spent per country"});
            this.GrapCBL.Location = new System.Drawing.Point(2, 308);
            this.GrapCBL.Name = "GrapCBL";
            this.GrapCBL.Size = new System.Drawing.Size(181, 106);
            this.GrapCBL.TabIndex = 38;
            // 
            // SpentToLbl
            // 
            this.SpentToLbl.AutoSize = true;
            this.SpentToLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SpentToLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SpentToLbl.Location = new System.Drawing.Point(5, 41);
            this.SpentToLbl.Name = "SpentToLbl";
            this.SpentToLbl.Size = new System.Drawing.Size(62, 17);
            this.SpentToLbl.TabIndex = 26;
            this.SpentToLbl.Text = "Spent To";
            // 
            // SpentFromLbl
            // 
            this.SpentFromLbl.AutoSize = true;
            this.SpentFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SpentFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SpentFromLbl.Location = new System.Drawing.Point(3, 0);
            this.SpentFromLbl.Name = "SpentFromLbl";
            this.SpentFromLbl.Size = new System.Drawing.Size(79, 17);
            this.SpentFromLbl.TabIndex = 25;
            this.SpentFromLbl.Text = "Spent From";
            // 
            // SpentToIntegerTxt
            // 
            this.SpentToIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SpentToIntegerTxt.Location = new System.Drawing.Point(3, 60);
            this.SpentToIntegerTxt.Name = "SpentToIntegerTxt";
            this.SpentToIntegerTxt.Size = new System.Drawing.Size(179, 20);
            this.SpentToIntegerTxt.TabIndex = 24;
            // 
            // SpentFromIntegerTxt
            // 
            this.SpentFromIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SpentFromIntegerTxt.Location = new System.Drawing.Point(3, 19);
            this.SpentFromIntegerTxt.Name = "SpentFromIntegerTxt";
            this.SpentFromIntegerTxt.Size = new System.Drawing.Size(179, 20);
            this.SpentFromIntegerTxt.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(4, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateFromLbl.Location = new System.Drawing.Point(5, 83);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(73, 17);
            this.DateFromLbl.TabIndex = 13;
            this.DateFromLbl.Text = "Date From";
            // 
            // DateToClnd
            // 
            this.DateToClnd.Checked = false;
            this.DateToClnd.CustomFormat = "ddMMMMyyyy";
            this.DateToClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToClnd.Location = new System.Drawing.Point(2, 142);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(180, 20);
            this.DateToClnd.TabIndex = 12;
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(2, 101);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(180, 20);
            this.DateFromClnd.TabIndex = 11;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(3, 165);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(46, 17);
            this.StatusLbl.TabIndex = 6;
            this.StatusLbl.Text = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Approved",
            "Unapproved"});
            this.comboBox1.Location = new System.Drawing.Point(3, 183);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(3, 227);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 20);
            this.NameTxt.TabIndex = 1;
            // 
            // SupplierNameLbl
            // 
            this.SupplierNameLbl.AutoSize = true;
            this.SupplierNameLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SupplierNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierNameLbl.Location = new System.Drawing.Point(1, 207);
            this.SupplierNameLbl.Name = "SupplierNameLbl";
            this.SupplierNameLbl.Size = new System.Drawing.Size(99, 17);
            this.SupplierNameLbl.TabIndex = 3;
            this.SupplierNameLbl.Text = "Supplier Name";
            // 
            // CountryLbl
            // 
            this.CountryLbl.AutoSize = true;
            this.CountryLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryLbl.Location = new System.Drawing.Point(4, 250);
            this.CountryLbl.Name = "CountryLbl";
            this.CountryLbl.Size = new System.Drawing.Size(113, 17);
            this.CountryLbl.TabIndex = 4;
            this.CountryLbl.Text = "Supplier Country";
            // 
            // CountryTxt
            // 
            this.CountryTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryTxt.Location = new System.Drawing.Point(3, 268);
            this.CountryTxt.MaxLength = 50;
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(180, 20);
            this.CountryTxt.TabIndex = 2;
            // 
            // SearchSupplierInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchSupplierInvoiceReport";
            this.Size = new System.Drawing.Size(200, 434);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TextBoxesRightPanel;
        private System.Windows.Forms.Label GraphLbl;
        public System.Windows.Forms.CheckedListBox GrapCBL;
        private System.Windows.Forms.Label SpentToLbl;
        private System.Windows.Forms.Label SpentFromLbl;
        public IntegerTextBoxUserControl SpentToIntegerTxt;
        public IntegerTextBoxUserControl SpentFromIntegerTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DateFromLbl;
        public System.Windows.Forms.DateTimePicker DateToClnd;
        public System.Windows.Forms.DateTimePicker DateFromClnd;
        private System.Windows.Forms.Label StatusLbl;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label SupplierNameLbl;
        private System.Windows.Forms.Label CountryLbl;
        public System.Windows.Forms.TextBox CountryTxt;
    }
}
