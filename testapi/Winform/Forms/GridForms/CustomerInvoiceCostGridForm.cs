using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.GridForms
{
    public partial class CustomerInvoiceCostGridForm : Form
    {
        int? invoiceId;
        int? costFrom;
        int? costTo;
        string? name;
        readonly CustomerInvoiceCostService _customerInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        public CustomerInvoiceCostGridForm()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            pages = (int)Math.Ceiling(_customerInvoiceCostService.Count(new CustomerInvoiceCostFilter()) / itemsPage);


            InitializeComponent();
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerInvoiceCostDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }


        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            invoiceId = !string.IsNullOrEmpty(InvoiceIDTxt.GetText()) ? int.Parse(InvoiceIDTxt.GetText()) : null;
            costFrom = !string.IsNullOrEmpty(CostFromTxt.GetText()) ? int.Parse(CostFromTxt.GetText()) : null;
            costTo = !string.IsNullOrEmpty(CostToTxt.GetText()) ? int.Parse(CostToTxt.GetText()) : null;
            name = !string.IsNullOrEmpty(NameTxt.Text) ? NameTxt.Text : null;
            CustomerInvoiceCostFilter filter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                page = PaginationUserControl.CurrentPage,
                Name = NameTxt.Text,
            };
            CustomerInvoiceCostFilter filterPage = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                Name = NameTxt.Text,
            };
            IEnumerable<CustomerInvoiceCost> query = _customerInvoiceCostService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_customerInvoiceCostService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CustomerInvoiceCostDgv.DataSource = query.ToList();
            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true;
                CustomerInvoiceCostDgv.Columns["CustomerInvoiceCostsID"].Visible = false;
            }

        }

        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            CustomerInvoiceCostFilter filter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                page = PaginationUserControl.CurrentPage,
                Name = NameTxt.Text,
            };

            IEnumerable<CustomerInvoiceCost> query = _customerInvoiceCostService.GetAll(filter);
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

            BottomPanel.Location = new Point((Width - BottomPanel.Width) / 2, 0);
            PaginationUserControl.Location = new Point((BottomPanel.Width - PaginationUserControl.Width) / 2, (BottomPanel.Height - PaginationUserControl.Height) / 2);
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
        private void ContextMenuStripCheckEvent(object sender, EventArgs e)
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

            }
        }
    }
}
