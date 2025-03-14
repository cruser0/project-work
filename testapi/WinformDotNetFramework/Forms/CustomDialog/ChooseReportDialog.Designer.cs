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
            this.SaleBtn = new System.Windows.Forms.Button();
            this.CustomerInvoiceBtn = new System.Windows.Forms.Button();
            this.SupplierInvoiceBtn = new System.Windows.Forms.Button();
            this.ReportLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SaleBtn);
            this.panel1.Controls.Add(this.CustomerInvoiceBtn);
            this.panel1.Controls.Add(this.SupplierInvoiceBtn);
            this.panel1.Controls.Add(this.ReportLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 105);
            this.panel1.TabIndex = 13;
            // 
            // SaleBtn
            // 
            this.SaleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaleBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleBtn.Location = new System.Drawing.Point(168, 61);
            this.SaleBtn.Name = "SaleBtn";
            this.SaleBtn.Size = new System.Drawing.Size(64, 25);
            this.SaleBtn.TabIndex = 10;
            this.SaleBtn.Text = "Sale";
            this.SaleBtn.UseVisualStyleBackColor = false;
            this.SaleBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerInvoiceBtn
            // 
            this.CustomerInvoiceBtn.AutoSize = true;
            this.CustomerInvoiceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.CustomerInvoiceBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerInvoiceBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CustomerInvoiceBtn.Location = new System.Drawing.Point(52, 61);
            this.CustomerInvoiceBtn.Name = "CustomerInvoiceBtn";
            this.CustomerInvoiceBtn.Size = new System.Drawing.Size(110, 25);
            this.CustomerInvoiceBtn.TabIndex = 9;
            this.CustomerInvoiceBtn.Text = "Customer Invoice";
            this.CustomerInvoiceBtn.UseVisualStyleBackColor = false;
            this.CustomerInvoiceBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // SupplierInvoiceBtn
            // 
            this.SupplierInvoiceBtn.AutoSize = true;
            this.SupplierInvoiceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SupplierInvoiceBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierInvoiceBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierInvoiceBtn.Location = new System.Drawing.Point(238, 61);
            this.SupplierInvoiceBtn.Name = "SupplierInvoiceBtn";
            this.SupplierInvoiceBtn.Size = new System.Drawing.Size(101, 25);
            this.SupplierInvoiceBtn.TabIndex = 8;
            this.SupplierInvoiceBtn.Text = "Supplier Invoice";
            this.SupplierInvoiceBtn.UseVisualStyleBackColor = false;
            this.SupplierInvoiceBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportLbl
            // 
            this.ReportLbl.AutoSize = true;
            this.ReportLbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ReportLbl.Location = new System.Drawing.Point(81, 21);
            this.ReportLbl.Name = "ReportLbl";
            this.ReportLbl.Size = new System.Drawing.Size(218, 19);
            this.ReportLbl.TabIndex = 0;
            this.ReportLbl.Text = "Select the form you want to open!";
            // 
            // ChooseReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 109);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 148);
            this.MinimumSize = new System.Drawing.Size(400, 148);
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
        private System.Windows.Forms.Button SaleBtn;
        private System.Windows.Forms.Button CustomerInvoiceBtn;
        private System.Windows.Forms.Button SupplierInvoiceBtn;
    }
}