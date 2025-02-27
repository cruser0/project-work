namespace Winform.Forms.AddForms
{
    partial class CreateCustomerInvoiceCostForm
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerInvoiceIdTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.QuantityTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CostTxt = new Winform.Forms.control.DecimalTextBoxUserControl();
            this.OpenSale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(416, 329);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Invoice ID *";
            // 
            // CustomerInvoiceIdTxt
            // 
            this.CustomerInvoiceIdTxt.Location = new System.Drawing.Point(291, 108);
            this.CustomerInvoiceIdTxt.Name = "CustomerInvoiceIdTxt";
            this.CustomerInvoiceIdTxt.Size = new System.Drawing.Size(200, 23);
            this.CustomerInvoiceIdTxt.TabIndex = 10;
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Location = new System.Drawing.Point(291, 213);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(200, 23);
            this.QuantityTxt.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Quantity *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cost *";
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(291, 269);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(200, 23);
            this.NameTxt.TabIndex = 19;
            this.NameTxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name *";
            // 
            // CostTxt
            // 
            this.CostTxt.Location = new System.Drawing.Point(291, 169);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(200, 23);
            this.CostTxt.TabIndex = 21;
            // 
            // OpenSale
            // 
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSale.Location = new System.Drawing.Point(497, 108);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(64, 23);
            this.OpenSale.TabIndex = 33;
            this.OpenSale.Text = "Open-->";
            this.OpenSale.UseVisualStyleBackColor = true;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // CreateCustomerInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OpenSale);
            this.Controls.Add(this.CostTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CustomerInvoiceIdTxt);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label1);
            this.Name = "CreateCustomerInvoiceCostForm";
            this.Text = "CreateCustomerInvoiceCostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SaveBtn;
        private Label label1;
        private control.IntegerTextBoxUserControl CustomerInvoiceIdTxt;
        private control.IntegerTextBoxUserControl QuantityTxt;
        private Label label3;
        private Label label2;
        private TextBox NameTxt;
        private Label label4;
        private control.DecimalTextBoxUserControl CostTxt;
        private Button OpenSale;
    }
}