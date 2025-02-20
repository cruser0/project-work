using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class SupplierInvoiceCostGridForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        public SupplierInvoiceCostGridForm()
        {
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                SupplierInvoiceCostDetailsForm sid = new SupplierInvoiceCostDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }

        private void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceId = !string.IsNullOrEmpty(InvoiceIDTxt.GetText()) ? int.Parse(InvoiceIDTxt.GetText()) : null,
                Cost = !string.IsNullOrEmpty(CostTxt.GetText()) ? int.Parse(CostTxt.GetText()) : null
            };

            IEnumerable<SupplierInvoiceCost> query = _supplierInvoiceCostService.GetAll(filter);

            SupplierInvoiceCostDgv.DataSource = query.ToList();

        }
    }
}
