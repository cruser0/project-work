﻿using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class SupplierInvoiceCostGridForm : Form
    {

        int? invoiceId;
        int? costFrom;
        int? costTo;
        string? name;
        SupplierInvoiceCostService _supplierInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        List<string> authRoles = new List<string>
            {
                "SupplierInvoiceCostAdmin",
                "Admin"
            };
        UserService _userService;

        Task<ICollection<SupplierInvoiceCost>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<SupplierInvoiceCostDGV> getFav;
        public SupplierInvoiceCostGridForm()
        {
            Init();
        }

        private async void Init()
        {
            _userService = new UserService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _supplierInvoiceCostService.Count(new SupplierInvoiceCostFilter()) / itemsPage);


            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceCostDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
                SupplierInvoiceCostIDTsmi.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }




        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            invoiceId = !string.IsNullOrEmpty(InvoiceIDTxt.GetText()) ? int.Parse(InvoiceIDTxt.GetText()) : null;
            costFrom = !string.IsNullOrEmpty(CostFromTxt.GetText()) ? int.Parse(CostFromTxt.GetText()) : null;
            costTo = !string.IsNullOrEmpty(CostToTxt.GetText()) ? int.Parse(CostToTxt.GetText()) : null;
            name = !string.IsNullOrEmpty(NameTxt.Text) ? NameTxt.Text : null;
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostPage = PaginationUserControl.CurrentPage,
                SupplierInvoiceCostName = name
            };
            SupplierInvoiceCostFilter filterPage = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostName = name
            };
            var query = _supplierInvoiceCostService.GetAll(filter);
            var count = _supplierInvoiceCostService.Count(filterPage);
            await Task.WhenAll(query, count);


            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            IEnumerable<SupplierInvoiceCost> query1 = await query;
            SupplierInvoiceCostDgv.DataSource = query1.ToList();

        }
        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SupplierInvoiceCost> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceCostDgv.DataSource = query.ToList();
            SupplierInvoiceCostDGV cdgv = await getFav;

            SupplierInvoiceCostCostTsmi.Checked = cdgv.ShowCost;
            SupplierInvoiceCostSupplierInvoiceIDTsmi.Checked = cdgv.ShowSupplierInvoiceID;
            SupplierInvoiceCostIDTsmi.Checked = cdgv.ShowID;
            SupplierInvoiceCostNameTsmi.Checked = cdgv.ShowName;
            SupplierInvoiceCostQuantityTsmi.Checked = cdgv.ShowQuantity;
            SupplierInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = cdgv.ShowID;
            SupplierInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = cdgv.ShowSupplierInvoiceID;
            SupplierInvoiceCostDgv.Columns["Cost"].Visible = cdgv.ShowCost;
            SupplierInvoiceCostDgv.Columns["Quantity"].Visible = cdgv.ShowQuantity;
            SupplierInvoiceCostDgv.Columns["Name"].Visible = cdgv.ShowName;
            PaginationUserControl.Visible = true;

        }

        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter
            {
                SupplierInvoiceCostSupplierInvoiceId = invoiceId,
                SupplierInvoiceCostCostFrom = costFrom,
                SupplierInvoiceCostCostTo = costTo,
                SupplierInvoiceCostPage = PaginationUserControl.CurrentPage,
                SupplierInvoiceCostName = name
            };

            IEnumerable<SupplierInvoiceCost> query = await _supplierInvoiceCostService.GetAll(filter);
            SupplierInvoiceCostDgv.DataSource = query.ToList();
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

            PaginationPanel.Location = new Point((Width - PaginationPanel.Width) / 2, 0);
            PaginationUserControl.Location = new Point((PaginationPanel.Width - PaginationUserControl.Width) / 2, (PaginationPanel.Height - PaginationUserControl.Height) / 2);

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
                var test = SupplierInvoiceCostDgv.HitTest(e.X, e.Y);
                if (test.RowIndex >= 0)
                {
                    RightClickDgv.Show(RightClickDgv, e.Location);
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
                    case "SupplierInvoiceCostIDTsmi":
                        SupplierInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostSupplierInvoiceIDTsmi":
                        SupplierInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostCostTsmi":
                        SupplierInvoiceCostDgv.Columns["Cost"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostQuantityTsmi":
                        SupplierInvoiceCostDgv.Columns["Quantity"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCostNameTsmi":
                        SupplierInvoiceCostDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                SupplierInvoiceCostDGV cdgv = new SupplierInvoiceCostDGV
                {
                    ShowCost = SupplierInvoiceCostCostTsmi.Checked,
                    ShowQuantity = SupplierInvoiceCostQuantityTsmi.Checked,
                    ShowName = SupplierInvoiceCostNameTsmi.Checked,
                    ShowID = SupplierInvoiceCostIDTsmi.Checked,
                    ShowSupplierInvoiceID = SupplierInvoiceCostSupplierInvoiceIDTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSupplierInvoiceCostDGV(cdgv);

            }
        }

        private async void SupplierInvoiceCostGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _supplierInvoiceCostService.GetAll(new SupplierInvoiceCostFilter() { SupplierInvoiceCostPage = 1 });
            countNotFiltered = _supplierInvoiceCostService.Count(new SupplierInvoiceCostFilter());
            getFav = _userService.GetSupplierInvoiceCostDGV();
            await SetCheckBoxes();
        }

        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Supplier Invoice Cost!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in SupplierInvoiceCostDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (SupplierInvoiceCostDgv.Rows[rowid].DataBoundItem is SupplierInvoiceCost customer)
                            id.Add(customer.SupplierInvoiceCostsId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _supplierInvoiceCostService.MassDelete(id);
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
            UtilityFunctions.Pdf_ClickBtn(SupplierInvoiceCostDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(SupplierInvoiceCostDgv, this);
        }
    }
}
