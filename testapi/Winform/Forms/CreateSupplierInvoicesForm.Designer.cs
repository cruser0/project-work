namespace Winform.Forms
{
    partial class CreateSupplierInvoicesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.SaleIDTxt = new System.Windows.Forms.TextBox();
            this.SupplierIDTxt = new System.Windows.Forms.TextBox();
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.CreatePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(924, 435);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(57, 205);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(206, 23);
            this.StatusCmbx.TabIndex = 26;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(58, 187);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(59, 78);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(59, 133);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // DateClnd
            // 
            this.DateClnd.AllowDrop = true;
            this.DateClnd.Location = new System.Drawing.Point(57, 260);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(206, 23);
            this.DateClnd.TabIndex = 28;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.AllowDrop = true;
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(57, 316);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(157, 23);
            this.SaveEditCustomerBtn.TabIndex = 25;
            this.SaveEditCustomerBtn.Text = "Create Supplier Invoice";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.AllowDrop = true;
            this.SaleIDTxt.Location = new System.Drawing.Point(57, 94);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(206, 23);
            this.SaleIDTxt.TabIndex = 20;
            this.SaleIDTxt.Click += new System.EventHandler(this.SaleIDTxt_Click);
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.AllowDrop = true;
            this.SupplierIDTxt.Location = new System.Drawing.Point(57, 151);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(206, 23);
            this.SupplierIDTxt.TabIndex = 21;
            this.SupplierIDTxt.Click += new System.EventHandler(this.SupplierIDTxt_Click);
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CreatePanel.Controls.Add(this.SupplierIDTxt);
            this.CreatePanel.Controls.Add(this.SaleIDTxt);
            this.CreatePanel.Controls.Add(this.SaleIDLbl);
            this.CreatePanel.Controls.Add(this.SupplierIDLbl);
            this.CreatePanel.Controls.Add(this.StatusLbl);
            this.CreatePanel.Controls.Add(this.SaveEditCustomerBtn);
            this.CreatePanel.Controls.Add(this.DateClnd);
            this.CreatePanel.Controls.Add(this.StatusCmbx);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CreatePanel.Location = new System.Drawing.Point(0, 0);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(391, 635);
            this.CreatePanel.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1315, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 635);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(391, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 100);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(391, 535);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 100);
            this.panel3.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(391, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(924, 435);
            this.panel4.TabIndex = 33;
            // 
            // CreateSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 635);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CreatePanel);
            this.Name = "CreateSupplierInvoicesForm";
            this.Text = "CreateSupplierInvoicesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.CreatePanel.ResumeLayout(false);
            this.CreatePanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private ComboBox StatusCmbx;
        private Label StatusLbl;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private DateTimePicker DateClnd;
        private Button SaveEditCustomerBtn;
        private TextBox SaleIDTxt;
        private TextBox SupplierIDTxt;
        private Panel CreatePanel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}