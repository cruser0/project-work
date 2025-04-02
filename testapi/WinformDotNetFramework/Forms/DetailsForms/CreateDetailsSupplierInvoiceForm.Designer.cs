using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsSupplierInvoiceForm
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
            this.SaveEditCustomerBtn = new System.Windows.Forms.Button();
            this.EditCbx = new System.Windows.Forms.CheckBox();
            this.DateClnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SupplierInvoiceCostGrbBX = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.costRegistryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceCostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.InvoiceCodeCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SaveQuitBtn = new System.Windows.Forms.Button();
            this.FlushCreateBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.NameCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.DateLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BoLCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BKCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.SupplierInvoiceCostGrbBX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceCostBindingSource)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveEditCustomerBtn
            // 
            this.SaveEditCustomerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveEditCustomerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveEditCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveEditCustomerBtn.Location = new System.Drawing.Point(625, 70);
            this.SaveEditCustomerBtn.Name = "SaveEditCustomerBtn";
            this.SaveEditCustomerBtn.Size = new System.Drawing.Size(110, 25);
            this.SaveEditCustomerBtn.TabIndex = 16;
            this.SaveEditCustomerBtn.Text = "Save";
            this.SaveEditCustomerBtn.UseVisualStyleBackColor = false;
            this.SaveEditCustomerBtn.Click += new System.EventHandler(this.SaveEditCustomerBtn_Click);
            // 
            // EditCbx
            // 
            this.EditCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCbx.AutoSize = true;
            this.EditCbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCbx.Location = new System.Drawing.Point(469, 142);
            this.EditCbx.Name = "EditCbx";
            this.EditCbx.Size = new System.Drawing.Size(46, 19);
            this.EditCbx.TabIndex = 15;
            this.EditCbx.Text = "Edit";
            this.EditCbx.UseVisualStyleBackColor = true;
            this.EditCbx.CheckedChanged += new System.EventHandler(this.EditCustomerCbx_CheckedChanged);
            // 
            // DateClnd
            // 
            this.DateClnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateClnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateClnd.Location = new System.Drawing.Point(254, 137);
            this.DateClnd.Name = "DateClnd";
            this.DateClnd.Size = new System.Drawing.Size(200, 23);
            this.DateClnd.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 461);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(767, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 461);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(17, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 17);
            this.panel3.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(17, 444);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 17);
            this.panel4.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel5.Controls.Add(this.SupplierInvoiceCostGrbBX);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(17, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(750, 427);
            this.panel5.TabIndex = 27;
            // 
            // SupplierInvoiceCostGrbBX
            // 
            this.SupplierInvoiceCostGrbBX.Controls.Add(this.dataGridView1);
            this.SupplierInvoiceCostGrbBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceCostGrbBX.Location = new System.Drawing.Point(0, 187);
            this.SupplierInvoiceCostGrbBX.Name = "SupplierInvoiceCostGrbBX";
            this.SupplierInvoiceCostGrbBX.Size = new System.Drawing.Size(750, 240);
            this.SupplierInvoiceCostGrbBX.TabIndex = 64;
            this.SupplierInvoiceCostGrbBX.TabStop = false;
            this.SupplierInvoiceCostGrbBX.Text = "Supplier Invoice Costs";
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
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn,
            this.supplierInvoiceIdDataGridViewTextBoxColumn,
            this.supplierInvoiceCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.supplierInvoiceCostBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(744, 221);
            this.dataGridView1.TabIndex = 61;
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
            // supplierInvoiceCostsIdDataGridViewTextBoxColumn
            // 
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn.DataPropertyName = "SupplierInvoiceCostsId";
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn.HeaderText = "SupplierInvoiceCostsId";
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn.Name = "supplierInvoiceCostsIdDataGridViewTextBoxColumn";
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierInvoiceCostsIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // supplierInvoiceIdDataGridViewTextBoxColumn
            // 
            this.supplierInvoiceIdDataGridViewTextBoxColumn.DataPropertyName = "SupplierInvoiceId";
            this.supplierInvoiceIdDataGridViewTextBoxColumn.HeaderText = "SupplierInvoiceId";
            this.supplierInvoiceIdDataGridViewTextBoxColumn.Name = "supplierInvoiceIdDataGridViewTextBoxColumn";
            this.supplierInvoiceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierInvoiceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // supplierInvoiceCodeDataGridViewTextBoxColumn
            // 
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.DataPropertyName = "SupplierInvoiceCode";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.HeaderText = "SupplierInvoiceCode";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.Name = "supplierInvoiceCodeDataGridViewTextBoxColumn";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // supplierInvoiceCostBindingSource
            // 
            this.supplierInvoiceCostBindingSource.DataSource = typeof(Entity_Validator.Entity.DTO.SupplierInvoiceCostDTOGet);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.InvoiceCodeCtb);
            this.panel6.Controls.Add(this.SaveQuitBtn);
            this.panel6.Controls.Add(this.FlushCreateBtn);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.OpenSale);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.DateClnd);
            this.panel6.Controls.Add(this.SaveEditCustomerBtn);
            this.panel6.Controls.Add(this.NameCmbxUC);
            this.panel6.Controls.Add(this.EditCbx);
            this.panel6.Controls.Add(this.DateLbl);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.BoLCmbxUC);
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Controls.Add(this.BKCmbxUC);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(750, 187);
            this.panel6.TabIndex = 60;
            // 
            // InvoiceCodeCtb
            // 
            this.InvoiceCodeCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InvoiceCodeCtb.Location = new System.Drawing.Point(9, 10);
            this.InvoiceCodeCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.InvoiceCodeCtb.Name = "InvoiceCodeCtb";
            this.InvoiceCodeCtb.Size = new System.Drawing.Size(200, 47);
            this.InvoiceCodeCtb.TabIndex = 62;
            this.InvoiceCodeCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // SaveQuitBtn
            // 
            this.SaveQuitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuitBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuitBtn.Location = new System.Drawing.Point(625, 110);
            this.SaveQuitBtn.Name = "SaveQuitBtn";
            this.SaveQuitBtn.Size = new System.Drawing.Size(110, 25);
            this.SaveQuitBtn.TabIndex = 65;
            this.SaveQuitBtn.Text = "Save and Quit";
            this.SaveQuitBtn.UseVisualStyleBackColor = false;
            this.SaveQuitBtn.Click += new System.EventHandler(this.SaveQuitBtn_Click);
            // 
            // FlushCreateBtn
            // 
            this.FlushCreateBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlushCreateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.FlushCreateBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlushCreateBtn.Location = new System.Drawing.Point(625, 28);
            this.FlushCreateBtn.Name = "FlushCreateBtn";
            this.FlushCreateBtn.Size = new System.Drawing.Size(110, 25);
            this.FlushCreateBtn.TabIndex = 64;
            this.FlushCreateBtn.Text = "Create New";
            this.FlushCreateBtn.UseVisualStyleBackColor = false;
            this.FlushCreateBtn.Visible = false;
            this.FlushCreateBtn.Click += new System.EventHandler(this.FlushCreateBtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.button2.Location = new System.Drawing.Point(462, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 25);
            this.button2.TabIndex = 63;
            this.button2.Text = "->";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SupplierFillBtn_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(213, 114);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(30, 25);
            this.OpenSale.TabIndex = 62;
            this.OpenSale.Text = "->";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.SaleFillBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(469, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 25);
            this.button1.TabIndex = 59;
            this.button1.Text = "Add Cost";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddCostBtn_Click);
            // 
            // NameCmbxUC
            // 
            this.NameCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCmbxUC.listItemsDropCmbx = null;
            this.NameCmbxUC.Location = new System.Drawing.Point(254, 72);
            this.NameCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.NameCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.NameCmbxUC.Name = "NameCmbxUC";
            this.NameCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.NameCmbxUC.TabIndex = 57;
            // 
            // DateLbl
            // 
            this.DateLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.Location = new System.Drawing.Point(251, 119);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(31, 15);
            this.DateLbl.TabIndex = 22;
            this.DateLbl.Text = "Date";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(253, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "Status*";
            // 
            // BoLCmbxUC
            // 
            this.BoLCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoLCmbxUC.listItemsDropCmbx = null;
            this.BoLCmbxUC.Location = new System.Drawing.Point(6, 125);
            this.BoLCmbxUC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BoLCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.BoLCmbxUC.Name = "BoLCmbxUC";
            this.BoLCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.BoLCmbxUC.TabIndex = 54;
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Approved",
            "Unapproved"});
            this.comboBox1.Location = new System.Drawing.Point(254, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 23);
            this.comboBox1.TabIndex = 49;
            // 
            // BKCmbxUC
            // 
            this.BKCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BKCmbxUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BKCmbxUC.listItemsDropCmbx = null;
            this.BKCmbxUC.Location = new System.Drawing.Point(6, 72);
            this.BKCmbxUC.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.BKCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.BKCmbxUC.Name = "BKCmbxUC";
            this.BKCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.BKCmbxUC.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Sale Bill Of Lading*";
            // 
            // CreateDetailsSupplierInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsSupplierInvoiceForm";
            this.Text = "SupplierInvoiceDetailsForm";
            this.panel5.ResumeLayout(false);
            this.SupplierInvoiceCostGrbBX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceCostBindingSource)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SaveEditCustomerBtn;
        private CheckBox EditCbx;
        private DateTimePicker DateClnd;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label DateLbl;
        private control.DropDownMenuAutoCompleteUserControl NameCmbxUC;
        private control.DropDownMenuAutoCompleteUserControl BoLCmbxUC;
        private control.DropDownMenuAutoCompleteUserControl BKCmbxUC;
        private Label label2;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panel6;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn costRegistryCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn supplierInvoiceCostsIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn supplierInvoiceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn supplierInvoiceCodeDataGridViewTextBoxColumn;
        private BindingSource supplierInvoiceCostBindingSource;
        private Button button2;
        private Button OpenSale;
        private GroupBox SupplierInvoiceCostGrbBX;
        private Button FlushCreateBtn;
        private Button SaveQuitBtn;
        private control.CustomTextBoxUserControl InvoiceCodeCtb;
    }
}