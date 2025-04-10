﻿
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities.Preference;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class CustomerGridForm : Form
    {
        CustomerFilter filter = new CustomerFilter() { CustomerPage = 1, CustomerDeprecated = false };

        private CustomerService _customerService;
        int pages;
        double itemsPage = 10.0;
        Form _father;
        Task<ICollection<CustomerDTOGet>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerDGV> getFav;

        private UserService _userService;
        public CustomerGridForm()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _userService = new UserService();
        }

        public CustomerGridForm(CreateDetailsSaleForm father)
        {
            InitializeComponent();
            _father = father;
            toolStrip1.Visible = false;
            _customerService = new CustomerService();
            _userService = new UserService();
        }

        private async Task Init()
        {

            if (DesignMode)
                return;
            CustomerDgv.ReadOnly = true;


            pages = (int)Math.Ceiling(await _customerService.Count(new CustomerFilter() { CustomerDeprecated = false }) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.PageNumberTextboxEvent += PaginationUserControl_PageNumberTextboxEvent;

            searchCustomer1.comboBox1.SelectedIndex = 1;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerDgv.ContextMenuStrip = RightClickDgv;
            if (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerAdmin", "Admin" }))
            {
                CustomerIDTsmi.Visible = false;
                CustomerOriginalIDTsmi.Visible = false;
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;

            filter = searchCustomer1.GetFilter();
            filter.CustomerPage = PaginationUserControl.CurrentPage;
            CustomerFilter filterPage = searchCustomer1.GetFilter();

            var query = _customerService.GetAll(filter);
            var totalCount = _customerService.Count(filterPage);
            await Task.WhenAll(query, totalCount);
            IEnumerable<CustomerDTOGet> query1 = await query;

            CustomerDgv.DataSource = query1.ToList();

            PaginationUserControl.maxPage = ((int)Math.Ceiling(await totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<CustomerDTOGet> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CustomerDgv.DataSource = query.ToList();

            CustomerDGV cdgv = await getFav;
            CustomerCountryTsmi.Checked = (bool)cdgv.ShowCountry;
            CustomerDateTsmi.Checked = (bool)cdgv.ShowDate;
            CustomerIDTsmi.Checked = (bool)cdgv.ShowID;
            CustomerStatusTsmi.Checked = (bool)cdgv.ShowStatus;
            CustomerOriginalIDTsmi.Checked = (bool)cdgv.ShowOriginalID;
            CustomerNameTsmi.Checked = (bool)cdgv.ShowName;
            PaginationUserControl.Visible = true;
            CustomerDgv.Columns["IsPost"].Visible = false;

            CustomerDgv.Columns["CustomerName"].Visible = (bool)cdgv.ShowName;
            CustomerDgv.Columns["Country"].Visible = (bool)cdgv.ShowCountry;
            CustomerDgv.Columns["CreatedAt"].Visible = (bool)cdgv.ShowDate;
            CustomerDgv.Columns["OriginalID"].Visible = (bool)cdgv.ShowOriginalID;
            CustomerDgv.Columns["Deprecated"].Visible = (bool)cdgv.ShowStatus;
            CustomerDgv.Columns["CustomerID"].Visible = CustomerIDTsmi.Checked;

            CustomerDgv.Columns["CustomerID"].HeaderText = "Customer ID";
            CustomerDgv.Columns["CustomerName"].HeaderText = "Customer Name";
            CustomerDgv.Columns["Country"].HeaderText = "Customer Country";
            CustomerDgv.Columns["CreatedAt"].HeaderText = "Creation Date";
            CustomerDgv.Columns["OriginalID"].HeaderText = "Original Customer ID";

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.CustomerPage = PaginationUserControl.CurrentPage;
            IEnumerable<CustomerDTOGet> query = await _customerService.GetAll(filter);
            CustomerDgv.DataSource = query.ToList();
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
                if (_father is CreateDetailsSaleForm csf)
                {
                    csf.SetCustomerID(dgv.CurrentRow.Cells["CustomerID"].Value.ToString());
                    csf.SetCustomerNameCountry(dgv.CurrentRow.Cells["CustomerName"].Value.ToString(), dgv.CurrentRow.Cells["Country"].Value.ToString());
                }
            }
        }

        public void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            panel5.Location = new System.Drawing.Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new System.Drawing.Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
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
                var hitTest = CustomerDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CustomerDgv, e.Location);
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
                    case "CustomerIDTsmi":
                        CustomerDgv.Columns["CustomerID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerNameTsmi":
                        CustomerDgv.Columns["CustomerName"].Visible = tsmi.Checked;
                        break;
                    case "CustomerCountryTsmi":
                        CustomerDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "CustomerDateTsmi":
                        CustomerDgv.Columns["CreatedAt"].Visible = tsmi.Checked;
                        break;
                    case "CustomerOriginalIDTsmi":
                        CustomerDgv.Columns["OriginalID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerStatusTsmi":
                        CustomerDgv.Columns["Deprecated"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerDGV cdgv = new CustomerDGV
                {
                    ShowDate = CustomerDateTsmi.Checked,
                    ShowID = CustomerIDTsmi.Checked,
                    ShowStatus = CustomerStatusTsmi.Checked,
                    ShowOriginalID = CustomerOriginalIDTsmi.Checked,
                    ShowCountry = CustomerCountryTsmi.Checked,
                    ShowName = CustomerNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerDGV(cdgv);

            }
        }

        private async void CustomerGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
            getAllNotFiltered = _customerService.GetAll(filter);
            countNotFiltered = _customerService.Count(new CustomerFilter() { CustomerDeprecated = false });
            getFav = _userService.GetCustomerDGV();
            await SetCheckBoxes();

        }


        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Customers!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in CustomerDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (CustomerDgv.Rows[rowid].DataBoundItem is CustomerDTOGet customer)
                            id.Add((int)customer.CustomerId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _customerService.MassDelete(id);
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
            ToolStripButton btn = (ToolStripButton)ts.Items["CustomerCreateTS"];
            btn.PerformClick();
        }
    }
}
