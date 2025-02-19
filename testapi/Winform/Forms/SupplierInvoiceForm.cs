using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierInvoiceForm : Form
    {
        SupplierInvoiceService _supplierInvoiceService;
        private DateTime selectedDateFrom;
        private DateTime selectedDateTo;
        public SupplierInvoiceForm(string? id)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            if (id != null)
            {
                SupplierIDTxt.Text = id;
                MyControl_ButtonClicked(this, EventArgs.Empty);
            }
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                SupplierInvoiceDetailsForm sid = new SupplierInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }

        private void MyControl_ButtonClicked(object? sender, EventArgs e)
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

            IEnumerable<SupplierInvoice> query = _supplierInvoiceService.GetAll(SaleIDTxt.GetText(), SupplierIDTxt.GetText(), DateFromClnd.Checked ? DateFromClnd.Value : null, DateToClnd.Checked ? DateToClnd.Value : null, StatusCmb.Text);

            SupplierInvoiceDgv.DataSource = query.ToList();
        }

    }
}
