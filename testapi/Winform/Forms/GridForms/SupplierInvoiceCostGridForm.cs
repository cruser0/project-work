using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class SupplierInvoiceCostGridForm : Form
    {

        int? invoiceId;
        int? costFrom;
        int? costTo;
        string? name;
        readonly SupplierInvoiceCostService _supplierInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        public SupplierInvoiceCostGridForm()
        {
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            pages = (int)Math.Ceiling(_supplierInvoiceCostService.Count(new SupplierInvoiceCostFilter()) / itemsPage);


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
                SupplierInvoiceCostDetailsForm sid = new SupplierInvoiceCostDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }

        private void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            invoiceId = !string.IsNullOrEmpty(InvoiceIDTxt.GetText()) ? int.Parse(InvoiceIDTxt.GetText()) : null;
            costFrom = !string.IsNullOrEmpty(CostFromTxt.GetText()) ? int.Parse(CostFromTxt.GetText()) : null;
            costTo = !string.IsNullOrEmpty(CostToTxt.GetText()) ? int.Parse(CostToTxt.GetText()) : null;
            name = !string.IsNullOrEmpty(NameTxt.Text) ? NameTxt.Text : null;
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                page = PaginationUserControl.CurrentPage,
                Name =NameTxt.Text,
            };
            SupplierInvoiceCostFilter filterPage = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                Name = NameTxt.Text,
            };
            IEnumerable<SupplierInvoiceCost> query = _supplierInvoiceCostService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_supplierInvoiceCostService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierInvoiceCostDgv.DataSource = query.ToList();

        }

        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceId = invoiceId,
                CostFrom = costFrom,
                CostTo = costTo,
                page = PaginationUserControl.CurrentPage,
                Name = NameTxt.Text,
            };

            IEnumerable<SupplierInvoiceCost> query = _supplierInvoiceCostService.GetAll(filter);
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
            BottomPanel.Location = new Point((Width - BottomPanel.Width) / 2, 0);
            PaginationUserControl.Location = new Point((BottomPanel.Width - PaginationUserControl.Width) / 2, (BottomPanel.Height - PaginationUserControl.Height) / 2);

        }
    }
}
