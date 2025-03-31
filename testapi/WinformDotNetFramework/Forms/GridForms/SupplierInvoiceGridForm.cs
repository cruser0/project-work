using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class SupplierInvoiceGridForm : Form
    {

        SupplierInvoiceFilter filter = new SupplierInvoiceFilter() { SupplierInvoicePage = 1 };

        Form _father;
        UserService _userService;
        SupplierInvoiceService _supplierInvoiceService;
        int pages;
        double itemsPage = 10.0;
        Task<ICollection<SupplierInvoiceSupplierDTO>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<SupplierInvoiceDGV> getFav;
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

        private async Task Init()
        {
            if (DesignMode)
                return;
            _userService = new UserService();
            _supplierInvoiceService = new SupplierInvoiceService();
            pages = (int)Math.Ceiling(await _supplierInvoiceService.Count(new SupplierInvoiceFilter()) / itemsPage);

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

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
                    sigf.SetSupplierID(dgv.CurrentRow.Cells["InvoiceID"].Value.ToString());
                    sigf.SetSupplierCode(dgv.CurrentRow.Cells["SupplierInvoiceCode"].Value.ToString());

                }
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {

            filter = searchSupplierInvoice1.GetFilter();
            filter.SupplierInvoicePage = PaginationUserControl.CurrentPage;

            SupplierInvoiceFilter filterPage = searchSupplierInvoice1.GetFilter();

            var query = _supplierInvoiceService.GetAll(filter);
            var count = _supplierInvoiceService.Count(filterPage);
            await Task.WhenAll(count, query);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            IEnumerable<SupplierInvoiceSupplierDTO> query1 = await query;
            SupplierInvoiceDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
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

            SupplierInvoiceIDTsmi.Checked = cdgv.ShowID;
            SupplierInvoiceSaleIDTsmi.Checked = cdgv.ShowSaleID;
            SupplierInvoiceInvoiceAmountTsmi.Checked = cdgv.ShowInvoiceAmount;
            SupplierInvoiceDateTsmi.Checked = cdgv.ShowInvoiceDate;
            SupplierInvoiceStatusTsmi.Checked = cdgv.ShowStatus;
            SupplierInvoiceSupplierNameTsmi.Checked = cdgv.ShowSupplierName;
            SupplierInvoiceCountryTsmi.Checked = cdgv.ShowCountry;
            SupplierInvoiceSupplierIDTsmi.Checked = cdgv.ShowSupplierID;

            SupplierInvoiceDgv.Columns["InvoiceID"].Visible = cdgv.ShowID;
            SupplierInvoiceDgv.Columns["SaleID"].Visible = cdgv.ShowSaleID;
            SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = cdgv.ShowInvoiceAmount;
            SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = cdgv.ShowInvoiceDate;
            SupplierInvoiceDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            SupplierInvoiceDgv.Columns["SupplierName"].Visible = cdgv.ShowSupplierName;
            SupplierInvoiceDgv.Columns["Country"].Visible = cdgv.ShowCountry;
            SupplierInvoiceDgv.Columns["SupplierID"].Visible = cdgv.ShowSupplierID;

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
                        SupplierInvoiceDgv.Columns["InvoiceID"].Visible = tsmi.Checked;
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
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSupplierInvoiceDGV(cdgv);
            }
        }

        private async void SupplierInvoiceGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
            getAllNotFiltered = _supplierInvoiceService.GetAll(new SupplierInvoiceFilter() { SupplierInvoicePage = 1 });
            countNotFiltered = _supplierInvoiceService.Count(new SupplierInvoiceFilter());
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
                            id.Add(customer.InvoiceId);
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



        private HashSet<int> modifiedRows = new HashSet<int>();
        private void SupplierInvoiceDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                List<SupplierInvoiceDTOGet> modifiedEntities = new List<SupplierInvoiceDTOGet>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (SupplierInvoiceDgv.Rows[rowIndex].DataBoundItem is SupplierInvoiceSupplierDTO entity)
                    {
                        modifiedEntities.Add((SupplierInvoiceDTOGet)(object)entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _supplierInvoiceService.MassUpdate(modifiedEntities);
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
            SupplierInvoiceDgv.ReadOnly = !SupplierInvoiceDgv.ReadOnly;

            if (SupplierInvoiceDgv.ReadOnly) // Modalità visualizzazione
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
                        SupplierInvoiceDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                SupplierInvoiceDgv.Cursor = Cursors.Default;
                SupplierInvoiceDgv.CellDoubleClick += MyControl_OpenDetails_Clicked;
                SupplierInvoiceDgv.CellValueChanged -= SupplierInvoiceDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                SupplierInvoiceDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                SupplierInvoiceDgv.CellDoubleClick -= MyControl_OpenDetails_Clicked;
                SupplierInvoiceDgv.CellValueChanged += SupplierInvoiceDgv_CellValueChanged;
            }
        }
    }
}
