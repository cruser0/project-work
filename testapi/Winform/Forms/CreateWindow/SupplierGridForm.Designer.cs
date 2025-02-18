namespace Winform.Forms.CreateWindow
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
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CountryLvl = new System.Windows.Forms.Label();
            this.CountryTxt = new System.Windows.Forms.TextBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SupplierDgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 0;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.StatusLbl);
            this.TextBoxesRightPanel.Controls.Add(this.StatusCmb);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CountryLvl);
            this.TextBoxesRightPanel.Controls.Add(this.CountryTxt);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 106);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 287);
            this.TextBoxesRightPanel.TabIndex = 10;
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
            // StatusCmb
            // 
            this.StatusCmb.BackColor = System.Drawing.Color.Gainsboro;
            this.StatusCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusCmb.ForeColor = System.Drawing.Color.Black;
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Items.AddRange(new object[] {
            "All",
            "Active",
            "Deprecated"});
            this.StatusCmb.Location = new System.Drawing.Point(3, 122);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(194, 23);
            this.StatusCmb.TabIndex = 5;
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
            // CountryTxt
            // 
            this.CountryTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.CountryTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryTxt.Location = new System.Drawing.Point(3, 69);
            this.CountryTxt.Name = "CountryTxt";
            this.CountryTxt.Size = new System.Drawing.Size(194, 23);
            this.CountryTxt.TabIndex = 2;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 450);
            this.RightSideBar.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SupplierDgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 450);
            this.panel2.TabIndex = 1;
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
            this.SupplierDgv.Size = new System.Drawing.Size(600, 450);
            this.SupplierDgv.TabIndex = 9;
            this.SupplierDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDgv_CellDoubleClick);
            // 
            // SupplierGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SupplierGridForm";
            this.Text = "SupplierGridForm";
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel TextBoxesRightPanel;
        private Label StatusLbl;
        private ComboBox StatusCmb;
        private TextBox NameTxt;
        private Label label1;
        private Label CountryLvl;
        private TextBox CountryTxt;
        private control.RightSideBarUserControl RightSideBar;
        private DataGridView SupplierDgv;
    }
}