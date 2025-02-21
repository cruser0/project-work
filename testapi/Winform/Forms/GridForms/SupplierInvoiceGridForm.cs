using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierInvoiceGridForm : Form
    {

        int? SaleID;
        int? SupplierID;
        DateTime? InvoiceDateFrom;
        DateTime? InvoiceDateTo;
        int? InvoiceAmountFrom;
        int? InvoiceAmountTo;
        string? Status;

        readonly SupplierInvoiceService _supplierInvoiceService;
        int pages;
        double itemsPage = 10.0;
        public SupplierInvoiceGridForm()
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            pages = (int)Math.Ceiling(_supplierInvoiceService.Count(new SupplierInvoiceFilter()) / itemsPage);


            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }
        public SupplierInvoiceGridForm(string? id)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            if (id != null)
            {
                SupplierIDTxt.SetText(id);
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
                if (e.RowIndex == -1)
                    return;
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
                {
                    MessageBox.Show("Incorrect Input Date From");
                    return;
                }

                if (flagto)
                {
                    MessageBox.Show("Incorrect Input Date To");
                    return;
                }

            }
            PaginationUserControl.CurrentPage = 1;
            SaleID = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null;
            SupplierID = !string.IsNullOrEmpty(SupplierIDTxt.GetText()) ? int.Parse(SupplierIDTxt.GetText()) : null;
            InvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            InvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null;
            Status = StatusCmb.Text;

            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SaleID = SaleID,
                SupplierID = SupplierID,
                InvoiceDateFrom = InvoiceDateFrom,
                InvoiceDateTo = InvoiceDateTo,
                Status = Status,
                page = PaginationUserControl.CurrentPage
            };
            SupplierInvoiceFilter filterPage = new SupplierInvoiceFilter
            {
                SaleID = SaleID,
                SupplierID = SupplierID,
                InvoiceDateFrom = InvoiceDateFrom,
                InvoiceDateTo = InvoiceDateTo,
                Status = Status,
            };


            IEnumerable<SupplierInvoice> query = _supplierInvoiceService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_supplierInvoiceService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierInvoiceDgv.DataSource = query.ToList();
        }

        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SaleID = SaleID,
                SupplierID = SupplierID,
                InvoiceDateFrom = InvoiceDateFrom,
                InvoiceDateTo = InvoiceDateTo,
                Status = Status,
                page = PaginationUserControl.CurrentPage
            };

            IEnumerable<SupplierInvoice> query = _supplierInvoiceService.GetAll(filter);
            SupplierInvoiceDgv.DataSource = query.ToList();
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
        private void CustomerGridForm_Resize(object sender, EventArgs e)
        {
            BottomPanel.Location = new Point((Width - BottomPanel.Width) / 2, 0);
            PaginationUserControl.Location = new Point((BottomPanel.Width - PaginationUserControl.Width) / 2, (BottomPanel.Height - PaginationUserControl.Height) / 2);

        }
    }
}
