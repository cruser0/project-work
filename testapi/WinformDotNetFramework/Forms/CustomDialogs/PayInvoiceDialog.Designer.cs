namespace WinformDotNetFramework.Forms.CustomDialogs
{
    partial class PayInvoiceDialog
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
            this.InvoiceAmountBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.PayBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.CustomerBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.InvoiceCodeBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.BkBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.BolBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.AmountToPayBtc = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SuspendLayout();
            // 
            // InvoiceAmountBtc
            // 
            this.InvoiceAmountBtc.Location = new System.Drawing.Point(12, 124);
            this.InvoiceAmountBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.InvoiceAmountBtc.Name = "InvoiceAmountBtc";
            this.InvoiceAmountBtc.Size = new System.Drawing.Size(200, 47);
            this.InvoiceAmountBtc.TabIndex = 0;
            this.InvoiceAmountBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // PayBtn
            // 
            this.PayBtn.Location = new System.Drawing.Point(266, 176);
            this.PayBtn.Name = "PayBtn";
            this.PayBtn.Size = new System.Drawing.Size(75, 23);
            this.PayBtn.TabIndex = 1;
            this.PayBtn.Text = "Pay";
            this.PayBtn.UseVisualStyleBackColor = true;
            this.PayBtn.Click += new System.EventHandler(this.PayBtn_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(347, 176);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(75, 23);
            this.QuitBtn.TabIndex = 2;
            this.QuitBtn.Text = "Cancel";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // CustomerBtc
            // 
            this.CustomerBtc.Location = new System.Drawing.Point(12, 65);
            this.CustomerBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerBtc.Name = "CustomerBtc";
            this.CustomerBtc.Size = new System.Drawing.Size(200, 47);
            this.CustomerBtc.TabIndex = 3;
            this.CustomerBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // InvoiceCodeBtc
            // 
            this.InvoiceCodeBtc.Location = new System.Drawing.Point(222, 65);
            this.InvoiceCodeBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.InvoiceCodeBtc.Name = "InvoiceCodeBtc";
            this.InvoiceCodeBtc.Size = new System.Drawing.Size(200, 47);
            this.InvoiceCodeBtc.TabIndex = 4;
            this.InvoiceCodeBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // BkBtc
            // 
            this.BkBtc.Location = new System.Drawing.Point(222, 12);
            this.BkBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.BkBtc.Name = "BkBtc";
            this.BkBtc.Size = new System.Drawing.Size(200, 47);
            this.BkBtc.TabIndex = 5;
            this.BkBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // BolBtc
            // 
            this.BolBtc.Location = new System.Drawing.Point(12, 12);
            this.BolBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.BolBtc.Name = "BolBtc";
            this.BolBtc.Size = new System.Drawing.Size(200, 47);
            this.BolBtc.TabIndex = 6;
            this.BolBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // AmountToPayBtc
            // 
            this.AmountToPayBtc.Location = new System.Drawing.Point(222, 124);
            this.AmountToPayBtc.MinimumSize = new System.Drawing.Size(200, 47);
            this.AmountToPayBtc.Name = "AmountToPayBtc";
            this.AmountToPayBtc.Size = new System.Drawing.Size(200, 47);
            this.AmountToPayBtc.TabIndex = 7;
            this.AmountToPayBtc.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // PayInvoiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.AmountToPayBtc);
            this.Controls.Add(this.BolBtc);
            this.Controls.Add(this.BkBtc);
            this.Controls.Add(this.InvoiceCodeBtc);
            this.Controls.Add(this.CustomerBtc);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.PayBtn);
            this.Controls.Add(this.InvoiceAmountBtc);
            this.Name = "PayInvoiceDialog";
            this.Text = "PayInvoiceDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private control.CustomTextBoxUserControl InvoiceAmountBtc;
        private System.Windows.Forms.Button PayBtn;
        private System.Windows.Forms.Button QuitBtn;
        private control.CustomTextBoxUserControl CustomerBtc;
        private control.CustomTextBoxUserControl InvoiceCodeBtc;
        private control.CustomTextBoxUserControl BkBtc;
        private control.CustomTextBoxUserControl BolBtc;
        private control.CustomTextBoxUserControl AmountToPayBtc;
    }
}