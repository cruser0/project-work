﻿using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
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
            this.CostRegistryLbl = new System.Windows.Forms.Label();
            this.CostRegistryCmbx = new System.Windows.Forms.ComboBox();
            this.InvoiceCodeTxt = new System.Windows.Forms.TextBox();
            this.InvoiceCodeLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.CostToTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.label1 = new System.Windows.Forms.Label();
            this.CostFromTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.CostLbl = new System.Windows.Forms.Label();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.CostRegistryLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostRegistryCmbx);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceCodeTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceCodeLbl);
            this.TextBoxesRightPanel.Controls.Add(this.label4);
            this.TextBoxesRightPanel.Controls.Add(this.NameTxt);
            this.TextBoxesRightPanel.Controls.Add(this.NameLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostToTxt);
            this.TextBoxesRightPanel.Controls.Add(this.label1);
            this.TextBoxesRightPanel.Controls.Add(this.CostFromTxt);
            this.TextBoxesRightPanel.Controls.Add(this.CostLbl);
            this.TextBoxesRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 0);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 256);
            this.TextBoxesRightPanel.TabIndex = 9;
            // 
            // CostRegistryLbl
            // 
            this.CostRegistryLbl.AutoSize = true;
            this.CostRegistryLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CostRegistryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostRegistryLbl.Location = new System.Drawing.Point(6, 195);
            this.CostRegistryLbl.Name = "CostRegistryLbl";
            this.CostRegistryLbl.Size = new System.Drawing.Size(125, 17);
            this.CostRegistryLbl.TabIndex = 24;
            this.CostRegistryLbl.Text = "Cost Registry Code";
            // 
            // CostRegistryCmbx
            // 
            this.CostRegistryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CostRegistryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CostRegistryCmbx.FormattingEnabled = true;
            this.CostRegistryCmbx.Location = new System.Drawing.Point(3, 215);
            this.CostRegistryCmbx.Name = "CostRegistryCmbx";
            this.CostRegistryCmbx.Size = new System.Drawing.Size(180, 21);
            this.CostRegistryCmbx.TabIndex = 23;
            // 
            // InvoiceCodeTxt
            // 
            this.InvoiceCodeTxt.BackColor = System.Drawing.SystemColors.Window;
            this.InvoiceCodeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoiceCodeTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceCodeTxt.Location = new System.Drawing.Point(3, 172);
            this.InvoiceCodeTxt.MaxLength = 100;
            this.InvoiceCodeTxt.Name = "InvoiceCodeTxt";
            this.InvoiceCodeTxt.Size = new System.Drawing.Size(180, 20);
            this.InvoiceCodeTxt.TabIndex = 21;
            // 
            // InvoiceCodeLbl
            // 
            this.InvoiceCodeLbl.AutoSize = true;
            this.InvoiceCodeLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.InvoiceCodeLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.InvoiceCodeLbl.Location = new System.Drawing.Point(6, 152);
            this.InvoiceCodeLbl.Name = "InvoiceCodeLbl";
            this.InvoiceCodeLbl.Size = new System.Drawing.Size(150, 17);
            this.InvoiceCodeLbl.TabIndex = 22;
            this.InvoiceCodeLbl.Text = "Customer Invoice Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Customer Invoice Cost";
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.NameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(3, 129);
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
            this.NameLbl.Location = new System.Drawing.Point(6, 109);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(119, 17);
            this.NameLbl.TabIndex = 16;
            this.NameLbl.Text = "Description Name";
            // 
            // CostToTxt
            // 
            this.CostToTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CostToTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostToTxt.Location = new System.Drawing.Point(3, 86);
            this.CostToTxt.Name = "CostToTxt";
            this.CostToTxt.Size = new System.Drawing.Size(180, 20);
            this.CostToTxt.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cost To";
            // 
            // CostFromTxt
            // 
            this.CostFromTxt.BackColor = System.Drawing.SystemColors.Window;
            this.CostFromTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostFromTxt.Location = new System.Drawing.Point(3, 43);
            this.CostFromTxt.Name = "CostFromTxt";
            this.CostFromTxt.Size = new System.Drawing.Size(180, 20);
            this.CostFromTxt.TabIndex = 12;
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CostLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostLbl.Location = new System.Drawing.Point(6, 23);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(71, 17);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost From";
            // 
            // SearchCustomerInvoiceCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.TextBoxesRightPanel);
            this.Name = "SearchCustomerInvoiceCost";
            this.Size = new System.Drawing.Size(200, 256);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TextBoxesRightPanel;
        private Label NameLbl;
        private Label label1;
        private Label CostLbl;
        private Label label4;
        public IntegerTextBoxUserControl CostFromTxt;
        public IntegerTextBoxUserControl CostToTxt;
        public TextBox NameTxt;
        public TextBox InvoiceCodeTxt;
        private Label InvoiceCodeLbl;
        private ComboBox CostRegistryCmbx;
        private Label CostRegistryLbl;
    }
}
