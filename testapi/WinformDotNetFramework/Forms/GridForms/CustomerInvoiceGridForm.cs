using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Entities.Preference;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class CustomerInvoiceGridForm : Form
    {
        CustomerInvoiceFilter filter = new CustomerInvoiceFilter() { CustomerInvoicePage = 1 };

        double itemsPage = 10.0;
        int pages;
        CustomerInvoiceService _customerInvoiceService;
        Form _father;
        Task<ICollection<CustomerInvoice>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerInvoiceDGV> getFav;
        List<string> authRoles = new List<string>
            {
                "CustomerInvoiceAdmin",
                "Admin"
            };
        UserService _userService;
        public CustomerInvoiceGridForm()
        {
            Init();
        }
        public CustomerInvoiceGridForm(CreateCustomerInvoiceCostForm father)
        {
            _father = father;
            Init();
            toolStrip1.Visible = false;
        }

        private async void Init()
        {
            _userService = new UserService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _customerInvoiceService.Count(new CustomerInvoiceFilter()) / itemsPage);

            PaginationUserControl.CurrentPage = 1;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.ContextMenuStrip = RightClickDgv;
            if (!Authorize(authRoles))
                CustomerInvoiceIDTsmi.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }



        private async void RightSideBar_searchBtnEvent(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;

            filter = searchCustomerInvoice1.GetFilter();
            filter.CustomerInvoicePage = PaginationUserControl.CurrentPage;
            CustomerInvoiceFilter filterPage = searchCustomerInvoice1.GetFilter();

            var query = _customerInvoiceService.GetAll(filter);
            var count = _customerInvoiceService.Count(filterPage);
            await Task.WhenAll(count, query);


            IEnumerable<CustomerInvoice> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.DataSource = query1.ToList();

            if (!PaginationUserControl.Visible)
            {
                await SetCheckBoxes();
            }

        }
        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<CustomerInvoice> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.DataSource = query.ToList();
            CustomerInvoiceDGV cdgv = await getFav;

            CustomerInvoiceDateTsmi.Checked = cdgv.ShowDate;
            CustomerInvoiceIDTsmi.Checked = cdgv.ShowID;
            CustomerInvoiceInvoiceAmountTsmi.Checked = cdgv.ShowInvoiceAmount;
            CustomerInvoiceSaleIDTsmi.Checked = cdgv.ShowSaleID;
            CustomerInvoiceStatusTsmi.Checked = cdgv.ShowStatus;
            CenterDgv.Columns["CustomerInvoiceID"].Visible = cdgv.ShowID;
            CenterDgv.Columns["SaleID"].Visible = cdgv.ShowSaleID;
            CenterDgv.Columns["InvoiceAmount"].Visible = cdgv.ShowInvoiceAmount;
            CenterDgv.Columns["InvoiceDate"].Visible = cdgv.ShowDate;
            CenterDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {

            filter.CustomerInvoicePage = PaginationUserControl.CurrentPage;


            IEnumerable<CustomerInvoice> query = await _customerInvoiceService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        public virtual void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateCustomerInvoiceCostForm csif)
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString());
            }

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

        private void RightClickDhvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CenterDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CenterDgv, e.Location);
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
                    case "CustomerInvoiceIDTsmi":
                        CenterDgv.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceSaleIDTsmi":
                        CenterDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceInvoiceAmountTsmi":
                        CenterDgv.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceDateTsmi":
                        CenterDgv.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceStatusTsmi":
                        CenterDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerInvoiceDGV cdgv = new CustomerInvoiceDGV
                {
                    ShowDate = CustomerInvoiceDateTsmi.Checked,
                    ShowID = CustomerInvoiceIDTsmi.Checked,
                    ShowInvoiceAmount = CustomerInvoiceInvoiceAmountTsmi.Checked,
                    ShowSaleID = CustomerInvoiceSaleIDTsmi.Checked,
                    ShowStatus = CustomerInvoiceStatusTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceDGV(cdgv);
            }
        }

        private async void CustomerInvoiceGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoicePage = 1 });
            countNotFiltered = _customerInvoiceService.Count(new CustomerInvoiceFilter());
            getFav = _userService.GetCustomerInvoiceDGV();
            await SetCheckBoxes();
        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Customer Invoice!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in CenterDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (CenterDgv.Rows[rowid].DataBoundItem is CustomerInvoice customer)
                            id.Add(customer.CustomerInvoiceId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _customerInvoiceService.MassDelete(id);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No Row was selected");
                    }
                    RightSideBar_searchBtnEvent(sender, e);
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
            UtilityFunctions.Pdf_ClickBtn(CenterDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(CenterDgv, this);
        }

        private async void MassUpdateTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
         "This action is permanent and it will update all the history bound to this entity!",
         "Confirm Update?",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<CustomerInvoice> newEntities = new List<CustomerInvoice>();
                    HashSet<int> ids = new HashSet<int>();

                    foreach (DataGridViewCell cell in CenterDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }

                    foreach (var rowId in ids)
                    {
                        if (CenterDgv.Rows[rowId].DataBoundItem is CustomerInvoice entity)
                            newEntities.Add(entity);
                    }
                    if (newEntities.Count > 0)
                    {
                        string message = await _customerInvoiceService.MassUpdate(newEntities);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No Row was selected");
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }
    }
}
