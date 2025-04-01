namespace WinformDotNetFramework
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.CustomerInvoiceCode = new WinformDotNetFramework.RedTextBox();
            this.CostRegistryCode = new WinformDotNetFramework.RedTextBox();
            this.name = new WinformDotNetFramework.RedTextBox();
            this.Quantity = new WinformDotNetFramework.RedTextBox();
            this.Cost = new WinformDotNetFramework.RedTextBox();
            this.CustomerInvoiceId = new WinformDotNetFramework.RedTextBox();
            this.CustomerInvoiceIdLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.QuantityLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostRegistryCodeLbl = new System.Windows.Forms.Label();
            this.CustomerInvoiceCodeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerInvoiceCode
            // 
            this.CustomerInvoiceCode.Location = new System.Drawing.Point(259, 291);
            this.CustomerInvoiceCode.Name = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.Size = new System.Drawing.Size(199, 20);
            this.CustomerInvoiceCode.TabIndex = 7;
            this.CustomerInvoiceCode.Tag = "CustomerInvoiceCode";
            // 
            // CostRegistryCode
            // 
            this.CostRegistryCode.Location = new System.Drawing.Point(259, 242);
            this.CostRegistryCode.Name = "CostRegistryCode";
            this.CostRegistryCode.Size = new System.Drawing.Size(199, 20);
            this.CostRegistryCode.TabIndex = 6;
            this.CostRegistryCode.Tag = "CostRegistryCode";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(259, 193);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(199, 20);
            this.name.TabIndex = 5;
            this.name.Tag = "Name";
            // 
            // Quantity
            // 
            this.Quantity.Location = new System.Drawing.Point(259, 144);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(199, 20);
            this.Quantity.TabIndex = 4;
            this.Quantity.Tag = "Quantity";
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(259, 95);
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(199, 20);
            this.Cost.TabIndex = 3;
            this.Cost.Tag = "Cost";
            // 
            // CustomerInvoiceId
            // 
            this.CustomerInvoiceId.Location = new System.Drawing.Point(259, 46);
            this.CustomerInvoiceId.Name = "CustomerInvoiceId";
            this.CustomerInvoiceId.Size = new System.Drawing.Size(199, 20);
            this.CustomerInvoiceId.TabIndex = 2;
            this.CustomerInvoiceId.Tag = "CustomerInvoiceId";
            // 
            // CustomerInvoiceIdLbl
            // 
            this.CustomerInvoiceIdLbl.AutoSize = true;
            this.CustomerInvoiceIdLbl.Location = new System.Drawing.Point(259, 25);
            this.CustomerInvoiceIdLbl.Name = "CustomerInvoiceIdLbl";
            this.CustomerInvoiceIdLbl.Size = new System.Drawing.Size(95, 13);
            this.CustomerInvoiceIdLbl.TabIndex = 8;
            this.CustomerInvoiceIdLbl.Text = "CustomerInvoiceId";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Location = new System.Drawing.Point(259, 74);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(28, 13);
            this.CostLbl.TabIndex = 9;
            this.CostLbl.Text = "Cost";
            // 
            // QuantityLbl
            // 
            this.QuantityLbl.AutoSize = true;
            this.QuantityLbl.Location = new System.Drawing.Point(259, 123);
            this.QuantityLbl.Name = "QuantityLbl";
            this.QuantityLbl.Size = new System.Drawing.Size(46, 13);
            this.QuantityLbl.TabIndex = 10;
            this.QuantityLbl.Text = "Quantity";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(259, 172);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(35, 13);
            this.NameLbl.TabIndex = 11;
            this.NameLbl.Text = "Name";
            // 
            // CostRegistryCodeLbl
            // 
            this.CostRegistryCodeLbl.AutoSize = true;
            this.CostRegistryCodeLbl.Location = new System.Drawing.Point(259, 221);
            this.CostRegistryCodeLbl.Name = "CostRegistryCodeLbl";
            this.CostRegistryCodeLbl.Size = new System.Drawing.Size(91, 13);
            this.CostRegistryCodeLbl.TabIndex = 12;
            this.CostRegistryCodeLbl.Text = "CostRegistryCode";
            // 
            // CustomerInvoiceCodeLbl
            // 
            this.CustomerInvoiceCodeLbl.AutoSize = true;
            this.CustomerInvoiceCodeLbl.Location = new System.Drawing.Point(259, 270);
            this.CustomerInvoiceCodeLbl.Name = "CustomerInvoiceCodeLbl";
            this.CustomerInvoiceCodeLbl.Size = new System.Drawing.Size(111, 13);
            this.CustomerInvoiceCodeLbl.TabIndex = 13;
            this.CustomerInvoiceCodeLbl.Text = "CustomerInvoiceCode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomerInvoiceCodeLbl);
            this.Controls.Add(this.CostRegistryCodeLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.QuantityLbl);
            this.Controls.Add(this.CostLbl);
            this.Controls.Add(this.CustomerInvoiceIdLbl);
            this.Controls.Add(this.CustomerInvoiceCode);
            this.Controls.Add(this.CostRegistryCode);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.CustomerInvoiceId);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private RedTextBox CustomerInvoiceId;
        private RedTextBox Cost;
        private RedTextBox name;
        private RedTextBox Quantity;
        private RedTextBox CustomerInvoiceCode;
        private RedTextBox CostRegistryCode;
        private System.Windows.Forms.Label CustomerInvoiceIdLbl;
        private System.Windows.Forms.Label CostLbl;
        private System.Windows.Forms.Label QuantityLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label CostRegistryCodeLbl;
        private System.Windows.Forms.Label CustomerInvoiceCodeLbl;
    }
}