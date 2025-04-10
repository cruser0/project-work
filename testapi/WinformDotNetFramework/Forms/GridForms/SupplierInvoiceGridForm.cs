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
    public partial class SupplierInvoiceGridForm : Form
    {

        SupplierInvoiceSupplierFilter filter = new SupplierInvoiceSupplierFilter() { SupplierInvoicePage = 1 };

        Form _father;
        UserService _userService;
        SupplierInvoiceService _supplierInvoiceService;
        int pages;
        double itemsPage = 10.0;
        public Task<ICollection<SupplierInvoiceSupplierDTO>> getAllNotFiltered;
        public Task<int> countNotFiltered;
        public Task<SupplierInvoiceDGV> getFav;
        List<string> authRoles = new List<string>
            {
                "SupplierInvoiceAdmin",
                "Admin"
            };
        public SupplierInvoiceGridForm()
        {
            InitializeComponent();
        }
        public SupplierInvoiceGridForm(Form father)
        {
            _father = father;

            InitializeComponent();
            toolStrip1.Visible = false;
        }
        public SupplierInvoiceGridForm(string id)
        {
            Init();
            if (id != null)
            {
                //searchSupplierInvoice1.SupplierIDTxt.SetText(id);
                MyControl_ButtonClicked(this, EventArgs.Empty);
            }
        }

        public async Task Init()
        {
            if (DesignMode)
                return;
            _userService = new UserService();
            _supplierInvoiceService = new SupplierInvoiceService();
            pages = (int)Math.Ceiling(await _supplierInvoiceService.Count(new SupplierInvoiceSupplierFilter()) / itemsPage);

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.PageNumberTextboxEvent += PaginationUserControl_PageNumberTextboxEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
            {
                SupplierInvoiceIDTsmi.Visible = false;
                SupplierInvoiceSupplierIDTsmi.Visible = false;
            }
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }


        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (_father is CreateDetailsSupplierInvoiceCostForm sigf)
                {
                    sigf.SetSupplierID(dgv.CurrentRow.Cells["SupplierInvoiceID"].Value.ToString());
                    sigf.SetSupplierCode(dgv.CurrentRow.Cells["SupplierInvoiceCode"].Value.ToString());

                }
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {

            filter = searchSupplierInvoice1.GetFilter();
            filter.SupplierInvoicePage = PaginationUserControl.CurrentPage;

            SupplierInvoiceSupplierFilter filterPage = searchSupplierInvoice1.GetFilter();

            var query = _supplierInvoiceService.GetAll(filter);
            var count = _supplierInvoiceService.Count(filterPage);
            await Task.WhenAll(count, query);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            IEnumerable<SupplierInvoiceSupplierDTO> query1 = await query;
            SupplierInvoiceDgv.DataSource = query1.ToList();
        }

        public async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SupplierInvoiceSupplierDTO> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceDgv.DataSource = query.ToList();
            SupplierInvoiceDGV cdgv = await getFav;

            SupplierInvoiceIDTsmi.Checked = (bool)cdgv.ShowID;
            SupplierInvoiceSaleIDTsmi.Checked = (bool)cdgv.ShowSaleID;
            SupplierInvoiceInvoiceAmountTsmi.Checked = (bool)cdgv.ShowInvoiceAmount;
            SupplierInvoiceDateTsmi.Checked = (bool)cdgv.ShowInvoiceDate;
            SupplierInvoiceStatusTsmi.Checked = (bool)cdgv.ShowStatus;
            SupplierInvoiceSupplierNameTsmi.Checked = (bool)cdgv.ShowSupplierName;
            SupplierInvoiceCountryTsmi.Checked = (bool)cdgv.ShowCountry;
            SupplierInvoiceSupplierIDTsmi.Checked = (bool)cdgv.ShowSupplierID;

            SupplierInvoiceDgv.Columns["IsPost"].Visible = false;

            SupplierInvoiceDgv.Columns["SupplierInvoiceID"].Visible = (bool)cdgv.ShowID;
            SupplierInvoiceDgv.Columns["SaleID"].Visible = (bool)cdgv.ShowSaleID;
            SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = (bool)cdgv.ShowInvoiceAmount;
            SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = (bool)cdgv.ShowInvoiceDate;
            SupplierInvoiceDgv.Columns["Status"].Visible = (bool)cdgv.ShowStatus;
            SupplierInvoiceDgv.Columns["SupplierName"].Visible = (bool)cdgv.ShowSupplierName;
            SupplierInvoiceDgv.Columns["Country"].Visible = (bool)cdgv.ShowCountry;
            SupplierInvoiceDgv.Columns["SupplierID"].Visible = (bool)cdgv.ShowSupplierID;
            SupplierInvoiceDgv.Columns["SupplierInvoiceCode"].Visible = (bool)cdgv.ShowInvoiceCode;//change ref
            SupplierInvoiceDgv.Columns["SaleBookingNumber"].Visible = (bool)cdgv.ShowSaleBookingNumber;
            SupplierInvoiceDgv.Columns["SaleBoL"].Visible = (bool)cdgv.ShowSaleBoL;

            SupplierInvoiceDgv.Columns["SupplierInvoiceID"].HeaderText = "Supplier Invoice ID";
            SupplierInvoiceDgv.Columns["SaleID"].HeaderText = "Sale ID";
            SupplierInvoiceDgv.Columns["InvoiceAmount"].HeaderText = "Total Amount";
            SupplierInvoiceDgv.Columns["InvoiceDate"].HeaderText = "Creation Date";
            SupplierInvoiceDgv.Columns["SupplierName"].HeaderText = "Supplier Name";
            SupplierInvoiceDgv.Columns["Country"].HeaderText = "Supplier Country";
            SupplierInvoiceDgv.Columns["SupplierID"].HeaderText = "Supplier ID";
            SupplierInvoiceDgv.Columns["SupplierInvoiceCode"].HeaderText = "Supplier Invoice Code";
            SupplierInvoiceDgv.Columns["SaleBookingNumber"].HeaderText = "Sale Booking Number";
            SupplierInvoiceDgv.Columns["SaleBoL"].HeaderText = "Sale Bill of Lading";

            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.SupplierInvoicePage = PaginationUserControl.CurrentPage;

            IEnumerable<SupplierInvoiceSupplierDTO> query = await _supplierInvoiceService.GetAll(filter);
            SupplierInvoiceDgv.DataSource = query.ToList();
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
            panel2.Location = new Point((Width - panel2.Width) / 2, 0);
            PaginationUserControl.Location = new Point((panel2.Width - PaginationUserControl.Width) / 2, (panel2.Height - PaginationUserControl.Height) / 2);


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
                var test = SupplierInvoiceDgv.HitTest(e.X, e.Y);
                if (test.RowIndex >= 0)
                {
                    RightClickDgv.Show(SupplierInvoiceDgv, e.Location);
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
                    case "SupplierInvoiceIDTsmi":
                        SupplierInvoiceDgv.Columns["SupplierInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSaleIDTsmi":
                        SupplierInvoiceDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceInvoiceAmountTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceDateTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceStatusTsmi":
                        SupplierInvoiceDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierNameTsmi":
                        SupplierInvoiceDgv.Columns["SupplierName"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCountryTsmi":
                        SupplierInvoiceDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierIDTsmi":
                        SupplierInvoiceDgv.Columns["SupplierID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierInvoiceCodeTsmi":
                        SupplierInvoiceDgv.Columns["SupplierInvoiceCode"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSaleBookingNumberTsmi":
                        SupplierInvoiceDgv.Columns["SaleBookingNumber"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSaleBolTsmi":
                        SupplierInvoiceDgv.Columns["SaleBoL"].Visible = tsmi.Checked;
                        break;

                    default:
                        break;
                }
                SupplierInvoiceDGV cdgv = new SupplierInvoiceDGV
                {
                    ShowInvoiceDate = SupplierInvoiceDateTsmi.Checked,
                    ShowID = SupplierInvoiceIDTsmi.Checked,
                    ShowInvoiceAmount = SupplierInvoiceInvoiceAmountTsmi.Checked,
                    ShowSaleID = SupplierInvoiceSaleIDTsmi.Checked,
                    ShowStatus = SupplierInvoiceStatusTsmi.Checked,
                    ShowCountry = SupplierInvoiceCountryTsmi.Checked,
                    ShowSupplierName = SupplierInvoiceSupplierNameTsmi.Checked,
                    ShowSupplierID = SupplierInvoiceSupplierIDTsmi.Checked,
                    ShowSaleBoL = SupplierInvoiceSaleBolTsmi.Checked,
                    ShowSaleBookingNumber = SupplierInvoiceSaleBookingNumberTsmi.Checked,
                    ShowInvoiceCode = SupplierInvoiceSupplierInvoiceCodeTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSupplierInvoiceDGV(cdgv);
            }
        }

        public async virtual void SupplierInvoiceGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
            getAllNotFiltered = _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter() { SupplierInvoicePage = 1 });
            countNotFiltered = _supplierInvoiceService.Count(new SupplierInvoiceSupplierFilter());
            getFav = _userService.GetSupplierInvoiceDGV();
            await SetCheckBoxes();
        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Supplier Invoice!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in SupplierInvoiceDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (SupplierInvoiceDgv.Rows[rowid].DataBoundItem is SupplierInvoiceSupplierDTO customer)
                            id.Add((int)customer.SupplierInvoiceId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _supplierInvoiceService.MassDelete(id);
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
            ToolStripButton btn = (ToolStripButton)ts.Items["SupplierInvoiceCreateTS"];
            btn.PerformClick();
        }
    }
}
