using API.Models.Filters;
using Winform.Entities.DTO;
using Winform.Forms.AddForms;
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
        Form _father;

        readonly SupplierInvoiceService _supplierInvoiceService;
        int pages;
        double itemsPage = 10.0;

        List<string> authRoles = new List<string>
            {
                "SupplierInvoiceAdmin",
                "Admin"
            };
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
            SupplierInvoiceDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
            {
                SupplierInvoiceIDTsmi.Visible = false;
                SupplierInvoiceSupplierIDTsmi.Visible = false;
            }
        }
        public SupplierInvoiceGridForm(Form father)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            pages = (int)Math.Ceiling(_supplierInvoiceService.Count(new SupplierInvoiceFilter()) / itemsPage);

            _father = father;
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
            SupplierInvoiceDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
            {
                SupplierInvoiceIDTsmi.Visible = false;
                SupplierInvoiceSupplierIDTsmi.Visible = false;
            }
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
            SupplierInvoiceDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
            {
                SupplierInvoiceIDTsmi.Visible = false;
                SupplierInvoiceSupplierIDTsmi.Visible = false;
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

        public virtual void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            /*if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;
                SupplierInvoiceDetailsForm sid = new SupplierInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells["InvoiceId"].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }*/
            if (sender is DataGridView dgv)
            {
                if (_father is CreateSupplierInvoiceCostForm sigf)
                    sigf.SetSupplierID(dgv.CurrentRow.Cells["InvoiceID"].Value.ToString());
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
            InvoiceAmountFrom = !string.IsNullOrEmpty(InvoiceAmountFromTxt.GetText()) ? int.Parse(InvoiceAmountFromTxt.GetText()) : null;
            InvoiceAmountTo = !string.IsNullOrEmpty(InvoiceAmountToTxt.GetText()) ? int.Parse(InvoiceAmountToTxt.GetText()) : null;
            InvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            InvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null;
            Status = StatusCmb.Text;

            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
                SupplierInvoicePage = PaginationUserControl.CurrentPage
            };
            SupplierInvoiceFilter filterPage = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
            };


            IEnumerable<SupplierInvoiceSupplierDTO> query = _supplierInvoiceService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_supplierInvoiceService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierInvoiceDgv.DataSource = query.ToList();
            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true;
                SupplierInvoiceDgv.Columns["InvoiceID"].Visible = false;
                SupplierInvoiceDgv.Columns["SupplierID"].Visible = false;

            }
        }

        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
                SupplierInvoicePage = PaginationUserControl.CurrentPage
            };

            IEnumerable<SupplierInvoiceSupplierDTO> query = _supplierInvoiceService.GetAll(filter);
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


            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }
        }

        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var test = SupplierInvoiceDgv.HitTest(e.X, e.Y);
                if (test.RowIndex >= 0)
                {
                    RightClickDgv.Show(SupplierInvoiceDgv, e.Location);
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
                    case "SupplierInvoiceIDTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSaleIDTsmi":
                        SupplierInvoiceDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceInvoiceAmountTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceDateTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceStatusTsmi":
                        SupplierInvoiceDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierNameTsmi":
                        SupplierInvoiceDgv.Columns["SupplierName"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCountryTsmi":
                        SupplierInvoiceDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierIDTsmi":
                        SupplierInvoiceDgv.Columns["SupplierID"].Visible = tsmi.Checked;
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
