namespace Winform.Forms.control
{
    partial class SearchCustomerInvoiceCost
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostToTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.CostFromTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.label4);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.NameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CostFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostLbl);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 279);
            this.TextBoxesRightPanel.TabIndex = 9;
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.Color.Gainsboro;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.Location = new System.Drawing.Point(3, 203);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 23);
            this.NameTxt.TabIndex = 15;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NameLbl.Location = new System.Drawing.Point(3, 182);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(118, 18);
            this.NameLbl.TabIndex = 16;
            this.NameLbl.Text = "Description Name";
            // 
            // CostToTxt
            // 
            this.CostToTxt.Location = new System.Drawing.Point(3, 151);
            this.CostToTxt.Name = "CostToTxt";
            this.CostToTxt.Size = new System.Drawing.Size(180, 23);
            this.CostToTxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cost To";
            // 
            // CostFromTxt
            // 
            this.CostFromTxt.Location = new System.Drawing.Point(2, 97);
            this.CostFromTxt.Name = "CostFromTxt";
            this.CostFromTxt.Size = new System.Drawing.Size(180, 23);
            this.CostFromTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.Location = new System.Drawing.Point(2, 50);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(180, 23);
            this.InvoiceIDTxt.TabIndex = 11;
            // 
            // InvoiceIDLbl
            // 
            this.InvoiceIDLbl.AutoSize = true;
            this.InvoiceIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InvoiceIDLbl.Location = new System.Drawing.Point(2, 29);
            this.InvoiceIDLbl.Name = "InvoiceIDLbl";
            this.InvoiceIDLbl.Size = new System.Drawing.Size(71, 18);
            this.InvoiceIDLbl.TabIndex = 3;
            this.InvoiceIDLbl.Text = "Invoice ID";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CostLbl.Location = new System.Drawing.Point(2, 76);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(68, 18);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Customer Invoice Cost";
            // 
            // SearchCustomerInvoiceCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchCustomerInvoiceCost";
            this.Size = new System.Drawing.Size(200, 279);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TextBoxesRightPanel;
        private TextBox NameTxt;
        private Label NameLbl;
        private IntegerTextBoxUserControl CostToTxt;
        private Label label1;
        private IntegerTextBoxUserControl CostFromTxt;
        private IntegerTextBoxUserControl InvoiceIDTxt;
        private Label InvoiceIDLbl;
        private Label CostLbl;
        private Label label4;
    }
}
