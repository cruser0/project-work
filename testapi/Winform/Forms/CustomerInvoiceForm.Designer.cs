namespace Winform.Forms
{
    partial class CustomerInvoiceForm
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
            this.leftSideBar = new Winform.Forms.control.LeftSideBarUSerControl();
            this.CustomerInvoiceLbl = new System.Windows.Forms.Label();
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
            this.LeftPanel.Controls.Add(this.CustomerInvoiceLbl);
            this.LeftPanel.Controls.Add(this.leftSideBar);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 450);
            this.LeftPanel.TabIndex = 2;
            // 
            // leftSideBar
            // 
            this.leftSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.leftSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideBar.Location = new System.Drawing.Point(0, 0);
            this.leftSideBar.Name = "leftSideBar";
            this.leftSideBar.Size = new System.Drawing.Size(200, 450);
            this.leftSideBar.TabIndex = 0;
            // 
            // CustomerInvoiceLbl
            // 
            this.CustomerInvoiceLbl.AutoSize = true;
            this.CustomerInvoiceLbl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CustomerInvoiceLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CustomerInvoiceLbl.Location = new System.Drawing.Point(0, 0);
            this.CustomerInvoiceLbl.Name = "CustomerInvoiceLbl";
            this.CustomerInvoiceLbl.Size = new System.Drawing.Size(167, 25);
            this.CustomerInvoiceLbl.TabIndex = 2;
            this.CustomerInvoiceLbl.Text = "Customer Invoice";
            // 
            // CustomerInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LeftPanel);
            this.Name = "CustomerInvoiceForm";
            this.Text = "CustomerInvoiceForm";
            this.Controls.SetChildIndex(this.LeftPanel, 0);
            this.Controls.SetChildIndex(this.CenterPanel, 0);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LeftPanel;
        private control.LeftSideBarUSerControl leftSideBar;
        private Label CustomerInvoiceLbl;
    }
}