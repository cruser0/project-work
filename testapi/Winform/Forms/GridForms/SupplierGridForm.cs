using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierGridForm : Form
    {
        string name;
        string country;
        int status;
        int pages;
        DateTime? dateFrom;
        DateTime? dateTo;
        double itemsPage = 10.0;
        private SupplierService _supplierService;
        private CreateSupplierInvoicesForm _father;
        List<string> authRoles = new List<string>
            {
                "SupplierAdmin",
                "Admin"
            };
        UserService _userService;
        public SupplierGridForm()
        {
            Init();
        }
        public SupplierGridForm(CreateSupplierInvoicesForm father)
        {
            _father = father;
            Init();
        }

        private async void Init()
        {
            _supplierService = new SupplierService();
            _userService = new UserService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _supplierService.Count(new SupplierFilter()) / itemsPage);

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

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
            if (!Authorize(authRoles))
                SupplierIDTsmi.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }



        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            SupplierFilter filter = new SupplierFilter
            {
                SupplierName = NameSupplierTxt.Text,
                SupplierCountry = CountrySupplierTxt.Text,
                SupplierDeprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                SupplierCreatedDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                SupplierCreatedDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                SupplierPage = PaginationUserControl.CurrentPage

            };
            SupplierFilter filterPage = new SupplierFilter
            {
                SupplierName = NameSupplierTxt.Text,
                SupplierCountry = CountrySupplierTxt.Text,
                SupplierDeprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                SupplierCreatedDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                SupplierCreatedDateTo = DateToClnd.Checked ? DateToClnd.Value : null,

            };
            name = NameSupplierTxt.Text;
            country = CountrySupplierTxt.Text;
            status = comboBox1.SelectedIndex;
            dateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            dateTo = DateToClnd.Checked ? DateToClnd.Value : null;
            IEnumerable<Supplier> query = await _supplierService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await _supplierService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            SupplierDgv.DataSource = query.ToList();


            if (!PaginationUserControl.Visible)
            {
                SetCheckBoxes();
            }
        }

        private async void SetCheckBoxes()
        {
            SupplierDGV cdgv = await _userService.GetSupplierDGV();
            SupplierCountryTsmi.Checked = cdgv.ShowCountry;
            SupplierDateTsmi.Checked = cdgv.ShowDate;
            SupplierIDTsmi.Checked = cdgv.ShowID;
            SupplierStatusTsmi.Checked = cdgv.ShowStatus;
            SupplierOriginalIDTsmi.Checked = cdgv.ShowOriginalID;
            SupplierNameTsmi.Checked = cdgv.ShowName;
            SupplierDgv.Columns["SupplierName"].Visible = cdgv.ShowName;
            SupplierDgv.Columns["Country"].Visible = cdgv.ShowCountry;
            SupplierDgv.Columns["CreatedAt"].Visible = cdgv.ShowDate;
            SupplierDgv.Columns["OriginalID"].Visible = cdgv.ShowOriginalID;
            SupplierDgv.Columns["Deprecated"].Visible = cdgv.ShowStatus;
            SupplierDgv.Columns["SupplierID"].Visible = SupplierIDTsmi.Checked;
            PaginationUserControl.Visible = true;
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierFilter filter = new SupplierFilter
            {
                SupplierName = name,
                SupplierCountry = country,
                SupplierDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                SupplierCreatedDateFrom = dateFrom,
                SupplierCreatedDateTo = dateTo,
                SupplierPage = PaginationUserControl.CurrentPage
            };

            IEnumerable<Supplier> query = await _supplierService.GetAll(filter);
            SupplierDgv.DataSource = query.ToList();
        }

        public virtual void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
                _father.SetSupplierID(dgv.CurrentRow.Cells["SupplierID"].Value.ToString());
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

        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = SupplierDgv.HitTest(e.X, e.Y);
                MessageBox.Show($"{e.X}, {e.Y}");
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(SupplierDgv, e.Location);
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
                    case "SupplierIDTsmi":
                        SupplierDgv.Columns["SupplierID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierNameTsmi":
                        SupplierDgv.Columns["SupplierName"].Visible = tsmi.Checked;
                        break;
                    case "SupplierCountryTsmi":
                        SupplierDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "SupplierDateTsmi":
                        SupplierDgv.Columns["CreatedAt"].Visible = tsmi.Checked;
                        break;
                    case "SupplierOriginalIDTsmi":
                        SupplierDgv.Columns["OriginalID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierStatusTsmi":
                        SupplierDgv.Columns["Deprecated"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                SupplierDGV cdgv = new SupplierDGV
                {
                    ShowDate = SupplierDateTsmi.Checked,
                    ShowID = SupplierIDTsmi.Checked,
                    ShowStatus = SupplierStatusTsmi.Checked,
                    ShowOriginalID = SupplierOriginalIDTsmi.Checked,
                    ShowCountry = SupplierCountryTsmi.Checked,
                    ShowName = SupplierNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSupplierDGV(cdgv);

            }
        }
    }
}
