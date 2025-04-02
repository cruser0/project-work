using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Entities.Preference;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class CostRegistryGridForm : Form
    {
        CostRegistryFilter filter = new CostRegistryFilter() { CostRegistryPage = 1 };

        private CostRegistryService _costRegistryService;
        int pages;
        double itemsPage = 10.0;
        Form _father;
        Task<ICollection<CostRegistryDTOGet>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CostRegistryDGV> getFav;

        private UserService _userService;
        public CostRegistryGridForm()
        {
            InitializeComponent();
            _costRegistryService = new CostRegistryService();
            _userService = new UserService();

        }

        private async Task Init()
        {


            CostRegistryDgv.ReadOnly = true;

            pages = (int)Math.Ceiling(await _costRegistryService.Count(new CostRegistryFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CostRegistryDgv.ContextMenuStrip = RightClickDgv;
            //if (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "CostRegistryAdmin", "Admin" }))
            //{
            //    CostRegistryIDTsmi.Visible = false;
            //    CostRegistryOriginalIDTsmi.Visible = false;
            //}
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;

            filter = searchCostRegistry1.GetFilter();
            filter.CostRegistryPage = PaginationUserControl.CurrentPage;
            CostRegistryFilter filterPage = searchCostRegistry1.GetFilter();

            var query = _costRegistryService.GetAll(filter);
            var totalCount = _costRegistryService.Count(filterPage);
            await Task.WhenAll(query, totalCount);
            IEnumerable<CostRegistryDTOGet> query1 = await query;

            CostRegistryDgv.DataSource = query1.ToList();

            PaginationUserControl.maxPage = ((int)Math.Ceiling(await totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }

        private async Task SetCheckBoxes()
        {
            //await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            List<CostRegistryDTOGet> query = (await getAllNotFiltered).ToList();
            int mPage = (int)Math.Ceiling(await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CostRegistryDgv.DataSource = query.ToList();



            CostRegistryDGV cdgv = await getFav;
            CostRegistryIDTsmi.Checked = (bool)cdgv.ShowRegistryID;
            CostRegistryCodeTsmi.Checked = (bool)cdgv.ShowRegistryCode;
            CostRegistryCostTsmi.Checked =(bool)cdgv.ShowRegistryPrice;
            CostRegistryQuantityTsmi.Checked =(bool)cdgv.ShowRegistryQuantity;
            CostRegistryNameTsmi.Checked =(bool)cdgv.ShowRegistryName;

            CostRegistryDgv.Columns["IsPost"].Visible = false;

            CostRegistryDgv.Columns["CostRegistryName"].Visible = (bool)cdgv.ShowRegistryName;
            CostRegistryDgv.Columns["CostRegistryUniqueCode"].Visible = (bool)cdgv.ShowRegistryCode;
            CostRegistryDgv.Columns["CostRegistryPrice"].Visible = (bool)cdgv.ShowRegistryPrice;
            CostRegistryDgv.Columns["CostRegistryQuantity"].Visible = (bool)cdgv.ShowRegistryQuantity;
            CostRegistryDgv.Columns["CostRegistryID"].Visible = (bool)cdgv.ShowRegistryID;

            CostRegistryDgv.Columns["CostRegistryName"].HeaderText = "Cost Registry Default Description";
            CostRegistryDgv.Columns["CostRegistryUniqueCode"].HeaderText = "Cost Registry  Unique Code";
            CostRegistryDgv.Columns["CostRegistryPrice"].HeaderText = "Cost Registry Default Price";
            CostRegistryDgv.Columns["CostRegistryQuantity"].HeaderText = "Cost Registry Default Quantity";
            CostRegistryDgv.Columns["CostRegistryID"].HeaderText = "Cost Registry ID";
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.CostRegistryPage = PaginationUserControl.CurrentPage;
            IEnumerable<CostRegistryDTOGet> query = await _costRegistryService.GetAll(filter);
            CostRegistryDgv.DataSource = query.ToList();
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

            //if (sender is DataGridView dgv)
            //{
            //    if (_father is CreateDetailsSaleForm csf)
            //    {
            //        csf.SetCostRegistryID(dgv.CurrentRow.Cells["CostRegistryID"].Value.ToString());
            //        csf.SetCostRegistryNameCountry(dgv.CurrentRow.Cells["CostRegistryName"].Value.ToString(), dgv.CurrentRow.Cells["Country"].Value.ToString());
            //    }
            //}
        }

        public void CostRegistryGridForm_Resize(object sender, EventArgs e)
        {

            panel5.Location = new System.Drawing.Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new System.Drawing.Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }

        }

        private void CostRegistryDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CostRegistryDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CostRegistryDgv, e.Location);
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
                    case "CostRegistryNameTsmi":
                        CostRegistryDgv.Columns["CostRegistryName"].Visible = tsmi.Checked;
                        break;
                    case "CostRegistryIDTsmi":
                        CostRegistryDgv.Columns["CostRegistryID"].Visible = tsmi.Checked;
                        break;
                    case "CostRegistryCodeTsmi":
                        CostRegistryDgv.Columns["CostRegistryUniqueCode"].Visible = tsmi.Checked;
                        break;
                    case "CostRegistryCostTsmi":
                        CostRegistryDgv.Columns["CostRegistryPrice"].Visible = tsmi.Checked;
                        break;
                    case "CostRegistryQuantityTsmi":
                        CostRegistryDgv.Columns["CostRegistryQuantity"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CostRegistryDGV cdgv = new CostRegistryDGV
                {
                    ShowRegistryName = CostRegistryNameTsmi.Checked,
                    ShowRegistryID = CostRegistryIDTsmi.Checked,
                    ShowRegistryCode = CostRegistryCodeTsmi.Checked,
                    ShowRegistryPrice = CostRegistryCostTsmi.Checked,
                    ShowRegistryQuantity = CostRegistryQuantityTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCostRegistryDGV(cdgv);
            }
        }

        private async void CostRegistryGridForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            await Init();
            getAllNotFiltered = _costRegistryService.GetAll(filter);
            countNotFiltered = _costRegistryService.Count(new CostRegistryFilter());



            
            getFav = _userService.GetCostRegistryDGV();
            PaginationUserControl.Visible = true;

            await SetCheckBoxes();
        }


        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this CostRegistrys!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in CostRegistryDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (CostRegistryDgv.Rows[rowid].DataBoundItem is CostRegistryDTOGet costRegistry)
                            id.Add((int)costRegistry.CostRegistryID);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _costRegistryService.MassDelete(id);
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

        private void CostRegistryDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                List<CostRegistryDTOGet> modifiedEntities = new List<CostRegistryDTOGet>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (CostRegistryDgv.Rows[rowIndex].DataBoundItem is CostRegistryDTOGet entity)
                    {
                        modifiedEntities.Add(entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _costRegistryService.MassUpdate(modifiedEntities);
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
            CostRegistryDgv.ReadOnly = !CostRegistryDgv.ReadOnly;

            if (CostRegistryDgv.ReadOnly) // Modalità visualizzazione
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
                        CostRegistryDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                CostRegistryDgv.Cursor = Cursors.Default;
                CostRegistryDgv.CellDoubleClick += MyControl_OpenDetails_Clicked;
                CostRegistryDgv.CellValueChanged -= CostRegistryDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                CostRegistryDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                CostRegistryDgv.CellDoubleClick -= MyControl_OpenDetails_Clicked;
                CostRegistryDgv.CellValueChanged += CostRegistryDgv_CellValueChanged;
            }
        }
    }
}
