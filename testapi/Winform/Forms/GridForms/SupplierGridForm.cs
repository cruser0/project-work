using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierGridForm : Form
    {
        string name;
        string country;
        int status;
        int pages;
        double itemsPage = 10.0;
        private SupplierService _supplierService;
        private CreateSupplierInvoicesForm _father;
        public SupplierGridForm()
        {
            _supplierService = new SupplierService();

            InitializeComponent();
            pages = (int)Math.Ceiling(_supplierService.Count(new SupplierFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            comboBox1.SelectedIndex = 1;

            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        }
        public SupplierGridForm(CreateSupplierInvoicesForm father)
        {
            _father = father;
            _supplierService = new SupplierService();
            InitializeComponent();
            pages = (int)Math.Ceiling(_supplierService.Count(new SupplierFilter()) / itemsPage);

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            comboBox1.SelectedIndex = 1;

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
            SupplierFilter filter = new SupplierFilter
            {
                Name = NameSupplierTxt.Text,
                Country = CountrySupplierTxt.Text,
                Deprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                page = PaginationUserControl.CurrentPage
                //OriginalID
                //CreatedOn
            };
            SupplierFilter filterPage = new SupplierFilter
            {
                Name = NameSupplierTxt.Text,
                Country = CountrySupplierTxt.Text,
                Deprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                //OriginalID
                //CreatedOn
            };
            name = NameSupplierTxt.Text;
            country = CountrySupplierTxt.Text;
            status = comboBox1.SelectedIndex;
            //OriginalID
            //CreatedOn
            IEnumerable<Supplier> query = _supplierService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_supplierService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierDgv.DataSource = query.ToList();


            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true;
            }
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierFilter filter = new SupplierFilter
            {
                Name = name,
                Country = country,
                Deprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                page = PaginationUserControl.CurrentPage
            };

            IEnumerable<Supplier> query = _supplierService.GetAll(filter);
            SupplierDgv.DataSource = query.ToList();
        }

        private void baseGridComponent_Load(object sender, EventArgs e)
        {

        }

        public virtual void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
                _father.SetSupplierID(dgv.CurrentRow.Cells[0].Value.ToString());
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

        }
    }
}
