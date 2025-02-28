using API.Models.Filters;
using Winform.Entities;
using Winform.Forms.AddForms;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class CustomerInvoiceGridForm : Form
    {
        string? saleID;
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
        public CustomerInvoiceGridForm()
        {

            _customerService = new CustomerInvoiceService();
            pages = (int)Math.Ceiling(_customerService.Count(new CustomerInvoiceFilter()) / itemsPage);

            InitializeComponent();
            PaginationUserControl.CurrentPage = 1;
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

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
        public CustomerInvoiceGridForm(CreateCustomerInvoiceCostForm father)
        {
            _father = father;
            _customerService = new CustomerInvoiceService();
            pages = (int)Math.Ceiling(_customerService.Count(new CustomerInvoiceFilter()) / itemsPage);

            InitializeComponent();
            PaginationUserControl.CurrentPage = 1;
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

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

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void RightSideBar_searchBtnEvent(object? sender, EventArgs e)
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

            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                CustomerInvoiceInvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                CustomerInvoiceInvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                CustomerInvoiceStatus = StatusCmb.Text,
                CustomerInvoicePage = PaginationUserControl.CurrentPage,
                CustomerInvoiceInvoiceAmountFrom = !string.IsNullOrEmpty(AmountFromTxt.GetText()) ? int.Parse(AmountFromTxt.GetText()) : null,
                CustomerInvoiceInvoiceAmountTo = !string.IsNullOrEmpty(AmountToTxt.GetText()) ? int.Parse(AmountToTxt.GetText()) : null

            };
            CustomerInvoiceFilter filterPage = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                CustomerInvoiceInvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                CustomerInvoiceInvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                CustomerInvoiceStatus = StatusCmb.Text,
                CustomerInvoiceInvoiceAmountFrom = !string.IsNullOrEmpty(AmountFromTxt.GetText()) ? int.Parse(AmountFromTxt.GetText()) : null,
                CustomerInvoiceInvoiceAmountTo = !string.IsNullOrEmpty(AmountToTxt.GetText()) ? int.Parse(AmountToTxt.GetText()) : null
            };
            saleID = SaleIDTxt.GetText();
            invoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            invoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null;
            status = StatusCmb.Text;
            invoiceAmountFrom = !string.IsNullOrEmpty(AmountFromTxt.GetText()) ? int.Parse(AmountFromTxt.GetText()) : null;
            invoiceAmountTo = !string.IsNullOrEmpty(AmountToTxt.GetText()) ? int.Parse(AmountToTxt.GetText()) : null;

            IEnumerable<CustomerInvoice> query = _customerService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_customerService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CenterDgv.DataSource = query.ToList();

            if (!PaginationUserControl.Visible)
            {
                CenterDgv.Columns["CustomerInvoiceID"].Visible = false;
                PaginationUserControl.Visible = true;
            }
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            int idNum;
            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = int.TryParse(saleID, out idNum) ? idNum : null,
                CustomerInvoiceInvoiceDateFrom = invoiceDateFrom,
                CustomerInvoiceInvoiceDateTo = invoiceDateTo,
                CustomerInvoiceStatus = status,
                CustomerInvoicePage = PaginationUserControl.CurrentPage,
                CustomerInvoiceInvoiceAmountFrom = invoiceAmountFrom,
                CustomerInvoiceInvoiceAmountTo = invoiceAmountTo
            };

            IEnumerable<CustomerInvoice> query = _customerService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        public virtual void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateCustomerInvoiceCostForm csif)
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
            }
        
            /*if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                CustomerInvoiceDetailsForm sid = new CustomerInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }*/
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
        private void ContextMenuStripCheckEvent(object sender, EventArgs e)
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

            }
        }
    }
}
