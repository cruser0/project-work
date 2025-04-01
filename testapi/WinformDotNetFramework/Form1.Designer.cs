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
            this.CustomerInvoiceIdLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.QuantityLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostRegistryCodeLbl = new System.Windows.Forms.Label();
            this.CustomerInvoiceCodeLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IsPostTxt = new WinformDotNetFramework.CustomTextbox();
            this.CustomerInvoiceCodeTxt = new WinformDotNetFramework.CustomTextbox();
            this.CostRegistryCodeTxt = new WinformDotNetFramework.CustomTextbox();
            this.NameTxt = new WinformDotNetFramework.CustomTextbox();
            this.QuantityTxt = new WinformDotNetFramework.CustomTextbox();
            this.CostTxt = new WinformDotNetFramework.CustomTextbox();
            this.CustomerInvoiceIdTxt = new WinformDotNetFramework.CustomTextbox();
            this.customComboBox1 = new WinformDotNetFramework.Forms.CustomComboBox();
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
            this.CostLbl.Location = new System.Drawing.Point(259, 76);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(28, 13);
            this.CostLbl.TabIndex = 9;
            this.CostLbl.Text = "Cost";
            // 
            // QuantityLbl
            // 
            this.QuantityLbl.AutoSize = true;
            this.QuantityLbl.Location = new System.Drawing.Point(259, 127);
            this.QuantityLbl.Name = "QuantityLbl";
            this.QuantityLbl.Size = new System.Drawing.Size(46, 13);
            this.QuantityLbl.TabIndex = 10;
            this.QuantityLbl.Text = "Quantity";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(259, 178);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(35, 13);
            this.NameLbl.TabIndex = 11;
            this.NameLbl.Text = "Name";
            // 
            // CostRegistryCodeLbl
            // 
            this.CostRegistryCodeLbl.AutoSize = true;
            this.CostRegistryCodeLbl.Location = new System.Drawing.Point(259, 229);
            this.CostRegistryCodeLbl.Name = "CostRegistryCodeLbl";
            this.CostRegistryCodeLbl.Size = new System.Drawing.Size(91, 13);
            this.CostRegistryCodeLbl.TabIndex = 12;
            this.CostRegistryCodeLbl.Text = "CostRegistryCode";
            // 
            // CustomerInvoiceCodeLbl
            // 
            this.CustomerInvoiceCodeLbl.AutoSize = true;
            this.CustomerInvoiceCodeLbl.Location = new System.Drawing.Point(259, 280);
            this.CustomerInvoiceCodeLbl.Name = "CustomerInvoiceCodeLbl";
            this.CustomerInvoiceCodeLbl.Size = new System.Drawing.Size(111, 13);
            this.CustomerInvoiceCodeLbl.TabIndex = 13;
            this.CustomerInvoiceCodeLbl.Text = "CustomerInvoiceCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "IsPost";
            // 
            // IsPostTxt
            // 
            this.IsPostTxt.Location = new System.Drawing.Point(259, 348);
            this.IsPostTxt.Name = "IsPostTxt";
            this.IsPostTxt.Size = new System.Drawing.Size(199, 20);
            this.IsPostTxt.TabIndex = 16;
            // 
            // CustomerInvoiceCodeTxt
            // 
            this.CustomerInvoiceCodeTxt.Location = new System.Drawing.Point(259, 302);
            this.CustomerInvoiceCodeTxt.Name = "CustomerInvoiceCodeTxt";
            this.CustomerInvoiceCodeTxt.Size = new System.Drawing.Size(199, 20);
            this.CustomerInvoiceCodeTxt.TabIndex = 7;
            // 
            // CostRegistryCodeTxt
            // 
            this.CostRegistryCodeTxt.Location = new System.Drawing.Point(259, 251);
            this.CostRegistryCodeTxt.Name = "CostRegistryCodeTxt";
            this.CostRegistryCodeTxt.Size = new System.Drawing.Size(199, 20);
            this.CostRegistryCodeTxt.TabIndex = 6;
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(259, 200);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(199, 20);
            this.NameTxt.TabIndex = 5;
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Location = new System.Drawing.Point(259, 149);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(199, 20);
            this.QuantityTxt.TabIndex = 4;
            // 
            // CostTxt
            // 
            this.CostTxt.Location = new System.Drawing.Point(259, 98);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(199, 20);
            this.CostTxt.TabIndex = 3;
            // 
            // CustomerInvoiceIdTxt
            // 
            this.CustomerInvoiceIdTxt.Location = new System.Drawing.Point(259, 47);
            this.CustomerInvoiceIdTxt.Name = "CustomerInvoiceIdTxt";
            this.CustomerInvoiceIdTxt.Size = new System.Drawing.Size(199, 20);
            this.CustomerInvoiceIdTxt.TabIndex = 2;
            // 
            // customComboBox1
            // 
            this.customComboBox1.BorderColor = System.Drawing.Color.Black;
            this.customComboBox1.FormattingEnabled = true;
            this.customComboBox1.Location = new System.Drawing.Point(36, 199);
            this.customComboBox1.Name = "customComboBox1";
            this.customComboBox1.Size = new System.Drawing.Size(152, 21);
            this.customComboBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customComboBox1);
            this.Controls.Add(this.IsPostTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerInvoiceCodeLbl);
            this.Controls.Add(this.CostRegistryCodeLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.QuantityLbl);
            this.Controls.Add(this.CostLbl);
            this.Controls.Add(this.CustomerInvoiceIdLbl);
            this.Controls.Add(this.CustomerInvoiceCodeTxt);
            this.Controls.Add(this.CostRegistryCodeTxt);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.CostTxt);
            this.Controls.Add(this.CustomerInvoiceIdTxt);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private CustomTextbox CustomerInvoiceIdTxt;
        private CustomTextbox CostTxt;
        private CustomTextbox NameTxt;
        private CustomTextbox QuantityTxt;
        private CustomTextbox CustomerInvoiceCodeTxt;
        private CustomTextbox CostRegistryCodeTxt;
        private System.Windows.Forms.Label CustomerInvoiceIdLbl;
        private System.Windows.Forms.Label CostLbl;
        private System.Windows.Forms.Label QuantityLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label CostRegistryCodeLbl;
        private System.Windows.Forms.Label CustomerInvoiceCodeLbl;
        private System.Windows.Forms.Label label1;
        private CustomTextbox IsPostTxt;
        private Forms.CustomComboBox customComboBox1;
    }
}