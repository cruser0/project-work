namespace WinformDotNetFramework.Forms.SelectionForm
{
    partial class SelectSupplierInvoicesForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PercentageCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.FixedCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.MakeInvoiceBtn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CenterPanel
            // 
            this.CenterPanel.Location = new System.Drawing.Point(0, 100);
            this.CenterPanel.Size = new System.Drawing.Size(800, 361);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(800, 100);
            this.panel1.Size = new System.Drawing.Size(0, 361);
            this.panel1.Visible = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Location = new System.Drawing.Point(0, 461);
            this.BottomPanel.Size = new System.Drawing.Size(800, 0);
            this.BottomPanel.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.panel3.Controls.Add(this.MakeInvoiceBtn);
            this.panel3.Controls.Add(this.FixedCtb);
            this.panel3.Controls.Add(this.PercentageCtb);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 100);
            this.panel3.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // PercentageCtb
            // 
            this.PercentageCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PercentageCtb.Location = new System.Drawing.Point(12, 47);
            this.PercentageCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.PercentageCtb.Name = "PercentageCtb";
            this.PercentageCtb.Size = new System.Drawing.Size(200, 47);
            this.PercentageCtb.TabIndex = 14;
            this.PercentageCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
            // FixedCtb
            // 
            this.FixedCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FixedCtb.Location = new System.Drawing.Point(218, 47);
            this.FixedCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.FixedCtb.Name = "FixedCtb";
            this.FixedCtb.Size = new System.Drawing.Size(200, 47);
            this.FixedCtb.TabIndex = 15;
            this.FixedCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
            // MakeInvoiceBtn
            // 
            this.MakeInvoiceBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MakeInvoiceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.MakeInvoiceBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeInvoiceBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.MakeInvoiceBtn.Location = new System.Drawing.Point(705, 58);
            this.MakeInvoiceBtn.Name = "MakeInvoiceBtn";
            this.MakeInvoiceBtn.Size = new System.Drawing.Size(92, 25);
            this.MakeInvoiceBtn.TabIndex = 16;
            this.MakeInvoiceBtn.Text = "Make Invoice";
            this.MakeInvoiceBtn.UseVisualStyleBackColor = false;
            this.MakeInvoiceBtn.Click += new System.EventHandler(this.MakeInvoiceBtn_Click);
            // 
            // SelectSupplierInvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.panel3);
            this.Name = "SelectSupplierInvoicesForm";
            this.Text = "SelectSupplierInvoicesForm";
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.CenterPanel, 0);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private control.CustomTextBoxUserControl FixedCtb;
        private control.CustomTextBoxUserControl PercentageCtb;
        private System.Windows.Forms.Button MakeInvoiceBtn;
    }
}