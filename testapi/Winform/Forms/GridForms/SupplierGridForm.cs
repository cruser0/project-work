﻿using API.Models.Filters;
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
        Task<ICollection<Supplier>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<SupplierDGV> getFav;
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
            name = NameSupplierTxt.Text;
            country = CountrySupplierTxt.Text;
            status = comboBox1.SelectedIndex;
            dateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            dateTo = DateToClnd.Checked ? DateToClnd.Value : null;

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
            SupplierFilter filterPage = new SupplierFilter
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
                SupplierCreatedDateTo = dateTo
            };



            var query = _supplierService.GetAll(filter);
            var count = _supplierService.Count(filterPage);


            await Task.WhenAll(query, count);

            IEnumerable<Supplier> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<Supplier> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierDgv.DataSource = query.ToList();
            SupplierDGV cdgv = await getFav;
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

        private async void SupplierGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _supplierService.GetAll(new SupplierFilter() { SupplierPage = 1 });
            countNotFiltered = _supplierService.Count(new SupplierFilter());
            getFav = _userService.GetSupplierDGV();
            await SetCheckBoxes();

        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Supplier!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in SupplierDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (SupplierDgv.Rows[rowid].DataBoundItem is Supplier customer)
                            id.Add(customer.SupplierId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _supplierService.MassDelete(id);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No Row was selected");
                    }
                    MyControl_ButtonClicked(sender, e);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }
        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Pdf_ClickBtn(SupplierDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(SupplierDgv, this);
        }
    }
}
