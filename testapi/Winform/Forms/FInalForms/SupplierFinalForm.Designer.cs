namespace Winform.Forms.FInalForms
{
    partial class SupplierFinalForm
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
            this.LeftPane = new System.Windows.Forms.Panel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SpliContainerDGV = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.DoubleLeft = new System.Windows.Forms.ToolStripButton();
            this.Left = new System.Windows.Forms.ToolStripButton();
            this.Right = new System.Windows.Forms.ToolStripButton();
            this.DoubleRight = new System.Windows.Forms.ToolStripButton();
            this.TSLbl1 = new System.Windows.Forms.ToolStripLabel();
            this.SplitContainerDGV2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.DoubleLeft2 = new System.Windows.Forms.ToolStripButton();
            this.Left2 = new System.Windows.Forms.ToolStripButton();
            this.Right2 = new System.Windows.Forms.ToolStripButton();
            this.DoubleRight2 = new System.Windows.Forms.ToolStripButton();
            this.TSLbl2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.DoubleLeft3 = new System.Windows.Forms.ToolStripButton();
            this.Left3 = new System.Windows.Forms.ToolStripButton();
            this.Right3 = new System.Windows.Forms.ToolStripButton();
            this.DoubleRight3 = new System.Windows.Forms.ToolStripButton();
            this.TSLbl3 = new System.Windows.Forms.ToolStripLabel();
            this.searchSupplier1 = new Winform.Forms.control.SearchSupplier();
            this.searchSupplierInvoice1 = new Winform.Forms.control.SearchSupplierInvoice();
            this.searchSupplierInvoiceCost1 = new Winform.Forms.control.SearchSupplierInvoiceCost();
            this.LeftPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpliContainerDGV)).BeginInit();
            this.SpliContainerDGV.Panel1.SuspendLayout();
            this.SpliContainerDGV.Panel2.SuspendLayout();
            this.SpliContainerDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerDGV2)).BeginInit();
            this.SplitContainerDGV2.Panel1.SuspendLayout();
            this.SplitContainerDGV2.Panel2.SuspendLayout();
            this.SplitContainerDGV2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPane
            // 
            this.LeftPane.Controls.Add(this.MainSplitContainer);
            this.LeftPane.Controls.Add(this.panel3);
            this.LeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPane.Location = new System.Drawing.Point(0, 0);
            this.LeftPane.Name = "LeftPane";
            this.LeftPane.Size = new System.Drawing.Size(1204, 601);
            this.LeftPane.TabIndex = 3;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(68, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.SpliContainerDGV);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.MainSplitContainer.Size = new System.Drawing.Size(1136, 601);
            this.MainSplitContainer.SplitterDistance = 906;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // SpliContainerDGV
            // 
            this.SpliContainerDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpliContainerDGV.Location = new System.Drawing.Point(0, 0);
            this.SpliContainerDGV.Name = "SpliContainerDGV";
            this.SpliContainerDGV.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SpliContainerDGV.Panel1
            // 
            this.SpliContainerDGV.Panel1.Controls.Add(this.dataGridView1);
            this.SpliContainerDGV.Panel1.Controls.Add(this.toolStrip2);
            // 
            // SpliContainerDGV.Panel2
            // 
            this.SpliContainerDGV.Panel2.Controls.Add(this.SplitContainerDGV2);
            this.SpliContainerDGV.Size = new System.Drawing.Size(906, 601);
            this.SpliContainerDGV.SplitterDistance = 173;
            this.SpliContainerDGV.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(906, 148);
            this.dataGridView1.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoubleLeft,
            this.Left,
            this.Right,
            this.DoubleRight,
            this.TSLbl1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 148);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(906, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // DoubleLeft
            // 
            this.DoubleLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleLeft.Image = global::Winform.Properties.Resources.double_left_resize;
            this.DoubleLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleLeft.Name = "DoubleLeft";
            this.DoubleLeft.Size = new System.Drawing.Size(23, 22);
            this.DoubleLeft.Text = "toolStripButton1";
            // 
            // Left
            // 
            this.Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Left.Image = global::Winform.Properties.Resources.single_left_resize;
            this.Left.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(23, 22);
            this.Left.Text = "toolStripButton2";
            // 
            // Right
            // 
            this.Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Right.Image = global::Winform.Properties.Resources.single_right_resize;
            this.Right.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(23, 22);
            this.Right.Text = "toolStripButton3";
            // 
            // DoubleRight
            // 
            this.DoubleRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleRight.Image = global::Winform.Properties.Resources.double_right_resize;
            this.DoubleRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleRight.Name = "DoubleRight";
            this.DoubleRight.Size = new System.Drawing.Size(23, 22);
            this.DoubleRight.Text = "toolStripButton4";
            // 
            // TSLbl1
            // 
            this.TSLbl1.Name = "TSLbl1";
            this.TSLbl1.Size = new System.Drawing.Size(86, 22);
            this.TSLbl1.Text = "toolStripLabel1";
            // 
            // SplitContainerDGV2
            // 
            this.SplitContainerDGV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerDGV2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerDGV2.Name = "SplitContainerDGV2";
            // 
            // SplitContainerDGV2.Panel1
            // 
            this.SplitContainerDGV2.Panel1.Controls.Add(this.dataGridView4);
            this.SplitContainerDGV2.Panel1.Controls.Add(this.toolStrip4);
            // 
            // SplitContainerDGV2.Panel2
            // 
            this.SplitContainerDGV2.Panel2.Controls.Add(this.dataGridView3);
            this.SplitContainerDGV2.Panel2.Controls.Add(this.toolStrip3);
            this.SplitContainerDGV2.Size = new System.Drawing.Size(906, 424);
            this.SplitContainerDGV2.SplitterDistance = 332;
            this.SplitContainerDGV2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.searchSupplier1);
            this.flowLayoutPanel1.Controls.Add(this.searchSupplierInvoice1);
            this.flowLayoutPanel1.Controls.Add(this.searchSupplierInvoiceCost1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(226, 601);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(68, 601);
            this.panel3.TabIndex = 0;
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 601);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(1204, 100);
            this.FooterPanel.TabIndex = 4;
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 25;
            this.dataGridView4.Size = new System.Drawing.Size(332, 399);
            this.dataGridView4.TabIndex = 3;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(570, 399);
            this.dataGridView3.TabIndex = 4;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoubleLeft2,
            this.Left2,
            this.Right2,
            this.DoubleRight2,
            this.TSLbl2});
            this.toolStrip4.Location = new System.Drawing.Point(0, 399);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(332, 25);
            this.toolStrip4.TabIndex = 5;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // DoubleLeft2
            // 
            this.DoubleLeft2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleLeft2.Image = global::Winform.Properties.Resources.double_left_resize;
            this.DoubleLeft2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleLeft2.Name = "DoubleLeft2";
            this.DoubleLeft2.Size = new System.Drawing.Size(23, 22);
            this.DoubleLeft2.Text = "toolStripButton1";
            // 
            // Left2
            // 
            this.Left2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Left2.Image = global::Winform.Properties.Resources.single_left_resize;
            this.Left2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Left2.Name = "Left2";
            this.Left2.Size = new System.Drawing.Size(23, 22);
            this.Left2.Text = "toolStripButton2";
            // 
            // Right2
            // 
            this.Right2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Right2.Image = global::Winform.Properties.Resources.single_right_resize;
            this.Right2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Right2.Name = "Right2";
            this.Right2.Size = new System.Drawing.Size(23, 22);
            this.Right2.Text = "toolStripButton3";
            // 
            // DoubleRight2
            // 
            this.DoubleRight2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleRight2.Image = global::Winform.Properties.Resources.double_right_resize;
            this.DoubleRight2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleRight2.Name = "DoubleRight2";
            this.DoubleRight2.Size = new System.Drawing.Size(23, 22);
            this.DoubleRight2.Text = "toolStripButton4";
            // 
            // TSLbl2
            // 
            this.TSLbl2.Name = "TSLbl2";
            this.TSLbl2.Size = new System.Drawing.Size(86, 22);
            this.TSLbl2.Text = "toolStripLabel2";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoubleLeft3,
            this.Left3,
            this.Right3,
            this.DoubleRight3,
            this.TSLbl3});
            this.toolStrip3.Location = new System.Drawing.Point(0, 399);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(570, 25);
            this.toolStrip3.TabIndex = 6;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // DoubleLeft3
            // 
            this.DoubleLeft3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleLeft3.Image = global::Winform.Properties.Resources.double_left_resize;
            this.DoubleLeft3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleLeft3.Name = "DoubleLeft3";
            this.DoubleLeft3.Size = new System.Drawing.Size(23, 22);
            this.DoubleLeft3.Text = "toolStripButton1";
            // 
            // Left3
            // 
            this.Left3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Left3.Image = global::Winform.Properties.Resources.single_left_resize;
            this.Left3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Left3.Name = "Left3";
            this.Left3.Size = new System.Drawing.Size(23, 22);
            this.Left3.Text = "toolStripButton2";
            // 
            // Right3
            // 
            this.Right3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Right3.Image = global::Winform.Properties.Resources.single_right_resize;
            this.Right3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Right3.Name = "Right3";
            this.Right3.Size = new System.Drawing.Size(23, 22);
            this.Right3.Text = "toolStripButton3";
            // 
            // DoubleRight3
            // 
            this.DoubleRight3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DoubleRight3.Image = global::Winform.Properties.Resources.double_right_resize;
            this.DoubleRight3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DoubleRight3.Name = "DoubleRight3";
            this.DoubleRight3.Size = new System.Drawing.Size(23, 22);
            this.DoubleRight3.Text = "toolStripButton4";
            // 
            // TSLbl3
            // 
            this.TSLbl3.Name = "TSLbl3";
            this.TSLbl3.Size = new System.Drawing.Size(86, 22);
            this.TSLbl3.Text = "toolStripLabel3";
            // 
            // searchSupplier1
            // 
            this.searchSupplier1.Location = new System.Drawing.Point(3, 3);
            this.searchSupplier1.Name = "searchSupplier1";
            this.searchSupplier1.Size = new System.Drawing.Size(200, 309);
            this.searchSupplier1.TabIndex = 0;
            // 
            // searchSupplierInvoice1
            // 
            this.searchSupplierInvoice1.Location = new System.Drawing.Point(3, 318);
            this.searchSupplierInvoice1.Name = "searchSupplierInvoice1";
            this.searchSupplierInvoice1.Size = new System.Drawing.Size(200, 374);
            this.searchSupplierInvoice1.TabIndex = 1;
            // 
            // searchSupplierInvoiceCost1
            // 
            this.searchSupplierInvoiceCost1.Location = new System.Drawing.Point(3, 698);
            this.searchSupplierInvoiceCost1.Name = "searchSupplierInvoiceCost1";
            this.searchSupplierInvoiceCost1.Size = new System.Drawing.Size(200, 246);
            this.searchSupplierInvoiceCost1.TabIndex = 2;
            // 
            // SupplierFinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 701);
            this.Controls.Add(this.LeftPane);
            this.Controls.Add(this.FooterPanel);
            this.Name = "SupplierFinalForm";
            this.Text = "SupplierFinalForm";
            this.LeftPane.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.SpliContainerDGV.Panel1.ResumeLayout(false);
            this.SpliContainerDGV.Panel1.PerformLayout();
            this.SpliContainerDGV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpliContainerDGV)).EndInit();
            this.SpliContainerDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.SplitContainerDGV2.Panel1.ResumeLayout(false);
            this.SplitContainerDGV2.Panel1.PerformLayout();
            this.SplitContainerDGV2.Panel2.ResumeLayout(false);
            this.SplitContainerDGV2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerDGV2)).EndInit();
            this.SplitContainerDGV2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel LeftPane;
        private SplitContainer MainSplitContainer;
        private SplitContainer SpliContainerDGV;
        private DataGridView dataGridView1;
        private ToolStrip toolStrip2;
        private ToolStripButton DoubleLeft;
        private ToolStripButton Left;
        private ToolStripButton Right;
        private ToolStripButton DoubleRight;
        private ToolStripLabel TSLbl1;
        private SplitContainer SplitContainerDGV2;
        private DataGridView dataGridView4;
        private ToolStrip toolStrip4;
        private ToolStripButton DoubleLeft2;
        private ToolStripButton Left2;
        private ToolStripButton Right2;
        private ToolStripButton DoubleRight2;
        private ToolStripLabel TSLbl2;
        private DataGridView dataGridView3;
        private ToolStrip toolStrip3;
        private ToolStripButton DoubleLeft3;
        private ToolStripButton Left3;
        private ToolStripButton Right3;
        private ToolStripButton DoubleRight3;
        private ToolStripLabel TSLbl3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private Panel FooterPanel;
        private control.SearchSupplier searchSupplier1;
        private control.SearchSupplierInvoice searchSupplierInvoice1;
        private control.SearchSupplierInvoiceCost searchSupplierInvoiceCost1;
    }
}