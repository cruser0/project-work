using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SaleForm : Form
    {

        private SaleService _saleService;
        public SaleForm()
        {
            _saleService = new SaleService();

            InitializeComponent();

            StatusCB.SelectedIndex = 0;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            SaleFilter filter = new SaleFilter
            {
                BookingNumber = BNTextBox.Text,
                BoLnumber = BoLTextBox.Text,
                SaleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null,
                SaleDateTo = DateToDTP.Checked ? DateToDTP.Value : null,
                CustomerId = string.IsNullOrEmpty(CustomerIDTextBox.Text) ? null : int.Parse(CustomerIDTextBox.Text),
                Status = StatusCB.Text == "All" ? null : StatusCB.Text
            };

            IEnumerable<Sale> query = _saleService.GetAll(filter);

            SaleDgv.DataSource=query.ToList();
        }

        private void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                //CustomerDetailsForm cdf = new CustomerDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                //cdf.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }

        }

        private void CustomerIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}


