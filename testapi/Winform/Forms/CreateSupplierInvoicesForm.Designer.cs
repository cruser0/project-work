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
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDTxt = new System.Windows.Forms.TextBox();
            this.SaleIDTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DateClnd
            // 
            this.DateClnd.AllowDrop = true;
            this.DateClnd.Location = new System.Drawing.Point(297, 269);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(206, 23);
            this.DateClnd.TabIndex = 28;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Location = new System.Drawing.Point(298, 196);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.StatusCmbx.Location = new System.Drawing.Point(297, 214);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(206, 23);
            this.StatusCmbx.TabIndex = 26;
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.AllowDrop = true;
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(297, 325);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(157, 23);
            this.SaveEditCustomerBtn.TabIndex = 25;
            this.SaveEditCustomerBtn.Text = "Create Supplier Invoice";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = true;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(299, 142);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(61, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "SupplierID";
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(299, 87);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(39, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "SaleID";
            // 
            // SupplierIDTxt
            // 
            this.SupplierIDTxt.AllowDrop = true;
            this.SupplierIDTxt.Location = new System.Drawing.Point(297, 160);
            this.SupplierIDTxt.Name = "SupplierIDTxt";
            this.SupplierIDTxt.Size = new System.Drawing.Size(206, 23);
            this.SupplierIDTxt.TabIndex = 21;
            // 
            // SaleIDTxt
            // 
            this.SaleIDTxt.AllowDrop = true;
            this.SaleIDTxt.Location = new System.Drawing.Point(297, 103);
            this.SaleIDTxt.Name = "SaleIDTxt";
            this.SaleIDTxt.Size = new System.Drawing.Size(206, 23);
            this.SaleIDTxt.TabIndex = 20;
            // 
            // CreateSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DateClnd);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.StatusCmbx);
            this.Controls.Add(this.SaveEditCustomerBtn);
            this.Controls.Add(this.SupplierIDLbl);
            this.Controls.Add(this.SaleIDLbl);
            this.Controls.Add(this.SupplierIDTxt);
            this.Controls.Add(this.SaleIDTxt);
            this.Name = "CreateSupplierInvoicesForm";
            this.Text = "CreateSupplierInvoicesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker DateClnd;
        private Label StatusLbl;
        private ComboBox StatusCmbx;
        private Button SaveEditCustomerBtn;
        private Label SupplierIDLbl;
        private Label SaleIDLbl;
        private TextBox SupplierIDTxt;
        private TextBox SaleIDTxt;
    }
}