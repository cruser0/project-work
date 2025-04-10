﻿using Entity_Validator.Entity.DTO;
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
    public partial class CustomerInvoiceGridForm : Form
    {
        CustomerInvoiceFilter filter = new CustomerInvoiceFilter() { CustomerInvoicePage = 1 };

        double itemsPage = 10.0;
        int pages;
        CustomerInvoiceService _customerInvoiceService;
        Form _father;
        Task<ICollection<CustomerInvoiceDTOGet>> getAllNotFiltered;
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
            ConstructInit();
        }
        public CustomerInvoiceGridForm(CreateDetailsCustomerInvoiceCostForm father)
        {
            _father = father;
            ConstructInit();
            toolStrip1.Visible = false;
        }
        public void ConstructInit()
        {
            _userService = new UserService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();

        }
        private async Task Init()
        {
            if (DesignMode)
                return;
            pages = (int)Math.Ceiling(await _customerInvoiceService.Count(new CustomerInvoiceFilter()) / itemsPage);

            PaginationUserControl.CurrentPage = 1;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.PageNumberTextboxEvent += PaginationUserControl_PageNumberTextboxEvent;

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


            IEnumerable<CustomerInvoiceDTOGet> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await count / itemsPage)).ToString();
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
            IEnumerable<CustomerInvoiceDTOGet> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.DataSource = query.ToList();
            CustomerInvoiceDGV cdgv = await getFav;

            CustomerInvoiceDateTsmi.Checked = (bool)cdgv.ShowDate;
            CustomerInvoiceIDTsmi.Checked = (bool)cdgv.ShowID;
            CustomerInvoiceInvoiceAmountTsmi.Checked = (bool)cdgv.ShowInvoiceAmount;
            CustomerInvoiceSaleIDTsmi.Checked = (bool)cdgv.ShowSaleID;
            CustomerInvoiceStatusTsmi.Checked = (bool)cdgv.ShowStatus;
            CenterDgv.Columns["IsPost"].Visible = false;

            CenterDgv.Columns["CustomerInvoiceID"].Visible = (bool)cdgv.ShowID;
            CenterDgv.Columns["SaleID"].Visible = (bool)cdgv.ShowSaleID;
            CenterDgv.Columns["InvoiceAmount"].Visible = (bool)cdgv.ShowInvoiceAmount;
            CenterDgv.Columns["InvoiceDate"].Visible = (bool)cdgv.ShowDate;
            CenterDgv.Columns["Status"].Visible = (bool)cdgv.ShowStatus;
            CenterDgv.Columns["CustomerInvoiceCode"].Visible = (bool)cdgv.ShowInvoiceCode;
            CenterDgv.Columns["SaleBookingNumber"].Visible = (bool)cdgv.ShowSaleBookingNumber;
            CenterDgv.Columns["SaleBol"].Visible = (bool)cdgv.ShowSaleBoL;

            CenterDgv.Columns["CustomerInvoiceID"].HeaderText = "Customer Invoice ID";
            CenterDgv.Columns["SaleID"].HeaderText = "Sale ID";
            CenterDgv.Columns["InvoiceAmount"].HeaderText = "Total Invoice Amount";
            CenterDgv.Columns["InvoiceDate"].HeaderText = "Creation Date";
            CenterDgv.Columns["CustomerInvoiceCode"].HeaderText = "Customer Invoice Code";
            CenterDgv.Columns["SaleBookingNumber"].HeaderText = "Sale Booking Number";
            CenterDgv.Columns["SaleBol"].HeaderText = "Sale Bill of Lading";
            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {

            filter.CustomerInvoicePage = PaginationUserControl.CurrentPage;


            IEnumerable<CustomerInvoiceDTOGet> query = await _customerInvoiceService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        public virtual void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateDetailsCustomerInvoiceCostForm csif)
                {
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString());
                    csif.SetCustomerInvoiceCode(dgv.CurrentRow.Cells["CustomerInvoiceCode"].Value.ToString());
                }
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

        private void PaginationUserControl_PageNumberTextboxEvent(object sender, EventArgs e)
        {

            if (int.Parse(PaginationUserControl.CurrentPageTxt.Text) > int.Parse(PaginationUserControl.GetmaxPage()))
                PaginationUserControl.CurrentPageTxt.Text = PaginationUserControl.GetmaxPage();

            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.CurrentPageTxt.Text);
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
                    case "CustomerInvoiceCodeTsmi":
                        CenterDgv.Columns["CustomerInvoiceCode"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceSaleBookingNumberTsmi":
                        CenterDgv.Columns["SaleBookingNumber"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceSaleBolTsmi":
                        CenterDgv.Columns["SaleBol"].Visible = tsmi.Checked;
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
                    ShowInvoiceCode = CustomerInvoiceCodeTsmi.Checked,
                    ShowSaleBoL = CustomerInvoiceSaleBolTsmi.Checked,
                    ShowSaleBookingNumber = CustomerInvoiceSaleBookingNumberTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceDGV(cdgv);
            }
        }

        private async void CustomerInvoiceGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
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
                        if (CenterDgv.Rows[rowid].DataBoundItem is CustomerInvoiceDTOGet customer)
                            id.Add((int)customer.CustomerInvoiceId);
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

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)MdiParent;

            TabPage tp = mf.tabControl.TabPages["AddTP"];
            ToolStrip ts = (ToolStrip)tp.Controls["Create"];
            ToolStripButton btn = (ToolStripButton)ts.Items["CustomerInvoiceCreateTS"];
            btn.PerformClick();
        }
    }
}
