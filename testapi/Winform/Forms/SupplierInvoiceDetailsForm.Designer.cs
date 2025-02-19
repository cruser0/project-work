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
            this.EditCbx = new System.Windows.Forms.CheckBox();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.IdSupplierInvoiceLbl = new System.Windows.Forms.Label();
            this.IdTxt = new System.Windows.Forms.TextBox();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.SaleIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SupplierIDTxt1 = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SuspendLayout();
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(320, 324);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(107, 23);
            this.SaveEditCustomerBtn.TabIndex = 16;
            this.SaveEditCustomerBtn.Text = "Save changes";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // EditCbx
            // 
            this.EditCbx.AutoSize = true;
            this.EditCbx.Location = new System.Drawing.Point(320, 299);
            this.EditCbx.Name = "EditCbx";
            this.EditCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCbx.TabIndex = 15;
            this.EditCbx.Text = "Edit";
            this.EditCbx.UseVisualStyleBackColor = true;
            this.EditCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(322, 125);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 14;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(322, 70);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 13;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // IdSupplierInvoiceLbl
            // 
            this.IdSupplierInvoiceLbl.AutoSize = true;
            this.IdSupplierInvoiceLbl.Location = new System.Drawing.Point(322, 14);
            this.IdSupplierInvoiceLbl.Name = "IdSupplierInvoiceLbl";
            this.IdSupplierInvoiceLbl.Size = new System.Drawing.Size(17, 15);
            this.IdSupplierInvoiceLbl.TabIndex = 12;
            this.IdSupplierInvoiceLbl.Text = "Id";
            // 
            // IdTxt
            // 
            this.IdTxt.Location = new System.Drawing.Point(320, 32);
            this.IdTxt.Name = "IdTxt";
            this.IdTxt.Size = new System.Drawing.Size(206, 23);
            this.IdTxt.TabIndex = 9;
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(320, 197);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(206, 23);
            this.StatusCmbx.TabIndex = 17;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(321, 179);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 18;
            this.StatusLbl.Text = "Status";
            // 
            // DateClnd
            // 
            this.DateClnd.Location = new System.Drawing.Point(320, 252);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(206, 23);
            this.DateClnd.TabIndex = 19;
            // 
            // SaleIDTxt1
            // 
            this.SaleIDTxt1.Location = new System.Drawing.Point(320, 88);
            this.SaleIDTxt1.Name = "SaleIDTxt1";
            this.SaleIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SaleIDTxt1.TabIndex = 20;
            // 
            // SupplierIDTxt1
            // 
            this.SupplierIDTxt1.Location = new System.Drawing.Point(320, 143);
            this.SupplierIDTxt1.Name = "SupplierIDTxt1";
            this.SupplierIDTxt1.Size = new System.Drawing.Size(206, 23);
            this.SupplierIDTxt1.TabIndex = 21;
            // 
            // SupplierInvoiceDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SupplierIDTxt1);
            this.Controls.Add(this.SaleIDTxt1);
            this.Controls.Add(this.DateClnd);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.StatusCmbx);
            this.Controls.Add(this.SaveEditCustomerBtn);
            this.Controls.Add(this.EditCbx);
            this.Controls.Add(this.SupplierIDLbl);
            this.Controls.Add(this.SaleIDLbl);
            this.Controls.Add(this.IdSupplierInvoiceLbl);
            this.Controls.Add(this.IdTxt);
            this.Name = "SupplierInvoiceDetailsForm";
            this.Text = "SupplierInvoiceDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveEditCustomerBtn;
        private CheckBox EditCbx;
        private Label SupplierIDLbl;
        private Label SaleIDLbl;
        private Label IdSupplierInvoiceLbl;
        private TextBox IdTxt;
        private ComboBox StatusCmbx;
        private Label StatusLbl;
        private DateTimePicker DateClnd;
        private control.IntegerTextBoxUserControl SaleIDTxt1;
        private control.IntegerTextBoxUserControl SupplierIDTxt1;
    }
}