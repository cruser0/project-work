namespace WinformDotNetFramework.Forms.GroupForms
{
    partial class CustomerInvoiceGroupCreateForm
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
            this.CustomerInvoiceDetailsGrpBx = new System.Windows.Forms.GroupBox();
            this.CustomerInvoicecostDgv = new System.Windows.Forms.DataGridView();
            this.CustomerInvoiceCostsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerInvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostRegistryCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomerInvoiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerInvoiceCostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.CustomerInvoiceDetailsGrpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoicecostDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(307, 95);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(307, 113);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(779, 111);
            // 
            // SaleBKLbl
            // 
            this.SaleBKLbl.Location = new System.Drawing.Point(307, 6);
            // 
            // OpenSale
            // 
            this.OpenSale.Enabled = false;
            this.OpenSale.FlatAppearance.BorderSize = 0;
            this.OpenSale.Location = new System.Drawing.Point(210, 369);
            this.OpenSale.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CustomerInvoiceDetailsGrpBx);
            this.panel1.Size = new System.Drawing.Size(850, 427);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.OpenSale, 0);
            this.panel1.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.panel1.Controls.SetChildIndex(this.SaleBKLbl, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.BKCmbxUC, 0);
            this.panel1.Controls.SetChildIndex(this.BoLCmbxUC, 0);
            this.panel1.Controls.SetChildIndex(this.SaveBtn, 0);
            this.panel1.Controls.SetChildIndex(this.CustomerInvoiceDetailsGrpBx, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(884, 17);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(867, 17);
            // 
            // panel5
            // 
            this.panel5.Size = new System.Drawing.Size(884, 17);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(307, 51);
            // 
            // BoLCmbxUC
            // 
            this.BoLCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoLCmbxUC.Location = new System.Drawing.Point(310, 69);
            // 
            // BKCmbxUC
            // 
            this.BKCmbxUC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BKCmbxUC.Location = new System.Drawing.Point(310, 25);
            // 
            // CustomerInvoiceDetailsGrpBx
            // 
            this.CustomerInvoiceDetailsGrpBx.Controls.Add(this.CustomerInvoicecostDgv);
            this.CustomerInvoiceDetailsGrpBx.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CustomerInvoiceDetailsGrpBx.Location = new System.Drawing.Point(0, 142);
            this.CustomerInvoiceDetailsGrpBx.Name = "CustomerInvoiceDetailsGrpBx";
            this.CustomerInvoiceDetailsGrpBx.Size = new System.Drawing.Size(848, 283);
            this.CustomerInvoiceDetailsGrpBx.TabIndex = 41;
            this.CustomerInvoiceDetailsGrpBx.TabStop = false;
            this.CustomerInvoiceDetailsGrpBx.Text = "Customer Invoice Cost";
            // 
            // CustomerInvoicecostDgv
            // 
            this.CustomerInvoicecostDgv.AutoGenerateColumns = false;
            this.CustomerInvoicecostDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerInvoicecostDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerInvoicecostDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerInvoiceCostsId,
            this.CustomerInvoiceId,
            this.Cost,
            this.Quantity,
            this.Name,
            this.CostRegistryCode,
            this.CustomerInvoiceCode});
            this.CustomerInvoicecostDgv.DataSource = this.customerInvoiceCostBindingSource;
            this.CustomerInvoicecostDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerInvoicecostDgv.Location = new System.Drawing.Point(3, 16);
            this.CustomerInvoicecostDgv.Name = "CustomerInvoicecostDgv";
            this.CustomerInvoicecostDgv.Size = new System.Drawing.Size(842, 264);
            this.CustomerInvoicecostDgv.TabIndex = 0;
            this.CustomerInvoicecostDgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.CustomerInvoicecostDgv_EditingControlShowing);
            // 
            // CustomerInvoiceCostsId
            // 
            this.CustomerInvoiceCostsId.DataPropertyName = "CustomerInvoiceCostsId";
            this.CustomerInvoiceCostsId.HeaderText = "CustomerInvoiceCostsId";
            this.CustomerInvoiceCostsId.Name = "CustomerInvoiceCostsId";
            this.CustomerInvoiceCostsId.Visible = false;
            // 
            // CustomerInvoiceId
            // 
            this.CustomerInvoiceId.DataPropertyName = "CustomerInvoiceId";
            this.CustomerInvoiceId.HeaderText = "CustomerInvoiceId";
            this.CustomerInvoiceId.Name = "CustomerInvoiceId";
            this.CustomerInvoiceId.Visible = false;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // CostRegistryCode
            // 
            this.CostRegistryCode.DataPropertyName = "CostRegistryCode";
            this.CostRegistryCode.HeaderText = "CostRegistryCode";
            this.CostRegistryCode.Name = "CostRegistryCode";
            this.CostRegistryCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CostRegistryCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CustomerInvoiceCode
            // 
            this.CustomerInvoiceCode.DataPropertyName = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.HeaderText = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.Name = "CustomerInvoiceCode";
            this.CustomerInvoiceCode.Visible = false;
            // 
            // customerInvoiceCostBindingSource
            // 
            this.customerInvoiceCostBindingSource.DataSource = typeof(WinformDotNetFramework.Entities.CustomerInvoiceCost);
            // 
            // CustomerInvoiceGroupCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "CustomerInvoiceGroupCreateForm";
            this.Text = "CustomerInvoiceGroupCreateForm";
            this.Load += new System.EventHandler(this.CustomerInvoiceGroupCreateForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CustomerInvoiceDetailsGrpBx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerInvoicecostDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerInvoiceCostBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox CustomerInvoiceDetailsGrpBx;
        private System.Windows.Forms.DataGridView CustomerInvoicecostDgv;
        private System.Windows.Forms.BindingSource customerInvoiceCostBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerInvoiceCostsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerInvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn CostRegistryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerInvoiceCode;
    }
}