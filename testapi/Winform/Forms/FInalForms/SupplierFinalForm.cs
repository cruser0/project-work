using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms.FInalForms
{
    public partial class SupplierFinalForm : Form
    {
        private ValueService _valueService;

        SupplierFilter supplierFilter;
        SupplierInvoiceFilter supplierInvoiceFilter;
        SupplierInvoiceCostFilter supplierInvoiceCostFilter;

        supplierGroupDTO data;

        private int pageSize = 10; // Numero di righe per pagina

        private int supplierCurrentPage = 1;
        private int supplierTotalRecords;
        private int supplierTotalPages;
        private List<Supplier> allSuppliers = new List<Supplier>(); // Lista completa dei supplier

        private int supplierInvoiceCurrentPage = 1;
        private int supplierInvoiceTotalRecords;
        private int supplierInvoiceTotalPages;
        private List<SupplierInvoice> allSupplierInvoices = new List<SupplierInvoice>(); // Lista completa dei supplier inv

        private int supplierInvoiceCostCurrentPage = 1;
        private int supplierInvoiceCostTotalRecords;
        private int supplierInvoiceCostTotalPages;
        private List<SupplierInvoiceCost> allSupplierInvoiceCosts = new List<SupplierInvoiceCost>(); // Lista completa dei supplier inv cost

        public SupplierFinalForm()
        {
            _valueService = new ValueService();
            InitializeComponent();
        }

        private void SupplierFinalForm_Load(object sender, EventArgs e)
        {
            int minSize = searchSupplier1.Width + 30;
            MainSplitContainer.Panel2MinSize = minSize;
            MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
            panel1.Width = flowLayoutPanel1.Width;


            supplierFilter = searchSupplier1.GetFilter();

            supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();

            supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

            data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SuppliersSource.DataSource = data.suppliers;
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSuppliers = (List<Supplier>)SuppliersSource.DataSource;

            if (allSuppliers.Any())
            {
                allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                    .Where(x => x.SupplierId == allSuppliers.First().SupplierId)
                    .ToList();
            }
            else
            {
                allSupplierInvoices = new List<SupplierInvoice>();
            }

            if (allSupplierInvoices.Any())
            {
                allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                    .Where(x => x.SupplierInvoiceId == allSupplierInvoices.First().InvoiceId)
                    .ToList();
            }
            else
            {
                allSupplierInvoiceCosts = new List<SupplierInvoiceCost>();
            }


            supplierTotalRecords = allSuppliers.Count;
            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;
            LoadTableSupplier();
            LoadTableSupplierInvoice();
            LoadTableSupplierInvoicecost();
        }

        private void LoadTableSupplier()
        {
            var supplierPagedData = allSuppliers.Skip((supplierCurrentPage - 1) * pageSize).Take(pageSize).ToList();
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
            var supplierInvoicePagedData = allSupplierInvoices.Skip((supplierInvoiceCurrentPage - 1) * pageSize).Take(pageSize).ToList();
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
            var supplierInvoiceCostPagedData = allSupplierInvoiceCosts.Skip((supplierInvoiceCostCurrentPage - 1) * pageSize).Take(pageSize).ToList();
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
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
                    }
                    break;
                case "Right2":
                    if (supplierInvoiceCurrentPage < supplierInvoiceTotalPages)
                    {
                        supplierInvoiceCurrentPage++;
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
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
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
                    }
                    break;
                case "DoubleRight2":
                    if (supplierInvoiceCurrentPage < supplierInvoiceTotalPages)
                    {
                        supplierInvoiceCurrentPage = supplierInvoiceTotalPages;
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
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
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
                    }
                    break;
                case "Left2":
                    if (supplierInvoiceCurrentPage > 1)
                    {
                        supplierInvoiceCurrentPage--;
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
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
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
                    }
                    break;
                case "DoubleLeft2":
                    if (supplierInvoiceCurrentPage > 1)
                    {
                        supplierInvoiceCurrentPage = 1;
                        LoadTableSupplierInvoice();
                        ChangedSupplierInvoiceDgv();
                        LoadTableSupplierInvoicecost();
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            supplierFilter = searchSupplier1.GetFilter();

            supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();

            supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

            data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SuppliersSource.DataSource = data.suppliers;
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSuppliers = (List<Supplier>)SuppliersSource.DataSource;

            if (allSuppliers.Count > 0)
                allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                    .Where(x => x.SupplierId == data.suppliers.First().SupplierId).ToList();
            else
                allSupplierInvoices = new List<SupplierInvoice>();

            if (allSupplierInvoices.Count > 0)
                allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                .Where(x => x.SupplierInvoiceId == data.invoices.First().InvoiceId).ToList();
            else
                allSupplierInvoiceCosts = new List<SupplierInvoiceCost>();

            supplierTotalRecords = allSuppliers.Count;
            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

            supplierCurrentPage = 1;
            supplierInvoiceCurrentPage = 1;
            supplierInvoiceCostCurrentPage = 1;

            LoadTableSupplier();
            LoadTableSupplierInvoice();
            LoadTableSupplierInvoicecost();
        }

        private void SupplierDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;


            data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            ChangedSupplierDgv();

            LoadTableSupplierInvoice();
            LoadTableSupplierInvoicecost();
        }

        private void SupInvoiceDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            ChangedSupplierInvoiceDgv();

            LoadTableSupplierInvoicecost();
        }

        private void ChangedSupplierDgv()
        {
            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                .Where(x => x.SupplierId == (int?)SupplierDgv.CurrentRow.Cells["SupplierID"].Value).ToList();

            if (allSupplierInvoices.Count > 0)
                allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                    .Where(x => x.SupplierInvoiceId == data.invoices.Where(x => x.SupplierId == (int?)SupplierDgv.CurrentRow.Cells["SupplierID"].Value).ToList().First().InvoiceId).ToList();
            else
                allSupplierInvoiceCosts = new List<SupplierInvoiceCost>();

            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

            supplierInvoiceCurrentPage = 1;
            supplierInvoiceCostCurrentPage = 1;
        }

        private void ChangedSupplierInvoiceDgv()
        {
            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                .Where(x => x.SupplierId == (int?)SupplierDgv.CurrentRow.Cells["SupplierID"].Value).ToList();

            if (allSupplierInvoices.Count > 0)
                allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                .Where(x => x.SupplierInvoiceId == (int?)SupInvoiceDgv.CurrentRow.Cells["InvoiceID"].Value).ToList();
            else
                allSupplierInvoiceCosts = new List<SupplierInvoiceCost>();

            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

            supplierInvoiceCurrentPage = 1;
            supplierInvoiceCostCurrentPage = 1;
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
            if (DockButton.Text == ">")
            {
                int minSize = searchSupplier1.Width + 30;
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
