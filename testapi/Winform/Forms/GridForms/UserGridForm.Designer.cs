namespace Winform.Forms.GridForms
{
    partial class UserGridForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rolesListBox = new System.Windows.Forms.CheckedListBox();
            this.Emailtxt = new System.Windows.Forms.TextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.RightSideBar = new Winform.Forms.control.RightSideBarUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PaginationPanel = new System.Windows.Forms.Panel();
            this.paginationControl = new Winform.Forms.control.PaginationUserControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.RightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CustomerIDTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerNameTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerCountryTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerDateTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerStatusTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.FilterPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PaginationPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.RightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FilterPanel);
            this.panel1.Controls.Add(this.RightSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(962, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 648);
            this.panel1.TabIndex = 0;
            // 
            // FilterPanel
            // 
            this.FilterPanel.AutoScroll = true;
            this.FilterPanel.AutoScrollMargin = new System.Drawing.Size(0, 30);
            this.FilterPanel.BackColor = System.Drawing.Color.DarkGray;
            this.FilterPanel.Controls.Add(this.label4);
            this.FilterPanel.Controls.Add(this.label3);
            this.FilterPanel.Controls.Add(this.label2);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Controls.Add(this.rolesListBox);
            this.FilterPanel.Controls.Add(this.Emailtxt);
            this.FilterPanel.Controls.Add(this.lastNameTxt);
            this.FilterPanel.Controls.Add(this.nameTxt);
            this.FilterPanel.Location = new System.Drawing.Point(0, 103);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(200, 661);
            this.FilterPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Roles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name";
            // 
            // rolesListBox
            // 
            this.rolesListBox.FormattingEnabled = true;
            this.rolesListBox.HorizontalScrollbar = true;
            this.rolesListBox.Items.AddRange(new object[] {
            "All",
            "Admin",
            "CustomerRead",
            "CustomerWrite",
            "CustomerDelete",
            "CustomerInvoiceRead",
            "CustomerInvoiceWrite",
            "CustomerInvoiceDelete",
            "CustomerInvoiceCostRead",
            "CustomerInvoiceCostWrite",
            "CustomerInvoiceCostDelete",
            "SupplierRead",
            "SupplierWrite",
            "SupplierDelete",
            "SupplierInvoiceRead",
            "SupplierInvoiceWrite",
            "SupplierInvoiceDelete",
            "SupplierInvoiceCostRead",
            "SupplierInvoiceCostWrite",
            "SupplierInvoiceCostDelete",
            "SaleRead",
            "SaleWrite",
            "SaleDelete"});
            this.rolesListBox.Location = new System.Drawing.Point(3, 189);
            this.rolesListBox.MinimumSize = new System.Drawing.Size(0, 436);
            this.rolesListBox.Name = "rolesListBox";
            this.rolesListBox.Size = new System.Drawing.Size(180, 436);
            this.rolesListBox.TabIndex = 4;
            this.rolesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rolesListBox_ItemCheck);
            this.rolesListBox.Click += new System.EventHandler(this.rolesListBox_Click);
            // 
            // Emailtxt
            // 
            this.Emailtxt.Location = new System.Drawing.Point(3, 131);
            this.Emailtxt.Name = "Emailtxt";
            this.Emailtxt.Size = new System.Drawing.Size(180, 23);
            this.Emailtxt.TabIndex = 2;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Location = new System.Drawing.Point(3, 83);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(180, 23);
            this.lastNameTxt.TabIndex = 1;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(3, 28);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(180, 23);
            this.nameTxt.TabIndex = 0;
            // 
            // RightSideBar
            // 
            this.RightSideBar.BackColor = System.Drawing.Color.DarkGray;
            this.RightSideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideBar.Location = new System.Drawing.Point(0, 0);
            this.RightSideBar.Name = "RightSideBar";
            this.RightSideBar.Size = new System.Drawing.Size(200, 648);
            this.RightSideBar.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.PaginationPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 100);
            this.panel2.TabIndex = 1;
            // 
            // PaginationPanel
            // 
            this.PaginationPanel.BackColor = System.Drawing.Color.DarkGray;
            this.PaginationPanel.Controls.Add(this.paginationControl);
            this.PaginationPanel.Location = new System.Drawing.Point(224, 0);
            this.PaginationPanel.Name = "PaginationPanel";
            this.PaginationPanel.Size = new System.Drawing.Size(407, 100);
            this.PaginationPanel.TabIndex = 0;
            // 
            // paginationControl
            // 
            this.paginationControl.CurrentPage = 0;
            this.paginationControl.Location = new System.Drawing.Point(45, 23);
            this.paginationControl.Name = "paginationControl";
            this.paginationControl.Size = new System.Drawing.Size(316, 50);
            this.paginationControl.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.userDgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 548);
            this.panel3.TabIndex = 2;
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDgv.Location = new System.Drawing.Point(0, 0);
            this.userDgv.Name = "userDgv";
            this.userDgv.ReadOnly = true;
            this.userDgv.RowTemplate.Height = 25;
            this.userDgv.Size = new System.Drawing.Size(962, 548);
            this.userDgv.TabIndex = 0;
            this.userDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyControl_OpenDetails_Clicked);
            this.userDgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userDgv_RightClick);
            // 
            // RightClickDgv
            // 
            this.RightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerIDTsmi,
            this.CustomerNameTsmi,
            this.CustomerCountryTsmi,
            this.CustomerDateTsmi,
            this.CustomerStatusTsmi});
            this.RightClickDgv.Name = "contextMenuStrip1";
            this.RightClickDgv.Size = new System.Drawing.Size(163, 114);
            // 
            // CustomerIDTsmi
            // 
            this.CustomerIDTsmi.CheckOnClick = true;
            this.CustomerIDTsmi.Name = "CustomerIDTsmi";
            this.CustomerIDTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerIDTsmi.Text = "Show ID";
            this.CustomerIDTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerNameTsmi
            // 
            this.CustomerNameTsmi.Checked = true;
            this.CustomerNameTsmi.CheckOnClick = true;
            this.CustomerNameTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerNameTsmi.Name = "CustomerNameTsmi";
            this.CustomerNameTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerNameTsmi.Text = "Show Name";
            this.CustomerNameTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerCountryTsmi
            // 
            this.CustomerCountryTsmi.Checked = true;
            this.CustomerCountryTsmi.CheckOnClick = true;
            this.CustomerCountryTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerCountryTsmi.Name = "CustomerCountryTsmi";
            this.CustomerCountryTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerCountryTsmi.Text = "Show Last Name";
            this.CustomerCountryTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerDateTsmi
            // 
            this.CustomerDateTsmi.Checked = true;
            this.CustomerDateTsmi.CheckOnClick = true;
            this.CustomerDateTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerDateTsmi.Name = "CustomerDateTsmi";
            this.CustomerDateTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerDateTsmi.Text = "Show Email";
            this.CustomerDateTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // CustomerStatusTsmi
            // 
            this.CustomerStatusTsmi.Checked = true;
            this.CustomerStatusTsmi.CheckOnClick = true;
            this.CustomerStatusTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CustomerStatusTsmi.Name = "CustomerStatusTsmi";
            this.CustomerStatusTsmi.Size = new System.Drawing.Size(162, 22);
            this.CustomerStatusTsmi.Text = "Show Roles";
            this.CustomerStatusTsmi.CheckedChanged += new System.EventHandler(this.ContextMenuStripCheckEvent);
            // 
            // UserGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 648);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserGridForm";
            this.Text = "UserGridForm";
            this.Load += new System.EventHandler(this.MyControl_ButtonClicked);
            this.Resize += new System.EventHandler(this.CustomerGridForm_Resize);
            this.panel1.ResumeLayout(false);
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PaginationPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.RightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel FilterPanel;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckedListBox rolesListBox;
        private TextBox Emailtxt;
        private TextBox lastNameTxt;
        private TextBox nameTxt;
        private control.RightSideBarUserControl RightSideBar;
        private Panel panel2;
        private Panel PaginationPanel;
        private control.PaginationUserControl paginationControl;
        private DataGridView userDgv;
        private ContextMenuStrip RightClickDgv;
        private ToolStripMenuItem CustomerIDTsmi;
        private ToolStripMenuItem CustomerNameTsmi;
        private ToolStripMenuItem CustomerCountryTsmi;
        private ToolStripMenuItem CustomerDateTsmi;
        private ToolStripMenuItem CustomerStatusTsmi;
        public Panel panel3;
    }
}