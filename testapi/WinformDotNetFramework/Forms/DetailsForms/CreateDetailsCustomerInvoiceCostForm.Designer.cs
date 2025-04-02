using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsCustomerInvoiceCostForm
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
            this.components = new System.ComponentModel.Container();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenSale = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PanelCreateCustomerInvoiceCost = new System.Windows.Forms.Panel();
            this.SaveQuit = new System.Windows.Forms.Button();
            this.CostRegistryLbl = new System.Windows.Forms.Label();
            this.CostRegistryCmbx = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.QuantityCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CostCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.NameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.InvoiceCodeCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.PanelCreateCustomerInvoiceCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(426, 320);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(64, 25);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(290, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Invoice Code *";
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(508, 103);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(55, 23);
            this.OpenSale.TabIndex = 33;
            this.OpenSale.Text = "Open";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 461);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(767, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 461);
            this.panel2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(17, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 17);
            this.panel3.TabIndex = 36;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(17, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 17);
            this.panel4.TabIndex = 37;
            // 
            // PanelCreateCustomerInvoiceCost
            // 
            this.PanelCreateCustomerInvoiceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.QuantityCtb);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostCtb);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.NameCtb);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.SaveQuit);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.InvoiceCodeCmbxUC);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostRegistryLbl);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostRegistryCmbx);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.SaveBtn);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.label1);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.OpenSale);
            this.PanelCreateCustomerInvoiceCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCreateCustomerInvoiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PanelCreateCustomerInvoiceCost.Location = new System.Drawing.Point(17, 17);
            this.PanelCreateCustomerInvoiceCost.Name = "PanelCreateCustomerInvoiceCost";
            this.PanelCreateCustomerInvoiceCost.Size = new System.Drawing.Size(750, 427);
            this.PanelCreateCustomerInvoiceCost.TabIndex = 38;
            // 
            // SaveQuit
            // 
            this.SaveQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveQuit.Location = new System.Drawing.Point(290, 318);
            this.SaveQuit.Name = "SaveQuit";
            this.SaveQuit.Size = new System.Drawing.Size(94, 25);
            this.SaveQuit.TabIndex = 39;
            this.SaveQuit.Text = "Save and Quit";
            this.SaveQuit.UseVisualStyleBackColor = false;
            this.SaveQuit.Click += new System.EventHandler(this.SaveQuit_Click);
            // 
            // CostRegistryLbl
            // 
            this.CostRegistryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryLbl.AutoSize = true;
            this.CostRegistryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostRegistryLbl.Location = new System.Drawing.Point(290, 131);
            this.CostRegistryLbl.Name = "CostRegistryLbl";
            this.CostRegistryLbl.Size = new System.Drawing.Size(76, 13);
            this.CostRegistryLbl.TabIndex = 36;
            this.CostRegistryLbl.Text = "Cost Registry *";
            // 
            // CostRegistryCmbx
            // 
            this.CostRegistryCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CostRegistryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CostRegistryCmbx.FormattingEnabled = true;
            this.CostRegistryCmbx.Location = new System.Drawing.Point(290, 149);
            this.CostRegistryCmbx.Name = "CostRegistryCmbx";
            this.CostRegistryCmbx.Size = new System.Drawing.Size(200, 21);
            this.CostRegistryCmbx.TabIndex = 35;
            this.CostRegistryCmbx.SelectedIndexChanged += new System.EventHandler(this.CostRegistryCmbx_SelectedIndexChanged);
            // 
            // QuantityCtb
            // 
            this.QuantityCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityCtb.Location = new System.Drawing.Point(290, 267);
            this.QuantityCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.QuantityCtb.Name = "QuantityCtb";
            this.QuantityCtb.Size = new System.Drawing.Size(200, 47);
            this.QuantityCtb.TabIndex = 43;
            this.QuantityCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Integer;
            // 
            // CostCtb
            // 
            this.CostCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostCtb.Location = new System.Drawing.Point(290, 223);
            this.CostCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CostCtb.Name = "CostCtb";
            this.CostCtb.Size = new System.Drawing.Size(200, 47);
            this.CostCtb.TabIndex = 42;
            this.CostCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
            // NameCtb
            // 
            this.NameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCtb.Location = new System.Drawing.Point(290, 176);
            this.NameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.NameCtb.Name = "NameCtb";
            this.NameCtb.Size = new System.Drawing.Size(200, 47);
            this.NameCtb.TabIndex = 41;
            this.NameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // InvoiceCodeCmbxUC
            // 
            this.InvoiceCodeCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceCodeCmbxUC.listItemsDropCmbx = null;
            this.InvoiceCodeCmbxUC.Location = new System.Drawing.Point(290, 83);
            this.InvoiceCodeCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InvoiceCodeCmbxUC.MaximumSize = new System.Drawing.Size(200, 47);
            this.InvoiceCodeCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.InvoiceCodeCmbxUC.Name = "InvoiceCodeCmbxUC";
            this.InvoiceCodeCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.InvoiceCodeCmbxUC.TabIndex = 38;
            // 
            // CreateDetailsCustomerInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.PanelCreateCustomerInvoiceCost);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsCustomerInvoiceCostForm";
            this.Text = "CreateCustomerInvoiceCostForm";
            this.Load += new System.EventHandler(this.CreateCustomerInvoiceCostForm_Load);
            this.PanelCreateCustomerInvoiceCost.ResumeLayout(false);
            this.PanelCreateCustomerInvoiceCost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveBtn;
        private Label label1;
        private Button OpenSale;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel PanelCreateCustomerInvoiceCost;
        private Label CostRegistryLbl;
        private ComboBox CostRegistryCmbx;
        private Timer timer;
        private control.DropDownMenuAutoCompleteUserControl InvoiceCodeCmbxUC;
        private Button SaveQuit;
        private control.CustomTextBoxUserControl QuantityCtb;
        private control.CustomTextBoxUserControl CostCtb;
        private control.CustomTextBoxUserControl NameCtb;
    }
}