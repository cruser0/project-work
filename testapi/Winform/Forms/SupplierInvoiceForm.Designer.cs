namespace Winform.Forms
{
    partial class SupplierInvoiceForm
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.leftSideBaruSerControl1 = new Winform.Forms.control.LeftSideBarUSerControl();
            this.SupplierInvoiceLbl = new System.Windows.Forms.Label();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CenterPanel
            // 
            this.CenterPanel.Location = new System.Drawing.Point(200, 0);
            this.CenterPanel.Size = new System.Drawing.Size(400, 450);
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.SupplierInvoiceLbl);
            this.LeftPanel.Controls.Add(this.leftSideBaruSerControl1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 450);
            this.LeftPanel.TabIndex = 19;
            // 
            // leftSideBaruSerControl1
            // 
            this.leftSideBaruSerControl1.BackColor = System.Drawing.Color.DarkGray;
            this.leftSideBaruSerControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSideBaruSerControl1.Location = new System.Drawing.Point(0, 0);
            this.leftSideBaruSerControl1.Name = "leftSideBaruSerControl1";
            this.leftSideBaruSerControl1.Size = new System.Drawing.Size(200, 450);
            this.leftSideBaruSerControl1.TabIndex = 0;
            // 
            // SupplierInvoiceLbl
            // 
            this.SupplierInvoiceLbl.AutoSize = true;
            this.SupplierInvoiceLbl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SupplierInvoiceLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SupplierInvoiceLbl.Location = new System.Drawing.Point(0, 0);
            this.SupplierInvoiceLbl.Name = "SupplierInvoiceLbl";
            this.SupplierInvoiceLbl.Size = new System.Drawing.Size(156, 25);
            this.SupplierInvoiceLbl.TabIndex = 20;
            this.SupplierInvoiceLbl.Text = "Supplier Invoice";
            // 
            // SupplierInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LeftPanel);
            this.Name = "SupplierInvoiceForm";
            this.Controls.SetChildIndex(this.LeftPanel, 0);
            this.Controls.SetChildIndex(this.CenterPanel, 0);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LeftPanel;
        private Label SupplierInvoiceLbl;
        private control.LeftSideBarUSerControl leftSideBaruSerControl1;
    }
}