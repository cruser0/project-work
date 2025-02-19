namespace Winform.Forms
{
    partial class CustomerForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.CustomerLbl = new System.Windows.Forms.Label();
            this.leftSideBaruSerControl1 = new Winform.Forms.control.LeftSideBarUSerControl();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CenterPanel
            // 
            this.CenterPanel.Location = new System.Drawing.Point(200, 0);
            this.CenterPanel.Size = new System.Drawing.Size(400, 450);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CustomerLbl);
            this.panel2.Controls.Add(this.leftSideBaruSerControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 450);
            this.panel2.TabIndex = 10;
            // 
            // CustomerLbl
            // 
            this.CustomerLbl.AutoSize = true;
            this.CustomerLbl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CustomerLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomerLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CustomerLbl.Location = new System.Drawing.Point(0, 0);
            this.CustomerLbl.Name = "CustomerLbl";
            this.CustomerLbl.Size = new System.Drawing.Size(98, 25);
            this.CustomerLbl.TabIndex = 1;
            this.CustomerLbl.Text = "Customer";
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
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.CenterPanel, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Label CustomerLbl;
        private control.LeftSideBarUSerControl leftSideBaruSerControl1;
    }
}