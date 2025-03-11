using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.AddForms
{
    partial class CreateSupplierInvoiceCostForm
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
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.Quantity = new System.Windows.Forms.Label();
            this.QuantityIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.CostIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.OpenSupplierInvoice = new System.Windows.Forms.Button();
            this.SupplierInvoiceIDIntegerTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CreatePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.Control;
            this.CreatePanel.Controls.Add(this.panel1);
            this.CreatePanel.Controls.Add(this.panel4);
            this.CreatePanel.Controls.Add(this.panel3);
            this.CreatePanel.Controls.Add(this.panel2);
            this.CreatePanel.Controls.Add(this.panel5);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatePanel.Location = new System.Drawing.Point(0, 0);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(784, 461);
            this.CreatePanel.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SaleIDLbl);
            this.panel1.Controls.Add(this.NameSupplierLbl);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.NameTxt);
            this.panel1.Controls.Add(this.Quantity);
            this.panel1.Controls.Add(this.QuantityIntegerTxt);
            this.panel1.Controls.Add(this.SupplierIDLbl);
            this.panel1.Controls.Add(this.CostIntegerTxt);
            this.panel1.Controls.Add(this.OpenSupplierInvoice);
            this.panel1.Controls.Add(this.SupplierInvoiceIDIntegerTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 36;
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaleIDLbl.Location = new System.Drawing.Point(289, 94);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(105, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "Supplier Invoice ID";
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSupplierLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameSupplierLbl.Location = new System.Drawing.Point(289, 232);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(102, 15);
            this.NameSupplierLbl.TabIndex = 35;
            this.NameSupplierLbl.Text = "Description Name";
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(319, 279);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(147, 20);
            this.SaveBtn.TabIndex = 25;
            this.SaveBtn.Text = "Create Supplier Invoice Cost";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // NameTxt
            // 
            this.NameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NameTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(289, 250);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(177, 23);
            this.NameTxt.TabIndex = 34;
            // 
            // Quantity
            // 
            this.Quantity.AllowDrop = true;
            this.Quantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Quantity.AutoSize = true;
            this.Quantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.Quantity.Location = new System.Drawing.Point(289, 186);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(53, 15);
            this.Quantity.TabIndex = 27;
            this.Quantity.Text = "Quantity";
            // 
            // QuantityIntegerTxt
            // 
            this.QuantityIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityIntegerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.QuantityIntegerTxt.Location = new System.Drawing.Point(289, 204);
            this.QuantityIntegerTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.QuantityIntegerTxt.Name = "QuantityIntegerTxt";
            this.QuantityIntegerTxt.Size = new System.Drawing.Size(177, 25);
            this.QuantityIntegerTxt.TabIndex = 33;
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierIDLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierIDLbl.Location = new System.Drawing.Point(289, 140);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(31, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "Cost";
            // 
            // CostIntegerTxt
            // 
            this.CostIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostIntegerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostIntegerTxt.Location = new System.Drawing.Point(289, 158);
            this.CostIntegerTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CostIntegerTxt.Name = "CostIntegerTxt";
            this.CostIntegerTxt.Size = new System.Drawing.Size(177, 25);
            this.CostIntegerTxt.TabIndex = 32;
            // 
            // OpenSupplierInvoice
            // 
            this.OpenSupplierInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSupplierInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSupplierInvoice.FlatAppearance.BorderSize = 0;
            this.OpenSupplierInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSupplierInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSupplierInvoice.Location = new System.Drawing.Point(472, 112);
            this.OpenSupplierInvoice.Name = "OpenSupplierInvoice";
            this.OpenSupplierInvoice.Size = new System.Drawing.Size(55, 25);
            this.OpenSupplierInvoice.TabIndex = 29;
            this.OpenSupplierInvoice.Text = "Open";
            this.OpenSupplierInvoice.UseVisualStyleBackColor = false;
            this.OpenSupplierInvoice.Click += new System.EventHandler(this.OpenSupplierInvoice_Click);
            // 
            // SupplierInvoiceIDIntegerTxt
            // 
            this.SupplierInvoiceIDIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierInvoiceIDIntegerTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierInvoiceIDIntegerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SupplierInvoiceIDIntegerTxt.Location = new System.Drawing.Point(289, 112);
            this.SupplierInvoiceIDIntegerTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SupplierInvoiceIDIntegerTxt.Name = "SupplierInvoiceIDIntegerTxt";
            this.SupplierInvoiceIDIntegerTxt.Size = new System.Drawing.Size(177, 25);
            this.SupplierInvoiceIDIntegerTxt.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(767, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 427);
            this.panel4.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 427);
            this.panel3.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 17);
            this.panel2.TabIndex = 37;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 444);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 17);
            this.panel5.TabIndex = 40;
            // 
            // CreateSupplierInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CreatePanel);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateSupplierInvoiceCostForm";
            this.Text = "CreateSupplierInvoiceCostForm";
            this.CreatePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel CreatePanel;
        private control.IntegerTextBoxUserControl QuantityIntegerTxt;
        private control.IntegerTextBoxUserControl CostIntegerTxt;
        private control.IntegerTextBoxUserControl SupplierInvoiceIDIntegerTxt;
        private Button OpenSupplierInvoice;
        private Label SaleIDLbl;
        private Label SupplierIDLbl;
        private Label Quantity;
        private Button SaveBtn;
        private Label NameSupplierLbl;
        private TextBox NameTxt;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
    }
}