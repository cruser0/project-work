namespace WinformDotNetFramework.Forms.GroupForms
{
    partial class SaleGroupCreateForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerInvoiceDgv = new System.Windows.Forms.DataGridView();
            this.SupplierInvoiceDgv = new System.Windows.Forms.DataGridView();
            this.SupplierNameCmbxDgv = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SupplierCountryCmbxDgv = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SaleBookingNumberTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleBoLTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceIdTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleIdTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierInvoiceTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierIdTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmountTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDateTxtDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDataCmbxDgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInvoiceSupplierDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceSupplierDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // saleDateDtp
            // 
            this.saleDateDtp.Location = new System.Drawing.Point(126, 111);
            // 
            // boltxt
            // 
            this.boltxt.Location = new System.Drawing.Point(126, 67);
            // 
            // bntxt
            // 
            this.bntxt.Location = new System.Drawing.Point(126, 21);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(126, 93);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 49);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(126, 2);
            // 
            // StatusLbl
            // 
            this.StatusLbl.Location = new System.Drawing.Point(439, 96);
            // 
            // StatusCmbx
            // 
            this.StatusCmbx.Location = new System.Drawing.Point(439, 111);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(638, 140);
            this.SaveBtn.Size = new System.Drawing.Size(116, 23);
            this.SaveBtn.Text = "Create Sale Group";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // OpenSale
            // 
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Location = new System.Drawing.Point(-21, 414);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(800, 20);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Size = new System.Drawing.Size(760, 421);
            this.panel2.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel2.Controls.SetChildIndex(this.saleDateDtp, 0);
            this.panel2.Controls.SetChildIndex(this.boltxt, 0);
            this.panel2.Controls.SetChildIndex(this.StatusCmbx, 0);
            this.panel2.Controls.SetChildIndex(this.bntxt, 0);
            this.panel2.Controls.SetChildIndex(this.StatusLbl, 0);
            this.panel2.Controls.SetChildIndex(this.SaveBtn, 0);
            this.panel2.Controls.SetChildIndex(this.label4, 0);
            this.panel2.Controls.SetChildIndex(this.OpenSale, 0);
            this.panel2.Controls.SetChildIndex(this.label3, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.CustomerNameLbl, 0);
            this.panel2.Controls.SetChildIndex(this.CustomerCountryLbl, 0);
            this.panel2.Controls.SetChildIndex(this.NameCmbxUC, 0);
            this.panel2.Controls.SetChildIndex(this.CountryCmbxUC, 0);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 441);
            this.panel3.Size = new System.Drawing.Size(800, 20);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(20, 421);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(780, 20);
            this.panel5.Size = new System.Drawing.Size(20, 421);
            // 
            // CustomerCountryLbl
            // 
            this.CustomerCountryLbl.Location = new System.Drawing.Point(472, 45);
            // 
            // CustomerNameLbl
            // 
            this.CustomerNameLbl.Location = new System.Drawing.Point(472, 0);
            // 
            // CountryCmbxUC
            // 
            this.CountryCmbxUC.Location = new System.Drawing.Point(439, 67);
            // 
            // NameCmbxUC
            // 
            this.NameCmbxUC.Location = new System.Drawing.Point(439, 22);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            this.tableLayoutPanel1.Controls.Add(this.CustomerInvoiceDgv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SupplierInvoiceDgv, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 169);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 250);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // CustomerInvoiceDgv
            // 
            this.CustomerInvoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerInvoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerInvoiceDgv.Location = new System.Drawing.Point(380, 3);
            this.CustomerInvoiceDgv.Name = "CustomerInvoiceDgv";
            this.CustomerInvoiceDgv.Size = new System.Drawing.Size(375, 244);
            this.CustomerInvoiceDgv.TabIndex = 2;
            // 
            // SupplierInvoiceDgv
            // 
            this.SupplierInvoiceDgv.AutoGenerateColumns = false;
            this.SupplierInvoiceDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierInvoiceDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierNameCmbxDgv,
            this.SupplierCountryCmbxDgv,
            this.SaleBookingNumberTxtDgv,
            this.SaleBoLTxtDgv,
            this.InvoiceIdTxtDgv,
            this.SaleIdTxtDgv,
            this.SupplierInvoiceTxtDgv,
            this.SupplierIdTxtDgv,
            this.InvoiceAmountTxtDgv,
            this.InvoiceDateTxtDgv,
            this.StatusDataCmbxDgv});
            this.SupplierInvoiceDgv.DataSource = this.supplierInvoiceSupplierDTOBindingSource;
            this.SupplierInvoiceDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SupplierInvoiceDgv.Location = new System.Drawing.Point(3, 3);
            this.SupplierInvoiceDgv.Name = "SupplierInvoiceDgv";
            this.SupplierInvoiceDgv.Size = new System.Drawing.Size(371, 244);
            this.SupplierInvoiceDgv.TabIndex = 3;
            this.SupplierInvoiceDgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.SupplierInvoiceDgv_EditingControlShowing);
            this.SupplierInvoiceDgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.SupplierInvoiceDgv_RowsAdded);
            // 
            // SupplierNameCmbxDgv
            // 
            this.SupplierNameCmbxDgv.DataPropertyName = "SupplierName";
            this.SupplierNameCmbxDgv.HeaderText = "SupplierName";
            this.SupplierNameCmbxDgv.Name = "SupplierNameCmbxDgv";
            this.SupplierNameCmbxDgv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierNameCmbxDgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SupplierCountryCmbxDgv
            // 
            this.SupplierCountryCmbxDgv.DataPropertyName = "Country";
            this.SupplierCountryCmbxDgv.HeaderText = "Country";
            this.SupplierCountryCmbxDgv.Name = "SupplierCountryCmbxDgv";
            this.SupplierCountryCmbxDgv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierCountryCmbxDgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SaleBookingNumberTxtDgv
            // 
            this.SaleBookingNumberTxtDgv.DataPropertyName = "SaleBookingNumber";
            this.SaleBookingNumberTxtDgv.HeaderText = "SaleBookingNumber";
            this.SaleBookingNumberTxtDgv.Name = "SaleBookingNumberTxtDgv";
            this.SaleBookingNumberTxtDgv.Visible = false;
            // 
            // SaleBoLTxtDgv
            // 
            this.SaleBoLTxtDgv.DataPropertyName = "SaleBoL";
            this.SaleBoLTxtDgv.HeaderText = "SaleBoL";
            this.SaleBoLTxtDgv.Name = "SaleBoLTxtDgv";
            this.SaleBoLTxtDgv.Visible = false;
            // 
            // InvoiceIdTxtDgv
            // 
            this.InvoiceIdTxtDgv.DataPropertyName = "InvoiceId";
            this.InvoiceIdTxtDgv.HeaderText = "InvoiceId";
            this.InvoiceIdTxtDgv.Name = "InvoiceIdTxtDgv";
            this.InvoiceIdTxtDgv.Visible = false;
            // 
            // SaleIdTxtDgv
            // 
            this.SaleIdTxtDgv.DataPropertyName = "SaleId";
            this.SaleIdTxtDgv.HeaderText = "SaleId";
            this.SaleIdTxtDgv.Name = "SaleIdTxtDgv";
            this.SaleIdTxtDgv.Visible = false;
            // 
            // SupplierInvoiceTxtDgv
            // 
            this.SupplierInvoiceTxtDgv.DataPropertyName = "SupplierInvoiceCode";
            this.SupplierInvoiceTxtDgv.HeaderText = "SupplierInvoiceCode";
            this.SupplierInvoiceTxtDgv.Name = "SupplierInvoiceTxtDgv";
            this.SupplierInvoiceTxtDgv.Visible = false;
            // 
            // SupplierIdTxtDgv
            // 
            this.SupplierIdTxtDgv.DataPropertyName = "SupplierId";
            this.SupplierIdTxtDgv.HeaderText = "SupplierId";
            this.SupplierIdTxtDgv.Name = "SupplierIdTxtDgv";
            this.SupplierIdTxtDgv.Visible = false;
            // 
            // InvoiceAmountTxtDgv
            // 
            this.InvoiceAmountTxtDgv.DataPropertyName = "InvoiceAmount";
            this.InvoiceAmountTxtDgv.HeaderText = "InvoiceAmount";
            this.InvoiceAmountTxtDgv.Name = "InvoiceAmountTxtDgv";
            this.InvoiceAmountTxtDgv.Visible = false;
            // 
            // InvoiceDateTxtDgv
            // 
            this.InvoiceDateTxtDgv.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.InvoiceDateTxtDgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceDateTxtDgv.HeaderText = "InvoiceDate";
            this.InvoiceDateTxtDgv.Name = "InvoiceDateTxtDgv";
            this.InvoiceDateTxtDgv.ToolTipText = "dd/mm/yyyy";
            // 
            // StatusDataCmbxDgv
            // 
            this.StatusDataCmbxDgv.DataPropertyName = "Status";
            this.StatusDataCmbxDgv.HeaderText = "Status";
            this.StatusDataCmbxDgv.Name = "StatusDataCmbxDgv";
            // 
            // supplierInvoiceSupplierDTOBindingSource
            // 
            this.supplierInvoiceSupplierDTOBindingSource.DataSource = typeof(WinformDotNetFramework.Entities.DTO.SupplierInvoiceSupplierDTO);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // SaleGroupCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Name = "SaleGroupCreateForm";
            this.Text = "SaleGroupCreateForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoiceDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierInvoiceDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInvoiceSupplierDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView CustomerInvoiceDgv;
        private System.Windows.Forms.DataGridView SupplierInvoiceDgv;
        private System.Windows.Forms.BindingSource supplierInvoiceSupplierDTOBindingSource;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridViewComboBoxColumn SupplierNameCmbxDgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn SupplierCountryCmbxDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleBookingNumberTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleBoLTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceIdTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleIdTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierInvoiceTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierIdTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmountTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDateTxtDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDataCmbxDgv;
    }
}