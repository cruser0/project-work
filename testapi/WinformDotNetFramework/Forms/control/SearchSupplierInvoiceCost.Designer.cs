using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    partial class SearchSupplierInvoiceCost
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostToTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.CostFromTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.RegistryTxt = new System.Windows.Forms.TextBox();
            this.RegistryLbl = new System.Windows.Forms.Label();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.RegistryTxt);
            this.TextBoxesRightPanel.Controls.Add(this.RegistryLbl);
            this.TextBoxesRightPanel.Controls.Add(this.label2);
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
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 260);
            this.TextBoxesRightPanel.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Supplier Invoice Cost";
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(0, 174);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(180, 20);
            this.NameTxt.TabIndex = 15;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.NameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameLbl.Location = new System.Drawing.Point(3, 156);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(119, 17);
            this.NameLbl.TabIndex = 16;
            this.NameLbl.Text = "Description Name";
            // 
            // CostToTxt
            // 
            this.CostToTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CostToTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostToTxt.Location = new System.Drawing.Point(0, 129);
            this.CostToTxt.Name = "CostToTxt";
            this.CostToTxt.Size = new System.Drawing.Size(180, 20);
            this.CostToTxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(3, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cost To";
            // 
            // CostFromTxt
            // 
            this.CostFromTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CostFromTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostFromTxt.Location = new System.Drawing.Point(0, 82);
            this.CostFromTxt.Name = "CostFromTxt";
            this.CostFromTxt.Size = new System.Drawing.Size(180, 20);
            this.CostFromTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceIDTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceIDTxt.Location = new System.Drawing.Point(0, 42);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceIDTxt.TabIndex = 11;
            // 
            // InvoiceIDLbl
            // 
            this.InvoiceIDLbl.AutoSize = true;
            this.InvoiceIDLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.InvoiceIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceIDLbl.Location = new System.Drawing.Point(2, 23);
            this.InvoiceIDLbl.Name = "InvoiceIDLbl";
            this.InvoiceIDLbl.Size = new System.Drawing.Size(70, 17);
            this.InvoiceIDLbl.TabIndex = 3;
            this.InvoiceIDLbl.Text = "Invoice ID";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CostLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostLbl.Location = new System.Drawing.Point(2, 64);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(71, 17);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost From";
            // 
            // RegistryTxt
            // 
            this.RegistryTxt.BackColor = System.Drawing.SystemColors.Window;
            this.RegistryTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistryTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.RegistryTxt.Location = new System.Drawing.Point(0, 219);
            this.RegistryTxt.MaxLength = 100;
            this.RegistryTxt.Name = "RegistryTxt";
            this.RegistryTxt.Size = new System.Drawing.Size(180, 20);
            this.RegistryTxt.TabIndex = 18;
            // 
            // RegistryLbl
            // 
            this.RegistryLbl.AutoSize = true;
            this.RegistryLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.RegistryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.RegistryLbl.Location = new System.Drawing.Point(3, 201);
            this.RegistryLbl.Name = "RegistryLbl";
            this.RegistryLbl.Size = new System.Drawing.Size(94, 17);
            this.RegistryLbl.TabIndex = 19;
            this.RegistryLbl.Text = "Registry Code";
            // 
            // SearchSupplierInvoiceCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchSupplierInvoiceCost";
            this.Size = new System.Drawing.Size(200, 260);
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
        private Label label2;
        private TextBox RegistryTxt;
        private Label RegistryLbl;
    }
}
