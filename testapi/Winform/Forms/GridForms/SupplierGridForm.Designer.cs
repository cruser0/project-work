namespace Winform.Forms
{
    partial class SupplierGridForm
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
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryLvl = new System.Windows.Forms.Label();
            this.CountrySupplierTxt = new System.Windows.Forms.TextBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SupplierDgv = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new Winform.Forms.control.PaginationUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierOriginalIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(819, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 454);
            this.panel1.TabIndex = 10;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.comboBox1);
            this.TextBoxesRightPanel.Controls.Add(this.NameSupplierTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLvl);
            this.TextBoxesRightPanel.Controls.Add(this.CountrySupplierTxt);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(-1, 106);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 287);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.Location = new System.Drawing.Point(3, 104);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(45, 18);
            this.StatusLbl.TabIndex = 6;
            this.StatusLbl.Text = "Status";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Active",
            "Deprecated"});
            this.comboBox1.Location = new System.Drawing.Point(3, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NameSupplierTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameSupplierTxt.Location = new System.Drawing.Point(3, 26);
            this.NameSupplierTxt.MaxLength = 100;
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(194, 23);
            this.NameSupplierTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // CountryLvl
            // 
            this.CountryLvl.AutoSize = true;
            this.CountryLvl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CountryLvl.Location = new System.Drawing.Point(3, 52);
            this.CountryLvl.Name = "CountryLvl";
            this.CountryLvl.Size = new System.Drawing.Size(56, 18);
            this.CountryLvl.TabIndex = 4;
            this.CountryLvl.Text = "Country";
            // 
            // CountrySupplierTxt
            // 
            this.CountrySupplierTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.CountrySupplierTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountrySupplierTxt.Location = new System.Drawing.Point(3, 73);
            this.CountrySupplierTxt.MaxLength = 50;
            this.CountrySupplierTxt.Name = "CountrySupplierTxt";
            this.CountrySupplierTxt.Size = new System.Drawing.Size(194, 23);
            this.CountrySupplierTxt.TabIndex = 2;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 454);
            this.RightSideBar.TabIndex = 7;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierDgv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(819, 454);
            this.CenterPanel.TabIndex = 12;
            // 
            // SupplierDgv
            // 
            this.SupplierDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierDgv.Location = new System.Drawing.Point(0, 0);
            this.SupplierDgv.Name = "SupplierDgv";
            this.SupplierDgv.ReadOnly = true;
            this.SupplierDgv.RowTemplate.Height = 25;
            this.SupplierDgv.Size = new System.Drawing.Size(819, 454);
            this.SupplierDgv.TabIndex = 8;
            this.SupplierDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDgv_CellDoubleClick);
            this.SupplierDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.DarkGray;
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 454);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1019, 100);
            this.BottomPanel.TabIndex = 13;
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
            this.panel4.Location = new System.Drawing.Point(1019, 0);
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
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SupplierIDTsmi,
            this.SupplierNameTsmi,
            this.SupplierCountryTsmi,
            this.SupplierDateTsmi,
            this.SupplierOriginalIDTsmi,
            this.SupplierStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(181, 158);
            // 
            // SupplierIDTsmi
            // 
            this.SupplierIDTsmi.CheckOnClick = true;
            this.SupplierIDTsmi.Name = "SupplierIDTsmi";
            this.SupplierIDTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierIDTsmi.Text = "Show ID";
            this.SupplierIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierNameTsmi
            // 
            this.SupplierNameTsmi.Checked = true;
            this.SupplierNameTsmi.CheckOnClick = true;
            this.SupplierNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierNameTsmi.Name = "SupplierNameTsmi";
            this.SupplierNameTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierNameTsmi.Text = "Show Name";
            this.SupplierNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierCountryTsmi
            // 
            this.SupplierCountryTsmi.Checked = true;
            this.SupplierCountryTsmi.CheckOnClick = true;
            this.SupplierCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierCountryTsmi.Name = "SupplierCountryTsmi";
            this.SupplierCountryTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierCountryTsmi.Text = "Show Country";
            this.SupplierCountryTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierDateTsmi
            // 
            this.SupplierDateTsmi.Checked = true;
            this.SupplierDateTsmi.CheckOnClick = true;
            this.SupplierDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierDateTsmi.Name = "SupplierDateTsmi";
            this.SupplierDateTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierDateTsmi.Text = "Show Date";
            this.SupplierDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierOriginalIDTsmi
            // 
            this.SupplierOriginalIDTsmi.CheckOnClick = true;
            this.SupplierOriginalIDTsmi.Name = "SupplierOriginalIDTsmi";
            this.SupplierOriginalIDTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierOriginalIDTsmi.Text = "Show Original ID";
            this.SupplierOriginalIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierStatusTsmi
            // 
            this.SupplierStatusTsmi.Checked = true;
            this.SupplierStatusTsmi.CheckOnClick = true;
            this.SupplierStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierStatusTsmi.Name = "SupplierStatusTsmi";
            this.SupplierStatusTsmi.Size = new System.Drawing.Size(180, 22);
            this.SupplierStatusTsmi.Text = "Show Status";
            this.SupplierStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 554);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BottomPanel);
            this.Name = "SupplierGridForm";
            this.Text = "SupplierForm";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel TextBoxesRightPanel;
        private Label StatusLbl;
        private ComboBox comboBox1;
        private TextBox NameSupplierTxt;
        private Label label1;
        private Label CountryLvl;
        private TextBox CountrySupplierTxt;
        private control.RightSideBarUserControl RightSideBar;
        private DataGridView SupplierDgv;
        public Panel CenterPanel;
        private Panel BottomPanel;
        private Panel panel5;
        private control.PaginationUserControl PaginationUserControl;
        private Panel panel4;
        private Panel panel3;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem SupplierIDTsmi;
        private ToolStripMenuItem SupplierNameTsmi;
        private ToolStripMenuItem SupplierCountryTsmi;
        private ToolStripMenuItem SupplierDateTsmi;
        private ToolStripMenuItem SupplierOriginalIDTsmi;
        private ToolStripMenuItem SupplierStatusTsmi;
    }
}