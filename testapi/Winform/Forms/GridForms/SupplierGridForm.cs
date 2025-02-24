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
            SupplierDgv.ContextMenuStrip = RightClickDgv;
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
            SupplierDgv.ContextMenuStrip = RightClickDgv;
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
                SupplierDgv.Columns["SupplierID"].Visible = false;
                SupplierDgv.Columns["OriginalID"].Visible = false;
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

        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = SupplierDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(SupplierDgv, e.Location);
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
                    case "SupplierIDTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["SupplierID"].Visible = true;
                        else
                            SupplierDgv.Columns["SupplierID"].Visible = false;
                        break;
                    case "SupplierNameTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["SupplierName"].Visible = true;
                        else
                            SupplierDgv.Columns["SupplierName"].Visible = false;
                        break;
                    case "SupplierCountryTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["Country"].Visible = true;
                        else
                            SupplierDgv.Columns["Country"].Visible = false;
                        break;
                    case "SupplierDateTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["CreatedAt"].Visible = true;
                        else
                            SupplierDgv.Columns["CreatedAt"].Visible = false;
                        break;
                    case "SupplierOriginalIDTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["OriginalID"].Visible = true;
                        else
                            SupplierDgv.Columns["OriginalID"].Visible = false;
                        break;
                    case "SupplierStatusTsmi":
                        if (tsmi.Checked)
                            SupplierDgv.Columns["Deprecated"].Visible = true;
                        else
                            SupplierDgv.Columns["Deprecated"].Visible = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
