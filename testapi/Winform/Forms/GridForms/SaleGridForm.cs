using API.Models.Filters;
using Winform.Entities.DTO;
using Winform.Entities.Preference;
using Winform.Forms.AddForms;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SaleGridForm : Form
    {

        string bkNumber;
        string blNumber;
        DateTime? saleDateFrom;
        DateTime? saleDateTo;
        int? revenueFrom;
        int? revenueTo;
        string customerID;
        string status;
        int pages;
        double itemsPage = 10.0;
        private SaleService _saleService;
        private Form _father;
        List<string> authRoles = new List<string>
            {
                "SaleAdmin",
                "Admin"
            };
        UserService _userService;
        public SaleGridForm()
        {
            _userService = new UserService();
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
            SaleDgv.ContextMenuStrip = RightClickDgv;
            if (!Authorize(authRoles))
            {
                SaleCustomerIDTsmi.Visible = false;
                SaleIDTsmi.Visible = false;

            }
        }


        public SaleGridForm(CreateSupplierInvoicesForm father)
        {

            _userService = new UserService();

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

            if (!Authorize(authRoles))
            {
                SaleCustomerIDTsmi.Visible = false;
                SaleIDTsmi.Visible = false;

            }
        }
        public SaleGridForm(CreateCustomerInvoiceForm father)
        {
            _userService = new UserService();

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

            if (!Authorize(authRoles))
            {
                SaleCustomerIDTsmi.Visible = false;
                SaleIDTsmi.Visible = false;

            }
        }
        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
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
                SaleBookingNumber = BNTextBox.Text,
                SaleBoLnumber = BoLTextBox.Text,
                SaleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null,
                SaleDateTo = DateToDTP.Checked ? DateToDTP.Value : null,
                SaleRevenueFrom = string.IsNullOrEmpty(RevenueFromTxt.GetText()) ? null : int.Parse(RevenueFromTxt.GetText()),
                SaleRevenueTo = string.IsNullOrEmpty(RevenueToTxt.GetText()) ? null : int.Parse(RevenueToTxt.GetText()),
                SaleCustomerId = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : int.Parse(CustomerIDTextBoxUserControl.GetText()),
                SaleStatus = StatusCB.Text == "All" ? null : StatusCB.Text,
                SalePage = PaginationUserControl.CurrentPage

            };
            SaleFilter filterPage = new SaleFilter
            {
                SaleBookingNumber = BNTextBox.Text,
                SaleBoLnumber = BoLTextBox.Text,
                SaleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null,
                SaleDateTo = DateToDTP.Checked ? DateToDTP.Value : null,
                SaleRevenueFrom = string.IsNullOrEmpty(RevenueFromTxt.GetText()) ? null : int.Parse(RevenueFromTxt.GetText()),
                SaleRevenueTo = string.IsNullOrEmpty(RevenueToTxt.GetText()) ? null : int.Parse(RevenueToTxt.GetText()),
                SaleCustomerId = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : int.Parse(CustomerIDTextBoxUserControl.GetText()),
                SaleStatus = StatusCB.Text == "All" ? null : StatusCB.Text
            };

            bkNumber = BNTextBox.Text;
            blNumber = BoLTextBox.Text;
            saleDateFrom = DateFromDTP.Checked ? DateFromDTP.Value : null;
            saleDateTo = DateToDTP.Checked ? DateToDTP.Value : null;
            customerID = string.IsNullOrEmpty(CustomerIDTextBoxUserControl.GetText()) ? null : CustomerIDTextBoxUserControl.GetText();
            revenueFrom = string.IsNullOrEmpty(RevenueFromTxt.GetText()) ? null : int.Parse(RevenueFromTxt.GetText());
            revenueTo = string.IsNullOrEmpty(RevenueToTxt.GetText()) ? null : int.Parse(RevenueToTxt.GetText());
            status = StatusCB.Text == "All" ? null : StatusCB.Text;


            IEnumerable<SaleCustomerDTO> query = _saleService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_saleService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SaleDgv.DataSource = query.ToList();
            if (!PaginationUserControl.Visible)
            {
                SetCheckBoxes();
            }
        }

        private void SetCheckBoxes()
        {
            SaleDGV cdgv = _userService.GetSaleDGV();

            SaleIDTsmi.Checked = cdgv.ShowID;
            SaleBkNumberTsmi.Checked = cdgv.ShowBKNumber;
            SaleCustomerCountryTsmi.Checked = cdgv.ShowCustomerCountry;
            SaleCustomerNameTsmi.Checked = cdgv.ShowCustomerName;
            SaleBoLNumberTsmi.Checked = cdgv.ShowBoL;
            SaleCustomerIDTsmi.Checked= cdgv.ShowCustomerID;
            SaleTotalRevenueTsmi.Checked = cdgv.ShowTotalRevenue;
            SaleStatusTsmi.Checked = cdgv.ShowStatus;
            SaleDateTsmi.Checked = cdgv.ShowDate;

            SaleDgv.Columns["SaleID"].Visible = cdgv.ShowID;
            SaleDgv.Columns["BookingNumber"].Visible = cdgv.ShowBKNumber;
            SaleDgv.Columns["Country"].Visible = cdgv.ShowCustomerCountry;
            SaleDgv.Columns["CustomerName"].Visible = cdgv.ShowCustomerName;
            SaleDgv.Columns["BoLNumber"].Visible = cdgv.ShowBoL;
            SaleDgv.Columns["CustomerID"].Visible = cdgv.ShowCustomerID;
            SaleDgv.Columns["TotalRevenue"].Visible = cdgv.ShowTotalRevenue;
            SaleDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            SaleDgv.Columns["SaleDate"].Visible = cdgv.ShowDate;

            PaginationUserControl.Visible = true;
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            int outVal;
            SaleFilter filter = new SaleFilter
            {
                SaleBookingNumber = bkNumber,
                SaleBoLnumber = blNumber,
                SaleDateFrom = saleDateFrom,
                SaleDateTo = saleDateTo,
                SaleCustomerId = int.TryParse(customerID, out outVal) ? outVal : null,
                SaleRevenueFrom = revenueFrom,
                SaleRevenueTo = revenueTo,
                SaleStatus = status,
                SalePage = PaginationUserControl.CurrentPage

            };

            IEnumerable<SaleCustomerDTO> query = _saleService.GetAll(filter);
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
            if (sender is DataGridView dgv)
            {
                if (_father is CreateSupplierInvoicesForm csif)
                    csif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
                if (_father is CreateCustomerInvoiceForm ccif)
                    ccif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
            }
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
            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }
        }
        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                RightClickDgv.Show(SaleDgv, SaleDgv.PointToClient(Cursor.Position));
        }
        private void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "SaleIDTsmi":
                        SaleDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "SaleBkNumberTsmi":
                        SaleDgv.Columns["BookingNumber"].Visible = tsmi.Checked;
                        break;
                    case "SaleCustomerCountryTsmi":
                        SaleDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "SaleCustomerNameTsmi":
                        SaleDgv.Columns["CustomerName"].Visible = tsmi.Checked;
                        break;
                    case "SaleBoLNumberTsmi":
                        SaleDgv.Columns["BoLNumber"].Visible = tsmi.Checked;
                        break;
                    case "SaleCustomerIDTsmi":
                        SaleDgv.Columns["CustomerID"].Visible = tsmi.Checked;
                        break;
                    case "SaleTotalRevenueTsmi":
                        SaleDgv.Columns["TotalRevenue"].Visible = tsmi.Checked;
                        break;
                    case "SaleStatusTsmi":
                        SaleDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    case "SaleDateTsmi":
                        SaleDgv.Columns["SaleDate"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                SaleDGV cdgv = new SaleDGV
                {
                    ShowID=SaleIDTsmi.Checked,
                    ShowDate=SaleDateTsmi.Checked,
                    ShowStatus=SaleStatusTsmi.Checked,
                    ShowTotalRevenue=SaleTotalRevenueTsmi.Checked,
                    ShowCustomerID=SaleCustomerIDTsmi.Checked,
                    ShowBoL=SaleBoLNumberTsmi.Checked,
                    ShowBKNumber=SaleBkNumberTsmi.Checked,
                    ShowCustomerCountry=SaleCustomerCountryTsmi.Checked,
                    ShowCustomerName=SaleCustomerNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                _userService.PostSaleDGV(cdgv);
            }
        }
    }
}


