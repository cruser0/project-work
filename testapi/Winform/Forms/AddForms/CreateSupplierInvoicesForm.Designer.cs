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
            this.SupplierIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SaleIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.OpenSupplier = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.CreatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(482, 308);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(206, 23);
            this.StatusCmbx.TabIndex = 26;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(483, 290);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(484, 181);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(484, 236);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // DateClnd
            // 
            this.DateClnd.AllowDrop = true;
            this.DateClnd.Location = new System.Drawing.Point(482, 363);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(206, 23);
            this.DateClnd.TabIndex = 28;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.AllowDrop = true;
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(482, 419);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(157, 23);
            this.SaveEditCustomerBtn.TabIndex = 25;
            this.SaveEditCustomerBtn.Text = "Create Supplier Invoice";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CreatePanel.Controls.Add(this.SupplierIDTxt1);
            this.CreatePanel.Controls.Add(this.SaleIDTxt1);
            this.CreatePanel.Controls.Add(this.OpenSupplier);
            this.CreatePanel.Controls.Add(this.OpenSale);
            this.CreatePanel.Controls.Add(this.SaleIDLbl);
            this.CreatePanel.Controls.Add(this.SupplierIDLbl);
            this.CreatePanel.Controls.Add(this.StatusLbl);
            this.CreatePanel.Controls.Add(this.SaveEditCustomerBtn);
            this.CreatePanel.Controls.Add(this.DateClnd);
            this.CreatePanel.Controls.Add(this.StatusCmbx);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatePanel.Location = new System.Drawing.Point(0, 0);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(1459, 635);
            this.CreatePanel.TabIndex = 29;
            // 
            // SupplierIDTxt1
            // 
            this.SupplierIDTxt1.Location = new System.Drawing.Point(482, 254);
            this.SupplierIDTxt1.Name = "SupplierIDTxt1";
            this.SupplierIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SupplierIDTxt1.TabIndex = 32;
            // 
            // SaleIDTxt1
            // 
            this.SaleIDTxt1.Location = new System.Drawing.Point(482, 199);
            this.SaleIDTxt1.Name = "SaleIDTxt1";
            this.SaleIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SaleIDTxt1.TabIndex = 31;
            // 
            // OpenSupplier
            // 
            this.OpenSupplier.FlatAppearance.BorderSize = 0;
            this.OpenSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSupplier.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSupplier.Location = new System.Drawing.Point(694, 254);
            this.OpenSupplier.Name = "OpenSupplier";
            this.OpenSupplier.Size = new System.Drawing.Size(64, 23);
            this.OpenSupplier.TabIndex = 30;
            this.OpenSupplier.Text = "Open-->";
            this.OpenSupplier.UseVisualStyleBackColor = true;
            this.OpenSupplier.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSale.Location = new System.Drawing.Point(694, 197);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 29;
            this.OpenSale.Text = "Open-->";
            this.OpenSale.UseVisualStyleBackColor = true;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // CreateSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 635);
            this.Controls.Add(this.CreatePanel);
            this.Name = "CreateSupplierInvoicesForm";
            this.Text = "CreateSupplierInvoicesForm";
            this.CreatePanel.ResumeLayout(false);
            this.CreatePanel.PerformLayout();
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
    }
}