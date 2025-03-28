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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.CostRegistryDgv = new System.Windows.Forms.DataGridView();
            this.CostRegistryTS = new System.Windows.Forms.ToolStrip();
            this.CustomerGdv = new System.Windows.Forms.DataGridView();
            this.CustomerStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerOriginalIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.MassDeleteTSB = new System.Windows.Forms.ToolStripButton();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.searchCostRegistry1 = new WinformDotNetFramework.Forms.control.SearchCostRegistry();
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.CostRegistryDgv);
            this.CenterPanel.Controls.Add(this.CostRegistryTS);
            this.CenterPanel.Controls.Add(this.CustomerGdv);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(600, 363);
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
            this.CostRegistryDgv.Size = new System.Drawing.Size(600, 338);
            this.CostRegistryDgv.TabIndex = 7;
            // 
            // CostRegistryTS
            // 
            this.CostRegistryTS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CostRegistryTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleEditButton,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.MassDeleteTSB});
            this.CostRegistryTS.Location = new System.Drawing.Point(0, 0);
            this.CostRegistryTS.Name = "CostRegistryTS";
            this.CostRegistryTS.Size = new System.Drawing.Size(600, 25);
            this.CostRegistryTS.TabIndex = 10;
            this.CostRegistryTS.Text = "toolStrip1";
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
            this.CustomerGdv.Size = new System.Drawing.Size(600, 363);
            this.CustomerGdv.TabIndex = 6;
            // 
            // CustomerStatusTsmi
            // 
            this.CustomerStatusTsmi.Checked = true;
            this.CustomerStatusTsmi.CheckOnClick = true;
            this.CustomerStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerStatusTsmi.Name = "CustomerStatusTsmi";
            this.CustomerStatusTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerStatusTsmi.Text = "Show Status";
            // 
            // CustomerOriginalIDTsmi
            // 
            this.CustomerOriginalIDTsmi.CheckOnClick = true;
            this.CustomerOriginalIDTsmi.Name = "CustomerOriginalIDTsmi";
            this.CustomerOriginalIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerOriginalIDTsmi.Text = "Show Original ID";
            // 
            // CustomerDateTsmi
            // 
            this.CustomerDateTsmi.Checked = true;
            this.CustomerDateTsmi.CheckOnClick = true;
            this.CustomerDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerDateTsmi.Name = "CustomerDateTsmi";
            this.CustomerDateTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerDateTsmi.Text = "Show Date";
            // 
            // CustomerCountryTsmi
            // 
            this.CustomerCountryTsmi.Checked = true;
            this.CustomerCountryTsmi.CheckOnClick = true;
            this.CustomerCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerCountryTsmi.Name = "CustomerCountryTsmi";
            this.CustomerCountryTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerCountryTsmi.Text = "Show Country";
            // 
            // CustomerNameTsmi
            // 
            this.CustomerNameTsmi.Checked = true;
            this.CustomerNameTsmi.CheckOnClick = true;
            this.CustomerNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerNameTsmi.Name = "CustomerNameTsmi";
            this.CustomerNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerNameTsmi.Text = "Show Name";
            // 
            // CustomerIDTsmi
            // 
            this.CustomerIDTsmi.CheckOnClick = true;
            this.CustomerIDTsmi.Name = "CustomerIDTsmi";
            this.CustomerIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerIDTsmi.Text = "Show ID";
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerIDTsmi,
            this.CustomerNameTsmi,
            this.CustomerCountryTsmi,
            this.CustomerDateTsmi,
            this.CustomerOriginalIDTsmi,
            this.CustomerStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(163, 136);
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
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.BottomPanel.Controls.Add(this.panel5);
            this.BottomPanel.Controls.Add(this.panel4);
            this.BottomPanel.Controls.Add(this.panel3);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 363);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(600, 87);
            this.BottomPanel.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(600, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 87);
            this.panel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxesRightPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 10;
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
            // 
            // MassDeleteTSB
            // 
            this.MassDeleteTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MassDeleteTSB.Image = global::WinformDotNetFramework.Properties.Resources.trash;
            this.MassDeleteTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MassDeleteTSB.Name = "MassDeleteTSB";
            this.MassDeleteTSB.Size = new System.Drawing.Size(23, 22);
            this.MassDeleteTSB.Text = "toolStripButton4";
            this.MassDeleteTSB.ToolTipText = "Delete Selected Items";
            // 
            // PaginationUserControl
            // 
            this.PaginationUserControl.CurrentPage = 0;
            this.PaginationUserControl.Location = new System.Drawing.Point(15, 23);
            this.PaginationUserControl.Name = "PaginationUserControl";
            this.PaginationUserControl.Size = new System.Drawing.Size(265, 38);
            this.PaginationUserControl.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 450);
            this.RightSideBar.TabIndex = 0;
            // 
            // searchCostRegistry1
            // 
            this.searchCostRegistry1.Location = new System.Drawing.Point(3, 3);
            this.searchCostRegistry1.Name = "searchCostRegistry1";
            this.searchCostRegistry1.Size = new System.Drawing.Size(187, 125);
            this.searchCostRegistry1.TabIndex = 0;
            // 
            // CostRegistryGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.Name = "CostRegistryGridForm";
            this.Text = "CostRegistryGridForm";
            this.Load += new System.EventHandler(this.CostRegistryGridForm_Load);
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

        private System.Windows.Forms.Panel panel3;
        private control.PaginationUserControl PaginationUserControl;
        public System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripButton MassDeleteTSB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton ToggleEditButton;
        public System.Windows.Forms.Panel CenterPanel;
        public System.Windows.Forms.DataGridView CostRegistryDgv;
        public System.Windows.Forms.ToolStrip CostRegistryTS;
        private System.Windows.Forms.DataGridView CustomerGdv;
        private System.Windows.Forms.ToolStripMenuItem CustomerStatusTsmi;
        private System.Windows.Forms.ToolStripMenuItem CustomerOriginalIDTsmi;
        private System.Windows.Forms.ToolStripMenuItem CustomerDateTsmi;
        private System.Windows.Forms.ToolStripMenuItem CustomerCountryTsmi;
        private System.Windows.Forms.ToolStripMenuItem CustomerNameTsmi;
        private System.Windows.Forms.ToolStripMenuItem CustomerIDTsmi;
        private System.Windows.Forms.ContextMenuStrip RightClickDgv;
        private control.RightSideBarUserControl RightSideBar;
        private System.Windows.Forms.Panel TextBoxesRightPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private control.SearchCostRegistry searchCostRegistry1;
    }
}