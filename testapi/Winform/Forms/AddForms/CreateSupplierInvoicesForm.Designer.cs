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
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SaleIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.OpenSupplier = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CreatePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusCmbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(271, 203);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(200, 23);
            this.StatusCmbx.TabIndex = 26;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(271, 185);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIDLbl.Location = new System.Drawing.Point(271, 76);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierIDLbl.Location = new System.Drawing.Point(271, 131);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // DateClnd
            // 
            this.DateClnd.AllowDrop = true;
            this.DateClnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateClnd.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateClnd.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateClnd.Location = new System.Drawing.Point(271, 258);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(200, 23);
            this.DateClnd.TabIndex = 28;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.AllowDrop = true;
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(314, 287);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(157, 23);
            this.SaveEditCustomerBtn.TabIndex = 25;
            this.SaveEditCustomerBtn.Text = "Create Supplier Invoice";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.Control;
            this.CreatePanel.Controls.Add(this.panel1);
            this.CreatePanel.Controls.Add(this.panel5);
            this.CreatePanel.Controls.Add(this.panel3);
            this.CreatePanel.Controls.Add(this.panel2);
            this.CreatePanel.Controls.Add(this.panel4);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatePanel.Location = new System.Drawing.Point(0, 0);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(784, 461);
            this.CreatePanel.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SaleIDLbl);
            this.panel1.Controls.Add(this.SupplierIDTxt1);
            this.panel1.Controls.Add(this.StatusCmbx);
            this.panel1.Controls.Add(this.SaleIDTxt1);
            this.panel1.Controls.Add(this.DateClnd);
            this.panel1.Controls.Add(this.OpenSupplier);
            this.panel1.Controls.Add(this.SaveEditCustomerBtn);
            this.panel1.Controls.Add(this.OpenSale);
            this.panel1.Controls.Add(this.StatusLbl);
            this.panel1.Controls.Add(this.SupplierIDLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 421);
            this.panel1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(271, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date";
            // 
            // SupplierIDTxt1
            // 
            this.SupplierIDTxt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDTxt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierIDTxt1.Location = new System.Drawing.Point(271, 149);
            this.SupplierIDTxt1.Name = "SupplierIDTxt1";
            this.SupplierIDTxt1.Size = new System.Drawing.Size(200, 23);
            this.SupplierIDTxt1.TabIndex = 32;
            // 
            // SaleIDTxt1
            // 
            this.SaleIDTxt1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDTxt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIDTxt1.Location = new System.Drawing.Point(271, 94);
            this.SaleIDTxt1.Name = "SaleIDTxt1";
            this.SaleIDTxt1.Size = new System.Drawing.Size(200, 23);
            this.SaleIDTxt1.TabIndex = 31;
            // 
            // OpenSupplier
            // 
            this.OpenSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSupplier.FlatAppearance.BorderSize = 0;
            this.OpenSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSupplier.Location = new System.Drawing.Point(477, 149);
            this.OpenSupplier.Name = "OpenSupplier";
            this.OpenSupplier.Size = new System.Drawing.Size(64, 23);
            this.OpenSupplier.TabIndex = 30;
            this.OpenSupplier.Text = "Open";
            this.OpenSupplier.UseVisualStyleBackColor = false;
            this.OpenSupplier.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(477, 94);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 29;
            this.OpenSale.Text = "Open";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 421);
            this.panel5.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 421);
            this.panel3.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 20);
            this.panel2.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 441);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 20);
            this.panel4.TabIndex = 36;
            // 
            // CreateSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CreatePanel);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateSupplierInvoicesForm";
            this.Text = "CreateSupplierInvoicesForm";
            this.CreatePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox StatusCmbx;
        private Label StatusLbl;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private DateTimePicker DateClnd;
        private Button SaveEditCustomerBtn;
        private Panel CreatePanel;
        private Button OpenSupplier;
        private Button OpenSale;
        private control.IntegerTextBoxUserControl SupplierIDTxt1;
        private control.IntegerTextBoxUserControl SaleIDTxt1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
    }
}