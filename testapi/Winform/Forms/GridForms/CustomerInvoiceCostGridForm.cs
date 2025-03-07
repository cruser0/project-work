using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Services;

namespace Winform.Forms.GridForms
{
    public partial class CustomerInvoiceCostGridForm : Form
    {
        int? invoiceId;
        int? costFrom;
        int? costTo;
        string? name;
        CustomerInvoiceCostService _customerInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        UserService _userService;
        Task<ICollection<CustomerInvoiceCost>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerInvoiceCostDGV> getFav;
        public CustomerInvoiceCostGridForm()
        {
            Init();

        }

        private async void Init()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            InitializeComponent();
            _userService = new UserService();

            pages = (int)Math.Ceiling(await _customerInvoiceCostService.Count(new CustomerInvoiceCostFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerInvoiceCostDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!UtilityFunctions.IsAuthorized(new[] { "CustomerInvoiceCostAdmin", "Admin" }))
                CustomerInvoiceCostIDTsmi.Visible = false;
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
            CustomerInvoiceCostFilter filter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostCustomerInvoiceId = invoiceId,
                CustomerInvoiceCostCostFrom = costFrom,
                CustomerInvoiceCostCostTo = costTo,
                CustomerInvoiceCostPage = PaginationUserControl.CurrentPage,
                CustomerInvoiceCostName = NameTxt.Text,
            };
            CustomerInvoiceCostFilter filterPage = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostCustomerInvoiceId = invoiceId,
                CustomerInvoiceCostCostFrom = costFrom,
                CustomerInvoiceCostCostTo = costTo,
                CustomerInvoiceCostName = NameTxt.Text,
            };

            var getAllTask = _customerInvoiceCostService.GetAll(filter);
            var countTask = _customerInvoiceCostService.Count(filterPage);

            await Task.WhenAll(getAllTask, countTask);



            IEnumerable<CustomerInvoiceCost> query = await getAllTask;
            int totalCount = await countTask;

            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl($"{PaginationUserControl.CurrentPage}/{PaginationUserControl.GetmaxPage()}");

            CustomerInvoiceCostDgv.DataSource = query.ToList();

        }
        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<CustomerInvoiceCost> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerInvoiceCostDgv.DataSource = query.ToList();
            CustomerInvoiceCostDGV cdgv = await getFav;

            CustomerInvoiceCostCostTsmi.Checked = cdgv.ShowCost;
            CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked = cdgv.ShowInvoiceID;
            CustomerInvoiceCostIDTsmi.Checked = cdgv.ShowID;
            CustomerInvoiceCostNameTsmi.Checked = cdgv.ShowName;
            CustomerInvoiceCostQuantityTsmi.Checked = cdgv.ShowQuantity;
            CustomerInvoiceCostDgv.Columns["CustomerInvoiceCostsID"].Visible = cdgv.ShowID;
            CustomerInvoiceCostDgv.Columns["CustomerInvoiceID"].Visible = cdgv.ShowInvoiceID;
            CustomerInvoiceCostDgv.Columns["Cost"].Visible = cdgv.ShowCost;
            CustomerInvoiceCostDgv.Columns["Quantity"].Visible = cdgv.ShowQuantity;
            CustomerInvoiceCostDgv.Columns["Name"].Visible = cdgv.ShowName;
            PaginationUserControl.Visible = true;

        }

        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            CustomerInvoiceCostFilter filter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostCustomerInvoiceId = invoiceId,
                CustomerInvoiceCostCostFrom = costFrom,
                CustomerInvoiceCostCostTo = costTo,
                CustomerInvoiceCostPage = PaginationUserControl.CurrentPage,
                CustomerInvoiceCostName = NameTxt.Text,
            };

            IEnumerable<CustomerInvoiceCost> query = await _customerInvoiceCostService.GetAll(filter);
            CustomerInvoiceCostDgv.DataSource = query.ToList();
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

        private void CustomerDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CustomerInvoiceCostDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CustomerInvoiceCostDgv, e.Location);
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
                    case "CustomerInvoiceCostIDTsmi":
                        CustomerInvoiceCostDgv.Columns["CustomerInvoiceCostsID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCustomerInvoiceIDTsmi":
                        CustomerInvoiceCostDgv.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCostTsmi":
                        CustomerInvoiceCostDgv.Columns["Cost"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostQuantityTsmi":
                        CustomerInvoiceCostDgv.Columns["Quantity"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostNameTsmi":
                        CustomerInvoiceCostDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerInvoiceCostDGV cdgv = new CustomerInvoiceCostDGV
                {
                    ShowCost = CustomerInvoiceCostCostTsmi.Checked,
                    ShowQuantity = CustomerInvoiceCostQuantityTsmi.Checked,
                    ShowName = CustomerInvoiceCostNameTsmi.Checked,
                    ShowID = CustomerInvoiceCostIDTsmi.Checked,
                    ShowInvoiceID = CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceCostDGV(cdgv);

            }
        }

        private async void CustomerInvoiceCostGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter());
            countNotFiltered = _customerInvoiceCostService.Count(new CustomerInvoiceCostFilter());
            getFav = _userService.GetCustomerInvoiceCostDGV();
            await SetCheckBoxes();
        }
    }
}
