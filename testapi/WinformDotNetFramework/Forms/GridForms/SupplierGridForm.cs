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
    public partial class SupplierGridForm : Form
    {
        SupplierFilter filter = new SupplierFilter() { SupplierPage = 1, SupplierDeprecated = false };

        int pages;
        double itemsPage = 10.0;
        private SupplierService _supplierService;
        private Form _father;
        Task<ICollection<SupplierDTOGet>> getAllNotFiltered;
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
            InitializeComponent();

        }
        public SupplierGridForm(CreateDetailsSupplierInvoiceForm father)
        {
            _father = father;
            InitializeComponent();

            toolStrip1.Visible = false;
        }

        private async Task Init()
        {
            if (DesignMode)
                return;
            _supplierService = new SupplierService();
            _userService = new UserService();
            pages = (int)Math.Ceiling(await _supplierService.Count(new SupplierFilter()) / itemsPage);

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.PageNumberTextboxEvent += PaginationUserControl_PageNumberTextboxEvent;

            searchSupplier1.comboBox1.SelectedIndex = 1;

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

            filter = searchSupplier1.GetFilter();
            filter.SupplierPage = PaginationUserControl.CurrentPage;

            SupplierFilter filterPage = searchSupplier1.GetFilter();




            var query = _supplierService.GetAll(filter);
            var count = _supplierService.Count(filterPage);


            await Task.WhenAll(query, count);

            IEnumerable<SupplierDTOGet> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SupplierDTOGet> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();


            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierDgv.DataSource = query.ToList();
            SupplierDGV cdgv = await getFav;
            SupplierCountryTsmi.Checked = (bool)cdgv.ShowCountry;
            SupplierDateTsmi.Checked = (bool)cdgv.ShowDate;
            SupplierIDTsmi.Checked = (bool)cdgv.ShowID;
            SupplierStatusTsmi.Checked = (bool)cdgv.ShowStatus;
            SupplierOriginalIDTsmi.Checked = (bool)cdgv.ShowOriginalID;
            SupplierNameTsmi.Checked = (bool)cdgv.ShowName;

            SupplierDgv.Columns["IsPost"].Visible = false;

            SupplierDgv.Columns["SupplierName"].Visible = (bool)cdgv.ShowName;
            SupplierDgv.Columns["Country"].Visible = (bool)cdgv.ShowCountry;
            SupplierDgv.Columns["CreatedAt"].Visible = (bool)cdgv.ShowDate;
            SupplierDgv.Columns["OriginalID"].Visible = (bool)cdgv.ShowOriginalID;
            SupplierDgv.Columns["Deprecated"].Visible = (bool)cdgv.ShowStatus;
            SupplierDgv.Columns["SupplierID"].Visible = SupplierIDTsmi.Checked;


            SupplierDgv.Columns["SupplierName"].HeaderText = "Supplier Name";
            SupplierDgv.Columns["Country"].HeaderText = "Supplier Country";
            SupplierDgv.Columns["CreatedAt"].HeaderText = "Creation Date";
            SupplierDgv.Columns["OriginalID"].HeaderText = "Supplier Original ID";
            SupplierDgv.Columns["SupplierID"].HeaderText = "Supplier ID";

            PaginationUserControl.Visible = true;
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.SupplierPage = PaginationUserControl.CurrentPage;

            IEnumerable<SupplierDTOGet> query = await _supplierService.GetAll(filter);
            SupplierDgv.DataSource = query.ToList();
        }

        public virtual void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (_father is CreateDetailsSupplierInvoiceForm sidf)
                {
                    sidf.SetSupplierID(dgv.CurrentRow.Cells["SupplierID"].Value.ToString());
                    sidf.SetSupplierNameCountry(dgv.CurrentRow.Cells["SupplierName"].Value.ToString(), dgv.CurrentRow.Cells["Country"].Value.ToString());
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
            if (DesignMode)
                return;
            await Init();
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
                        if (SupplierDgv.Rows[rowid].DataBoundItem is SupplierDTOGet customer)
                            id.Add((int)customer.SupplierId);
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

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)MdiParent;

            TabPage tp = mf.tabControl.TabPages["AddTP"];
            ToolStrip ts = (ToolStrip)tp.Controls["Create"];
            ToolStripButton btn = (ToolStripButton)ts.Items["SupplierCreateTS"];
            btn.PerformClick();
        }
    }
}
