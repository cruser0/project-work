namespace WinformDotNetFramework.Forms
{
    partial class SaleReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.searchSaleReport1 = new WinformDotNetFramework.Forms.control.SearchSaleReport();
            this.rightSideBarUserControl1 = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphDropDownMenuUserControl1 = new WinformDotNetFramework.Forms.control.GraphDropDownMenuUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reportViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.splitContainer1.Panel2.Controls.Add(this.graphDropDownMenuUserControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.rightSideBarUserControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 461);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(384, 461);
            this.reportViewer1.TabIndex = 0;
            // 
            // searchSaleReport1
            // 
            this.searchSaleReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSaleReport1.Location = new System.Drawing.Point(0, 0);
            this.searchSaleReport1.Name = "searchSaleReport1";
            this.searchSaleReport1.Size = new System.Drawing.Size(200, 359);
            this.searchSaleReport1.TabIndex = 0;
            // 
            // rightSideBarUserControl1
            // 
            this.rightSideBarUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.rightSideBarUserControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightSideBarUserControl1.Location = new System.Drawing.Point(0, 0);
            this.rightSideBarUserControl1.Name = "rightSideBarUserControl1";
            this.rightSideBarUserControl1.Size = new System.Drawing.Size(396, 102);
            this.rightSideBarUserControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchSaleReport1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(196, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 359);
            this.panel1.TabIndex = 2;
            // 
            // graphDropDownMenuUserControl1
            // 
            this.graphDropDownMenuUserControl1.Location = new System.Drawing.Point(3, 167);
            this.graphDropDownMenuUserControl1.Name = "graphDropDownMenuUserControl1";
            this.graphDropDownMenuUserControl1.Size = new System.Drawing.Size(188, 22);
            this.graphDropDownMenuUserControl1.TabIndex = 3;
            // 
            // SaleReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SaleReportForm";
            this.Text = "SaleReportForm";
            this.Load += new System.EventHandler(this.SaleReportForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private control.SearchSaleReport searchSaleReport1;
        private control.RightSideBarUserControl rightSideBarUserControl1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private control.GraphDropDownMenuUserControl graphDropDownMenuUserControl1;
        private System.Windows.Forms.Panel panel1;
    }
}