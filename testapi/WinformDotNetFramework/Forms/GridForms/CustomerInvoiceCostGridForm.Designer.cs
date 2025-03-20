using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class CustomerInvoiceCostGridForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInvoiceCostGridForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomerInvoiceCostDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchCustomerInvoiceCost1 = new WinformDotNetFramework.Forms.control.SearchCustomerInvoiceCost();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.PaginationPanel = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CustomerInvoiceCostIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostCostTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostQuantityTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerInvoiceCostNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceCostDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.PaginationPanel.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CustomerInvoiceCostDgv);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 374);
            this.panel1.TabIndex = 3;
            // 
            // CustomerInvoiceCostDgv
            // 
            this.CustomerInvoiceCostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerInvoiceCostDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.CustomerInvoiceCostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerInvoiceCostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerInvoiceCostDgv.Location = new System.Drawing.Point(0, 25);
            this.CustomerInvoiceCostDgv.Name = "CustomerInvoiceCostDgv";
            this.CustomerInvoiceCostDgv.ReadOnly = true;
            this.CustomerInvoiceCostDgv.RowTemplate.Height = 25;
            this.CustomerInvoiceCostDgv.Size = new System.Drawing.Size(584, 349);
            this.CustomerInvoiceCostDgv.TabIndex = 0;
            this.CustomerInvoiceCostDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.CustomerInvoiceCostDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CustomerDgv_RightClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleEditButton,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToggleEditButton
            // 
            this.ToggleEditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToggleEditButton.Image = ((System.Drawing.Image)(resources.GetObject("ToggleEditButton.Image")));
            this.ToggleEditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToggleEditButton.Name = "ToggleEditButton";
            this.ToggleEditButton.Size = new System.Drawing.Size(69, 22);
            this.ToggleEditButton.Text = "Toggle Edit";
            this.ToggleEditButton.ToolTipText = "Toggle Edit Mode";
            this.ToggleEditButton.Click += new System.EventHandler(this.ToggleEditButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WinformDotNetFramework.Properties.Resources.save;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton1";
            this.toolStripButton2.ToolTipText = "Save Changes";
            this.toolStripButton2.Click += new System.EventHandler(this.MassUpdateTSB_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WinformDotNetFramework.Properties.Resources.trash;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton4";
            this.toolStripButton1.ToolTipText = "Delete Selected Items";
            this.toolStripButton1.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TextBoxesRightPanel);
            this.panel2.Controls.Add(this.RightSideBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(584, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 461);
            this.panel2.TabIndex = 4;
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchCustomerInvoiceCost1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 372);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // searchCustomerInvoiceCost1
            // 
            this.searchCustomerInvoiceCost1.AutoScroll = true;
            this.searchCustomerInvoiceCost1.Location = new System.Drawing.Point(3, 0);
            this.searchCustomerInvoiceCost1.Name = "searchCustomerInvoiceCost1";
            this.searchCustomerInvoiceCost1.Size = new System.Drawing.Size(197, 258);
            this.searchCustomerInvoiceCost1.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 461);
            this.RightSideBar.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.PaginationPanel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 374);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(584, 87);
            this.BottomPanel.TabIndex = 5;
            // 
            // PaginationPanel
            // 
            this.PaginationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.PaginationPanel.Controls.Add(this.PaginationUserControl);
            this.PaginationPanel.Location = new System.Drawing.Point(75, 0);
            this.PaginationPanel.Name = "PaginationPanel";
            this.PaginationPanel.Size = new System.Drawing.Size(349, 87);
            this.PaginationPanel.TabIndex = 1;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(30, 24);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(268, 43);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerInvoiceCostIDTsmi,
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi,
            this.CustomerInvoiceCostCostTsmi,
            this.CustomerInvoiceCostQuantityTsmi,
            this.CustomerInvoiceCostNameTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(214, 114);
            // 
            // CustomerInvoiceCostIDTsmi
            // 
            this.CustomerInvoiceCostIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostIDTsmi.Name = "CustomerInvoiceCostIDTsmi";
            this.CustomerInvoiceCostIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostIDTsmi.Text = "Show ID";
            this.CustomerInvoiceCostIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostCustomerInvoiceIDTsmi
            // 
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked = true;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Name = "CustomerInvoiceCostCustomerInvoiceIDTsmi";
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.Text = "Show Customer Invoice ID";
            this.CustomerInvoiceCostCustomerInvoiceIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostCostTsmi
            // 
            this.CustomerInvoiceCostCostTsmi.Checked = true;
            this.CustomerInvoiceCostCostTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostCostTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostCostTsmi.Name = "CustomerInvoiceCostCostTsmi";
            this.CustomerInvoiceCostCostTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostCostTsmi.Text = "Show Cost";
            this.CustomerInvoiceCostCostTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostQuantityTsmi
            // 
            this.CustomerInvoiceCostQuantityTsmi.Checked = true;
            this.CustomerInvoiceCostQuantityTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostQuantityTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostQuantityTsmi.Name = "CustomerInvoiceCostQuantityTsmi";
            this.CustomerInvoiceCostQuantityTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostQuantityTsmi.Text = "Show Quantity";
            this.CustomerInvoiceCostQuantityTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostNameTsmi
            // 
            this.CustomerInvoiceCostNameTsmi.Checked = true;
            this.CustomerInvoiceCostNameTsmi.CheckOnClick = true;
            this.CustomerInvoiceCostNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerInvoiceCostNameTsmi.Name = "CustomerInvoiceCostNameTsmi";
            this.CustomerInvoiceCostNameTsmi.Size = new System.Drawing.Size(213, 22);
            this.CustomerInvoiceCostNameTsmi.Text = "Show Description Name";
            this.CustomerInvoiceCostNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerInvoiceCostGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CustomerInvoiceCostGridForm";
            this.Text = "CustomerInvoiceCostGrid";
            this.Load += new System.EventHandler(this.CustomerInvoiceCostGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceCostDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.PaginationPanel.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Panel panel1;
        private DataGridView CustomerInvoiceCostDgv;
        private Panel panel2;
        private Panel TextBoxesRightPanel;
        private control.RightSideBarUserControl RightSideBar;
        private Panel BottomPanel;
        private control.PaginationUserControl PaginationUserControl;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem CustomerInvoiceCostIDTsmi;
        private ToolStripMenuItem CustomerInvoiceCostCustomerInvoiceIDTsmi;
        private ToolStripMenuItem CustomerInvoiceCostCostTsmi;
        private ToolStripMenuItem CustomerInvoiceCostQuantityTsmi;
        private ToolStripMenuItem CustomerInvoiceCostNameTsmi;
        private Panel PaginationPanel;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton1;
        private control.SearchCustomerInvoiceCost searchCustomerInvoiceCost1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton ToggleEditButton;
    }
}