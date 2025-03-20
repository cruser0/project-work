using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Entities.Preference;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class SaleGridForm : Form
    {

        SaleFilter filter = new SaleFilter() { SalePage = 1 };

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
            Init();
        }


        public SaleGridForm(CreateSupplierInvoicesForm father)
        {
            _father = father;
            Init();
            toolStrip1.Visible = false;
        }
        public SaleGridForm(CreateCustomerInvoiceForm father)
        {
            _father = father;
            Init();
            toolStrip1.Visible = false;
        }

        private async void Init()
        {
            _userService = new UserService();
            _saleService = new SaleService();

            InitializeComponent();
            pages = (int)Math.Ceiling(await _saleService.Count(new SaleFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

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

            SaleFilter filterPage = searchSale1.GetFilter();

            var query = _saleService.GetAll(filter);
            var count = _saleService.Count(filterPage);
            await Task.WhenAll(query, count);

            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            IEnumerable<SaleCustomerDTO> query1 = await query;
            SaleDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SaleCustomerDTO> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling((double)await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SaleDgv.DataSource = query.ToList();
            SaleDGV cdgv = await getFav;

            SaleIDTsmi.Checked = cdgv.ShowID;
            SaleBkNumberTsmi.Checked = cdgv.ShowBKNumber;
            SaleCustomerCountryTsmi.Checked = cdgv.ShowCustomerCountry;
            SaleCustomerNameTsmi.Checked = cdgv.ShowCustomerName;
            SaleBoLNumberTsmi.Checked = cdgv.ShowBoL;
            SaleCustomerIDTsmi.Checked = cdgv.ShowCustomerID;
            SaleTotalRevenueTsmi.Checked = cdgv.ShowTotalRevenue;
            SaleStatusTsmi.Checked = cdgv.ShowStatus;
            SaleDateTsmi.Checked = cdgv.ShowDate;

            SaleDgv.Columns["SaleID"].Visible = cdgv.ShowID;
            SaleDgv.Columns["BookingNumber"].Visible = cdgv.ShowBKNumber;
            SaleDgv.Columns["Country"].Visible = cdgv.ShowCustomerCountry;
            SaleDgv.Columns["CustomerName"].Visible = cdgv.ShowCustomerName;
            SaleDgv.Columns["BoLNumber"].Visible = cdgv.ShowBoL;
            SaleDgv.Columns["CustomerID"].Visible = cdgv.ShowCustomerID;
            SaleDgv.Columns["TotalRevenue"].Visible = cdgv.ShowTotalRevenue;
            SaleDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            SaleDgv.Columns["SaleDate"].Visible = cdgv.ShowDate;

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

        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (_father is CreateSupplierInvoicesForm csif)
                    csif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
                if (_father is CreateCustomerInvoiceForm ccif)
                    ccif.SetSaleID(dgv.CurrentRow.Cells["SaleID"].Value.ToString());
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
            getAllNotFiltered = _saleService.GetAll(new SaleFilter() { SalePage = 1 });
            countNotFiltered = _saleService.Count(new SaleFilter());
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
                            id.Add(customer.SaleId);
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
        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Pdf_ClickBtn(SaleDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(SaleDgv, this);
        }

        private HashSet<int> modifiedRows = new HashSet<int>();

        private void SaleDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modifiedRows.Add(e.RowIndex);
            }
        }
        private async void MassUpdateTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "This action is permanent and it will update all the history bound to this entity!",
                "Confirm Update?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                MessageBox.Show("Action canceled.");
                return;
            }

            try
            {
                List<Sale> modifiedEntities = new List<Sale>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (SaleDgv.Rows[rowIndex].DataBoundItem is SaleCustomerDTO entity)
                    {
                        modifiedEntities.Add((Sale)(object)entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _saleService.MassUpdate(modifiedEntities);
                    MessageBox.Show(message);

                    // Resetta le righe modificate dopo l'update
                    modifiedRows.Clear();
                    ToggleEditButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("No modified rows to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ToggleEditButton_Click(object sender, EventArgs e)
        {
            // Inverti lo stato ReadOnly
            SaleDgv.ReadOnly = !SaleDgv.ReadOnly;

            if (SaleDgv.ReadOnly) // Modalità visualizzazione
            {
                if (modifiedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                        "You haven't saved your changes, and all edits will be lost!\nDo you want to continue?",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        // Se l'utente sceglie "No", torna in modalità modifica
                        SaleDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                SaleDgv.Cursor = Cursors.Default;
                SaleDgv.CellDoubleClick += MyControl_OpenDetails_Clicked;
                SaleDgv.CellValueChanged -= SaleDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                SaleDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                SaleDgv.CellDoubleClick -= MyControl_OpenDetails_Clicked;
                SaleDgv.CellValueChanged += SaleDgv_CellValueChanged;
            }
        }
    }
}


