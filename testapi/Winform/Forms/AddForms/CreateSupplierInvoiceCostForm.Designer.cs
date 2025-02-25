namespace Winform.Forms.AddForms
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
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.QuantityIntegerTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.CostIntegerTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.SupplierInvoiceIDIntegerTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.OpenSupplierInvoice = new System.Windows.Forms.Button();
            this.SaleIDLbl = new System.Windows.Forms.Label();
            this.SupplierIDLbl = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CreatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CreatePanel.Controls.Add(this.NameSupplierLbl);
            this.CreatePanel.Controls.Add(this.NameTxt);
            this.CreatePanel.Controls.Add(this.QuantityIntegerTxt);
            this.CreatePanel.Controls.Add(this.CostIntegerTxt);
            this.CreatePanel.Controls.Add(this.SupplierInvoiceIDIntegerTxt);
            this.CreatePanel.Controls.Add(this.OpenSupplierInvoice);
            this.CreatePanel.Controls.Add(this.SaleIDLbl);
            this.CreatePanel.Controls.Add(this.SupplierIDLbl);
            this.CreatePanel.Controls.Add(this.Quantity);
            this.CreatePanel.Controls.Add(this.SaveBtn);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatePanel.Location = new System.Drawing.Point(0, 0);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(939, 527);
            this.CreatePanel.TabIndex = 30;
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Location = new System.Drawing.Point(484, 337);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(102, 15);
            this.NameSupplierLbl.TabIndex = 35;
            this.NameSupplierLbl.Text = "Description Name";
            // 
            // NameTxt
            // 
            this.NameTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NameTxt.Location = new System.Drawing.Point(482, 353);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(206, 23);
            this.NameTxt.TabIndex = 34;
            // 
            // QuantityIntegerTxt
            // 
            this.QuantityIntegerTxt.Location = new System.Drawing.Point(482, 308);
            this.QuantityIntegerTxt.Name = "QuantityIntegerTxt";
            this.QuantityIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.QuantityIntegerTxt.TabIndex = 33;
            // 
            // CostIntegerTxt
            // 
            this.CostIntegerTxt.Location = new System.Drawing.Point(482, 254);
            this.CostIntegerTxt.Name = "CostIntegerTxt";
            this.CostIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.CostIntegerTxt.TabIndex = 32;
            // 
            // SupplierInvoiceIDIntegerTxt
            // 
            this.SupplierInvoiceIDIntegerTxt.Location = new System.Drawing.Point(482, 210);
            this.SupplierInvoiceIDIntegerTxt.Name = "SupplierInvoiceIDIntegerTxt";
            this.SupplierInvoiceIDIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.SupplierInvoiceIDIntegerTxt.TabIndex = 31;
            // 
            // OpenSupplierInvoice
            // 
            this.OpenSupplierInvoice.FlatAppearance.BorderSize = 0;
            this.OpenSupplierInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSupplierInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSupplierInvoice.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSupplierInvoice.Location = new System.Drawing.Point(694, 210);
            this.OpenSupplierInvoice.Name = "OpenSupplierInvoice";
            this.OpenSupplierInvoice.Size = new System.Drawing.Size(64, 23);
            this.OpenSupplierInvoice.TabIndex = 29;
            this.OpenSupplierInvoice.Text = "Open-->";
            this.OpenSupplierInvoice.UseVisualStyleBackColor = true;
            this.OpenSupplierInvoice.Click += new System.EventHandler(this.OpenSupplierInvoice_Click);
            // 
            // SaleIDLbl
            // 
            this.SaleIDLbl.AllowDrop = true;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(484, 192);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(105, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "Supplier Invoice ID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(484, 236);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(31, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "Cost";
            // 
            // Quantity
            // 
            this.Quantity.AllowDrop = true;
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(483, 290);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(53, 15);
            this.Quantity.TabIndex = 27;
            this.Quantity.Text = "Quantity";
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Location = new System.Drawing.Point(482, 419);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(171, 23);
            this.SaveBtn.TabIndex = 25;
            this.SaveBtn.Text = "Create Supplier Invoice Cost";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CreateSupplierInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 527);
            this.Controls.Add(this.CreatePanel);
            this.Name = "CreateSupplierInvoiceCostForm";
            this.Text = "CreateSupplierInvoiceCostForm";
            this.CreatePanel.ResumeLayout(false);
            this.CreatePanel.PerformLayout();
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
    }
}