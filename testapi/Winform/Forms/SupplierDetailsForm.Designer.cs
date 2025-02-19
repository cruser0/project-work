namespace Winform.Forms
{
    partial class SupplierDetailsForm
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
            this.SaveEditSupplierBtn = new System.Windows.Forms.Button();
            this.EditSupplierCbx = new System.Windows.Forms.CheckBox();
            this.CountrySupplierLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.IdSupplierLbl = new System.Windows.Forms.Label();
            this.CountrySupplierTxt = new System.Windows.Forms.TextBox();
            this.IdSupplierTxt = new System.Windows.Forms.TextBox();
            this.NameSupplierTxt = new System.Windows.Forms.TextBox();
            this.SupplierGetInvoiceBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveEditSupplierBtn
            // 
            this.SaveEditSupplierBtn.Location = new System.Drawing.Point(343, 256);
            this.SaveEditSupplierBtn.Name = "SaveEditSupplierBtn";
            this.SaveEditSupplierBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditSupplierBtn.TabIndex = 16;
            this.SaveEditSupplierBtn.Text = "Save changes";
            this.SaveEditSupplierBtn.UseVisualStyleBackColor = true;
            this.SaveEditSupplierBtn.Click += new System.EventHandler(this.SaveEditSupplierBtn_Click);
            // 
            // EditSupplierCbx
            // 
            this.EditSupplierCbx.AutoSize = true;
            this.EditSupplierCbx.Location = new System.Drawing.Point(343, 214);
            this.EditSupplierCbx.Name = "EditSupplierCbx";
            this.EditSupplierCbx.Size = new System.Drawing.Size(46, 19);
            this.EditSupplierCbx.TabIndex = 15;
            this.EditSupplierCbx.Text = "Edit";
            this.EditSupplierCbx.UseVisualStyleBackColor = true;
            this.EditSupplierCbx.CheckedChanged += new System.EventHandler(this.EditSupplierCbx_CheckedChanged);
            // 
            // CountrySupplierLbl
            // 
            this.CountrySupplierLbl.AutoSize = true;
            this.CountrySupplierLbl.Location = new System.Drawing.Point(345, 165);
            this.CountrySupplierLbl.Name = "CountrySupplierLbl";
            this.CountrySupplierLbl.Size = new System.Drawing.Size(50, 15);
            this.CountrySupplierLbl.TabIndex = 14;
            this.CountrySupplierLbl.Text = "Country";
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Location = new System.Drawing.Point(345, 100);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(39, 15);
            this.NameSupplierLbl.TabIndex = 13;
            this.NameSupplierLbl.Text = "Name";
            // 
            // IdSupplierLbl
            // 
            this.IdSupplierLbl.AutoSize = true;
            this.IdSupplierLbl.Location = new System.Drawing.Point(345, 34);
            this.IdSupplierLbl.Name = "IdSupplierLbl";
            this.IdSupplierLbl.Size = new System.Drawing.Size(17, 15);
            this.IdSupplierLbl.TabIndex = 12;
            this.IdSupplierLbl.Text = "Id";
            // 
            // CountrySupplierTxt
            // 
            this.CountrySupplierTxt.Location = new System.Drawing.Point(343, 183);
            this.CountrySupplierTxt.MaxLength = 50;
            this.CountrySupplierTxt.Name = "CountrySupplierTxt";
            this.CountrySupplierTxt.Size = new System.Drawing.Size(100, 23);
            this.CountrySupplierTxt.TabIndex = 11;
            // 
            // IdSupplierTxt
            // 
            this.IdSupplierTxt.Location = new System.Drawing.Point(343, 52);
            this.IdSupplierTxt.Name = "IdSupplierTxt";
            this.IdSupplierTxt.Size = new System.Drawing.Size(100, 23);
            this.IdSupplierTxt.TabIndex = 9;
            // 
            // NameSupplierTxt
            // 
            this.NameSupplierTxt.Location = new System.Drawing.Point(343, 116);
            this.NameSupplierTxt.MaxLength = 100;
            this.NameSupplierTxt.Name = "NameSupplierTxt";
            this.NameSupplierTxt.Size = new System.Drawing.Size(100, 23);
            this.NameSupplierTxt.TabIndex = 10;
            // 
            // SupplierGetInvoiceBtn
            // 
            this.SupplierGetInvoiceBtn.Location = new System.Drawing.Point(12, 415);
            this.SupplierGetInvoiceBtn.Name = "SupplierGetInvoiceBtn";
            this.SupplierGetInvoiceBtn.Size = new System.Drawing.Size(99, 23);
            this.SupplierGetInvoiceBtn.TabIndex = 17;
            this.SupplierGetInvoiceBtn.Text = "See Invoices";
            this.SupplierGetInvoiceBtn.UseVisualStyleBackColor = true;
            this.SupplierGetInvoiceBtn.Click += new System.EventHandler(this.SupplierGetInvoiceBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DeleteBtn.Location = new System.Drawing.Point(713, 415);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 18;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // SupplierDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.SupplierGetInvoiceBtn);
            this.Controls.Add(this.SaveEditSupplierBtn);
            this.Controls.Add(this.EditSupplierCbx);
            this.Controls.Add(this.CountrySupplierLbl);
            this.Controls.Add(this.NameSupplierLbl);
            this.Controls.Add(this.IdSupplierLbl);
            this.Controls.Add(this.CountrySupplierTxt);
            this.Controls.Add(this.IdSupplierTxt);
            this.Controls.Add(this.NameSupplierTxt);
            this.Name = "SupplierDetailsForm";
            this.Text = "SupplierDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveEditSupplierBtn;
        private CheckBox EditSupplierCbx;
        private Label CountrySupplierLbl;
        private Label NameSupplierLbl;
        private Label IdSupplierLbl;
        private TextBox CountrySupplierTxt;
        private TextBox IdSupplierTxt;
        private TextBox NameSupplierTxt;
        private Button SupplierGetInvoiceBtn;
        private Button DeleteBtn;
    }
}