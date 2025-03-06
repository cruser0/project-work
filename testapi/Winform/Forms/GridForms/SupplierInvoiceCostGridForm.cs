using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class SupplierInvoiceCostGridForm : Form
    {

        int? invoiceId;
        int? costFrom;
        int? costTo;
        string? name;
        SupplierInvoiceCostService _supplierInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        List<string> authRoles = new List<string>
            {
                "SupplierInvoiceCostAdmin",
                "Admin"
            };
        UserService _userService;
        public SupplierInvoiceCostGridForm()
        {
            Init();
        }

        private async void Init()
        {
            _userService = new UserService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _supplierInvoiceCostService.Count(new SupplierInvoiceCostFilter()) / itemsPage);


            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceCostDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
                SupplierInvoiceCostIDTsmi.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }




        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            invoiceId = !string.IsNullOrEmpty(InvoiceIDTxt.GetText()) ? int.Parse(InvoiceIDTxt.GetText()) : null;
            costFrom = !string.IsNullOrEmpty(CostFromTxt.GetText()) ? int.Parse(CostFromTxt.GetText()) : null;
            costTo = !string.IsNullOrEmpty(CostToTxt.GetText()) ? int.Parse(CostToTxt.GetText()) : null;
            name = !string.IsNullOrEmpty(NameTxt.Text) ? NameTxt.Text : null;
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostPage = PaginationUserControl.CurrentPage,
                SupplierInvoiceCostName = NameTxt.Text,
            };
            SupplierInvoiceCostFilter filterPage = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostName = NameTxt.Text,
            };
            IEnumerable<SupplierInvoiceCost> query = await _supplierInvoiceCostService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await _supplierInvoiceCostService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierInvoiceCostDgv.DataSource = query.ToList();
            if (!PaginationUserControl.Visible)
            {
                SetCheckBoxes();
            }

        }
        private void SetCheckBoxes()
        {
            SupplierInvoiceCostDGV cdgv = _userService.GetSupplierInvoiceCostDGV();
            SupplierInvoiceCostCostTsmi.Checked = cdgv.ShowCost;
            SupplierInvoiceCostSupplierInvoiceIDTsmi.Checked = cdgv.ShowSupplierInvoiceID;
            SupplierInvoiceCostIDTsmi.Checked = cdgv.ShowID;
            SupplierInvoiceCostNameTsmi.Checked = cdgv.ShowName;
            SupplierInvoiceCostQuantityTsmi.Checked = cdgv.ShowQuantity;
            SupplierInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = cdgv.ShowID;
            SupplierInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = cdgv.ShowSupplierInvoiceID;
            SupplierInvoiceCostDgv.Columns["Cost"].Visible = cdgv.ShowCost;
            SupplierInvoiceCostDgv.Columns["Quantity"].Visible = cdgv.ShowQuantity;
            SupplierInvoiceCostDgv.Columns["Name"].Visible = cdgv.ShowName;
            PaginationUserControl.Visible = true;

        }

        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostPage = PaginationUserControl.CurrentPage,
                SupplierInvoiceCostName = NameTxt.Text,
            };

            IEnumerable<SupplierInvoiceCost> query = await _supplierInvoiceCostService.GetAll(filter);
            SupplierInvoiceCostDgv.DataSource = query.ToList();
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

            PaginationPanel.Location = new Point((Width - PaginationPanel.Width) / 2, 0);
            PaginationUserControl.Location = new Point((PaginationPanel.Width - PaginationUserControl.Width) / 2, (PaginationPanel.Height - PaginationUserControl.Height) / 2);

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
                var test = SupplierInvoiceCostDgv.HitTest(e.X, e.Y);
                if (test.RowIndex >= 0)
                {
                    RightClickDgv.Show(RightClickDgv, e.Location);
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
                    case "SupplierInvoiceCostIDTsmi":
                        SupplierInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostSupplierInvoiceIDTsmi":
                        SupplierInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostCostTsmi":
                        SupplierInvoiceCostDgv.Columns["Cost"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostQuantityTsmi":
                        SupplierInvoiceCostDgv.Columns["Quantity"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostNameTsmi":
                        SupplierInvoiceCostDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                SupplierInvoiceCostDGV cdgv = new SupplierInvoiceCostDGV
                {
                    ShowCost = SupplierInvoiceCostCostTsmi.Checked,
                    ShowQuantity = SupplierInvoiceCostQuantityTsmi.Checked,
                    ShowName = SupplierInvoiceCostNameTsmi.Checked,
                    ShowID = SupplierInvoiceCostIDTsmi.Checked,
                    ShowSupplierInvoiceID = SupplierInvoiceCostSupplierInvoiceIDTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                _userService.PostSupplierInvoiceCostDGV(cdgv);

            }
        }
    }
}
