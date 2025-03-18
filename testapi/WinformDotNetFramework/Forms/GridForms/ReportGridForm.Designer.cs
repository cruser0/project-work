namespace WinformDotNetFramework.Forms.GridForms
{
    partial class ReportGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGridForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.EmptyReportTSB = new System.Windows.Forms.ToolStripButton();
            this.PrintPagePreviewBTS = new System.Windows.Forms.ToolStripButton();
            this.ExcelTSB = new System.Windows.Forms.ToolStripButton();
            this.PdfTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DezoomTSB = new System.Windows.Forms.ToolStripButton();
            this.ZoomTSB = new System.Windows.Forms.ToolStripButton();
            this.ZoomTSLbl = new System.Windows.Forms.ToolStripLabel();
            this.ReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchSaleReport1 = new WinformDotNetFramework.Forms.control.SearchSaleReport();
            this.searchSupplierInvoiceReport1 = new WinformDotNetFramework.Forms.control.SearchSupplierInvoiceReport();
            this.searchCustomerInvoiceReportUserControl1 = new WinformDotNetFramework.Forms.control.SearchCustomerInvoiceReportUserControl();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.ReportViewer);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1034, 761);
            this.splitContainer1.SplitterDistance = 799;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EmptyReportTSB,
            this.PrintPagePreviewBTS,
            this.ExcelTSB,
            this.PdfTSB,
            this.toolStripSeparator2,
            this.DezoomTSB,
            this.ZoomTSB,
            this.ZoomTSLbl});
            this.toolStrip2.Location = new System.Drawing.Point(338, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(439, 20);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // EmptyReportTSB
            // 
            this.EmptyReportTSB.Image = global::WinformDotNetFramework.Properties.Resources.cleanpageicon_25x25;
            this.EmptyReportTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EmptyReportTSB.Name = "EmptyReportTSB";
            this.EmptyReportTSB.Size = new System.Drawing.Size(90, 17);
            this.EmptyReportTSB.Text = "Empty Page";
            this.EmptyReportTSB.Click += new System.EventHandler(this.EmptyReportTSB_Click);
            // 
            // PrintPagePreviewBTS
            // 
            this.PrintPagePreviewBTS.Image = ((System.Drawing.Image)(resources.GetObject("PrintPagePreviewBTS.Image")));
            this.PrintPagePreviewBTS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintPagePreviewBTS.Name = "PrintPagePreviewBTS";
            this.PrintPagePreviewBTS.Size = new System.Drawing.Size(137, 17);
            this.PrintPagePreviewBTS.Text = "Change Visualization";
            this.PrintPagePreviewBTS.Click += new System.EventHandler(this.PrintPagePreviewBTS_Click);
            // 
            // ExcelTSB
            // 
            this.ExcelTSB.Image = global::WinformDotNetFramework.Properties.Resources.excelicon_25x25;
            this.ExcelTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcelTSB.Name = "ExcelTSB";
            this.ExcelTSB.Size = new System.Drawing.Size(54, 17);
            this.ExcelTSB.Text = "Excel";
            this.ExcelTSB.Click += new System.EventHandler(this.ExcelTSB_Click);
            // 
            // PdfTSB
            // 
            this.PdfTSB.Image = global::WinformDotNetFramework.Properties.Resources.pdficon_25x25;
            this.PdfTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PdfTSB.Name = "PdfTSB";
            this.PdfTSB.Size = new System.Drawing.Size(48, 17);
            this.PdfTSB.Text = "PDF";
            this.PdfTSB.Click += new System.EventHandler(this.PrfButton_click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // DezoomTSB
            // 
            this.DezoomTSB.AutoSize = false;
            this.DezoomTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DezoomTSB.Image = global::WinformDotNetFramework.Properties.Resources.dezoom_23_25;
            this.DezoomTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DezoomTSB.Name = "DezoomTSB";
            this.DezoomTSB.Size = new System.Drawing.Size(25, 23);
            this.DezoomTSB.Text = "toolStripButton9";
            this.DezoomTSB.Click += new System.EventHandler(this.DezoomTSB_Click);
            // 
            // ZoomTSB
            // 
            this.ZoomTSB.AutoSize = false;
            this.ZoomTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomTSB.Image = global::WinformDotNetFramework.Properties.Resources.zoom_21x25;
            this.ZoomTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomTSB.Name = "ZoomTSB";
            this.ZoomTSB.Size = new System.Drawing.Size(25, 23);
            this.ZoomTSB.Text = "toolStripButton10";
            this.ZoomTSB.Click += new System.EventHandler(this.ZoomTSB_Click);
            // 
            // ZoomTSLbl
            // 
            this.ZoomTSLbl.Name = "ZoomTSLbl";
            this.ZoomTSLbl.Size = new System.Drawing.Size(35, 17);
            this.ZoomTSLbl.Text = "100%";
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.DocumentMapWidth = 56;
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Reports.SaleProfitReport.rdlc";
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ServerReport.BearerToken = null;
            this.ReportViewer.ShowBackButton = false;
            this.ReportViewer.ShowContextMenu = false;
            this.ReportViewer.ShowCredentialPrompts = false;
            this.ReportViewer.ShowDocumentMapButton = false;
            this.ReportViewer.ShowExportButton = false;
            this.ReportViewer.ShowParameterPrompts = false;
            this.ReportViewer.ShowPrintButton = false;
            this.ReportViewer.ShowRefreshButton = false;
            this.ReportViewer.ShowStopButton = false;
            this.ReportViewer.ShowZoomControl = false;
            this.ReportViewer.Size = new System.Drawing.Size(799, 761);
            this.ReportViewer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.searchSaleReport1);
            this.panel1.Controls.Add(this.searchSupplierInvoiceReport1);
            this.panel1.Controls.Add(this.searchCustomerInvoiceReportUserControl1);
            this.panel1.Controls.Add(this.SearchPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 761);
            this.panel1.TabIndex = 2;
            // 
            // searchSaleReport1
            // 
            this.searchSaleReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSaleReport1.Location = new System.Drawing.Point(0, 70);
            this.searchSaleReport1.Name = "searchSaleReport1";
            this.searchSaleReport1.Size = new System.Drawing.Size(231, 691);
            this.searchSaleReport1.TabIndex = 8;
            // 
            // searchSupplierInvoiceReport1
            // 
            this.searchSupplierInvoiceReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchSupplierInvoiceReport1.Location = new System.Drawing.Point(0, 70);
            this.searchSupplierInvoiceReport1.Name = "searchSupplierInvoiceReport1";
            this.searchSupplierInvoiceReport1.Size = new System.Drawing.Size(231, 691);
            this.searchSupplierInvoiceReport1.TabIndex = 10;
            // 
            // searchCustomerInvoiceReportUserControl1
            // 
            this.searchCustomerInvoiceReportUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCustomerInvoiceReportUserControl1.Location = new System.Drawing.Point(0, 70);
            this.searchCustomerInvoiceReportUserControl1.Name = "searchCustomerInvoiceReportUserControl1";
            this.searchCustomerInvoiceReportUserControl1.Size = new System.Drawing.Size(231, 691);
            this.searchCustomerInvoiceReportUserControl1.TabIndex = 9;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SearchPanel.Controls.Add(this.button1);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPanel.Location = new System.Drawing.Point(0, 27);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(231, 43);
            this.SearchPanel.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.button1.Location = new System.Drawing.Point(58, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.panel2.Controls.Add(this.DockButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 27);
            this.panel2.TabIndex = 6;
            // 
            // DockButton
            // 
            this.DockButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DockButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.DockButton.Location = new System.Drawing.Point(0, 0);
            this.DockButton.Name = "DockButton";
            this.DockButton.Size = new System.Drawing.Size(25, 25);
            this.DockButton.TabIndex = 0;
            this.DockButton.Text = ">";
            this.DockButton.UseVisualStyleBackColor = true;
            this.DockButton.Click += new System.EventHandler(this.DockButton_Click);
            // 
            // ReportGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 761);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1050, 800);
            this.Name = "ReportGridForm";
            this.Text = "SaleReportForm";
            this.Load += new System.EventHandler(this.SaleReportForm_Load);
            this.Shown += new System.EventHandler(this.SaleReportForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DockButton;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton EmptyReportTSB;
        private System.Windows.Forms.ToolStripButton PrintPagePreviewBTS;
        private System.Windows.Forms.ToolStripButton PdfTSB;
        private System.Windows.Forms.ToolStripButton ExcelTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton DezoomTSB;
        private System.Windows.Forms.ToolStripButton ZoomTSB;
        private System.Windows.Forms.ToolStripLabel ZoomTSLbl;
        private control.SearchSupplierInvoiceReport searchSupplierInvoiceReport1;
        private control.SearchCustomerInvoiceReportUserControl searchCustomerInvoiceReportUserControl1;
        private control.SearchSaleReport searchSaleReport1;
    }
}