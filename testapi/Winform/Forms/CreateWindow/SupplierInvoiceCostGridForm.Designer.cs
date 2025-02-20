namespace Winform.Forms.CreateWindow
{
    partial class SupplierInvoiceCostGridForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SupplierInvoiceCostDgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.CostTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDTxt = new Winform.Forms.control.IntegerTextBoxUserControl();
            this.InvoiceIDLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SupplierInvoiceCostDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 564);
            this.panel1.TabIndex = 0;
            // 
            // SupplierInvoiceCostDgv
            // 
            this.SupplierInvoiceCostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierInvoiceCostDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierInvoiceCostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceCostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceCostDgv.Location = new System.Drawing.Point(0, 0);
            this.SupplierInvoiceCostDgv.Name = "SupplierInvoiceCostDgv";
            this.SupplierInvoiceCostDgv.ReadOnly = true;
            this.SupplierInvoiceCostDgv.RowTemplate.Height = 25;
            this.SupplierInvoiceCostDgv.Size = new System.Drawing.Size(600, 564);
            this.SupplierInvoiceCostDgv.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxesRightPanel);
            this.panel2.Controls.Add(this.RightSideBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(600, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 564);
            this.panel2.TabIndex = 1;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.DarkGray;
            this.TextBoxesRightPanel.Controls.Add(this.CostTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDTxt);
            this.TextBoxesRightPanel.Controls.Add(this.InvoiceIDLbl);
            this.TextBoxesRightPanel.Controls.Add(this.CostLbl);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 150);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(203, 246);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // CostTxt
            // 
            this.CostTxt.Location = new System.Drawing.Point(3, 68);
            this.CostTxt.Name = "CostTxt";
            this.CostTxt.Size = new System.Drawing.Size(194, 23);
            this.CostTxt.TabIndex = 12;
            // 
            // InvoiceIDTxt
            // 
            this.InvoiceIDTxt.Location = new System.Drawing.Point(3, 21);
            this.InvoiceIDTxt.Name = "InvoiceIDTxt";
            this.InvoiceIDTxt.Size = new System.Drawing.Size(194, 23);
            this.InvoiceIDTxt.TabIndex = 11;
            // 
            // InvoiceIDLbl
            // 
            this.InvoiceIDLbl.AutoSize = true;
            this.InvoiceIDLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InvoiceIDLbl.Location = new System.Drawing.Point(3, 0);
            this.InvoiceIDLbl.Name = "InvoiceIDLbl";
            this.InvoiceIDLbl.Size = new System.Drawing.Size(71, 18);
            this.InvoiceIDLbl.TabIndex = 3;
            this.InvoiceIDLbl.Text = "Invoice ID";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CostLbl.Location = new System.Drawing.Point(3, 47);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(34, 18);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost";
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 564);
            this.RightSideBar.TabIndex = 0;
            // 
            // SupplierInvoiceCostGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SupplierInvoiceCostGridForm";
            this.Text = "SupplierInvoiceCostGridForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceCostDgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.TextBoxesRightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private DataGridView SupplierInvoiceCostDgv;
        private Panel panel2;
        private control.RightSideBarUserControl RightSideBar;
        private Panel TextBoxesRightPanel;
        private control.IntegerTextBoxUserControl CostTxt;
        private control.IntegerTextBoxUserControl InvoiceIDTxt;
        private Label InvoiceIDLbl;
        private Label CostLbl;
    }
}