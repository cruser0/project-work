using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.AddForms
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OpenSale = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PanelCreateCustomerInvoiceCost = new System.Windows.Forms.Panel();
            this.CostTxt = new WinformDotNetFramework.Forms.control.DecimalTextBoxUserControl();
            this.SaveQuit = new System.Windows.Forms.Button();
            this.InvoiceCodeCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.CostRegistryLbl = new System.Windows.Forms.Label();
            this.CostRegistryCmbx = new System.Windows.Forms.ComboBox();
            this.QuantityTxt = new WinformDotNetFramework.Forms.control.IntegerTextBoxUserControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.PanelCreateCustomerInvoiceCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(425, 319);
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
            this.label1.Location = new System.Drawing.Point(289, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer Invoice Code *";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(289, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Quantity (optional)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(289, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cost (optional)";
            // 
            // NameTxt
            // 
            this.NameTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.NameTxt.Location = new System.Drawing.Point(289, 200);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(200, 23);
            this.NameTxt.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(289, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name (optional)";
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(507, 114);
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
            this.PanelCreateCustomerInvoiceCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostTxt);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.SaveQuit);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.InvoiceCodeCmbxUC);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostRegistryLbl);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.CostRegistryCmbx);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.SaveBtn);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.label3);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.QuantityTxt);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.label2);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.label1);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.OpenSale);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.NameTxt);
            this.PanelCreateCustomerInvoiceCost.Controls.Add(this.label4);
            this.PanelCreateCustomerInvoiceCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCreateCustomerInvoiceCost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelCreateCustomerInvoiceCost.Location = new System.Drawing.Point(17, 17);
            this.PanelCreateCustomerInvoiceCost.Name = "PanelCreateCustomerInvoiceCost";
            this.PanelCreateCustomerInvoiceCost.Size = new System.Drawing.Size(750, 427);
            this.PanelCreateCustomerInvoiceCost.TabIndex = 38;
            // 
            // CostTxt
            // 
            this.CostTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostTxt.Location = new System.Drawing.Point(289, 244);
            this.CostTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(200, 23);
            this.CostTxt.TabIndex = 40;
            // 
            // SaveQuit
            // 
            this.SaveQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveQuit.Location = new System.Drawing.Point(289, 317);
            this.SaveQuit.Name = "SaveQuit";
            this.SaveQuit.Size = new System.Drawing.Size(94, 25);
            this.SaveQuit.TabIndex = 39;
            this.SaveQuit.Text = "Save and Quit";
            this.SaveQuit.UseVisualStyleBackColor = false;
            this.SaveQuit.Click += new System.EventHandler(this.SaveQuit_Click);
            // 
            // InvoiceCodeCmbxUC
            // 
            this.InvoiceCodeCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceCodeCmbxUC.listItemsDropCmbx = null;
            this.InvoiceCodeCmbxUC.Location = new System.Drawing.Point(289, 114);
            this.InvoiceCodeCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InvoiceCodeCmbxUC.Name = "InvoiceCodeCmbxUC";
            this.InvoiceCodeCmbxUC.Size = new System.Drawing.Size(200, 23);
            this.InvoiceCodeCmbxUC.TabIndex = 38;
            // 
            // CostRegistryLbl
            // 
            this.CostRegistryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryLbl.AutoSize = true;
            this.CostRegistryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostRegistryLbl.Location = new System.Drawing.Point(289, 138);
            this.CostRegistryLbl.Name = "CostRegistryLbl";
            this.CostRegistryLbl.Size = new System.Drawing.Size(84, 15);
            this.CostRegistryLbl.TabIndex = 36;
            this.CostRegistryLbl.Text = "Cost Registry *";
            // 
            // CostRegistryCmbx
            // 
            this.CostRegistryCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CostRegistryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CostRegistryCmbx.FormattingEnabled = true;
            this.CostRegistryCmbx.Location = new System.Drawing.Point(289, 156);
            this.CostRegistryCmbx.Name = "CostRegistryCmbx";
            this.CostRegistryCmbx.Size = new System.Drawing.Size(200, 23);
            this.CostRegistryCmbx.TabIndex = 35;
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.QuantityTxt.Location = new System.Drawing.Point(289, 288);
            this.QuantityTxt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(200, 23);
            this.QuantityTxt.TabIndex = 16;
            // 
            // CreateCustomerInvoiceCostForm
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
            this.Name = "CreateCustomerInvoiceCostForm";
            this.Text = "CreateCustomerInvoiceCostForm";
            this.Load += new System.EventHandler(this.CreateCustomerInvoiceCostForm_Load);
            this.PanelCreateCustomerInvoiceCost.ResumeLayout(false);
            this.PanelCreateCustomerInvoiceCost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveBtn;
        private Label label1;
        private control.IntegerTextBoxUserControl QuantityTxt;
        private Label label3;
        private Label label2;
        private TextBox NameTxt;
        private Label label4;
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
        private control.DecimalTextBoxUserControl CostTxt;
    }
}