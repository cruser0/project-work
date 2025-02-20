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
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(819, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 554);
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
            this.RightSideBar.Size = new System.Drawing.Size(200, 554);
            this.RightSideBar.TabIndex = 7;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierDgv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(819, 554);
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
            this.SupplierDgv.Size = new System.Drawing.Size(819, 554);
            this.SupplierDgv.TabIndex = 8;
            this.SupplierDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDgv_CellDoubleClick);
            // 
            // SupplierGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 554);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierGridForm";
            this.Text = "SupplierForm";
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).EndInit();
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
    }
}