using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsCustomerInvoiceForm
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
            this.InvoiceDateDTP = new System.Windows.Forms.DateTimePicker();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.costRegistryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInvoiceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInvoiceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInvoiceCostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.InvoiceAmountCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SaveQuitButton = new System.Windows.Forms.Button();
            this.CustomerInvoiceCodeCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.ButtonOpenSales = new System.Windows.Forms.Button();
            this.AddCostBtn = new System.Windows.Forms.Button();
            this.BoLCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.BKCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // InvoiceDateDTP
            // 
            this.InvoiceDateDTP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceDateDTP.CustomFormat = "ddMMMMyyyy";
            this.InvoiceDateDTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceDateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.InvoiceDateDTP.Location = new System.Drawing.Point(284, 115);
            this.InvoiceDateDTP.Name = "InvoiceDateDTP";
            this.InvoiceDateDTP.ShowCheckBox = true;
            this.InvoiceDateDTP.Size = new System.Drawing.Size(200, 23);
            this.InvoiceDateDTP.TabIndex = 22;
            // 
            // StatusCB
            // 
            this.StatusCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
            this.StatusCB.Location = new System.Drawing.Point(535, 115);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(200, 23);
            this.StatusCB.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label3.Location = new System.Drawing.Point(281, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Invoice Date";
            // 
            // StatusLbl
            // 
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(532, 100);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 27;
            this.StatusLbl.Text = "Status";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.checkBox1.Location = new System.Drawing.Point(535, 156);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Edit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveBtn.Location = new System.Drawing.Point(599, 156);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(148, 25);
            this.SaveBtn.TabIndex = 31;
            this.SaveBtn.Text = "Save Changes";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 427);
            this.panel1.TabIndex = 32;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 222);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(750, 205);
            this.panel7.TabIndex = 44;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.costRegistryCodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.customerInvoiceCodeDataGridViewTextBoxColumn,
            this.customerInvoiceIdDataGridViewTextBoxColumn,
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.customerInvoiceCostBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(750, 205);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // costRegistryCodeDataGridViewTextBoxColumn
            // 
            this.costRegistryCodeDataGridViewTextBoxColumn.DataPropertyName = "CostRegistryCode";
            this.costRegistryCodeDataGridViewTextBoxColumn.HeaderText = "CostRegistryCode";
            this.costRegistryCodeDataGridViewTextBoxColumn.Name = "costRegistryCodeDataGridViewTextBoxColumn";
            this.costRegistryCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerInvoiceCodeDataGridViewTextBoxColumn
            // 
            this.customerInvoiceCodeDataGridViewTextBoxColumn.DataPropertyName = "CustomerInvoiceCode";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.HeaderText = "CustomerInvoiceCode";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.Name = "customerInvoiceCodeDataGridViewTextBoxColumn";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerInvoiceCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerInvoiceIdDataGridViewTextBoxColumn
            // 
            this.customerInvoiceIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerInvoiceId";
            this.customerInvoiceIdDataGridViewTextBoxColumn.HeaderText = "CustomerInvoiceId";
            this.customerInvoiceIdDataGridViewTextBoxColumn.Name = "customerInvoiceIdDataGridViewTextBoxColumn";
            this.customerInvoiceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerInvoiceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerInvoiceCostsIdDataGridViewTextBoxColumn
            // 
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerInvoiceCostsId";
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn.HeaderText = "CustomerInvoiceCostsId";
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn.Name = "customerInvoiceCostsIdDataGridViewTextBoxColumn";
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerInvoiceCostsIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerInvoiceCostBindingSource
            // 
            this.customerInvoiceCostBindingSource.DataSource = typeof(Entity_Validator.Entity.DTO.CustomerInvoiceCostDTOGet);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.InvoiceAmountCtb);
            this.panel6.Controls.Add(this.SaveQuitButton);
            this.panel6.Controls.Add(this.CustomerInvoiceCodeCtb);
            this.panel6.Controls.Add(this.ButtonOpenSales);
            this.panel6.Controls.Add(this.AddCostBtn);
            this.panel6.Controls.Add(this.BoLCmbxUC);
            this.panel6.Controls.Add(this.BKCmbxUC);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.StatusCB);
            this.panel6.Controls.Add(this.StatusLbl);
            this.panel6.Controls.Add(this.InvoiceDateDTP);
            this.panel6.Controls.Add(this.SaveBtn);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(750, 222);
            this.panel6.TabIndex = 43;
            // 
            // InvoiceAmountCtb
            // 
            this.InvoiceAmountCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceAmountCtb.Location = new System.Drawing.Point(33, 103);
            this.InvoiceAmountCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.InvoiceAmountCtb.Name = "InvoiceAmountCtb";
            this.InvoiceAmountCtb.Size = new System.Drawing.Size(200, 47);
            this.InvoiceAmountCtb.TabIndex = 35;
            this.InvoiceAmountCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
            // SaveQuitButton
            // 
            this.SaveQuitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.SaveQuitButton.Location = new System.Drawing.Point(599, 191);
            this.SaveQuitButton.Name = "SaveQuitButton";
            this.SaveQuitButton.Size = new System.Drawing.Size(148, 25);
            this.SaveQuitButton.TabIndex = 65;
            this.SaveQuitButton.Text = "Save and Quit";
            this.SaveQuitButton.UseVisualStyleBackColor = false;
            this.SaveQuitButton.Click += new System.EventHandler(this.SaveQuitButton_Click);
            // 
            // CustomerInvoiceCodeCtb
            // 
            this.CustomerInvoiceCodeCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustomerInvoiceCodeCtb.Location = new System.Drawing.Point(33, 50);
            this.CustomerInvoiceCodeCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.CustomerInvoiceCodeCtb.Name = "CustomerInvoiceCodeCtb";
            this.CustomerInvoiceCodeCtb.Size = new System.Drawing.Size(200, 47);
            this.CustomerInvoiceCodeCtb.TabIndex = 34;
            this.CustomerInvoiceCodeCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // ButtonOpenSales
            // 
            this.ButtonOpenSales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonOpenSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.ButtonOpenSales.FlatAppearance.BorderSize = 0;
            this.ButtonOpenSales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonOpenSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ButtonOpenSales.Location = new System.Drawing.Point(491, 61);
            this.ButtonOpenSales.Name = "ButtonOpenSales";
            this.ButtonOpenSales.Size = new System.Drawing.Size(30, 25);
            this.ButtonOpenSales.TabIndex = 64;
            this.ButtonOpenSales.Text = "->";
            this.ButtonOpenSales.UseVisualStyleBackColor = false;
            this.ButtonOpenSales.Click += new System.EventHandler(this.OpenSaleButton_Click);
            // 
            // AddCostBtn
            // 
            this.AddCostBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddCostBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.AddCostBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCostBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.AddCostBtn.Location = new System.Drawing.Point(33, 156);
            this.AddCostBtn.Name = "AddCostBtn";
            this.AddCostBtn.Size = new System.Drawing.Size(148, 25);
            this.AddCostBtn.TabIndex = 43;
            this.AddCostBtn.Text = "Add Cost";
            this.AddCostBtn.UseVisualStyleBackColor = false;
            this.AddCostBtn.Click += new System.EventHandler(this.AddCostBtn_Click);
            // 
            // BoLCmbxUC
            // 
            this.BoLCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoLCmbxUC.listItemsDropCmbx = null;
            this.BoLCmbxUC.Location = new System.Drawing.Point(535, 50);
            this.BoLCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BoLCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.BoLCmbxUC.Name = "BoLCmbxUC";
            this.BoLCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.BoLCmbxUC.TabIndex = 42;
            // 
            // BKCmbxUC
            // 
            this.BKCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BKCmbxUC.listItemsDropCmbx = null;
            this.BKCmbxUC.Location = new System.Drawing.Point(284, 50);
            this.BKCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BKCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.BKCmbxUC.Name = "BKCmbxUC";
            this.BKCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.BKCmbxUC.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 17);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 444);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 17);
            this.panel3.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(767, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(17, 427);
            this.panel4.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(17, 427);
            this.panel5.TabIndex = 36;
            // 
            // CreateDetailsCustomerInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsCustomerInvoiceForm";
            this.Text = "CustomerInvoiceDetailsForm";
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DateTimePicker InvoiceDateDTP;
        private ComboBox StatusCB;
        private Label label3;
        private Label StatusLbl;
        private CheckBox checkBox1;
        private Button SaveBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private DataGridView dataGridView1;
        private control.DropDownMenuAutoCompleteUserControl BoLCmbxUC;
        private control.DropDownMenuAutoCompleteUserControl BKCmbxUC;
        private Panel panel6;
        private Panel panel7;
        private BindingSource customerInvoiceCostBindingSource;
        private Button AddCostBtn;
        private DataGridViewTextBoxColumn costRegistryCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerInvoiceCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerInvoiceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerInvoiceCostsIdDataGridViewTextBoxColumn;
        private Button ButtonOpenSales;
        private Button FlushTxtBtn;
        private Button SaveQuitButton;
        private control.CustomTextBoxUserControl InvoiceAmountCtb;
        private control.CustomTextBoxUserControl CustomerInvoiceCodeCtb;
    }
}