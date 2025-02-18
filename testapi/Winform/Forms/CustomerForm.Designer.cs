namespace Winform.Forms
{
    partial class CustomerForm
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
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.CountryTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryLvl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.CustomerGdv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.Supplier = new System.Windows.Forms.Label();
            this.leftSideBarUserControl = new Winform.Forms.control.LeftSideBarUSerControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.CustomerDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).BeginInit();
            this.panel3.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(3, 22);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(194, 23);
            this.NameTxt.TabIndex = 1;
            // 
            // CountryTxt
            // 
            this.CountryTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.CountryTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryTxt.Location = new System.Drawing.Point(3, 69);
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(194, 23);
            this.CountryTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // CountryLvl
            // 
            this.CountryLvl.AutoSize = true;
            this.CountryLvl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CountryLvl.Location = new System.Drawing.Point(3, 48);
            this.CountryLvl.Name = "CountryLvl";
            this.CountryLvl.Size = new System.Drawing.Size(56, 18);
            this.CountryLvl.TabIndex = 4;
            this.CountryLvl.Text = "Country";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1091, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 623);
            this.panel1.TabIndex = 5;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.comboBox1);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLvl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryTxt);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 106);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 287);
            this.TextBoxesRightPanel.TabIndex = 6;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.Location = new System.Drawing.Point(0, 101);
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
            this.comboBox1.Location = new System.Drawing.Point(3, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 623);
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
            this.CustomerGdv.Size = new System.Drawing.Size(891, 623);
            this.CustomerGdv.TabIndex = 6;
            this.CustomerGdv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Supplier);
            this.panel3.Controls.Add(this.leftSideBarUserControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 623);
            this.panel3.TabIndex = 8;
            // 
            // Supplier
            // 
            this.Supplier.AutoSize = true;
            this.Supplier.BackColor = System.Drawing.Color.DarkGray;
            this.Supplier.Dock = System.Windows.Forms.DockStyle.Left;
            this.Supplier.Location = new System.Drawing.Point(0, 0);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(59, 15);
            this.Supplier.TabIndex = 10;
            this.Supplier.Text = "Customer";
            // 
            // leftSideBarUserControl
            // 
            this.leftSideBarUserControl.BackColor = System.Drawing.Color.DarkGray;
            this.leftSideBarUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideBarUserControl.Location = new System.Drawing.Point(0, 0);
            this.leftSideBarUserControl.Name = "leftSideBarUserControl";
            this.leftSideBarUserControl.Size = new System.Drawing.Size(200, 623);
            this.leftSideBarUserControl.TabIndex = 0;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.CustomerDgv);
            this.CenterPanel.Controls.Add(this.CustomerGdv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(200, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(891, 623);
            this.CenterPanel.TabIndex = 9;
            // 
            // CustomerDgv
            // 
            this.CustomerDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustomerDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDgv.Location = new System.Drawing.Point(0, 0);
            this.CustomerDgv.Name = "CustomerDgv";
            this.CustomerDgv.ReadOnly = true;
            this.CustomerDgv.RowTemplate.Height = 25;
            this.CustomerDgv.Size = new System.Drawing.Size(891, 623);
            this.CustomerDgv.TabIndex = 7;
            this.CustomerDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 623);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerForm";
            this.Text = "testForm";
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDgv)).EndInit();
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
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel3;
        private Panel CenterPanel;
        private Label StatusLbl;
        private ComboBox comboBox1;
        private control.LeftSideBarUSerControl leftSideBarUserControl;
        private DataGridView CustomerDgv;
        private Label Supplier;
    }
}