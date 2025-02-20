using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class CustomerInvoiceGridForm : Form
    {
        CustomerInvoiceService _customerService;
        public CustomerInvoiceGridForm()
        {
            _customerService = new CustomerInvoiceService();
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void RightSideBar_searchBtnEvent(object? sender, EventArgs e)
        {
            bool flagfrom = false;
            bool flagto = false;
            if (DateFromClnd.Checked)
            {
                if (!(DateFromClnd.Value <= DateTime.Now) || !(DateFromClnd.Value > new DateTime(1975, 1, 1)))
                    flagfrom = true;
            }
            if (DateToClnd.Checked)
            {
                if (!(DateToClnd.Value <= DateTime.Now) || !(DateToClnd.Value >= DateFromClnd.Value))
                    flagto = true;
            }
            if (flagfrom && flagto)
                MessageBox.Show("Incorrect Input Date From and Date To");
            else
            {
                if (flagfrom)
                    MessageBox.Show("Incorrect Input Date From");
                if (flagto)
                    MessageBox.Show("Incorrect Input Date To");
            }

            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                SaleId = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                InvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                InvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                Status = StatusCmb.Text
            };

            IEnumerable<CustomerInvoice> query = _customerService.GetAll(filter);

            CenterDgv.DataSource = query.ToList();
        }

        private void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                CustomerInvoiceDetailsForm sid = new CustomerInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }
    }
}
