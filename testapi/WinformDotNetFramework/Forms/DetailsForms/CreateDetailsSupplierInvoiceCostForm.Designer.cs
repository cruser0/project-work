using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsSupplierInvoiceCostForm
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
            this.SaveQuitButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CostRegistryLbl = new System.Windows.Forms.Label();
            this.CostRegistryCmbx = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.OpenSupplierInvoice = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.NameCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SupplierInvoiceCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.QuantityCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.CostCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
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
            this.panel1.Controls.Add(this.CostCtb);
            this.panel1.Controls.Add(this.QuantityCtb);
            this.panel1.Controls.Add(this.NameCtb);
            this.panel1.Controls.Add(this.SaveQuitButton);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.SupplierInvoiceCmbxUC);
            this.panel1.Controls.Add(this.CostRegistryLbl);
            this.panel1.Controls.Add(this.CostRegistryCmbx);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.OpenSupplierInvoice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 36;
            // 
            // SaveQuitButton
            // 
            this.SaveQuitButton.AllowDrop = true;
            this.SaveQuitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuitButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveQuitButton.Location = new System.Drawing.Point(498, 292);
            this.SaveQuitButton.Name = "SaveQuitButton";
            this.SaveQuitButton.Size = new System.Drawing.Size(98, 23);
            this.SaveQuitButton.TabIndex = 45;
            this.SaveQuitButton.Text = "Save and quit";
            this.SaveQuitButton.UseVisualStyleBackColor = false;
            this.SaveQuitButton.Click += new System.EventHandler(this.SaveQuitButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.checkBox1.Location = new System.Drawing.Point(498, 238);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // CostRegistryLbl
            // 
            this.CostRegistryLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryLbl.AutoSize = true;
            this.CostRegistryLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.CostRegistryLbl.Location = new System.Drawing.Point(265, 278);
            this.CostRegistryLbl.Name = "CostRegistryLbl";
            this.CostRegistryLbl.Size = new System.Drawing.Size(76, 13);
            this.CostRegistryLbl.TabIndex = 41;
            this.CostRegistryLbl.Text = "Cost Registry *";
            // 
            // CostRegistryCmbx
            // 
            this.CostRegistryCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostRegistryCmbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CostRegistryCmbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CostRegistryCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CostRegistryCmbx.FormattingEnabled = true;
            this.CostRegistryCmbx.Location = new System.Drawing.Point(265, 291);
            this.CostRegistryCmbx.Name = "CostRegistryCmbx";
            this.CostRegistryCmbx.Size = new System.Drawing.Size(196, 21);
            this.CostRegistryCmbx.TabIndex = 40;
            this.CostRegistryCmbx.SelectedIndexChanged += new System.EventHandler(this.CostRegistryCmbx_SelectedIndexChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.AllowDrop = true;
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(498, 263);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(98, 23);
            this.SaveBtn.TabIndex = 25;
            this.SaveBtn.Text = "Save Cost";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // 
            // OpenSupplierInvoice
            // 
            this.OpenSupplierInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSupplierInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSupplierInvoice.FlatAppearance.BorderSize = 0;
            this.OpenSupplierInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSupplierInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSupplierInvoice.Location = new System.Drawing.Point(471, 76);
            this.OpenSupplierInvoice.Name = "OpenSupplierInvoice";
            this.OpenSupplierInvoice.Size = new System.Drawing.Size(55, 25);
            this.OpenSupplierInvoice.TabIndex = 29;
            this.OpenSupplierInvoice.Text = "Open";
            this.OpenSupplierInvoice.UseVisualStyleBackColor = false;
            this.OpenSupplierInvoice.Click += new System.EventHandler(this.OpenSupplierInvoice_Click);
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
            // NameCtb
            // 
            this.NameCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCtb.Location = new System.Drawing.Point(265, 137);
            this.NameCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.NameCtb.Name = "NameCtb";
            this.NameCtb.Size = new System.Drawing.Size(200, 47);
            this.NameCtb.TabIndex = 46;
            this.NameCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // SupplierInvoiceCmbxUC
            // 
            this.SupplierInvoiceCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierInvoiceCmbxUC.listItemsDropCmbx = null;
            this.SupplierInvoiceCmbxUC.Location = new System.Drawing.Point(265, 90);
            this.SupplierInvoiceCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SupplierInvoiceCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.SupplierInvoiceCmbxUC.Name = "SupplierInvoiceCmbxUC";
            this.SupplierInvoiceCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.SupplierInvoiceCmbxUC.TabIndex = 42;
            // 
            // QuantityCtb
            // 
            this.QuantityCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityCtb.Location = new System.Drawing.Point(265, 231);
            this.QuantityCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.QuantityCtb.Name = "QuantityCtb";
            this.QuantityCtb.Size = new System.Drawing.Size(200, 47);
            this.QuantityCtb.TabIndex = 47;
            this.QuantityCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Integer;
            // 
            // CostCtb
            // 
            this.CostCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostCtb.Location = new System.Drawing.Point(265, 184);
            this.CostCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CostCtb.Name = "CostCtb";
            this.CostCtb.Size = new System.Drawing.Size(200, 47);
            this.CostCtb.TabIndex = 48;
            this.CostCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
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
            // CreateDetailsSupplierInvoiceCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CreatePanel);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsSupplierInvoiceCostForm";
            this.Text = "CreateSupplierInvoiceCostForm";
            this.Load += new System.EventHandler(this.CreateSupplierInvoiceCostForm_Load);
            this.CreatePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel CreatePanel;
        private Button OpenSupplierInvoice;
        private Button SaveBtn;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
        private Label CostRegistryLbl;
        private ComboBox CostRegistryCmbx;
        private CheckBox checkBox1;
        private Button SaveQuitButton;
        private control.DropDownMenuAutoCompleteUserControl SupplierInvoiceCmbxUC;
        private control.CustomTextBoxUserControl NameCtb;
        private control.CustomTextBoxUserControl CostCtb;
        private control.CustomTextBoxUserControl QuantityCtb;
    }
}