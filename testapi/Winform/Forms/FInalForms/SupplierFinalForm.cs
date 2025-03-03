using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.FInalForms
{
    public partial class SupplierFinalForm : Form
    {
        private SupplierService _supplierService;
        private SupplierInvoiceService _supplierInvoiceService;
        private SupplierInvoiceCostService _supplierInvoiceCostService;
        private ValueService _valueService;

        SupplierFilter supplierFilter;
        SupplierInvoiceFilter supplierInvoiceFilter;
        SupplierInvoiceCostFilter supplierInvoiceCostFilter;


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
            _supplierService = new SupplierService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            _valueService = new ValueService();

            InitializeComponent();
        }

        private void SupplierFinalForm_Load(object sender, EventArgs e)
        {
            supplierFilter = searchSupplier1.GetFilter();

            supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();

            supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

            var data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SuppliersSource.DataSource = data.suppliers;
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSuppliers = (List<Supplier>)SuppliersSource.DataSource;
            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource).Where(x => x.SupplierId == allSuppliers.First().SupplierId).ToList();
            allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource).Where(x => x.SupplierInvoiceId == allSupplierInvoices.First().InvoiceId).ToList();

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
            supplierTotalPages = (int)Math.Ceiling((double)supplierTotalRecords / pageSize);
            TSLbl1.Text = $"Pagina {supplierCurrentPage} di {supplierTotalPages}";
        }
        private void LoadTableSupplierInvoice()
        {
            var supplierInvoicePagedData = allSupplierInvoices.Skip((supplierInvoiceCurrentPage - 1) * pageSize).Take(pageSize).ToList();
            SupInvoiceDgv.DataSource = supplierInvoicePagedData;
            supplierInvoiceTotalPages = (int)Math.Ceiling((double)supplierInvoiceTotalRecords / pageSize);
            TSLbl2.Text = $"Pagina {supplierInvoiceCurrentPage} di {supplierInvoiceTotalPages}";
        }
        private void LoadTableSupplierInvoicecost()
        {
            var supplierInvoiceCostPagedData = allSupplierInvoiceCosts.Skip((supplierInvoiceCostCurrentPage - 1) * pageSize).Take(pageSize).ToList();
            SupInvoiceCostDgv.DataSource = supplierInvoiceCostPagedData;
            supplierInvoiceCostTotalPages = (int)Math.Ceiling((double)supplierInvoiceCostTotalRecords / pageSize);
            TSLbl3.Text = $"Pagina {supplierInvoiceCostCurrentPage} di {supplierInvoiceCostTotalPages}";
        }

        private void NextSupplier_click(object sender, EventArgs e)
        {
            if (supplierCurrentPage < supplierTotalPages)
            {
                supplierCurrentPage++;
                LoadTableSupplier();
            }
        }
        private void NextSupplierInvoice_click(object sender, EventArgs e)
        {
            if (supplierInvoiceCurrentPage < supplierInvoiceTotalPages)
            {
                supplierInvoiceCurrentPage++;
                LoadTableSupplierInvoice();
            }
        }
        private void NextSupplierInvoieCost_click(object sender, EventArgs e)
        {
            if (supplierInvoiceCostCurrentPage < supplierInvoiceCostTotalPages)
            {
                supplierInvoiceCostCurrentPage++;
                LoadTableSupplierInvoicecost();
            }
        }

        private void PreviousSupplier_click(object sender, EventArgs e)
        {
            if (supplierCurrentPage > 1)
            {
                supplierCurrentPage--;
                LoadTableSupplier();
            }
        }
        private void PreviousSupplierInvoice_click(object sender, EventArgs e)
        {
            if (supplierInvoiceCurrentPage > 1)
            {
                supplierInvoiceCurrentPage--;
                LoadTableSupplierInvoice();
            }
        }
        private void PreviousSupplierInvoiceCost_click(object sender, EventArgs e)
        {
            if (supplierInvoiceCostCurrentPage > 1)
            {
                supplierInvoiceCostCurrentPage--;
                LoadTableSupplierInvoicecost();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            supplierFilter = searchSupplier1.GetFilter();

            supplierInvoiceFilter = searchSupplierInvoice1.GetFilter();

            supplierInvoiceCostFilter = searchSupplierInvoiceCost1.GetFilter();

            var data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SuppliersSource.DataSource = data.suppliers;
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSuppliers = (List<Supplier>)SuppliersSource.DataSource;
            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                .Where(x => x.SupplierId == data.suppliers.First().SupplierId).ToList();
            allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                .Where(x => x.SupplierInvoiceId == data.invoices.First().InvoiceId).ToList();

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


            var data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                .Where(x => x.SupplierId == (int?)dgv.CurrentRow.Cells["SupplierID"].Value).ToList();
            allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                .Where(x => x.SupplierInvoiceId == data.invoices.First().InvoiceId).ToList();

            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

            supplierInvoiceCurrentPage = 1;
            supplierInvoiceCostCurrentPage = 1;

            LoadTableSupplierInvoice();
            LoadTableSupplierInvoicecost();
        }

        private void SupInvoiceDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            var data = _valueService.GetSupplierTables(supplierFilter, supplierInvoiceFilter, supplierInvoiceCostFilter);
            SupplierInvoiceSource.DataSource = data.invoices;
            SupplierInvoicecostSource.DataSource = data.invoiceCosts;

            allSupplierInvoices = ((List<SupplierInvoice>)SupplierInvoiceSource.DataSource)
                .Where(x => x.SupplierId == (int?)SupplierDgv.CurrentRow.Cells["SupplierID"].Value).ToList();
            allSupplierInvoiceCosts = ((List<SupplierInvoiceCost>)SupplierInvoicecostSource.DataSource)
                .Where(x => x.SupplierInvoiceId == (int?)dgv.CurrentRow.Cells["InvoiceID"].Value).ToList();

            supplierInvoiceTotalRecords = allSupplierInvoices.Count;
            supplierInvoiceCostTotalRecords = allSupplierInvoiceCosts.Count;

            supplierInvoiceCurrentPage = 1;
            supplierInvoiceCostCurrentPage = 1;

            LoadTableSupplierInvoicecost();
        }
    }
}
