namespace WinformDotNetFramework.Forms.CustomDialog
{
    partial class ChooseReportDialog
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ReportLbl = new System.Windows.Forms.Label();
            this.SaleReportRadio = new System.Windows.Forms.RadioButton();
            this.CustomerInvoiceReportRadio = new System.Windows.Forms.RadioButton();
            this.SupplierInvoiceReportRadio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SupplierInvoiceReportRadio);
            this.panel1.Controls.Add(this.CustomerInvoiceReportRadio);
            this.panel1.Controls.Add(this.SaleReportRadio);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.ReportLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 181);
            this.panel1.TabIndex = 13;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(205, 133);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(64, 25);
            this.SaveBtn.TabIndex = 10;
            this.SaveBtn.Text = "Open";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // ReportLbl
            // 
            this.ReportLbl.AutoSize = true;
            this.ReportLbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ReportLbl.Location = new System.Drawing.Point(51, 26);
            this.ReportLbl.Name = "ReportLbl";
            this.ReportLbl.Size = new System.Drawing.Size(218, 19);
            this.ReportLbl.TabIndex = 0;
            this.ReportLbl.Text = "Select the form you want to open!";
            // 
            // SaleReportRadio
            // 
            this.SaleReportRadio.AutoSize = true;
            this.SaleReportRadio.Location = new System.Drawing.Point(55, 54);
            this.SaleReportRadio.Name = "SaleReportRadio";
            this.SaleReportRadio.Size = new System.Drawing.Size(84, 19);
            this.SaleReportRadio.TabIndex = 11;
            this.SaleReportRadio.TabStop = true;
            this.SaleReportRadio.Text = "Sale Report";
            this.SaleReportRadio.UseVisualStyleBackColor = true;
            // 
            // CustomerInvoiceReportRadio
            // 
            this.CustomerInvoiceReportRadio.AutoSize = true;
            this.CustomerInvoiceReportRadio.Location = new System.Drawing.Point(55, 79);
            this.CustomerInvoiceReportRadio.Name = "CustomerInvoiceReportRadio";
            this.CustomerInvoiceReportRadio.Size = new System.Drawing.Size(156, 19);
            this.CustomerInvoiceReportRadio.TabIndex = 12;
            this.CustomerInvoiceReportRadio.TabStop = true;
            this.CustomerInvoiceReportRadio.Text = "Customer Invoice Report";
            this.CustomerInvoiceReportRadio.UseVisualStyleBackColor = true;
            // 
            // SupplierInvoiceReportRadio
            // 
            this.SupplierInvoiceReportRadio.AutoSize = true;
            this.SupplierInvoiceReportRadio.Location = new System.Drawing.Point(55, 104);
            this.SupplierInvoiceReportRadio.Name = "SupplierInvoiceReportRadio";
            this.SupplierInvoiceReportRadio.Size = new System.Drawing.Size(147, 19);
            this.SupplierInvoiceReportRadio.TabIndex = 13;
            this.SupplierInvoiceReportRadio.TabStop = true;
            this.SupplierInvoiceReportRadio.Text = "Supplier Invoice Report";
            this.SupplierInvoiceReportRadio.UseVisualStyleBackColor = true;
            // 
            // ChooseReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 181);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 220);
            this.MinimumSize = new System.Drawing.Size(350, 220);
            this.Name = "ChooseReportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ReportLbl;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.RadioButton SupplierInvoiceReportRadio;
        private System.Windows.Forms.RadioButton CustomerInvoiceReportRadio;
        private System.Windows.Forms.RadioButton SaleReportRadio;
    }
}