namespace Winform.Forms
{
    partial class CustomerGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerGridForm));
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.CountryTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryLvl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DateFromLbl = new System.Windows.Forms.Label();
            this.DateToClnd = new System.Windows.Forms.DateTimePicker();
            this.DateFromClnd = new System.Windows.Forms.DateTimePicker();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.CustomerGdv = new System.Windows.Forms.DataGridView();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CustomerIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerOriginalIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.CustomerDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PdfTSB = new System.Windows.Forms.ToolStripButton();
            this.ExcelTSB = new System.Windows.Forms.ToolStripButton();
            this.MassDeleteTSB = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new Winform.Forms.control.PaginationUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).BeginInit();
            this.RightClickDgv.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(3, 22);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 23);
            this.NameTxt.TabIndex = 1;
            // 
            // CountryTxt
            // 
            this.CountryTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryTxt.Location = new System.Drawing.Point(3, 69);
            this.CountryTxt.MaxLength = 50;
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(180, 23);
            this.CountryTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // CountryLvl
            // 
            this.CountryLvl.AutoSize = true;
            this.CountryLvl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CountryLvl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CountryLvl.Location = new System.Drawing.Point(3, 48);
            this.CountryLvl.Name = "CountryLvl";
            this.CountryLvl.Size = new System.Drawing.Size(58, 17);
            this.CountryLvl.TabIndex = 4;
            this.CountryLvl.Text = "Country";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 5;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.label2);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromLbl);
            this.TextBoxesRightPanel.Controls.Add(this.DateToClnd);
            this.TextBoxesRightPanel.Controls.Add(this.DateFromClnd);
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.comboBox1);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLvl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryTxt);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 103);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 358);
            this.TextBoxesRightPanel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(3, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Date To";
            // 
            // DateFromLbl
            // 
            this.DateFromLbl.AutoSize = true;
            this.DateFromLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateFromLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateFromLbl.Location = new System.Drawing.Point(3, 153);
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
            this.DateToClnd.Location = new System.Drawing.Point(3, 221);
            this.DateToClnd.Name = "DateToClnd";
            this.DateToClnd.ShowCheckBox = true;
            this.DateToClnd.Size = new System.Drawing.Size(180, 23);
            this.DateToClnd.TabIndex = 12;
            // 
            // DateFromClnd
            // 
            this.DateFromClnd.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.DateFromClnd.Checked = false;
            this.DateFromClnd.CustomFormat = "ddMMMMyyyy";
            this.DateFromClnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFromClnd.Location = new System.Drawing.Point(3, 174);
            this.DateFromClnd.Name = "DateFromClnd";
            this.DateFromClnd.ShowCheckBox = true;
            this.DateFromClnd.Size = new System.Drawing.Size(180, 23);
            this.DateFromClnd.TabIndex = 11;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(0, 101);
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
            "Active",
            "Deprecated"});
            this.comboBox1.Location = new System.Drawing.Point(3, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 23);
            this.comboBox1.TabIndex = 5;
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
            // CustomerGdv
            // 
            this.CustomerGdv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerGdv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustomerGdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerGdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerGdv.Location = new System.Drawing.Point(0, 0);
            this.CustomerGdv.Name = "CustomerGdv";
            this.CustomerGdv.RowTemplate.Height = 25;
            this.CustomerGdv.Size = new System.Drawing.Size(584, 361);
            this.CustomerGdv.TabIndex = 6;
            this.CustomerGdv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerIDTsmi,
            this.CustomerNameTsmi,
            this.CustomerCountryTsmi,
            this.CustomerDateTsmi,
            this.CustomerOriginalIDTsmi,
            this.CustomerStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(163, 136);
            // 
            // CustomerIDTsmi
            // 
            this.CustomerIDTsmi.CheckOnClick = true;
            this.CustomerIDTsmi.Name = "CustomerIDTsmi";
            this.CustomerIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerIDTsmi.Text = "Show ID";
            this.CustomerIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerNameTsmi
            // 
            this.CustomerNameTsmi.Checked = true;
            this.CustomerNameTsmi.CheckOnClick = true;
            this.CustomerNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerNameTsmi.Name = "CustomerNameTsmi";
            this.CustomerNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerNameTsmi.Text = "Show Name";
            this.CustomerNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerCountryTsmi
            // 
            this.CustomerCountryTsmi.Checked = true;
            this.CustomerCountryTsmi.CheckOnClick = true;
            this.CustomerCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerCountryTsmi.Name = "CustomerCountryTsmi";
            this.CustomerCountryTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerCountryTsmi.Text = "Show Country";
            this.CustomerCountryTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerDateTsmi
            // 
            this.CustomerDateTsmi.Checked = true;
            this.CustomerDateTsmi.CheckOnClick = true;
            this.CustomerDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerDateTsmi.Name = "CustomerDateTsmi";
            this.CustomerDateTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerDateTsmi.Text = "Show Date";
            this.CustomerDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerOriginalIDTsmi
            // 
            this.CustomerOriginalIDTsmi.CheckOnClick = true;
            this.CustomerOriginalIDTsmi.Name = "CustomerOriginalIDTsmi";
            this.CustomerOriginalIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerOriginalIDTsmi.Text = "Show Original ID";
            this.CustomerOriginalIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerStatusTsmi
            // 
            this.CustomerStatusTsmi.Checked = true;
            this.CustomerStatusTsmi.CheckOnClick = true;
            this.CustomerStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerStatusTsmi.Name = "CustomerStatusTsmi";
            this.CustomerStatusTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerStatusTsmi.Text = "Show Status";
            this.CustomerStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.CustomerDgv);
            this.CenterPanel.Controls.Add(this.toolStrip1);
            this.CenterPanel.Controls.Add(this.CustomerGdv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(584, 361);
            this.CenterPanel.TabIndex = 9;
            // 
            // CustomerDgv
            // 
            this.CustomerDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.CustomerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDgv.Location = new System.Drawing.Point(0, 25);
            this.CustomerDgv.Name = "CustomerDgv";
            this.CustomerDgv.ReadOnly = true;
            this.CustomerDgv.RowTemplate.Height = 25;
            this.CustomerDgv.Size = new System.Drawing.Size(584, 336);
            this.CustomerDgv.TabIndex = 7;
            this.CustomerDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.CustomerDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CustomerDgv_RightClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.PdfTSB,
            this.ExcelTSB,
            this.MassDeleteTSB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Winform.Properties.Resources.save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PdfTSB
            // 
            this.PdfTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PdfTSB.Image = ((System.Drawing.Image)(resources.GetObject("PdfTSB.Image")));
            this.PdfTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PdfTSB.Name = "PdfTSB";
            this.PdfTSB.Size = new System.Drawing.Size(32, 22);
            this.PdfTSB.Text = "PDF";
            this.PdfTSB.Click += new System.EventHandler(this.Pdf_ClickBtn);
            // 
            // ExcelTSB
            // 
            this.ExcelTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExcelTSB.Image = ((System.Drawing.Image)(resources.GetObject("ExcelTSB.Image")));
            this.ExcelTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcelTSB.Name = "ExcelTSB";
            this.ExcelTSB.Size = new System.Drawing.Size(38, 22);
            this.ExcelTSB.Text = "Excel";
            this.ExcelTSB.Click += new System.EventHandler(this.Excel_ClickBtn);
            // 
            // MassDeleteTSB
            // 
            this.MassDeleteTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MassDeleteTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MassDeleteTSB.Image = global::Winform.Properties.Resources.trash;
            this.MassDeleteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MassDeleteTSB.Name = "MassDeleteTSB";
            this.MassDeleteTSB.Size = new System.Drawing.Size(23, 22);
            this.MassDeleteTSB.Text = "toolStripButton4";
            this.MassDeleteTSB.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 361);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(584, 100);
            this.BottomPanel.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.PaginationUserControl);
            this.panel5.Location = new System.Drawing.Point(213, 0);
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
            this.panel4.Location = new System.Drawing.Point(584, 0);
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
            // CustomerGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CustomerGridForm";
            this.Text = "testForm";
            this.Load += new System.EventHandler(this.CustomerGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).EndInit();
            this.RightClickDgv.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox NameTxt;
        private TextBox CountryTxt;
        private Label label1;
        private Label CountryLvl;
        private Panel panel1;
        private control.RightSideBarUserControl RightSideBar;
        private Panel TextBoxesRightPanel;
        private DataGridView CustomerGdv;
        private ContextMenuStrip RightClickDgv;
        private Label StatusLbl;
        private ComboBox comboBox1;
        public Panel CenterPanel;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private Panel panel4;
        private Panel panel3;
        public Panel panel5;
        public DataGridView CustomerDgv;
        private ToolStripMenuItem CustomerIDTsmi;
        private ToolStripMenuItem CustomerNameTsmi;
        private ToolStripMenuItem CustomerCountryTsmi;
        private ToolStripMenuItem CustomerDateTsmi;
        private ToolStripMenuItem CustomerOriginalIDTsmi;
        private ToolStripMenuItem CustomerStatusTsmi;
        private Label label2;
        private Label DateFromLbl;
        private DateTimePicker DateToClnd;
        private DateTimePicker DateFromClnd;
        private ToolStripButton PdfTSB;
        private ToolStripButton ExcelTSB;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton MassDeleteTSB;
        private ToolStripSeparator toolStripSeparator1;
    }
}