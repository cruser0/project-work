using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities.Preference;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class SaleGridForm : Form
    {

        SaleCustomerFilter filter = new SaleCustomerFilter() { SalePage = 1 };

        int pages;
        double itemsPage = 10.0;
        private SaleService _saleService;
        private Form _father;
        Task<ICollection<SaleCustomerDTO>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<SaleDGV> getFav;
        UserService _userService;
        public SaleGridForm()
        {
            InitializeComponent();
        }


        public SaleGridForm(CreateDetailsSupplierInvoiceForm father)
        {
            _father = father;
            InitializeComponent();
            toolStrip1.Visible = false;
        }
        public SaleGridForm(CreateDetailsCustomerInvoiceForm father)
        {
            _father = father;
            InitializeComponent();

            toolStrip1.Visible = false;
        }

        private async Task Init()
        {
            if (DesignMode)
                return;
            _userService = new UserService();
            _saleService = new SaleService();

            pages = (int)Math.Ceiling(await _saleService.Count(new SaleCustomerFilter() { SaleStatus = _father != null ? "Active" : null }) / itemsPage);


            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.PageNumberTextboxEvent += PaginationUserControl_PageNumberTextboxEvent;

            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SaleDgv.ContextMenuStrip = RightClickDgv;
            if (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "SaleAdmin", "Admin" }))
            {
                SaleCustomerIDTsmi.Visible = false;
                SaleIDTsmi.Visible = false;
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;

            filter = searchSale1.GetFilter();
            filter.SalePage = PaginationUserControl.CurrentPage;

            SaleCustomerFilter filterPage = searchSale1.GetFilter();

            var query = _saleService.GetAll(filter);
            var count = _saleService.Count(filterPage);
            await Task.WhenAll(query, count);

            PaginationUserControl.maxPage = ((int)Math.Ceiling(await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            IEnumerable<SaleCustomerDTO> query1 = await query;
            SaleDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SaleCustomerDTO> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SaleDgv.DataSource = query.ToList();
            SaleDGV cdgv = await getFav;

            SaleIDTsmi.Checked = (bool)cdgv.ShowID;
            SaleBkNumberTsmi.Checked = (bool)cdgv.ShowBKNumber;
            SaleCustomerCountryTsmi.Checked = (bool)cdgv.ShowCustomerCountry;
            SaleCustomerNameTsmi.Checked = (bool)cdgv.ShowCustomerName;
            SaleBoLNumberTsmi.Checked = (bool)cdgv.ShowBoL;
            SaleCustomerIDTsmi.Checked = (bool)cdgv.ShowCustomerID;
            SaleTotalRevenueTsmi.Checked = (bool)cdgv.ShowTotalRevenue;
            SaleStatusTsmi.Checked = (bool)cdgv.ShowStatus;
            SaleDateTsmi.Checked = (bool)cdgv.ShowDate;

            SaleDgv.Columns["IsPost"].Visible = false;


            SaleDgv.Columns["SaleID"].Visible = (bool)cdgv.ShowID;
            SaleDgv.Columns["BookingNumber"].Visible = (bool)cdgv.ShowBKNumber;
            SaleDgv.Columns["Country"].Visible = (bool)cdgv.ShowCustomerCountry;
            SaleDgv.Columns["CustomerName"].Visible = (bool)cdgv.ShowCustomerName;
            SaleDgv.Columns["BoLNumber"].Visible = (bool)cdgv.ShowBoL;
            SaleDgv.Columns["CustomerID"].Visible = (bool)cdgv.ShowCustomerID;
            SaleDgv.Columns["TotalRevenue"].Visible = (bool)cdgv.ShowTotalRevenue;
            SaleDgv.Columns["Status"].Visible = (bool)cdgv.ShowStatus;
            SaleDgv.Columns["SaleDate"].Visible = (bool)cdgv.ShowDate;

            SaleDgv.Columns["SaleID"].HeaderText = "Sale ID";
            SaleDgv.Columns["BookingNumber"].HeaderText = "Booking Number";
            SaleDgv.Columns["Country"].HeaderText = "Customer Country";
            SaleDgv.Columns["CustomerName"].HeaderText = "Customer Name";
            SaleDgv.Columns["BoLNumber"].HeaderText = "Bill of Lading";
            SaleDgv.Columns["CustomerID"].HeaderText = "Customer ID";
            SaleDgv.Columns["TotalRevenue"].HeaderText = "Total Revenue";
            SaleDgv.Columns["SaleDate"].HeaderText = "Creation Date";

            PaginationUserControl.Visible = true;
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.SalePage = PaginationUserControl.CurrentPage;

            IEnumerable<SaleCustomerDTO> query = await _saleService.GetAll(filter);
            SaleDgv.DataSource = query.ToList();
        }
        private void PaginationUserControl_SingleLeftArrowEvent(object sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }

        private void PaginationUserControl_PageNumberTextboxEvent(object sender, EventArgs e)
        {

            if (int.Parse(PaginationUserControl.CurrentPageTxt.Text) > int.Parse(PaginationUserControl.GetmaxPage()))
                PaginationUserControl.CurrentPageTxt.Text = PaginationUserControl.GetmaxPage();

            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.CurrentPageTxt.Text);
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (_father is CreateDetailsSupplierInvoiceForm csif)
                {
                    csif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
                    csif.SetSaleBkBol(dgv.CurrentRow.Cells["BoLNumber"].Value.ToString(), dgv.CurrentRow.Cells["BookingNumber"].Value.ToString());
                }
                if (_father is CreateDetailsCustomerInvoiceForm ccif)
                {
                    ccif.SetSaleBkBol(dgv.CurrentRow.Cells["BoLNumber"].Value.ToString(), dgv.CurrentRow.Cells["BookingNumber"].Value.ToString());
                    ccif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
                }
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
        private async void ContextMenuStripCheckEvent(object sender, EventArgs e)
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
                    ShowID = SaleIDTsmi.Checked,
                    ShowDate = SaleDateTsmi.Checked,
                    ShowStatus = SaleStatusTsmi.Checked,
                    ShowTotalRevenue = SaleTotalRevenueTsmi.Checked,
                    ShowCustomerID = SaleCustomerIDTsmi.Checked,
                    ShowBoL = SaleBoLNumberTsmi.Checked,
                    ShowBKNumber = SaleBkNumberTsmi.Checked,
                    ShowCustomerCountry = SaleCustomerCountryTsmi.Checked,
                    ShowCustomerName = SaleCustomerNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSaleDGV(cdgv);
            }
        }

        private async void SaleGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
            if (_father != null)
                searchSale1.StatusCB.Text = "Active";

            SaleCustomerFilter f = searchSale1.GetFilter();

            countNotFiltered = _saleService.Count(f);
            f.SalePage = 1;
            getAllNotFiltered = _saleService.GetAll(f);
            getFav = _userService.GetSaleDGV();
            await SetCheckBoxes();
        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Sale!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in SaleDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (SaleDgv.Rows[rowid].DataBoundItem is SaleCustomerDTO customer)
                            id.Add((int)customer.SaleId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _saleService.MassDelete(id);
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

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)MdiParent;

            TabPage tp = mf.tabControl.TabPages["AddTP"];
            ToolStrip ts = (ToolStrip)tp.Controls["Create"];
            ToolStripButton btn = (ToolStripButton)ts.Items["SaleCreateTS"];
            btn.PerformClick();
        }
    }
}


