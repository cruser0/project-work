using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SaleGridForm : Form
    {

        string bkNumber;
        string blNumber;
        DateTime? saleDateFrom;
        DateTime? saleDateTo;
        string customerID;
        string status;
        int pages;
        double itemsPage = 10.0;
        private SaleService _saleService;
        private CreateSupplierInvoicesForm _father;
        public SaleGridForm()
        {
            _saleService = new SaleService();

            InitializeComponent();
            pages = (int)Math.Ceiling(_saleService.Count(new SaleFilter()) / itemsPage);
            StatusCB.SelectedIndex = 0;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        }


        public SaleGridForm(CreateSupplierInvoicesForm father)
        {
            _father = father;
            _saleService = new SaleService();

            InitializeComponent();
            pages = (int)Math.Ceiling(_saleService.Count(new SaleFilter()) / itemsPage);

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            StatusCB.SelectedIndex = 0;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            SaleFilter filter = new SaleFilter
            {
                BookingNumber = BNTextBox.Text,
                BoLnumber = BoLTextBox.Text,
                SaleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null,
                SaleDateTo = DateToDTP.Checked ? DateToDTP.Value : null,
                CustomerId = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : int.Parse(CustomerIDTextBoxUserControl.GetText()),
                Status = StatusCB.Text == "All" ? null : StatusCB.Text,
                page = PaginationUserControl.CurrentPage

            };
            SaleFilter filterPage = new SaleFilter
            {
                BookingNumber = BNTextBox.Text,
                BoLnumber = BoLTextBox.Text,
                SaleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null,
                SaleDateTo = DateToDTP.Checked ? DateToDTP.Value : null,
                CustomerId = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : int.Parse(CustomerIDTextBoxUserControl.GetText()),
                Status = StatusCB.Text == "All" ? null : StatusCB.Text
            };

            bkNumber = BNTextBox.Text;
            blNumber = BoLTextBox.Text;
            saleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null;
            saleDateTo = DateToDTP.Checked ? DateToDTP.Value : null;
            customerID = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : CustomerIDTextBoxUserControl.GetText();
            status = StatusCB.Text == "All" ? null : StatusCB.Text;


            IEnumerable<Sale> query = _saleService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_saleService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SaleDgv.DataSource = query.ToList();
            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true;
            }
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            int outVal;
            SaleFilter filter = new SaleFilter
            {
                BookingNumber = bkNumber,
                BoLnumber = blNumber,
                SaleDateFrom = saleDateFrom,
                SaleDateTo = saleDateTo,
                CustomerId = int.TryParse(customerID, out outVal) ? outVal : null,
                Status = status,
                page = PaginationUserControl.CurrentPage

            };

            IEnumerable<Sale> query = _saleService.GetAll(filter);
            SaleDgv.DataSource = query.ToList();
        }
        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }

        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
        }



        private void CustomerIDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            panel5.Location = new Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);

        }
    }
}


