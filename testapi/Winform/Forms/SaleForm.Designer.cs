namespace Winform.Forms
{
    partial class SaleForm
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
            this.SaleLbl = new System.Windows.Forms.Label();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Size = new System.Drawing.Size(400, 450);
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.SaleLbl);
            this.LeftPanel.Controls.Add(this.leftSideBaruSerControl1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 450);
            this.LeftPanel.TabIndex = 18;
            // 
            // leftSideBaruSerControl1
            // 
            this.leftSideBaruSerControl1.BackColor = System.Drawing.Color.DarkGray;
            this.leftSideBaruSerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSideBaruSerControl1.Location = new System.Drawing.Point(0, 0);
            this.leftSideBaruSerControl1.Name = "leftSideBaruSerControl1";
            this.leftSideBaruSerControl1.Size = new System.Drawing.Size(200, 450);
            this.leftSideBaruSerControl1.TabIndex = 0;
            // 
            // SaleLbl
            // 
            this.SaleLbl.AutoSize = true;
            this.SaleLbl.BackColor = System.Drawing.Color.DarkGray;
            this.SaleLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaleLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaleLbl.Location = new System.Drawing.Point(0, 0);
            this.SaleLbl.Name = "SaleLbl";
            this.SaleLbl.Size = new System.Drawing.Size(48, 25);
            this.SaleLbl.TabIndex = 11;
            this.SaleLbl.Text = "Sale";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LeftPanel);
            this.Name = "SaleForm";
            this.Controls.SetChildIndex(this.LeftPanel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LeftPanel;
        private control.LeftSideBarUSerControl leftSideBaruSerControl1;
        private Label SaleLbl;
    }
}