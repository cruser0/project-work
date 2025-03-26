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
        public SupplierGridForm(SupplierInvoiceDetailsForm father)
        {
            _father = father;
            Init();
            toolStrip1.Visible = false;
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

            IEnumerable<Supplier> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<Supplier> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling((double)await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();


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
            filter.SupplierPage = PaginationUserControl.CurrentPage;

            IEnumerable<Supplier> query = await _supplierService.GetAll(filter);
            SupplierDgv.DataSource = query.ToList();
        }

        public virtual void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if(_father is SupplierInvoiceDetailsForm sidf)
                {
                    sidf.SetSupplierID(dgv.CurrentRow.Cells["SupplierID"].Value.ToString());
                    sidf.SetSupplierNameCoutnry(dgv.CurrentRow.Cells["SupplierName"].Value.ToString(), dgv.CurrentRow.Cells["Country"].Value.ToString());
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


        private HashSet<int> modifiedRows = new HashSet<int>();

        private void SupplierDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                List<Supplier> modifiedEntities = new List<Supplier>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (SupplierDgv.Rows[rowIndex].DataBoundItem is Supplier entity)
                    {
                        modifiedEntities.Add(entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _supplierService.MassUpdate(modifiedEntities);
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
            SupplierDgv.ReadOnly = !SupplierDgv.ReadOnly;

            if (SupplierDgv.ReadOnly) // Modalità visualizzazione
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
                        SupplierDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                SupplierDgv.Cursor = Cursors.Default;
                SupplierDgv.CellDoubleClick += SupplierDgv_CellDoubleClick;
                SupplierDgv.CellValueChanged -= SupplierDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                SupplierDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                SupplierDgv.CellDoubleClick -= SupplierDgv_CellDoubleClick;
                SupplierDgv.CellValueChanged += SupplierDgv_CellValueChanged;
            }
        }
    }
}
