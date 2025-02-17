namespace Winform.Forms
{
    partial class SupplierInvoiceDetailsForm
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
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.EditCustomerCbx = new System.Windows.Forms.CheckBox();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.IdSupplierInvoiceLbl = new System.Windows.Forms.Label();
            this.CountryCustomerTxt = new System.Windows.Forms.TextBox();
            this.IdCustomerTxt = new System.Windows.Forms.TextBox();
            this.NameCustomerTxt = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(322, 369);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditCustomerBtn.TabIndex = 16;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            // 
            // EditCustomerCbx
            // 
            this.EditCustomerCbx.AutoSize = true;
            this.EditCustomerCbx.Location = new System.Drawing.Point(320, 344);
            this.EditCustomerCbx.Name = "EditCustomerCbx";
            this.EditCustomerCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCustomerCbx.TabIndex = 15;
            this.EditCustomerCbx.Text = "Edit";
            this.EditCustomerCbx.UseVisualStyleBackColor = true;
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(322, 188);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(50, 15);
            this.SupplierIDLbl.TabIndex = 14;
            this.SupplierIDLbl.Text = "Country";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(322, 133);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 13;
            this.SaleIDLbl.Text = "Name";
            // 
            // IdSupplierInvoiceLbl
            // 
            this.IdSupplierInvoiceLbl.AutoSize = true;
            this.IdSupplierInvoiceLbl.Location = new System.Drawing.Point(322, 77);
            this.IdSupplierInvoiceLbl.Name = "IdSupplierInvoiceLbl";
            this.IdSupplierInvoiceLbl.Size = new System.Drawing.Size(17, 15);
            this.IdSupplierInvoiceLbl.TabIndex = 12;
            this.IdSupplierInvoiceLbl.Text = "Id";
            // 
            // CountryCustomerTxt
            // 
            this.CountryCustomerTxt.Location = new System.Drawing.Point(320, 206);
            this.CountryCustomerTxt.Name = "CountryCustomerTxt";
            this.CountryCustomerTxt.Size = new System.Drawing.Size(121, 23);
            this.CountryCustomerTxt.TabIndex = 11;
            // 
            // IdCustomerTxt
            // 
            this.IdCustomerTxt.Location = new System.Drawing.Point(320, 95);
            this.IdCustomerTxt.Name = "IdCustomerTxt";
            this.IdCustomerTxt.Size = new System.Drawing.Size(121, 23);
            this.IdCustomerTxt.TabIndex = 9;
            // 
            // NameCustomerTxt
            // 
            this.NameCustomerTxt.Location = new System.Drawing.Point(320, 149);
            this.NameCustomerTxt.Name = "NameCustomerTxt";
            this.NameCustomerTxt.Size = new System.Drawing.Size(121, 23);
            this.NameCustomerTxt.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(320, 260);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 17;
            // 
            // SupplierInvoiceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SaveEditCustomerBtn);
            this.Controls.Add(this.EditCustomerCbx);
            this.Controls.Add(this.SupplierIDLbl);
            this.Controls.Add(this.SaleIDLbl);
            this.Controls.Add(this.IdSupplierInvoiceLbl);
            this.Controls.Add(this.CountryCustomerTxt);
            this.Controls.Add(this.IdCustomerTxt);
            this.Controls.Add(this.NameCustomerTxt);
            this.Name = "SupplierInvoiceDetailsForm";
            this.Text = "SupplierInvoiceDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveEditCustomerBtn;
        private CheckBox EditCustomerCbx;
        private Label SupplierIDLbl;
        private Label SaleIDLbl;
        private Label IdSupplierInvoiceLbl;
        private TextBox CountryCustomerTxt;
        private TextBox IdCustomerTxt;
        private TextBox NameCustomerTxt;
        private ComboBox comboBox1;
    }
}