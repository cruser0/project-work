using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Entities.Preference;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class CustomerInvoiceCostGridForm : Form
    {
        CustomerInvoiceCostFilter filter = new CustomerInvoiceCostFilter() { CustomerInvoiceCostPage = 1 };

        CustomerInvoiceCostService _customerInvoiceCostService;
        int pages;
        double itemsPage = 10.0;
        UserService _userService;
        Task<ICollection<CustomerInvoiceCost>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerInvoiceCostDGV> getFav;
        public CustomerInvoiceCostGridForm()
        {
            Init();

        }

        private async void Init()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            InitializeComponent();
            _userService = new UserService();

            pages = (int)Math.Ceiling(await _customerInvoiceCostService.Count(new CustomerInvoiceCostFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerInvoiceCostDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerInvoiceCostAdmin", "Admin" }))
                CustomerInvoiceCostIDTsmi.Visible = false;
        }

        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;


            filter = searchCustomerInvoiceCost1.GetFilter();
            filter.CustomerInvoiceCostPage = PaginationUserControl.CurrentPage;

            CustomerInvoiceCostFilter filterPage = searchCustomerInvoiceCost1.GetFilter();

            var getAllTask = _customerInvoiceCostService.GetAll(filter);
            var countTask = _customerInvoiceCostService.Count(filterPage);

            await Task.WhenAll(getAllTask, countTask);



            IEnumerable<CustomerInvoiceCost> query = await getAllTask;
            int totalCount = await countTask;

            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl($"{PaginationUserControl.CurrentPage}/{PaginationUserControl.GetmaxPage()}");

            CustomerInvoiceCostDgv.DataSource = query.ToList();

        }
        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<CustomerInvoiceCost> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerInvoiceCostDgv.DataSource = query.ToList();
            CustomerInvoiceCostDGV cdgv = await getFav;

            CustomerInvoiceCostCostTsmi.Checked = cdgv.ShowCost;
            CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked = cdgv.ShowInvoiceID;
            CustomerInvoiceCostIDTsmi.Checked = cdgv.ShowID;
            CustomerInvoiceCostNameTsmi.Checked = cdgv.ShowName;
            CustomerInvoiceCostQuantityTsmi.Checked = cdgv.ShowQuantity;
            CustomerInvoiceCostDgv.Columns["CustomerInvoiceCostsID"].Visible = cdgv.ShowID;
            CustomerInvoiceCostDgv.Columns["CustomerInvoiceID"].Visible = cdgv.ShowInvoiceID;
            CustomerInvoiceCostDgv.Columns["Cost"].Visible = cdgv.ShowCost;
            CustomerInvoiceCostDgv.Columns["Quantity"].Visible = cdgv.ShowQuantity;
            CustomerInvoiceCostDgv.Columns["Name"].Visible = cdgv.ShowName;
            PaginationUserControl.Visible = true;

        }

        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            filter.CustomerInvoiceCostPage = PaginationUserControl.CurrentPage;

            IEnumerable<CustomerInvoiceCost> query = await _customerInvoiceCostService.GetAll(filter);
            CustomerInvoiceCostDgv.DataSource = query.ToList();
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

            PaginationPanel.Location = new System.Drawing.Point((Width - PaginationPanel.Width) / 2, 0);
            PaginationUserControl.Location = new System.Drawing.Point((PaginationPanel.Width - PaginationUserControl.Width) / 2, (PaginationPanel.Height - PaginationUserControl.Height) / 2);

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
                var hitTest = CustomerInvoiceCostDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CustomerInvoiceCostDgv, e.Location);
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
                    case "CustomerInvoiceCostIDTsmi":
                        CustomerInvoiceCostDgv.Columns["CustomerInvoiceCostsID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCustomerInvoiceIDTsmi":
                        CustomerInvoiceCostDgv.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCostTsmi":
                        CustomerInvoiceCostDgv.Columns["Cost"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostQuantityTsmi":
                        CustomerInvoiceCostDgv.Columns["Quantity"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostNameTsmi":
                        CustomerInvoiceCostDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerInvoiceCostDGV cdgv = new CustomerInvoiceCostDGV
                {
                    ShowCost = CustomerInvoiceCostCostTsmi.Checked,
                    ShowQuantity = CustomerInvoiceCostQuantityTsmi.Checked,
                    ShowName = CustomerInvoiceCostNameTsmi.Checked,
                    ShowID = CustomerInvoiceCostIDTsmi.Checked,
                    ShowInvoiceID = CustomerInvoiceCostCustomerInvoiceIDTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceCostDGV(cdgv);

            }
        }

        private async void CustomerInvoiceCostGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostPage = 1 });
            countNotFiltered = _customerInvoiceCostService.Count(new CustomerInvoiceCostFilter());
            getFav = _userService.GetCustomerInvoiceCostDGV();
            await SetCheckBoxes();
        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Customer Invoice Cost!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in CustomerInvoiceCostDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (CustomerInvoiceCostDgv.Rows[rowid].DataBoundItem is CustomerInvoiceCost customer)
                            id.Add(customer.CustomerInvoiceCostsId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _customerInvoiceCostService.MassDelete(id);
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
            UtilityFunctions.Pdf_ClickBtn(CustomerInvoiceCostDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(CustomerInvoiceCostDgv, this);
        }

        private HashSet<int> modifiedRows = new HashSet<int>();

        private void CustomerInvoiceCostDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                List<CustomerInvoiceCost> modifiedEntities = new List<CustomerInvoiceCost>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (CustomerInvoiceCostDgv.Rows[rowIndex].DataBoundItem is CustomerInvoiceCost entity)
                    {
                        modifiedEntities.Add(entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _customerInvoiceCostService.MassUpdate(modifiedEntities);
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
            CustomerInvoiceCostDgv.ReadOnly = !CustomerInvoiceCostDgv.ReadOnly;

            if (CustomerInvoiceCostDgv.ReadOnly) // Modalità visualizzazione
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
                        CustomerInvoiceCostDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                CustomerInvoiceCostDgv.Cursor = Cursors.Default;
                CustomerInvoiceCostDgv.CellDoubleClick += MyControl_OpenDetails_Clicked;
                CustomerInvoiceCostDgv.CellValueChanged -= CustomerInvoiceCostDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                CustomerInvoiceCostDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                CustomerInvoiceCostDgv.CellDoubleClick -= MyControl_OpenDetails_Clicked;
                CustomerInvoiceCostDgv.CellValueChanged += CustomerInvoiceCostDgv_CellValueChanged;
            }
        }
    }
}
