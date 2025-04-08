using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    partial class CreateDetailsSaleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.saleDateDtp = new System.Windows.Forms.DateTimePicker();
            this.EditCB = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CuInDgv = new System.Windows.Forms.DataGridView();
            this.customerInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PaidLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuInDgv = new System.Windows.Forms.DataGridView();
            this.supplierInvoiceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceSupplierDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.convertSupplierInvoicesBtn = new System.Windows.Forms.Button();
            this.BolCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.RevenueCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.BkCtb = new WinformDotNetFramework.Forms.control.CustomTextBoxUserControl();
            this.SaveQuitButton = new System.Windows.Forms.Button();
            this.OpenSale = new System.Windows.Forms.Button();
            this.NameCmbxUC = new WinformDotNetFramework.Forms.control.DropDownMenuAutoCompleteUserControl();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StatusCmbx = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.customerInvoiceCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuInDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceBindingSource)).BeginInit();
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuInDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceSupplierDTOBindingSource)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sale Date";
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saleDateDtp.CustomFormat = "ddMMMMyyyy";
            this.saleDateDtp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleDateDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.saleDateDtp.Location = new System.Drawing.Point(7, 125);
            this.saleDateDtp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saleDateDtp.Name = "saleDateDtp";
            this.saleDateDtp.ShowCheckBox = true;
            this.saleDateDtp.Size = new System.Drawing.Size(200, 23);
            this.saleDateDtp.TabIndex = 10;
            // 
            // EditCB
            // 
            this.EditCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EditCB.AutoSize = true;
            this.EditCB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCB.Location = new System.Drawing.Point(539, 127);
            this.EditCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditCB.Name = "EditCB";
            this.EditCB.Size = new System.Drawing.Size(46, 19);
            this.EditCB.TabIndex = 14;
            this.EditCB.Text = "Edit";
            this.EditCB.UseVisualStyleBackColor = true;
            this.EditCB.CheckedChanged += new System.EventHandler(this.EditCB_CheckedChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(593, 91);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(143, 25);
            this.saveBtn.TabIndex = 15;
            this.saveBtn.Text = "Save Changes";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 421);
            this.panel1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 163);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 258);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CuInDgv);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Invoices";
            // 
            // CuInDgv
            // 
            this.CuInDgv.AllowUserToAddRows = false;
            this.CuInDgv.AllowUserToDeleteRows = false;
            this.CuInDgv.AllowUserToOrderColumns = true;
            this.CuInDgv.AutoGenerateColumns = false;
            this.CuInDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CuInDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CuInDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerInvoiceCodeDataGridViewTextBoxColumn,
            this.invoiceAmountDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.CuInDgv.DataSource = this.customerInvoiceBindingSource;
            this.CuInDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CuInDgv.Location = new System.Drawing.Point(3, 44);
            this.CuInDgv.Name = "CuInDgv";
            this.CuInDgv.ReadOnly = true;
            this.CuInDgv.Size = new System.Drawing.Size(360, 205);
            this.CuInDgv.TabIndex = 0;
            this.CuInDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CuInDgv_CellDoubleClick);
            // 
            // customerInvoiceBindingSource
            // 
            this.customerInvoiceBindingSource.DataSource = typeof(Entity_Validator.Entity.DTO.CustomerInvoiceDTOGet);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.PaidLabel);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 19);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(360, 25);
            this.panel7.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(262, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Total Paid:";
            // 
            // PaidLabel
            // 
            this.PaidLabel.AutoSize = true;
            this.PaidLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PaidLabel.Location = new System.Drawing.Point(323, 0);
            this.PaidLabel.Name = "PaidLabel";
            this.PaidLabel.Size = new System.Drawing.Size(37, 15);
            this.PaidLabel.TabIndex = 18;
            this.PaidLabel.Text = "12345";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 25);
            this.button2.TabIndex = 17;
            this.button2.Text = "Create Customer Invoice";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.CustomerInvoiceBtn_click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SuInDgv);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(375, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Supplier Invoices";
            // 
            // SuInDgv
            // 
            this.SuInDgv.AllowUserToAddRows = false;
            this.SuInDgv.AllowUserToDeleteRows = false;
            this.SuInDgv.AllowUserToOrderColumns = true;
            this.SuInDgv.AutoGenerateColumns = false;
            this.SuInDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SuInDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SuInDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierInvoiceCodeDataGridViewTextBoxColumn,
            this.invoiceAmountDataGridViewTextBoxColumn1,
            this.invoiceDateDataGridViewTextBoxColumn1,
            this.supplierNameDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn1});
            this.SuInDgv.DataSource = this.supplierInvoiceSupplierDTOBindingSource;
            this.SuInDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuInDgv.Location = new System.Drawing.Point(3, 44);
            this.SuInDgv.Name = "SuInDgv";
            this.SuInDgv.ReadOnly = true;
            this.SuInDgv.Size = new System.Drawing.Size(360, 205);
            this.SuInDgv.TabIndex = 0;
            this.SuInDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SuInDgv_CellDoubleClick);
            // 
            // supplierInvoiceCodeDataGridViewTextBoxColumn
            // 
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.DataPropertyName = "SupplierInvoiceCode";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.HeaderText = "SupplierInvoiceCode";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.Name = "supplierInvoiceCodeDataGridViewTextBoxColumn";
            this.supplierInvoiceCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoiceAmountDataGridViewTextBoxColumn1
            // 
            this.invoiceAmountDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceAmount";
            dataGridViewCellStyle2.Format = "N2";
            this.invoiceAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoiceAmountDataGridViewTextBoxColumn1.HeaderText = "InvoiceAmount";
            this.invoiceAmountDataGridViewTextBoxColumn1.Name = "invoiceAmountDataGridViewTextBoxColumn1";
            this.invoiceAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // invoiceDateDataGridViewTextBoxColumn1
            // 
            this.invoiceDateDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn1.HeaderText = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn1.Name = "invoiceDateDataGridViewTextBoxColumn1";
            this.invoiceDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            this.statusDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // supplierInvoiceSupplierDTOBindingSource
            // 
            this.supplierInvoiceSupplierDTOBindingSource.DataSource = typeof(Entity_Validator.Entity.DTO.SupplierInvoiceSupplierDTO);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(360, 25);
            this.panel8.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Create Supplier Invoice";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SupplierInvoiceBtn_click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.RefreshBtn);
            this.panel6.Controls.Add(this.convertSupplierInvoicesBtn);
            this.panel6.Controls.Add(this.BolCtb);
            this.panel6.Controls.Add(this.RevenueCtb);
            this.panel6.Controls.Add(this.BkCtb);
            this.panel6.Controls.Add(this.SaveQuitButton);
            this.panel6.Controls.Add(this.OpenSale);
            this.panel6.Controls.Add(this.NameCmbxUC);
            this.panel6.Controls.Add(this.saleDateDtp);
            this.panel6.Controls.Add(this.StatusLbl);
            this.panel6.Controls.Add(this.StatusCmbx);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.EditCB);
            this.panel6.Controls.Add(this.saveBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(744, 163);
            this.panel6.TabIndex = 51;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RefreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.RefreshBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(433, 124);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(65, 25);
            this.RefreshBtn.TabIndex = 57;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // convertSupplierInvoicesBtn
            // 
            this.convertSupplierInvoicesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.convertSupplierInvoicesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.convertSupplierInvoicesBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertSupplierInvoicesBtn.Location = new System.Drawing.Point(593, 33);
            this.convertSupplierInvoicesBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.convertSupplierInvoicesBtn.Name = "convertSupplierInvoicesBtn";
            this.convertSupplierInvoicesBtn.Size = new System.Drawing.Size(143, 50);
            this.convertSupplierInvoicesBtn.TabIndex = 56;
            this.convertSupplierInvoicesBtn.Text = "Convert Supplier Invoices";
            this.convertSupplierInvoicesBtn.UseVisualStyleBackColor = false;
            this.convertSupplierInvoicesBtn.Click += new System.EventHandler(this.convertSupplierInvoicesBtn_Click);
            // 
            // BolCtb
            // 
            this.BolCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BolCtb.Location = new System.Drawing.Point(7, 68);
            this.BolCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.BolCtb.Name = "BolCtb";
            this.BolCtb.Size = new System.Drawing.Size(200, 47);
            this.BolCtb.TabIndex = 55;
            this.BolCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // RevenueCtb
            // 
            this.RevenueCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RevenueCtb.Location = new System.Drawing.Point(221, 113);
            this.RevenueCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.RevenueCtb.Name = "RevenueCtb";
            this.RevenueCtb.Size = new System.Drawing.Size(200, 47);
            this.RevenueCtb.TabIndex = 54;
            this.RevenueCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Decimal;
            // 
            // BkCtb
            // 
            this.BkCtb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BkCtb.Location = new System.Drawing.Point(7, 19);
            this.BkCtb.MinimumSize = new System.Drawing.Size(200, 47);
            this.BkCtb.Name = "BkCtb";
            this.BkCtb.Size = new System.Drawing.Size(200, 47);
            this.BkCtb.TabIndex = 53;
            this.BkCtb.TextBoxType = WinformDotNetFramework.Forms.control.TextBoxType.Default;
            // 
            // SaveQuitButton
            // 
            this.SaveQuitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveQuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.SaveQuitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuitButton.Location = new System.Drawing.Point(593, 124);
            this.SaveQuitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveQuitButton.Name = "SaveQuitButton";
            this.SaveQuitButton.Size = new System.Drawing.Size(143, 25);
            this.SaveQuitButton.TabIndex = 52;
            this.SaveQuitButton.Text = "Save and Quit";
            this.SaveQuitButton.UseVisualStyleBackColor = false;
            this.SaveQuitButton.Click += new System.EventHandler(this.SaveQuitButton_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OpenSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.OpenSale.Location = new System.Drawing.Point(433, 33);
            this.OpenSale.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OpenSale.Name = "OpenSale";
            this.OpenSale.Size = new System.Drawing.Size(29, 23);
            this.OpenSale.TabIndex = 51;
            this.OpenSale.Text = "->";
            this.OpenSale.UseVisualStyleBackColor = false;
            this.OpenSale.Click += new System.EventHandler(this.OpenSale_Click);
            // 
            // NameCmbxUC
            // 
            this.NameCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameCmbxUC.listItemsDropCmbx = null;
            this.NameCmbxUC.Location = new System.Drawing.Point(221, 19);
            this.NameCmbxUC.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.NameCmbxUC.MinimumSize = new System.Drawing.Size(200, 47);
            this.NameCmbxUC.Name = "NameCmbxUC";
            this.NameCmbxUC.Size = new System.Drawing.Size(200, 47);
            this.NameCmbxUC.TabIndex = 49;
            // 
            // StatusLbl
            // 
            this.StatusLbl.AllowDrop = true;
            this.StatusLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusLbl.Location = new System.Drawing.Point(218, 65);
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(39, 15);
            this.StatusLbl.TabIndex = 46;
            this.StatusLbl.Text = "Status";
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.AllowDrop = true;
            this.StatusCmbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCmbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusCmbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.StatusCmbx.FormattingEnabled = true;
            this.StatusCmbx.Items.AddRange(new object[] {
            "Active",
            "Closed"});
            this.StatusCmbx.Location = new System.Drawing.Point(221, 80);
            this.StatusCmbx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StatusCmbx.Name = "StatusCmbx";
            this.StatusCmbx.Size = new System.Drawing.Size(200, 23);
            this.StatusCmbx.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 461);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(764, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 461);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(20, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(744, 20);
            this.panel4.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(180)))), ((int)(((byte)(194)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(20, 441);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(744, 20);
            this.panel5.TabIndex = 24;
            // 
            // customerInvoiceCodeDataGridViewTextBoxColumn
            // 
            this.customerInvoiceCodeDataGridViewTextBoxColumn.DataPropertyName = "CustomerInvoiceCode";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.HeaderText = "CustomerInvoiceCode";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.Name = "customerInvoiceCodeDataGridViewTextBoxColumn";
            this.customerInvoiceCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoiceAmountDataGridViewTextBoxColumn
            // 
            this.invoiceAmountDataGridViewTextBoxColumn.DataPropertyName = "InvoiceAmount";
            dataGridViewCellStyle1.Format = "N2";
            this.invoiceAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.invoiceAmountDataGridViewTextBoxColumn.HeaderText = "InvoiceAmount";
            this.invoiceAmountDataGridViewTextBoxColumn.Name = "invoiceAmountDataGridViewTextBoxColumn";
            this.invoiceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // invoiceDateDataGridViewTextBoxColumn
            // 
            this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
            this.invoiceDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CreateDetailsSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(69)))));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "CreateDetailsSaleForm";
            this.Text = "SaleDetailsForm";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CuInDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceBindingSource)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SuInDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceSupplierDTOBindingSource)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label4;
        private DateTimePicker saleDateDtp;
        private CheckBox EditCB;
        private Button saveBtn;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        public control.DropDownMenuAutoCompleteUserControl NameCmbxUC;
        public Label StatusLbl;
        public ComboBox StatusCmbx;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private DataGridView CuInDgv;
        private BindingSource customerInvoiceBindingSource;
        private GroupBox groupBox2;
        private DataGridView SuInDgv;
        private BindingSource supplierInvoiceSupplierDTOBindingSource;
        private Panel panel7;
        private Button button2;
        private Panel panel8;
        private Button button1;
        public Button OpenSale;
        private Button SaveQuitButton;
        private control.CustomTextBoxUserControl BolCtb;
        private control.CustomTextBoxUserControl RevenueCtb;
        private control.CustomTextBoxUserControl BkCtb;
        private Button convertSupplierInvoicesBtn;
        private Button RefreshBtn;
        private Label label2;
        private Label PaidLabel;
        private DataGridViewTextBoxColumn supplierInvoiceCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn invoiceAmountDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn customerInvoiceCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn invoiceAmountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}