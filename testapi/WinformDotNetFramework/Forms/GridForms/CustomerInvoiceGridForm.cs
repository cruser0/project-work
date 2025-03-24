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
        Task<ICollection<CustomerInvoice>> getAllNotFiltered;
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
            Init();
        }
        public CustomerInvoiceGridForm(CreateCustomerInvoiceCostForm father)
        {
            _father = father;
            Init();
            toolStrip1.Visible = false;
        }

        private async void Init()
        {
            _userService = new UserService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();

            pages = (int)Math.Ceiling(await _customerInvoiceService.Count(new CustomerInvoiceFilter()) / itemsPage);

            PaginationUserControl.CurrentPage = 1;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
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


            IEnumerable<CustomerInvoice> query1 = await query;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
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
            IEnumerable<CustomerInvoice> query = await getAllNotFiltered;
            int mPage = (int)Math.Ceiling((double)await countNotFiltered / itemsPage);
            if (mPage <= 0)
                mPage = 1;

            PaginationUserControl.maxPage = mPage.ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CenterDgv.DataSource = query.ToList();
            CustomerInvoiceDGV cdgv = await getFav;

            CustomerInvoiceDateTsmi.Checked = cdgv.ShowDate;
            CustomerInvoiceIDTsmi.Checked = cdgv.ShowID;
            CustomerInvoiceInvoiceAmountTsmi.Checked = cdgv.ShowInvoiceAmount;
            CustomerInvoiceSaleIDTsmi.Checked = cdgv.ShowSaleID;
            CustomerInvoiceStatusTsmi.Checked = cdgv.ShowStatus;
            CenterDgv.Columns["CustomerInvoiceID"].Visible = cdgv.ShowID;
            CenterDgv.Columns["SaleID"].Visible = cdgv.ShowSaleID;
            CenterDgv.Columns["InvoiceAmount"].Visible = cdgv.ShowInvoiceAmount;
            CenterDgv.Columns["InvoiceDate"].Visible = cdgv.ShowDate;
            CenterDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {

            filter.CustomerInvoicePage = PaginationUserControl.CurrentPage;


            IEnumerable<CustomerInvoice> query = await _customerInvoiceService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        public virtual void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateCustomerInvoiceCostForm csif)
                {
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString());
                    csif.SetCustomerInvoiceID(dgv.CurrentRow.Cells["CustomerInvoiceCode"].Value.ToString());
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
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerInvoiceDGV(cdgv);
            }
        }

        private async void CustomerInvoiceGridForm_Load(object sender, EventArgs e)
        {
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
                        if (CenterDgv.Rows[rowid].DataBoundItem is CustomerInvoice customer)
                            id.Add(customer.CustomerInvoiceId);
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
        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Pdf_ClickBtn(CenterDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(CenterDgv, this);
        }

        private HashSet<int> modifiedRows = new HashSet<int>();

        private void CenterDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                List<CustomerInvoice> modifiedEntities = new List<CustomerInvoice>();

                // Itera solo sulle righe che sono state modificate
                foreach (int rowIndex in modifiedRows)
                {
                    if (CenterDgv.Rows[rowIndex].DataBoundItem is CustomerInvoice entity)
                    {
                        modifiedEntities.Add(entity);
                    }
                }

                if (modifiedEntities.Count > 0)
                {
                    string message = await _customerInvoiceService.MassUpdate(modifiedEntities);
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
            CenterDgv.ReadOnly = !CenterDgv.ReadOnly;

            if (CenterDgv.ReadOnly) // Modalità visualizzazione
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
                        CenterDgv.ReadOnly = false;
                        return;
                    }

                    // Reset modifiche solo se l'utente conferma
                    MyControl_ButtonClicked_Pagination(this, EventArgs.Empty);
                    modifiedRows.Clear();
                }

                // Ripristina modalità visualizzazione
                CenterDgv.Cursor = Cursors.Default;
                CenterDgv.CellDoubleClick += CenterDgv_CellDoubleClick;
                CenterDgv.CellValueChanged -= CenterDgv_CellValueChanged;
            }
            else // Modalità modifica attivata
            {
                CenterDgv.Cursor = Cursors.IBeam; // Migliore per l'editing di testo
                CenterDgv.CellDoubleClick -= CenterDgv_CellDoubleClick;
                CenterDgv.CellValueChanged += CenterDgv_CellValueChanged;
            }
        }
    }
}
