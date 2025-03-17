using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.GridForms
{
    partial class SupplierGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierGridForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxesRightPanel = new System.Windows.Forms.Panel();
            this.searchSupplier1 = new WinformDotNetFramework.Forms.control.SearchSupplier();
            this.RightSideBar = new WinformDotNetFramework.Forms.control.RightSideBarUserControl();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SupplierDgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToggleEditButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PaginationUserControl = new WinformDotNetFramework.Forms.control.PaginationUserControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SupplierIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierOriginalIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SupplierStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.TextBoxesRightPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
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
            // TextBoxesRightPanel
            // 
            this.TextBoxesRightPanel.AutoScroll = true;
            this.TextBoxesRightPanel.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.TextBoxesRightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.TextBoxesRightPanel.Controls.Add(this.searchSupplier1);
            this.TextBoxesRightPanel.Location = new System.Drawing.Point(0, 89);
            this.TextBoxesRightPanel.Name = "TextBoxesRightPanel";
            this.TextBoxesRightPanel.Size = new System.Drawing.Size(200, 372);
            this.TextBoxesRightPanel.TabIndex = 8;
            // 
            // searchSupplier1
            // 
            this.searchSupplier1.Location = new System.Drawing.Point(3, 0);
            this.searchSupplier1.Name = "searchSupplier1";
            this.searchSupplier1.Size = new System.Drawing.Size(197, 256);
            this.searchSupplier1.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 461);
            this.RightSideBar.TabIndex = 7;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.SupplierDgv);
            this.CenterPanel.Controls.Add(this.toolStrip1);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 0);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(584, 374);
            this.CenterPanel.TabIndex = 12;
            // 
            // SupplierDgv
            // 
            this.SupplierDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierDgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.SupplierDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierDgv.Location = new System.Drawing.Point(0, 25);
            this.SupplierDgv.Name = "SupplierDgv";
            this.SupplierDgv.ReadOnly = true;
            this.SupplierDgv.RowTemplate.Height = 25;
            this.SupplierDgv.Size = new System.Drawing.Size(584, 349);
            this.SupplierDgv.TabIndex = 8;
            this.SupplierDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDgv_CellDoubleClick);
            this.SupplierDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RightClickDgvEvent);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleEditButton,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 12;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.BottomPanel.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.PaginationUserControl);
            this.panel5.Location = new System.Drawing.Point(187, 0);
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
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(584, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 87);
            this.panel4.TabIndex = 1;
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
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SupplierIDTsmi,
            this.SupplierNameTsmi,
            this.SupplierCountryTsmi,
            this.SupplierDateTsmi,
            this.SupplierOriginalIDTsmi,
            this.SupplierStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(163, 136);
            // 
            // SupplierIDTsmi
            // 
            this.SupplierIDTsmi.CheckOnClick = true;
            this.SupplierIDTsmi.Name = "SupplierIDTsmi";
            this.SupplierIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierIDTsmi.Text = "Show ID";
            this.SupplierIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierNameTsmi
            // 
            this.SupplierNameTsmi.Checked = true;
            this.SupplierNameTsmi.CheckOnClick = true;
            this.SupplierNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierNameTsmi.Name = "SupplierNameTsmi";
            this.SupplierNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierNameTsmi.Text = "Show Name";
            this.SupplierNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierCountryTsmi
            // 
            this.SupplierCountryTsmi.Checked = true;
            this.SupplierCountryTsmi.CheckOnClick = true;
            this.SupplierCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierCountryTsmi.Name = "SupplierCountryTsmi";
            this.SupplierCountryTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierCountryTsmi.Text = "Show Country";
            this.SupplierCountryTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierDateTsmi
            // 
            this.SupplierDateTsmi.Checked = true;
            this.SupplierDateTsmi.CheckOnClick = true;
            this.SupplierDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierDateTsmi.Name = "SupplierDateTsmi";
            this.SupplierDateTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierDateTsmi.Text = "Show Date";
            this.SupplierDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierOriginalIDTsmi
            // 
            this.SupplierOriginalIDTsmi.CheckOnClick = true;
            this.SupplierOriginalIDTsmi.Name = "SupplierOriginalIDTsmi";
            this.SupplierOriginalIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierOriginalIDTsmi.Text = "Show Original ID";
            this.SupplierOriginalIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierStatusTsmi
            // 
            this.SupplierStatusTsmi.Checked = true;
            this.SupplierStatusTsmi.CheckOnClick = true;
            this.SupplierStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupplierStatusTsmi.Name = "SupplierStatusTsmi";
            this.SupplierStatusTsmi.Size = new System.Drawing.Size(162, 22);
            this.SupplierStatusTsmi.Text = "Show Status";
            this.SupplierStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // SupplierGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "SupplierGridForm";
            this.Text = "SupplierForm";
            this.Load += new System.EventHandler(this.SupplierGridForm_Load);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.TextBoxesRightPanel.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.CenterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDgv)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel TextBoxesRightPanel;
        private control.RightSideBarUserControl RightSideBar;
        private DataGridView SupplierDgv;
        public Panel CenterPanel;
        private Panel BottomPanel;
        private Panel panel5;
        private control.PaginationUserControl PaginationUserControl;
        private Panel panel4;
        private Panel panel3;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem SupplierIDTsmi;
        private ToolStripMenuItem SupplierNameTsmi;
        private ToolStripMenuItem SupplierCountryTsmi;
        private ToolStripMenuItem SupplierDateTsmi;
        private ToolStripMenuItem SupplierOriginalIDTsmi;
        private ToolStripMenuItem SupplierStatusTsmi;
        public ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton1;
        private control.SearchSupplier searchSupplier1;
        private ToolStripButton ToggleEditButton;
    }
}