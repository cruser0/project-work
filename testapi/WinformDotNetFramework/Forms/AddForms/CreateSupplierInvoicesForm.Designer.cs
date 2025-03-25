using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.AddForms
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
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CountryCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.NameCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.SupplierCountryLbl = new System.Windows.Forms.Label();
            this.SupplierNameLbl = new System.Windows.Forms.Label();
            this.BoLCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.BKCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.SaleBKLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.StatusCmbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCmbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(288, 247);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(172, 23);
            this.StatusCmbx.TabIndex = 26;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(289, 229);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(44, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status*";
            // 
            // DateClnd
            // 
            this.DateClnd.AllowDrop = true;
            this.DateClnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateClnd.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateClnd.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DateClnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateClnd.Location = new System.Drawing.Point(288, 291);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(172, 23);
            this.DateClnd.TabIndex = 28;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.AllowDrop = true;
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveEditCustomerBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(325, 320);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(135, 23);
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
            this.panel1.Controls.Add(this.CountryCmbxUC);
            this.panel1.Controls.Add(this.NameCmbxUC);
            this.panel1.Controls.Add(this.SupplierCountryLbl);
            this.panel1.Controls.Add(this.SupplierNameLbl);
            this.panel1.Controls.Add(this.BoLCmbxUC);
            this.panel1.Controls.Add(this.BKCmbxUC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SaleBKLbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.StatusCmbx);
            this.panel1.Controls.Add(this.DateClnd);
            this.panel1.Controls.Add(this.OpenSupplier);
            this.panel1.Controls.Add(this.SaveEditCustomerBtn);
            this.panel1.Controls.Add(this.OpenSale);
            this.panel1.Controls.Add(this.StatusLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 33;
            // 
            // CountryCmbxUC
            // 
            this.CountryCmbxUC.listItemsDropCmbx = null;
            this.CountryCmbxUC.Location = new System.Drawing.Point(288, 203);
            this.CountryCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.CountryCmbxUC.Name = "CountryCmbxUC";
            this.CountryCmbxUC.Size = new System.Drawing.Size(172, 23);
            this.CountryCmbxUC.TabIndex = 48;
            // 
            // NameCmbxUC
            // 
            this.NameCmbxUC.listItemsDropCmbx = null;
            this.NameCmbxUC.Location = new System.Drawing.Point(288, 163);
            this.NameCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.NameCmbxUC.Name = "NameCmbxUC";
            this.NameCmbxUC.Size = new System.Drawing.Size(172, 22);
            this.NameCmbxUC.TabIndex = 47;
            // 
            // SupplierCountryLbl
            // 
            this.SupplierCountryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierCountryLbl.AutoSize = true;
            this.SupplierCountryLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierCountryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierCountryLbl.Location = new System.Drawing.Point(288, 185);
            this.SupplierCountryLbl.Name = "SupplierCountryLbl";
            this.SupplierCountryLbl.Size = new System.Drawing.Size(101, 15);
            this.SupplierCountryLbl.TabIndex = 46;
            this.SupplierCountryLbl.Text = "Supplier Country*";
            // 
            // SupplierNameLbl
            // 
            this.SupplierNameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierNameLbl.AutoSize = true;
            this.SupplierNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierNameLbl.Location = new System.Drawing.Point(289, 145);
            this.SupplierNameLbl.Name = "SupplierNameLbl";
            this.SupplierNameLbl.Size = new System.Drawing.Size(90, 15);
            this.SupplierNameLbl.TabIndex = 45;
            this.SupplierNameLbl.Text = "Supplier Name*";
            // 
            // BoLCmbxUC
            // 
            this.BoLCmbxUC.listItemsDropCmbx = null;
            this.BoLCmbxUC.Location = new System.Drawing.Point(288, 117);
            this.BoLCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BoLCmbxUC.Name = "BoLCmbxUC";
            this.BoLCmbxUC.Size = new System.Drawing.Size(172, 23);
            this.BoLCmbxUC.TabIndex = 44;
            // 
            // BKCmbxUC
            // 
            this.BKCmbxUC.listItemsDropCmbx = null;
            this.BKCmbxUC.Location = new System.Drawing.Point(288, 77);
            this.BKCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BKCmbxUC.Name = "BKCmbxUC";
            this.BKCmbxUC.Size = new System.Drawing.Size(172, 23);
            this.BKCmbxUC.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(288, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 42;
            this.label2.Text = "Sale Bill Of Lading*";
            // 
            // SaleBKLbl
            // 
            this.SaleBKLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleBKLbl.AutoSize = true;
            this.SaleBKLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleBKLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleBKLbl.Location = new System.Drawing.Point(288, 59);
            this.SaleBKLbl.Name = "SaleBKLbl";
            this.SaleBKLbl.Size = new System.Drawing.Size(127, 15);
            this.SaleBKLbl.TabIndex = 41;
            this.SaleBKLbl.Text = "Sale Booking Number*";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(289, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date";
            // 
            // OpenSupplier
            // 
            this.OpenSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSupplier.FlatAppearance.BorderSize = 0;
            this.OpenSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSupplier.Location = new System.Drawing.Point(465, 185);
            this.OpenSupplier.Name = "OpenSupplier";
            this.OpenSupplier.Size = new System.Drawing.Size(55, 25);
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
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(465, 95);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(55, 25);
            this.OpenSale.TabIndex = 29;
            this.OpenSale.Text = "Open";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(767, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 427);
            this.panel5.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 427);
            this.panel3.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 17);
            this.panel2.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 444);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(784, 17);
            this.panel4.TabIndex = 36;
            // 
            // CreateSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
        private DateTimePicker DateClnd;
        private Button SaveEditCustomerBtn;
        private Panel CreatePanel;
        private Button OpenSupplier;
        private Button OpenSale;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private control.DropDownMenuAutoCompleteUserControl BoLCmbxUC;
        private control.DropDownMenuAutoCompleteUserControl BKCmbxUC;
        private Label label2;
        private Label SaleBKLbl;
        private control.DropDownMenuAutoCompleteUserControl CountryCmbxUC;
        private control.DropDownMenuAutoCompleteUserControl NameCmbxUC;
        private Label SupplierCountryLbl;
        private Label SupplierNameLbl;
    }
}