using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Forms.AddForms;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class CustomerInvoiceGridForm : Form
    {
        int? saleID;
        DateTime? invoiceDateFrom;
        DateTime? invoiceDateTo;
        int? invoiceAmountFrom;
        int? invoiceAmountTo;
        string status;
        double itemsPage = 10.0;
        int pages;
        CustomerInvoiceService _customerService;
        Form _father;
        List<string> authRoles = new List<string>
            {
                "CustomerInvoiceAdmin",
                "Admin"
            };
        UserService _userService;
        public CustomerInvoiceGridForm()
        {
            Init();
        }
        public CustomerInvoiceGridForm(CreateCustomerInvoiceCostForm father)
        {
            _father = father;
            Init();
        }

        private async void Init()
        {
            _userService = new UserService();
            _customerService = new CustomerInvoiceService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _customerService.Count(new CustomerInvoiceFilter()) / itemsPage);

            PaginationUserControl.CurrentPage = 1;
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.ContextMenuStrip = RightClickDgv;
            if (!Authorize(authRoles))
                CustomerInvoiceIDTsmi.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }



        private async void RightSideBar_searchBtnEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
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
            int idNum;
            saleID = int.TryParse(SaleIDTxt.GetText(), out idNum) ? idNum : null;
            invoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            invoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null;
            status = StatusCmb.Text;
            invoiceAmountFrom = !string.IsNullOrEmpty(AmountFromTxt.GetText()) ? int.Parse(AmountFromTxt.GetText()) : null;
            invoiceAmountTo = !string.IsNullOrEmpty(AmountToTxt.GetText()) ? int.Parse(AmountToTxt.GetText()) : null;


            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = saleID,
                CustomerInvoiceInvoiceDateFrom = invoiceDateFrom,
                CustomerInvoiceInvoiceDateTo = invoiceDateTo,
                CustomerInvoiceStatus = status,
                CustomerInvoicePage = PaginationUserControl.CurrentPage,
                CustomerInvoiceInvoiceAmountFrom = invoiceAmountFrom,
                CustomerInvoiceInvoiceAmountTo = invoiceAmountTo

            };
            CustomerInvoiceFilter filterPage = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = saleID,
                CustomerInvoiceInvoiceDateFrom = invoiceDateFrom,
                CustomerInvoiceInvoiceDateTo = invoiceDateTo,
                CustomerInvoiceStatus = status,
                CustomerInvoiceInvoiceAmountFrom = invoiceAmountFrom,
                CustomerInvoiceInvoiceAmountTo = invoiceAmountTo
            };


            var query = _customerService.GetAll(filter);
            var count = _customerService.Count(filterPage);


            IEnumerable<CustomerInvoice> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.DataSource = query1.ToList();

            if (!PaginationUserControl.Visible)
            {
                var check = SetCheckBoxes();
                await Task.WhenAll(count, query, check);
            }
            else
            {
                await Task.WhenAll(count, query);
            }
        }
        private async Task SetCheckBoxes()
        {
            CustomerInvoiceDGV cdgv = await _userService.GetCustomerInvoiceDGV();

            CustomerInvoiceDateTsmi.Checked = cdgv.ShowDate;
            CustomerInvoiceIDTsmi.Checked = cdgv.ShowID;
            CustomerInvoiceInvoiceAmountTsmi.Checked = cdgv.ShowInvoiceAmount;
            CustomerInvoiceSaleIDTsmi.Checked = cdgv.ShowSaleID;
            CustomerInvoiceStatusTsmi.Checked = cdgv.ShowStatus;
            CenterDgv.Columns["CustomerInvoiceID"].Visible = cdgv.ShowID;
            CenterDgv.Columns["SaleID"].Visible = cdgv.ShowSaleID;
            CenterDgv.Columns["InvoiceAmount"].Visible = cdgv.ShowInvoiceAmount;
            CenterDgv.Columns["InvoiceDate"].Visible = cdgv.ShowDate;
            CenterDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {

            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = saleID,
                CustomerInvoiceInvoiceDateFrom = invoiceDateFrom,
                CustomerInvoiceInvoiceDateTo = invoiceDateTo,
                CustomerInvoiceStatus = status,
                CustomerInvoicePage = PaginationUserControl.CurrentPage,
                CustomerInvoiceInvoiceAmountFrom = invoiceAmountFrom,
                CustomerInvoiceInvoiceAmountTo = invoiceAmountTo
            };

            IEnumerable<CustomerInvoice> query = await _customerService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        public virtual void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateCustomerInvoiceCostForm csif)
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString());
            }

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

            panel5.Location = new Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }
        }

        private void RightClickDhvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CenterDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CenterDgv, e.Location);
                }
            }
        }
        private async void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerInvoiceIDTsmi":
                        CenterDgv.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceSaleIDTsmi":
                        CenterDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceInvoiceAmountTsmi":
                        CenterDgv.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceDateTsmi":
                        CenterDgv.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceStatusTsmi":
                        CenterDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerInvoiceDGV cdgv = new CustomerInvoiceDGV
                {
                    ShowDate = CustomerInvoiceDateTsmi.Checked,
                    ShowID = CustomerInvoiceIDTsmi.Checked,
                    ShowInvoiceAmount = CustomerInvoiceInvoiceAmountTsmi.Checked,
                    ShowSaleID = CustomerInvoiceSaleIDTsmi.Checked,
                    ShowStatus = CustomerInvoiceStatusTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceDGV(cdgv);
            }
        }
    }
}
