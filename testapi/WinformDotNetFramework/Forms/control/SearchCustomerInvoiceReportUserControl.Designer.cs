namespace WinformDotNetFramework.Forms.control
{
    partial class SearchCustomerInvoiceReportUserControl
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
            this.RegionCmbx = new System.Windows.Forms.ComboBox();
            this.RegionLbl = new System.Windows.Forms.Label();
            this.CountryCmbx = new System.Windows.Forms.ComboBox();
            this.GraphLbl = new System.Windows.Forms.Label();
            this.GrapCBL = new System.Windows.Forms.CheckedListBox();
            this.GainedToLbl = new System.Windows.Forms.Label();
            this.GainedFromLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.CustomerNameLbl = new System.Windows.Forms.Label();
            this.CountryLbl = new System.Windows.Forms.Label();
            this.GainedToIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.GainedFromIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.RegionCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.RegionLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.GraphLbl);
            this.TextBoxesRightPanel.Controls.Add(this.GrapCBL);
            this.TextBoxesRightPanel.Controls.Add(this.GainedToLbl);
            this.TextBoxesRightPanel.Controls.Add(this.GainedFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.GainedToIntegerTxt);
            this.TextBoxesRightPanel.Controls.Add(this.GainedFromIntegerTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label2);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToClnd);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromClnd);
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.CustomerNameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLbl);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 460);
            this.TextBoxesRightPanel.TabIndex = 9;
            // 
            // RegionCmbx
            // 
            this.RegionCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.RegionCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.RegionCmbx.FormattingEnabled = true;
            this.RegionCmbx.Items.AddRange(new object[] {
            "All",
            "NA  (North America)",
            "LATAM  (Latin America & Caribbean)",
            "EU  (European Union)",
            "NON_EU  (Non-European Union)",
            "MEA  (Middle East & Africa)",
            "CIS  (Commonwealth of Independent)",
            "SEA  (Southeast Asia)",
            "EAS  (East Asia)",
            "OCE  (Oceania)",
            "SA  (South Asia)"});
            this.RegionCmbx.Location = new System.Drawing.Point(3, 308);
            this.RegionCmbx.Name = "RegionCmbx";
            this.RegionCmbx.Size = new System.Drawing.Size(180, 21);
            this.RegionCmbx.TabIndex = 46;
            this.RegionCmbx.SelectionChangeCommitted += new System.EventHandler(this.RegionCmbx_SelectionChangeCommitted);
            // 
            // RegionLbl
            // 
            this.RegionLbl.AutoSize = true;
            this.RegionLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.RegionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.RegionLbl.Location = new System.Drawing.Point(3, 289);
            this.RegionLbl.Name = "RegionLbl";
            this.RegionLbl.Size = new System.Drawing.Size(51, 17);
            this.RegionLbl.TabIndex = 45;
            this.RegionLbl.Text = "Region";
            // 
            // CountryCmbx
            // 
            this.CountryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CountryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountryCmbx.FormattingEnabled = true;
            this.CountryCmbx.Location = new System.Drawing.Point(3, 266);
            this.CountryCmbx.Name = "CountryCmbx";
            this.CountryCmbx.Size = new System.Drawing.Size(180, 21);
            this.CountryCmbx.TabIndex = 40;
            // 
            // GraphLbl
            // 
            this.GraphLbl.AutoSize = true;
            this.GraphLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.GraphLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GraphLbl.Location = new System.Drawing.Point(3, 331);
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
            "Total customer invoices per status",
            "Total customer invoices per country",
            "Total customer invoices per date",
            "Total gained per date",
            "Total gained per country"});
            this.GrapCBL.Location = new System.Drawing.Point(3, 350);
            this.GrapCBL.Name = "GrapCBL";
            this.GrapCBL.Size = new System.Drawing.Size(180, 89);
            this.GrapCBL.TabIndex = 38;
            // 
            // GainedToLbl
            // 
            this.GainedToLbl.AutoSize = true;
            this.GainedToLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.GainedToLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GainedToLbl.Location = new System.Drawing.Point(5, 41);
            this.GainedToLbl.Name = "GainedToLbl";
            this.GainedToLbl.Size = new System.Drawing.Size(70, 17);
            this.GainedToLbl.TabIndex = 26;
            this.GainedToLbl.Text = "Gained To";
            // 
            // GainedFromLbl
            // 
            this.GainedFromLbl.AutoSize = true;
            this.GainedFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.GainedFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GainedFromLbl.Location = new System.Drawing.Point(3, 0);
            this.GainedFromLbl.Name = "GainedFromLbl";
            this.GainedFromLbl.Size = new System.Drawing.Size(87, 17);
            this.GainedFromLbl.TabIndex = 25;
            this.GainedFromLbl.Text = "Gained From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(4, 123);
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
            this.DateFromLbl.Location = new System.Drawing.Point(5, 82);
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
            this.StatusLbl.Location = new System.Drawing.Point(3, 164);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(46, 17);
            this.StatusLbl.TabIndex = 6;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.BackColor = System.Drawing.SystemColors.Window;
            this.StatusCmbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "All",
            "Paid",
            "Unpaid"});
            this.StatusCmbx.Location = new System.Drawing.Point(3, 183);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(180, 21);
            this.StatusCmbx.TabIndex = 5;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(3, 225);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 20);
            this.NameTxt.TabIndex = 1;
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.AutoSize = true;
            this.CustomerNameLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CustomerNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerNameLbl.Location = new System.Drawing.Point(1, 206);
            this.CustomerNameLbl.Name = "CustomerNameLbl";
            this.CustomerNameLbl.Size = new System.Drawing.Size(107, 17);
            this.CustomerNameLbl.TabIndex = 3;
            this.CustomerNameLbl.Text = "Customer Name";
            // 
            // CountryLbl
            // 
            this.CountryLbl.AutoSize = true;
            this.CountryLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryLbl.Location = new System.Drawing.Point(4, 247);
            this.CountryLbl.Name = "CountryLbl";
            this.CountryLbl.Size = new System.Drawing.Size(121, 17);
            this.CountryLbl.TabIndex = 4;
            this.CountryLbl.Text = "Customer Country";
            // 
            // GainedToIntegerTxt
            // 
            this.GainedToIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GainedToIntegerTxt.Location = new System.Drawing.Point(3, 60);
            this.GainedToIntegerTxt.Name = "GainedToIntegerTxt";
            this.GainedToIntegerTxt.Size = new System.Drawing.Size(180, 20);
            this.GainedToIntegerTxt.TabIndex = 24;
            // 
            // GainedFromIntegerTxt
            // 
            this.GainedFromIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.GainedFromIntegerTxt.Location = new System.Drawing.Point(3, 19);
            this.GainedFromIntegerTxt.Name = "GainedFromIntegerTxt";
            this.GainedFromIntegerTxt.Size = new System.Drawing.Size(180, 20);
            this.GainedFromIntegerTxt.TabIndex = 23;
            // 
            // SearchCustomerInvoiceReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchCustomerInvoiceReportUserControl";
            this.Size = new System.Drawing.Size(200, 460);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TextBoxesRightPanel;
        private System.Windows.Forms.Label GraphLbl;
        public System.Windows.Forms.CheckedListBox GrapCBL;
        private System.Windows.Forms.Label GainedToLbl;
        private System.Windows.Forms.Label GainedFromLbl;
        public IntegerTextBoxUserControl GainedToIntegerTxt;
        public IntegerTextBoxUserControl GainedFromIntegerTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DateFromLbl;
        public System.Windows.Forms.DateTimePicker DateToClnd;
        public System.Windows.Forms.DateTimePicker DateFromClnd;
        private System.Windows.Forms.Label StatusLbl;
        public System.Windows.Forms.ComboBox StatusCmbx;
        public System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label CustomerNameLbl;
        private System.Windows.Forms.Label CountryLbl;
        private System.Windows.Forms.ComboBox CountryCmbx;
        private System.Windows.Forms.ComboBox RegionCmbx;
        private System.Windows.Forms.Label RegionLbl;
    }
}
