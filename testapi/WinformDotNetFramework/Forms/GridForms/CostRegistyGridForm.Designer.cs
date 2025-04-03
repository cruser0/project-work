namespace WinformDotNetFramework.Forms.GridForms
{
    partial class CostRegistryGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostRegistryGridForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.CostRegistryDgv = new System.Windows.Forms.DataGridView();
            this.CostRegistryTS = new System.Windows.Forms.ToolStrip();
            this.MassDeleteTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CreateBtn = new System.Windows.Forms.ToolStripButton();
            this.CustomerGdv = new System.Windows.Forms.DataGridView();
            this.CostRegistryQuantityTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CostRegistryCostTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CostRegistryNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CostRegistryCodeTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CostRegistryIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchCostRegistry1 = new WinformDotNetFramework.Forms.control.SearchCostRegistry();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.panel5.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostRegistryDgv)).BeginInit();
            this.CostRegistryTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).BeginInit();
            this.RightClickDgv.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 87);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.PaginationUserControl);
            this.panel5.Location = new System.Drawing.Point(183, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 87);
            this.panel5.TabIndex = 2;
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(15, 23);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(265, 38);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.CostRegistryDgv);
            this.CenterPanel.Controls.Add(this.CostRegistryTS);
            this.CenterPanel.Controls.Add(this.CustomerGdv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(584, 374);
            this.CenterPanel.TabIndex = 12;
            // 
            // CostRegistryDgv
            // 
            this.CostRegistryDgv.AllowUserToAddRows = false;
            this.CostRegistryDgv.AllowUserToDeleteRows = false;
            this.CostRegistryDgv.AllowUserToOrderColumns = true;
            this.CostRegistryDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CostRegistryDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.CostRegistryDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CostRegistryDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CostRegistryDgv.Location = new System.Drawing.Point(0, 25);
            this.CostRegistryDgv.Name = "CostRegistryDgv";
            this.CostRegistryDgv.ReadOnly = true;
            this.CostRegistryDgv.RowTemplate.Height = 25;
            this.CostRegistryDgv.Size = new System.Drawing.Size(584, 349);
            this.CostRegistryDgv.TabIndex = 7;
            this.CostRegistryDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.CostRegistryDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CostRegistryDgv_RightClick);
            // 
            // CostRegistryTS
            // 
            this.CostRegistryTS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CostRegistryTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MassDeleteTSB,
            this.toolStripSeparator1,
            this.CreateBtn});
            this.CostRegistryTS.Location = new System.Drawing.Point(0, 0);
            this.CostRegistryTS.Name = "CostRegistryTS";
            this.CostRegistryTS.Size = new System.Drawing.Size(584, 25);
            this.CostRegistryTS.TabIndex = 10;
            this.CostRegistryTS.Text = "toolStrip1";
            // 
            // MassDeleteTSB
            // 
            this.MassDeleteTSB.Image = global::WinformDotNetFramework.Properties.Resources.trash;
            this.MassDeleteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MassDeleteTSB.Name = "MassDeleteTSB";
            this.MassDeleteTSB.Size = new System.Drawing.Size(107, 22);
            this.MassDeleteTSB.Text = "&Delete Selected";
            this.MassDeleteTSB.ToolTipText = "Delete Selected Items";
            this.MassDeleteTSB.Click += new System.EventHandler(this.MassDeleteTSB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CreateBtn
            // 
            this.CreateBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateBtn.Image")));
            this.CreateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(88, 22);
            this.CreateBtn.Text = "Create &New";
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // CustomerGdv
            // 
            this.CustomerGdv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerGdv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CustomerGdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerGdv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerGdv.Location = new System.Drawing.Point(0, 0);
            this.CustomerGdv.Name = "CustomerGdv";
            this.CustomerGdv.RowTemplate.Height = 25;
            this.CustomerGdv.Size = new System.Drawing.Size(584, 374);
            this.CustomerGdv.TabIndex = 6;
            // 
            // CostRegistryQuantityTsmi
            // 
            this.CostRegistryQuantityTsmi.CheckOnClick = true;
            this.CostRegistryQuantityTsmi.Name = "CostRegistryQuantityTsmi";
            this.CostRegistryQuantityTsmi.Size = new System.Drawing.Size(207, 22);
            this.CostRegistryQuantityTsmi.Text = "Show Default Quantity";
            this.CostRegistryQuantityTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CostRegistryCostTsmi
            // 
            this.CostRegistryCostTsmi.Checked = true;
            this.CostRegistryCostTsmi.CheckOnClick = true;
            this.CostRegistryCostTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CostRegistryCostTsmi.Name = "CostRegistryCostTsmi";
            this.CostRegistryCostTsmi.Size = new System.Drawing.Size(207, 22);
            this.CostRegistryCostTsmi.Text = "Show Default Cost";
            this.CostRegistryCostTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CostRegistryNameTsmi
            // 
            this.CostRegistryNameTsmi.Checked = true;
            this.CostRegistryNameTsmi.CheckOnClick = true;
            this.CostRegistryNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CostRegistryNameTsmi.Name = "CostRegistryNameTsmi";
            this.CostRegistryNameTsmi.Size = new System.Drawing.Size(207, 22);
            this.CostRegistryNameTsmi.Text = "Show Default Description";
            this.CostRegistryNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CostRegistryCodeTsmi
            // 
            this.CostRegistryCodeTsmi.Checked = true;
            this.CostRegistryCodeTsmi.CheckOnClick = true;
            this.CostRegistryCodeTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CostRegistryCodeTsmi.Name = "CostRegistryCodeTsmi";
            this.CostRegistryCodeTsmi.Size = new System.Drawing.Size(207, 22);
            this.CostRegistryCodeTsmi.Text = "Show Unique Code";
            this.CostRegistryCodeTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CostRegistryIDTsmi
            // 
            this.CostRegistryIDTsmi.CheckOnClick = true;
            this.CostRegistryIDTsmi.Name = "CostRegistryIDTsmi";
            this.CostRegistryIDTsmi.Size = new System.Drawing.Size(207, 22);
            this.CostRegistryIDTsmi.Text = "Show ID";
            this.CostRegistryIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CostRegistryIDTsmi,
            this.CostRegistryCodeTsmi,
            this.CostRegistryNameTsmi,
            this.CostRegistryCostTsmi,
            this.CostRegistryQuantityTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(208, 114);
            // 
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchCostRegistry1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 372);
            this.TextBoxesRightPanel.TabIndex = 6;
            // 
            // searchCostRegistry1
            // 
            this.searchCostRegistry1.Location = new System.Drawing.Point(3, 3);
            this.searchCostRegistry1.Name = "searchCostRegistry1";
            this.searchCostRegistry1.Size = new System.Drawing.Size(187, 125);
            this.searchCostRegistry1.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 374);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(584, 87);
            this.BottomPanel.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(584, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 87);
            this.panel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 10;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 461);
            this.RightSideBar.TabIndex = 0;
            // 
            // CostRegistryGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CostRegistryGridForm";
            this.Text = "CostRegistryGridForm";
            this.Load += new System.EventHandler(this.CostRegistryGridForm_Load);
            this.Resize += new System.EventHandler(this.CostRegistryGridForm_Resize);
            this.panel5.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostRegistryDgv)).EndInit();
            this.CostRegistryTS.ResumeLayout(false);
            this.CostRegistryTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGdv)).EndInit();
            this.RightClickDgv.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel CenterPanel;
        public System.Windows.Forms.DataGridView CostRegistryDgv;
        public System.Windows.Forms.ToolStrip CostRegistryTS;
        public System.Windows.Forms.Panel panel3;
        public control.PaginationUserControl PaginationUserControl;
        public System.Windows.Forms.ToolStripButton MassDeleteTSB;
        public System.Windows.Forms.DataGridView CustomerGdv;
        public System.Windows.Forms.ToolStripMenuItem CostRegistryQuantityTsmi;
        public System.Windows.Forms.ToolStripMenuItem CostRegistryCostTsmi;
        public System.Windows.Forms.ToolStripMenuItem CostRegistryNameTsmi;
        public System.Windows.Forms.ToolStripMenuItem CostRegistryCodeTsmi;
        public System.Windows.Forms.ToolStripMenuItem CostRegistryIDTsmi;
        public System.Windows.Forms.ContextMenuStrip RightClickDgv;
        public control.RightSideBarUserControl RightSideBar;
        public System.Windows.Forms.Panel TextBoxesRightPanel;
        public System.Windows.Forms.Panel BottomPanel;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel1;
        public control.SearchCostRegistry searchCostRegistry1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CreateBtn;
    }
}