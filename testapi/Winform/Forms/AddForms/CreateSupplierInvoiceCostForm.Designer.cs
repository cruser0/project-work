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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
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
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Location = new System.Drawing.Point(272, 235);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(102, 15);
            this.NameSupplierLbl.TabIndex = 35;
            this.NameSupplierLbl.Text = "Description Name";
            // 
            // NameTxt
            // 
            this.NameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NameTxt.Location = new System.Drawing.Point(272, 251);
            this.NameTxt.MaxLength = 100;
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(206, 23);
            this.NameTxt.TabIndex = 34;
            // 
            // QuantityIntegerTxt
            // 
            this.QuantityIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityIntegerTxt.Location = new System.Drawing.Point(272, 206);
            this.QuantityIntegerTxt.Name = "QuantityIntegerTxt";
            this.QuantityIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.QuantityIntegerTxt.TabIndex = 33;
            // 
            // CostIntegerTxt
            // 
            this.CostIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostIntegerTxt.Location = new System.Drawing.Point(272, 152);
            this.CostIntegerTxt.Name = "CostIntegerTxt";
            this.CostIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.CostIntegerTxt.TabIndex = 32;
            // 
            // SupplierInvoiceIDIntegerTxt
            // 
            this.SupplierInvoiceIDIntegerTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierInvoiceIDIntegerTxt.Location = new System.Drawing.Point(272, 108);
            this.SupplierInvoiceIDIntegerTxt.Name = "SupplierInvoiceIDIntegerTxt";
            this.SupplierInvoiceIDIntegerTxt.Size = new System.Drawing.Size(206, 23);
            this.SupplierInvoiceIDIntegerTxt.TabIndex = 31;
            // 
            // OpenSupplierInvoice
            // 
            this.OpenSupplierInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSupplierInvoice.FlatAppearance.BorderSize = 0;
            this.OpenSupplierInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSupplierInvoice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.OpenSupplierInvoice.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OpenSupplierInvoice.Location = new System.Drawing.Point(484, 108);
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
            this.SaleIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaleIDLbl.AutoSize = true;
            this.SaleIDLbl.Location = new System.Drawing.Point(272, 90);
            this.SaleIDLbl.Name = "SaleIDLbl";
            this.SaleIDLbl.Size = new System.Drawing.Size(105, 15);
            this.SaleIDLbl.TabIndex = 22;
            this.SaleIDLbl.Text = "Supplier Invoice ID";
            // 
            // SupplierIDLbl
            // 
            this.SupplierIDLbl.AllowDrop = true;
            this.SupplierIDLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierIDLbl.AutoSize = true;
            this.SupplierIDLbl.Location = new System.Drawing.Point(272, 134);
            this.SupplierIDLbl.Name = "SupplierIDLbl";
            this.SupplierIDLbl.Size = new System.Drawing.Size(31, 15);
            this.SupplierIDLbl.TabIndex = 23;
            this.SupplierIDLbl.Text = "Cost";
            // 
            // Quantity
            // 
            this.Quantity.AllowDrop = true;
            this.Quantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(272, 188);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(53, 15);
            this.Quantity.TabIndex = 27;
            this.Quantity.Text = "Quantity";
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.Location = new System.Drawing.Point(307, 280);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(171, 23);
            this.SaveBtn.TabIndex = 25;
            this.SaveBtn.Text = "Create Supplier Invoice Cost";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 421);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 20);
            this.panel2.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 421);
            this.panel3.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(764, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 421);
            this.panel4.TabIndex = 39;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 441);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(784, 20);
            this.panel5.TabIndex = 40;
            // 
            // CreateSupplierInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
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