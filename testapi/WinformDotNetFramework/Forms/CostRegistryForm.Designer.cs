namespace WinformDotNetFramework.Forms
{
    partial class CostRegistryForm
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
            this.leftSideBarUSerControl1 = new WinformDotNetFramework.Forms.control.LeftSideBarUSerControl();
            this.panel5.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(251, 0);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Location = new System.Drawing.Point(200, 0);
            this.CenterPanel.Size = new System.Drawing.Size(400, 374);
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.Location = new System.Drawing.Point(24, 24);
            // 
            // RightSideBar
            // 
            this.RightSideBar.Size = new System.Drawing.Size(200, 374);
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 369);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Size = new System.Drawing.Size(800, 87);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(800, 0);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Size = new System.Drawing.Size(200, 374);
            // 
            // leftSideBarUSerControl1
            // 
            this.leftSideBarUSerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.leftSideBarUSerControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSideBarUSerControl1.Location = new System.Drawing.Point(0, 0);
            this.leftSideBarUSerControl1.Name = "leftSideBarUSerControl1";
            this.leftSideBarUSerControl1.Size = new System.Drawing.Size(200, 374);
            this.leftSideBarUSerControl1.TabIndex = 14;
            // 
            // CostRegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.leftSideBarUSerControl1);
            this.Name = "CostRegistryForm";
            this.Text = "CostRegistryForm";
            this.Controls.SetChildIndex(this.BottomPanel, 0);
            this.Controls.SetChildIndex(this.leftSideBarUSerControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.CenterPanel, 0);
            this.panel5.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private control.LeftSideBarUSerControl leftSideBarUSerControl1;
    }
}