using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GroupForms
{
    public partial class SupplierGroupForm : Form
    {
        private ValueService _valueService;

        SupplierFilter supplierFilter;
        SupplierInvoiceFilter supplierInvoiceFilter;
        SupplierInvoiceCostFilter supplierInvoiceCostFilter;

        SupplierGroupDTO data;

        // Dictionary for quicker lookup of related data
        private Dictionary<int, List<SupplierInvoiceDTOGet>> supplierInvoicesMap;
        private Dictionary<int, List<SupplierInvoiceCostDTOGet>> invoiceCostsMap;

        private int pageSize = 10; // Numero di righe per pagina

        private int supplierCurrentPage = 1;
        private int supplierTotalRecords;
        private int supplierTotalPages;
        private List<SupplierDTOGet> allSuppliers = new List<SupplierDTOGet>(); // Lista completa dei supplier

        private int supplierInvoiceCurrentPage = 1;
        private int supplierInvoiceTotalRecords;
        private int supplierInvoiceTotalPages;
        private List<SupplierInvoiceDTOGet> allSupplierInvoices = new List<SupplierInvoiceDTOGet>(); // Lista completa dei supplier inv

        private int supplierInvoiceCostCurrentPage = 1;
        private int supplierInvoiceCostTotalRecords;
        private int supplierInvoiceCostTotalPages;
        private List<SupplierInvoiceCostDTOGet> allSupplierInvoiceCosts = new List<SupplierInvoiceCostDTOGet>(); // Lista completa dei supplier inv cost

        public SupplierGroupForm()
        {
            _valueService = new ValueService();
            InitializeComponent();
            if (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" }) && (!UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }, true)))
            {
                HideMenuItems();
            }


        }

        private void HideMenuItems()
        {
            showIDToolStripMenuItem.Visible = false;
            showIDToolStripMenuItem1.Visible = false;
            showIDToolStripMenuItem2.Visible = false;
            showOriginalIDToolStripMenuItem.Visible = false;
            showSupplierIDToolStripMenuItem.Visible = false;
        }

        private async void SupplierFinalForm_Load(object sender, EventArgs e)
        {
            int minSize = 230;
            MainSplitContainer.Panel2MinSize = minSize;
            MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
            panel1.Width = flowLayoutPanel1.Width;

            supplierFilter = searchSupplier1.GetFilter();
            supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();
            supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

            await LoadData();
        }

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                data = await _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);

                // Preprocess data for faster lookups
                PreprocessData();

                SuppliersSource.DataSource = data.suppliers;
                SupplierInvoiceSource.DataSource = data.invoices;
                SupplierInvoicecostSource.DataSource = data.invoiceCosts;

                allSuppliers = data.suppliers.ToList();
                supplierTotalRecords = allSuppliers.Count;

                // Initialize related data
                if (allSuppliers.Any())
                {
                    int firstSupplierId = allSuppliers.First().SupplierId;
                    allSupplierInvoices = supplierInvoicesMap.ContainsKey(firstSupplierId)
                        ? supplierInvoicesMap[firstSupplierId]
                        : new List<SupplierInvoiceDTOGet>();
                }
                else
                {
                    allSupplierInvoices = new List<SupplierInvoiceDTOGet>();
                }
                supplierInvoiceTotalRecords = allSupplierInvoices.Count;

                // Initialize invoice costs
                if (allSupplierInvoices.Any())
                {
                    int firstInvoiceId = allSupplierInvoices.First().InvoiceId;
                    allSupplierInvoiceCosts = invoiceCostsMap.ContainsKey(firstInvoiceId)
                        ? invoiceCostsMap[firstInvoiceId]
                        : new List<SupplierInvoiceCostDTOGet>();
                }
                else
                {
                    allSupplierInvoiceCosts = new List<SupplierInvoiceCostDTOGet>();
                }
                supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

                LoadTableSupplier();
                LoadTableSupplierInvoice();
                LoadTableSupplierInvoicecost();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void PreprocessData()
        {
            // Create lookup dictionaries for faster access
            supplierInvoicesMap = new Dictionary<int, List<SupplierInvoiceDTOGet>>();
            invoiceCostsMap = new Dictionary<int, List<SupplierInvoiceCostDTOGet>>();

            // Group invoices by supplier ID
            foreach (var invoice in data.invoices)
            {
                if (invoice.SupplierId.HasValue)
                {
                    int supplierId = invoice.SupplierId.Value;
                    if (!supplierInvoicesMap.ContainsKey(supplierId))
                    {
                        supplierInvoicesMap[supplierId] = new List<SupplierInvoiceDTOGet>();
                    }
                    supplierInvoicesMap[supplierId].Add(invoice);
                }
            }

            // Group invoice costs by invoice ID
            foreach (var cost in data.invoiceCosts)
            {
                if (!invoiceCostsMap.ContainsKey((int)cost.SupplierInvoiceId))
                {
                    invoiceCostsMap[(int)cost.SupplierInvoiceId] = new List<SupplierInvoiceCostDTOGet>();
                }
                invoiceCostsMap[(int)cost.SupplierInvoiceId].Add(cost);
            }
        }

        private void LoadTableSupplier()
        {
            var supplierPagedData = allSuppliers
                .Skip((supplierCurrentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            SupplierDgv.DataSource = supplierPagedData;

            SupplierDgv.Columns["SupplierID"].Visible = showIDToolStripMenuItem.Checked;
            SupplierDgv.Columns["SupplierName"].Visible = showNameToolStripMenuItem.Checked;
            SupplierDgv.Columns["Country"].Visible = showCountryToolStripMenuItem.Checked;
            SupplierDgv.Columns["CreatedAt"].Visible = showDateToolStripMenuItem.Checked;
            SupplierDgv.Columns["OriginalID"].Visible = showOriginalIDToolStripMenuItem.Checked;
            SupplierDgv.Columns["Deprecated"].Visible = showStatusToolStripMenuItem.Checked;

            supplierTotalPages = (int)Math.Ceiling((double)supplierTotalRecords / pageSize);
            if (supplierTotalPages > 0)
                TSLbl1.Text = $"Pagina {supplierCurrentPage} di {supplierTotalPages}";
            else
                TSLbl1.Text = "There is no Data";
        }

        private void LoadTableSupplierInvoice()
        {
            var supplierInvoicePagedData = allSupplierInvoices
                .Skip((supplierInvoiceCurrentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            SupInvoiceDgv.DataSource = supplierInvoicePagedData;

            SupInvoiceDgv.Columns["InvoiceID"].Visible = showIDToolStripMenuItem2.Checked;
            SupInvoiceDgv.Columns["SaleID"].Visible = showSaleIDToolStripMenuItem.Checked;
            SupInvoiceDgv.Columns["InvoiceAmount"].Visible = showInvoiceAmountToolStripMenuItem.Checked;
            SupInvoiceDgv.Columns["InvoiceDate"].Visible = showInvoiceDateToolStripMenuItem.Checked;
            SupInvoiceDgv.Columns["Status"].Visible = showStatusToolStripMenuItem1.Checked;
            SupInvoiceDgv.Columns["SupplierID"].Visible = showSupplierIDToolStripMenuItem.Checked;

            supplierInvoiceTotalPages = (int)Math.Ceiling((double)supplierInvoiceTotalRecords / pageSize);
            if (supplierInvoiceTotalPages > 0)
                TSLbl2.Text = $"Pagina {supplierInvoiceCurrentPage} di {supplierInvoiceTotalPages}";
            else
                TSLbl2.Text = "There is no Data";
        }

        private void LoadTableSupplierInvoicecost()
        {
            var supplierInvoiceCostPagedData = allSupplierInvoiceCosts
                .Skip((supplierInvoiceCostCurrentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            SupInvoiceCostDgv.DataSource = supplierInvoiceCostPagedData;

            SupInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = showIDToolStripMenuItem1.Checked;
            SupInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = showCustomerInvoiceIDToolStripMenuItem.Checked;
            SupInvoiceCostDgv.Columns["Cost"].Visible = showCostToolStripMenuItem.Checked;
            SupInvoiceCostDgv.Columns["Quantity"].Visible = showQuantityToolStripMenuItem.Checked;
            SupInvoiceCostDgv.Columns["Name"].Visible = showDescriptionNameToolStripMenuItem.Checked;

            supplierInvoiceCostTotalPages = (int)Math.Ceiling((double)supplierInvoiceCostTotalRecords / pageSize);
            if (supplierInvoiceCostTotalPages > 0)
                TSLbl3.Text = $"Pagina {supplierInvoiceCostCurrentPage} di {supplierInvoiceCostTotalPages}";
            else
                TSLbl3.Text = "There is no Data";
        }

        private void ToolButton_click(object sender, EventArgs e)
        {
            ToolStripButton btnNext = (ToolStripButton)sender;

            switch (btnNext.Name)
            {
                case "Right":
                    if (supplierCurrentPage < supplierTotalPages)
                    {
                        supplierCurrentPage++;
                        LoadTableSupplier();
                    }
                    break;
                case "Right2":
                    if (supplierInvoiceCurrentPage < supplierInvoiceTotalPages)
                    {
                        supplierInvoiceCurrentPage++;
                        LoadTableSupplierInvoice();
                    }
                    break;
                case "Right3":
                    if (supplierInvoiceCostCurrentPage < supplierInvoiceCostTotalPages)
                    {
                        supplierInvoiceCostCurrentPage++;
                        LoadTableSupplierInvoicecost();
                    }
                    break;

                case "DoubleRight":
                    if (supplierCurrentPage < supplierTotalPages)
                    {
                        supplierCurrentPage = supplierTotalPages;
                        LoadTableSupplier();
                    }
                    break;
                case "DoubleRight2":
                    if (supplierInvoiceCurrentPage < supplierInvoiceTotalPages)
                    {
                        supplierInvoiceCurrentPage = supplierInvoiceTotalPages;
                        LoadTableSupplierInvoice();
                    }
                    break;
                case "DoubleRight3":
                    if (supplierInvoiceCostCurrentPage < supplierInvoiceCostTotalPages)
                    {
                        supplierInvoiceCostCurrentPage = supplierInvoiceCostTotalPages;
                        LoadTableSupplierInvoicecost();
                    }
                    break;

                case "Left":
                    if (supplierCurrentPage > 1)
                    {
                        supplierCurrentPage--;
                        LoadTableSupplier();
                    }
                    break;
                case "Left2":
                    if (supplierInvoiceCurrentPage > 1)
                    {
                        supplierInvoiceCurrentPage--;
                        LoadTableSupplierInvoice();
                    }
                    break;
                case "Left3":
                    if (supplierInvoiceCostCurrentPage > 1)
                    {
                        supplierInvoiceCostCurrentPage--;
                        LoadTableSupplierInvoicecost();
                    }
                    break;

                case "DoubleLeft":
                    if (supplierCurrentPage > 1)
                    {
                        supplierCurrentPage = 1;
                        LoadTableSupplier();
                    }
                    break;
                case "DoubleLeft2":
                    if (supplierInvoiceCurrentPage > 1)
                    {
                        supplierInvoiceCurrentPage = 1;
                        LoadTableSupplierInvoice();
                    }
                    break;
                case "DoubleLeft3":
                    if (supplierInvoiceCostCurrentPage > 1)
                    {
                        supplierInvoiceCostCurrentPage = 1;
                        LoadTableSupplierInvoicecost();
                    }
                    break;

                default:
                    break;
            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                supplierFilter = searchSupplier1.GetFilter();
                supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();
                supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

                supplierCurrentPage = 1;
                supplierInvoiceCurrentPage = 1;
                supplierInvoiceCostCurrentPage = 1;

                await LoadData();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SupplierDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Skip if header row is clicked

            try
            {
                Cursor = Cursors.WaitCursor;

                // Get selected supplier ID safely
                if (SupplierDgv.Rows.Count <= e.RowIndex ||
                    SupplierDgv.Rows[e.RowIndex].Cells["SupplierID"].Value == null)
                    return;

                int supplierId = (int)SupplierDgv.Rows[e.RowIndex].Cells["SupplierID"].Value;

                // Get invoices for this supplier from our lookup dictionary
                if (supplierInvoicesMap.ContainsKey(supplierId))
                {
                    allSupplierInvoices = supplierInvoicesMap[supplierId];
                }
                else
                {
                    allSupplierInvoices = new List<SupplierInvoiceDTOGet>();
                }

                supplierInvoiceTotalRecords = allSupplierInvoices.Count;
                supplierInvoiceCurrentPage = 1;

                // Reset and update invoice costs based on first invoice if available
                if (allSupplierInvoices.Any())
                {
                    int firstInvoiceId = allSupplierInvoices.First().InvoiceId;
                    if (invoiceCostsMap.ContainsKey(firstInvoiceId))
                    {
                        allSupplierInvoiceCosts = invoiceCostsMap[firstInvoiceId];
                    }
                    else
                    {
                        allSupplierInvoiceCosts = new List<SupplierInvoiceCostDTOGet>();
                    }
                }
                else
                {
                    allSupplierInvoiceCosts = new List<SupplierInvoiceCostDTOGet>();
                }

                supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;
                supplierInvoiceCostCurrentPage = 1;

                // Update UI
                LoadTableSupplierInvoice();
                LoadTableSupplierInvoicecost();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SupInvoiceDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Skip if header row is clicked

            try
            {
                Cursor = Cursors.WaitCursor;

                // Get selected invoice ID safely
                if (SupInvoiceDgv.Rows.Count <= e.RowIndex ||
                    SupInvoiceDgv.Rows[e.RowIndex].Cells["InvoiceID"].Value == null)
                    return;

                int invoiceId = (int)SupInvoiceDgv.Rows[e.RowIndex].Cells["InvoiceID"].Value;

                // Get costs for this invoice from our lookup dictionary
                if (invoiceCostsMap.ContainsKey(invoiceId))
                {
                    allSupplierInvoiceCosts = invoiceCostsMap[invoiceId];
                }
                else
                {
                    allSupplierInvoiceCosts = new List<SupplierInvoiceCostDTOGet>();
                }

                supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;
                supplierInvoiceCostCurrentPage = 1;

                // Update UI
                LoadTableSupplierInvoicecost();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == ">")
            {
                MainSplitContainer.Panel2MinSize = btn.Width;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - btn.Width;

                SearchPanel.Visible = false;
                searchSupplier1.Visible = false;
                searchSupplierInvoice1.Visible = false;
                searchSupplierInvoiceCost1.Visible = false;
                panel1.Width = flowLayoutPanel1.Width;
                btn.Text = "<";
            }
            else
            {
                searchSupplier1.Visible = true;
                searchSupplierInvoice1.Visible = true;
                searchSupplierInvoiceCost1.Visible = true;
                SearchPanel.Visible = true;

                int minSize = searchSupplier1.Width + 30;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;
                btn.Text = ">";
            }
        }

        private void SupplierFinalForm_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            if (DockButton.Text == ">")
            {
                int minSize = 230;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;
            }
            else
            {
                MainSplitContainer.Panel2MinSize = DockButton.Width;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - DockButton.Width;
                panel1.Width = flowLayoutPanel1.Width;
            }
        }

        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView target = new DataGridView();
            ContextMenuStrip ctxStrip = new ContextMenuStrip();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Name.Equals("SupplierDgv"))
            {
                target = SupplierDgv;
                ctxStrip = SupplierCtxStrip;
            }
            else if (dgv.Name.Equals("SupInvoiceDgv"))
            {
                target = SupInvoiceDgv;
                ctxStrip = SupInvoiceCtxStrip;
            }
            else if (dgv.Name.Equals("SupInvoiceCostDgv"))
            {
                target = SupInvoiceCostDgv;
                ctxStrip = SupInvoiceCostCtxStrip;
            }


            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                ctxStrip.Show(target, target.PointToClient(Cursor.Position));
        }

        private void SupplierCtxItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string text = menuItem.Text;

            switch (text)
            {
                case "Show ID":
                    SupplierDgv.Columns["SupplierID"].Visible = menuItem.Checked;
                    break;
                case "Show Name":
                    SupplierDgv.Columns["SupplierName"].Visible = menuItem.Checked;
                    break;
                case "Show Country":
                    SupplierDgv.Columns["Country"].Visible = menuItem.Checked;
                    break;
                case "Show Date":
                    SupplierDgv.Columns["CreatedAt"].Visible = menuItem.Checked;
                    break;
                case "Show Original ID":
                    SupplierDgv.Columns["OriginalID"].Visible = menuItem.Checked;
                    break;
                case "Show Status":
                    SupplierDgv.Columns["Deprecated"].Visible = menuItem.Checked;
                    break;
                default:
                    break;
            }
        }

        private void SupInvoiceCtxItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string text = menuItem.Text;

            switch (text)
            {
                case "Show ID":
                    SupInvoiceDgv.Columns["InvoiceID"].Visible = menuItem.Checked;
                    break;
                case "Show Sale ID":
                    SupInvoiceDgv.Columns["SaleID"].Visible = menuItem.Checked;
                    break;
                case "Show Invoice Amount":
                    SupInvoiceDgv.Columns["InvoiceAmount"].Visible = menuItem.Checked;
                    break;
                case "Show Invoice Date":
                    SupInvoiceDgv.Columns["InvoiceDate"].Visible = menuItem.Checked;
                    break;
                case "Show Status":
                    SupInvoiceDgv.Columns["Status"].Visible = menuItem.Checked;
                    break;
                case "Show Supplier ID":
                    SupInvoiceDgv.Columns["SupplierID"].Visible = menuItem.Checked;
                    break;
                default:
                    break;
            }
        }

        private void SupInvoiceCostCtxItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string text = menuItem.Text;

            switch (text)
            {
                case "Show ID":
                    SupInvoiceCostDgv.Columns["SupplierInvoiceCostsID"].Visible = menuItem.Checked;
                    break;
                case "Show Customer Invoice ID":
                    SupInvoiceCostDgv.Columns["SupplierInvoiceID"].Visible = menuItem.Checked;
                    break;
                case "Show Cost":
                    SupInvoiceCostDgv.Columns["Cost"].Visible = menuItem.Checked;
                    break;
                case "Show Quantity":
                    SupInvoiceCostDgv.Columns["Quantity"].Visible = menuItem.Checked;
                    break;
                case "Show Description Name":
                    SupInvoiceCostDgv.Columns["Name"].Visible = menuItem.Checked;
                    break;
                default:
                    break;
            }
        }
    }
}