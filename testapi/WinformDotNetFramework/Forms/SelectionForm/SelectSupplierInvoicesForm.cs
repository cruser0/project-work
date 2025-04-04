using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.SelectionForm
{
    public partial class SelectSupplierInvoicesForm : SupplierInvoiceGridForm
    {
        UserService _userService;
        SupplierInvoiceService _supplierInvoiceService;
        CustomerInvoiceService _customerInvoiceService;
        SaleCustomerDTO _sale;
        public SelectSupplierInvoicesForm(SaleCustomerDTO sale)
        {
            _userService = new UserService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            PercentageCtb.SetPropName("Surcharge %");
            FixedCtb.SetPropName("Surcharge Fixed");

            toolStrip1.Visible = false;
            _sale = sale;
            SupplierInvoiceDgv.CellContentClick += SupplierInvoiceDgv_CellClick;
            label1.Text = sale.BookingNumber + " " + sale.BoLnumber;
        }

        private void SupplierInvoiceDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.OwningColumn.Name == "SelectColumn")
            {
                DataGridViewCheckBoxCell boxCell = (DataGridViewCheckBoxCell)dgv.CurrentCell;
                bool currentValue = false;
                if (boxCell.Value != null)
                {
                    currentValue = (bool)boxCell.Value;
                }

                boxCell.Value = !currentValue;

                SupplierInvoiceDgv.EndEdit();
            }

        }

        public async override void SupplierInvoiceGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
            SupplierInvoiceSupplierFilter filter = new SupplierInvoiceSupplierFilter()
            {
                SupplierInvoiceStatus = "Approved",
                SupplierInvoiceSaleID = _sale.SaleId,
                SupplierInvoiceMakeInvoice = true
            };
            getAllNotFiltered = _supplierInvoiceService.GetAll(filter);
            countNotFiltered = _supplierInvoiceService.Count(filter);
            getFav = _userService.GetSupplierInvoiceDGV();
            await SetCheckBoxes();

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Select",
                Name = "SelectColumn",
                Width = 60,
                FalseValue = false,
                TrueValue = true,
                DataPropertyName = "IsSelected"
            };
            SupplierInvoiceDgv.Columns.Add(checkColumn);


        }

        private async void MakeInvoiceBtn_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();

            foreach (DataGridViewRow row in SupplierInvoiceDgv.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["SelectColumn"];
                if ((bool?)cell.Value == true)
                    ids.Add((int)((SupplierInvoiceDTOGet)row.DataBoundItem).SupplierInvoiceId);
            }

            MakeCustomerInvoiceDTO data = new MakeCustomerInvoiceDTO()
            {
                SaleID = (int)_sale.SaleId,
                SupplierInvoiceIDs = ids,
                FixedSurcharge = string.IsNullOrEmpty(FixedCtb.PropTxt.Text) ? decimal.Zero : decimal.Parse(FixedCtb.PropTxt.Text),
                PercentSurcharge = string.IsNullOrEmpty(PercentageCtb.PropTxt.Text) ? decimal.Zero : decimal.Parse(PercentageCtb.PropTxt.Text)
            };

            var result = await _customerInvoiceService.MakeInvoice(data);

            if (result == null)
                throw new Exception("Something went wrong");

            return;

        }

    }
}
