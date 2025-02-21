namespace Winform.Forms
{
    partial class SaleGridForm
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
            this.DateFromDTP = new System.Windows.Forms.DateTimePicker();
            this.DateToDTP = new System.Windows.Forms.DateTimePicker();
            this.RigtPanel = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.CustomerIDTextBoxUserControl = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.DateToLbl = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.CustomerIDLbl = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.BNTextBox = new System.Windows.Forms.TextBox();
            this.BookingNumberLbl = new System.Windows.Forms.Label();
            this.BillofLadingLbl = new System.Windows.Forms.Label();
            this.BoLTextBox = new System.Windows.Forms.TextBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaleDgv = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new Winform.Forms.control.PaginationUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RigtPanel.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDgv)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateFromDTP
            // 
            this.DateFromDTP.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.DateFromDTP.Checked = false;
            this.DateFromDTP.CustomFormat = "ddMMMMyyyy";
            this.DateFromDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromDTP.Location = new System.Drawing.Point(3, 162);
            this.DateFromDTP.Name = "DateFromDTP";
            this.DateFromDTP.ShowCheckBox = true;
            this.DateFromDTP.Size = new System.Drawing.Size(193, 23);
            this.DateFromDTP.TabIndex = 5;
            // 
            // DateToDTP
            // 
            this.DateToDTP.Checked = false;
            this.DateToDTP.CustomFormat = "ddMMMMyyyy";
            this.DateToDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateToDTP.Location = new System.Drawing.Point(3, 209);
            this.DateToDTP.Name = "DateToDTP";
            this.DateToDTP.ShowCheckBox = true;
            this.DateToDTP.Size = new System.Drawing.Size(193, 23);
            this.DateToDTP.TabIndex = 6;
            // 
            // RigtPanel
            // 
            this.RigtPanel.Controls.Add(this.TextBoxesRightPanel);
            this.RigtPanel.Controls.Add(this.RightSideBar);
            this.RigtPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RigtPanel.Location = new System.Drawing.Point(712, 0);
            this.RigtPanel.Name = "RigtPanel";
            this.RigtPanel.Size = new System.Drawing.Size(200, 501);
            this.RigtPanel.TabIndex = 15;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.CustomerIDTextBoxUserControl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CustomerIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusCB);
            this.TextBoxesRightPanel.Controls.Add(this.BNTextBox);
            this.TextBoxesRightPanel.Controls.Add(this.DateToDTP);
            this.TextBoxesRightPanel.Controls.Add(this.BookingNumberLbl);
            this.TextBoxesRightPanel.Controls.Add(this.BillofLadingLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromDTP);
            this.TextBoxesRightPanel.Controls.Add(this.BoLTextBox);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 141);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 529);
            this.TextBoxesRightPanel.TabIndex = 7;
            // 
            // CustomerIDTextBoxUserControl
            // 
            this.CustomerIDTextBoxUserControl.Location = new System.Drawing.Point(3, 115);
            this.CustomerIDTextBoxUserControl.Name = "CustomerIDTextBoxUserControl";
            this.CustomerIDTextBoxUserControl.Size = new System.Drawing.Size(194, 23);
            this.CustomerIDTextBoxUserControl.TabIndex = 11;
            // 
            // DateToLbl
            // 
            this.DateToLbl.AutoSize = true;
            this.DateToLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateToLbl.Location = new System.Drawing.Point(3, 188);
            this.DateToLbl.Name = "DateToLbl";
            this.DateToLbl.Size = new System.Drawing.Size(56, 18);
            this.DateToLbl.TabIndex = 10;
            this.DateToLbl.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateFromLbl.Location = new System.Drawing.Point(3, 141);
            this.DateFromLbl.Name = "DateFromLbl";
            this.DateFromLbl.Size = new System.Drawing.Size(71, 18);
            this.DateFromLbl.TabIndex = 9;
            this.DateFromLbl.Text = "Date From";
            // 
            // CustomerIDLbl
            // 
            this.CustomerIDLbl.AutoSize = true;
            this.CustomerIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CustomerIDLbl.Location = new System.Drawing.Point(3, 94);
            this.CustomerIDLbl.Name = "CustomerIDLbl";
            this.CustomerIDLbl.Size = new System.Drawing.Size(85, 18);
            this.CustomerIDLbl.TabIndex = 8;
            this.CustomerIDLbl.Text = "Customer ID";
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.Location = new System.Drawing.Point(3, 235);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(45, 18);
            this.StatusLbl.TabIndex = 6;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCB
            // 
            this.StatusCB.BackColor = System.Drawing.Color.Gainsboro;
            this.StatusCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusCB.ForeColor = System.Drawing.Color.Black;
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Items.AddRange(new object[] {
            "All",
            "Active",
            "Closed"});
            this.StatusCB.Location = new System.Drawing.Point(3, 256);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(194, 23);
            this.StatusCB.TabIndex = 5;
            // 
            // BNTextBox
            // 
            this.BNTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.BNTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BNTextBox.Location = new System.Drawing.Point(3, 21);
            this.BNTextBox.MaxLength = 50;
            this.BNTextBox.Name = "BNTextBox";
            this.BNTextBox.Size = new System.Drawing.Size(194, 23);
            this.BNTextBox.TabIndex = 1;
            // 
            // BookingNumberLbl
            // 
            this.BookingNumberLbl.AutoSize = true;
            this.BookingNumberLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BookingNumberLbl.Location = new System.Drawing.Point(3, 0);
            this.BookingNumberLbl.Name = "BookingNumberLbl";
            this.BookingNumberLbl.Size = new System.Drawing.Size(112, 18);
            this.BookingNumberLbl.TabIndex = 3;
            this.BookingNumberLbl.Text = "Booking Number";
            // 
            // BillofLadingLbl
            // 
            this.BillofLadingLbl.AutoSize = true;
            this.BillofLadingLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BillofLadingLbl.Location = new System.Drawing.Point(3, 47);
            this.BillofLadingLbl.Name = "BillofLadingLbl";
            this.BillofLadingLbl.Size = new System.Drawing.Size(89, 18);
            this.BillofLadingLbl.TabIndex = 4;
            this.BillofLadingLbl.Text = "Bill of Lading";
            // 
            // BoLTextBox
            // 
            this.BoLTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.BoLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoLTextBox.Location = new System.Drawing.Point(3, 68);
            this.BoLTextBox.MaxLength = 50;
            this.BoLTextBox.Name = "BoLTextBox";
            this.BoLTextBox.Size = new System.Drawing.Size(194, 23);
            this.BoLTextBox.TabIndex = 2;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 501);
            this.RightSideBar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaleDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 501);
            this.panel1.TabIndex = 17;
            // 
            // SaleDgv
            // 
            this.SaleDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SaleDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaleDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SaleDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaleDgv.Location = new System.Drawing.Point(0, 0);
            this.SaleDgv.Name = "SaleDgv";
            this.SaleDgv.ReadOnly = true;
            this.SaleDgv.RowTemplate.Height = 25;
            this.SaleDgv.Size = new System.Drawing.Size(712, 501);
            this.SaleDgv.TabIndex = 8;
            this.SaleDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkGray;
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 501);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(912, 100);
            this.BottomPanel.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.PaginationUserControl);
            this.panel5.Location = new System.Drawing.Point(218, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(365, 100);
            this.panel5.TabIndex = 2;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(17, 26);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(309, 44);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(912, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 100);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 100);
            this.panel3.TabIndex = 0;
            // 
            // SaleGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RigtPanel);
            this.Controls.Add(this.BottomPanel);
            this.Name = "SaleGridForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.RigtPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDgv)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DateTimePicker DateFromDTP;
        private DateTimePicker DateToDTP;
        private Panel RigtPanel;
        private control.RightSideBarUserControl RightSideBar;
        private Panel TextBoxesRightPanel;
        private Label DateToLbl;
        private Label DateFromLbl;
        private Label StatusLbl;
        private ComboBox StatusCB;
        private TextBox BNTextBox;
        private Label BookingNumberLbl;
        private Label BillofLadingLbl;
        private TextBox BoLTextBox;
        private Label CustomerIDLbl;
        private control.IntegerTextBoxUserControl CustomerIDTextBoxUserControl;
        public Panel panel1;
        public DataGridView SaleDgv;
        private Panel BottomPanel;
        private Panel panel5;
        private control.PaginationUserControl PaginationUserControl;
        private Panel panel4;
        private Panel panel3;
    }
}