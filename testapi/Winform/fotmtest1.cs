using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.DTO;
using Winform.Services;

namespace Winform
{
    public partial class fotmtest1 : Form
    {
        private UserService _userService;
        private CustomerService _customerService;
        private CustomerInvoiceService _customerInvoiceService;
        private CustomerInvoiceCostService _customerInvoiceCostService;
        private SaleService _saleService;
        private ValueService _valueService;

        //customer filter
        string customerName;
        string customerCountry;
        bool? customerStatus;
        DateTime? customerDateFrom;
        DateTime? customerDateTo;
        int customerPages;

        //customer invoice filter
        string? CIsaleID;
        DateTime? CIinvoiceDateFrom;
        DateTime? CIinvoiceDateTo;
        int? CIinvoiceAmountFrom;
        int? CIinvoiceAmountTo;
        string CIstatus;
        int CIPages;

        //customer invoice cost filter
        int? CICinvoiceId;
        int? CICcostFrom;
        int? CICcostTo;
        string? CICname;
        int CICPages;

        //sale filter
        string salebkNumber;
        string saleblNumber;
        DateTime? salesaleDateFrom;
        DateTime? salesaleDateTo;
        int? salerevenueFrom;
        int? salerevenueTo;
        string salecustomerID;
        string salestatus;
        int salePages;

        private int pageSize = 10; // Numero di righe per pagina

        private int customerCurrentPage = 1;
        private int customerTotalRecords;
        private int customerTotalPages;
        private List<Customer> allCustomers = new List<Customer>(); // Lista completa dei clienti

        private int saleCurrentPage = 1;
        private int saleTotalRecords;
        private int saleTotalPages;
        private List<SaleCustomerDTO> allSales = new List<SaleCustomerDTO>(); // Lista completa dei clienti

        private int customerInvoiceCurrentPage = 1;
        private int customerInvoiceTotalRecords;
        private int customerInvoiceTotalPages;
        private List<CustomerInvoice> allCustomerInvoices = new List<CustomerInvoice>(); // Lista completa dei clienti

        private int customerInvoiceCostCurrentPage = 1;
        private int customerInvoiceCostTotalRecords;
        private int customerInvoiceCostTotalPages;
        private List<CustomerInvoiceCost> allCustomerInvoiceCosts = new List<CustomerInvoiceCost>(); // Lista completa dei clienti


        public fotmtest1()
        {
            _userService = new UserService();
            _customerService = new CustomerService();
            _customerInvoiceService = new CustomerInvoiceService();
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            _saleService = new SaleService();
            _valueService = new ValueService();

            _userService.Login(new UserDTO() { Email = "Admin", Password = "Admin" });

            InitializeComponent();
        }

        private void fotmtest1_Load(object sender, EventArgs e)
        {

            allCustomers = _customerService.GetAll(new CustomerFilter()).ToList();
            allSales = _saleService.GetAll(new SaleFilter() { SaleCustomerId = allCustomers.First().CustomerId }).ToList();
            allCustomerInvoices = _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceSaleId = allSales.First().SaleId }).ToList();
            allCustomerInvoiceCosts = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostCustomerInvoiceId = allCustomerInvoices.First().CustomerInvoiceId }).ToList();

            customerTotalRecords = allCustomers.Count;
            saleTotalRecords = allSales.Count;
            customerInvoiceTotalRecords = allCustomerInvoices.Count;
            customerInvoiceCostTotalRecords = allCustomerInvoiceCosts.Count;
            LoadPagedData(true, true, true, true);
        }

        private void LoadPagedData(bool c = false, bool s = false, bool ci = false, bool cic = false)
        {
            // Filtra i dati per la pagina corrente (ad esempio 10 clienti per pagina)
            if (c)
            {
                allCustomers = _customerService.GetAll(new CustomerFilter()).ToList();
                var customerPagedData = allCustomers.Skip((customerCurrentPage - 1) * pageSize).Take(pageSize).ToList();
                customerDgv.DataSource = customerPagedData;
            }

            if (s)
            {
                allSales = _saleService.GetAll(new SaleFilter()).ToList();
                var salePagedData = allSales.Skip((saleCurrentPage - 1) * pageSize).Take(pageSize).ToList();
                SaleDgv.DataSource = salePagedData;
            }

            if (ci)
            {
                allCustomerInvoices = _customerInvoiceService.GetAll(new CustomerInvoiceFilter()).ToList();
                var customerInvoicepagedData = allCustomerInvoices.Skip((customerInvoiceCurrentPage - 1) * pageSize).Take(pageSize).ToList();
                customerInvoiceDgv.DataSource = customerInvoicepagedData;
            }

            if (cic)
            {
                allCustomerInvoiceCosts = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter()).ToList();
                var customerInvoiceCostpagedData = allCustomerInvoiceCosts.Skip((customerInvoiceCostCurrentPage - 1) * pageSize).Take(pageSize).ToList();
                customerInvoiceCostDgv.DataSource = customerInvoiceCostpagedData;
            }
            UpdatePaginationLabels();
        }

        private void UpdatePaginationLabels()
        {
            // Supponiamo che il totale dei record sia già stato calcolato
            customerTotalPages = (int)Math.Ceiling((double)customerTotalRecords / pageSize);
            toolStripLabel1.Text = $"Pagina {customerCurrentPage} di {customerTotalPages}";

            saleTotalPages = (int)Math.Ceiling((double)saleTotalRecords / pageSize);
            toolStripLabel2.Text = $"Pagina {saleCurrentPage} di {saleTotalPages}";

            customerInvoiceTotalPages = (int)Math.Ceiling((double)customerInvoiceTotalRecords / pageSize);
            toolStripLabel3.Text = $"Pagina {customerInvoiceCurrentPage} di {customerInvoiceTotalPages}";

            customerInvoiceCostTotalPages = (int)Math.Ceiling((double)customerInvoiceCostTotalRecords / pageSize);
            toolStripLabel4.Text = $"Pagina {customerInvoiceCostCurrentPage} di {customerInvoiceCostTotalPages}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string dataGridViewName = "";
            ToolStripButton btn = (ToolStripButton)sender;
            ToolStrip toolStrip = btn.GetCurrentParent();

            Panel panel = (Panel)toolStrip.Parent;
            foreach (Control control in panel.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    // Save the name of the DataGridView
                    dataGridViewName = dataGridView.Name;

                }
            }

            switch (dataGridViewName)
            {
                case "customerDgv":
                    if (customerCurrentPage < customerTotalPages)
                    {
                        customerCurrentPage++;
                        LoadPagedData(true, false, false, false);
                    }
                    break;
                case "SaleDgv":
                    if (saleCurrentPage < saleTotalPages)
                    {
                        saleCurrentPage++;
                        LoadPagedData(false, true, false, false);
                    }
                    break;
                case "customerInvoiceDgv":
                    if (customerInvoiceCurrentPage < customerInvoiceTotalPages)
                    {
                        customerInvoiceCurrentPage++;
                        LoadPagedData(false, false, true, false);
                    }
                    break;
                case "customerInvoiceCostDgv":
                    if (customerInvoiceCostCurrentPage < customerInvoiceCostTotalPages)
                    {
                        customerInvoiceCostCurrentPage++;
                        LoadPagedData(false, false, false, true);
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            string dataGridViewName = "";
            ToolStripButton btn = (ToolStripButton)sender;
            ToolStrip toolStrip = btn.GetCurrentParent();

            Panel panel = (Panel)toolStrip.Parent;
            foreach (Control control in panel.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    // Save the name of the DataGridView
                    dataGridViewName = dataGridView.Name;

                }
            }

            switch (dataGridViewName)
            {
                case "customerDgv":
                    if (customerCurrentPage > 1)
                    {
                        customerCurrentPage--;
                        LoadPagedData(true);
                    }
                    break;
                case "SaleDgv":
                    if (saleCurrentPage > 1)
                    {
                        saleCurrentPage--;
                        LoadPagedData(false, true);
                    }
                    break;
                case "customerInvoiceDgv":
                    if (customerInvoiceCurrentPage > 1)
                    {
                        customerInvoiceCurrentPage--;
                        LoadPagedData(false, false, true);
                    }
                    break;
                case "customerInvoiceCostDgv":
                    if (customerInvoiceCostCurrentPage > 1)
                    {
                        customerInvoiceCostCurrentPage--;
                        LoadPagedData(false, false, false, true);
                    }
                    break;
                default:
                    break;

            }
        }




        private void customerDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SaleDgv.DataSource = null;
            customerInvoiceDgv.DataSource = null;
            customerInvoiceCostDgv.DataSource = null;


            var data = _saleService.GetAll(new SaleFilter() { SaleCustomerId = (int)dgv.CurrentRow.Cells["CustomerID"].Value });
            SaleDgv.DataSource = data;


        }

        private void SaleDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            customerInvoiceDgv.DataSource = null;
            customerInvoiceCostDgv.DataSource = null;

            var data = _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceSaleId = (int)dgv.CurrentRow.Cells["SaleID"].Value });
            customerInvoiceDgv.DataSource = data;
        }

        private void CustomerInvoiceDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            customerInvoiceCostDgv.DataSource = null;

            var data = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostCustomerInvoiceId = (int)dgv.CurrentRow.Cells["CustomerInvoiceID"].Value });
            customerInvoiceCostDgv.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaleDgv.DataSource = null;
            customerInvoiceDgv.DataSource = null;
            customerInvoiceCostDgv.DataSource = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            customerInvoiceDgv.DataSource = null;
            customerInvoiceCostDgv.DataSource = null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            customerInvoiceCostDgv.DataSource = null;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            customerDgv.DataSourceChanged -= customerDgv_DataSourceChanged;
            SaleDgv.DataSourceChanged -= SaleDgv_DataSourceChanged;
            customerInvoiceDgv.DataSourceChanged -= customerInvoiceDgv_DataSourceChanged;

            customerName = CustomerNameTxt.Text;
            customerCountry = CustomerCountryTxt.Text;
            customerStatus = CustomerStatusCombo.SelectedIndex switch
            {
                1 => false,
                2 => true,
                _ => null
            };
            customerDateFrom = CustomerDateFromDtp.Checked ? CustomerDateFromDtp.Value : null;
            customerDateTo = CustomerDateToDtp.Checked ? CustomerDateToDtp.Value : null;


            CustomerFilter filter1 = new CustomerFilter()
            {
                CustomerName = customerName,
                CustomerCountry = customerCountry,
                CustomerDeprecated = customerStatus,
                CustomerCreatedDateFrom = customerDateFrom,
                CustomerCreatedDateTo = customerDateTo
            };

            SaleFilter filter2 = new SaleFilter()
            {
                SaleCustomerId = (int)customerDgv.CurrentRow.Cells["CustomerID"].Value
            };

            CustomerInvoiceFilter filter3 = new CustomerInvoiceFilter()
            {
                CustomerInvoiceSaleId = (int)SaleDgv.CurrentRow.Cells["SaleID"].Value
            };

            CustomerInvoiceCostFilter filter4 = new CustomerInvoiceCostFilter()
            {
                CustomerInvoiceCostCustomerInvoiceId = (int)customerInvoiceDgv.CurrentRow.Cells["CustomerInvoiceID"].Value
            };

            CustomerGroupDTO tabelle = _valueService.GetTables(filter1, filter2, filter3, filter4);

            customerDgv.DataSource = tabelle.customers;
            SaleDgv.DataSource = tabelle.sales;
            customerInvoiceDgv.DataSource = tabelle.invoices;
            customerInvoiceCostDgv.DataSource = tabelle.invoiceCosts;

            customerDgv.DataSourceChanged += customerDgv_DataSourceChanged;
            SaleDgv.DataSourceChanged += SaleDgv_DataSourceChanged;
            customerInvoiceDgv.DataSourceChanged += customerInvoiceDgv_DataSourceChanged;

        }

        private void SaleDgv_DataSourceChanged(object sender, EventArgs e)
        {

            var data = _customerInvoiceService.GetAll(new CustomerInvoiceFilter()
            { CustomerInvoiceSaleId = (int)customerDgv.CurrentRow.Cells["SaleID"].Value });
            customerInvoiceDgv.DataSource = data;
        }

        private void customerDgv_DataSourceChanged(object sender, EventArgs e)
        {

            var data = _saleService.GetAll(new SaleFilter()
            { SaleCustomerId = (int)SaleDgv.CurrentRow.Cells["CustomerID"].Value });
            SaleDgv.DataSource = data;
        }

        private void customerInvoiceDgv_DataSourceChanged(object sender, EventArgs e)
        {

            var data = _customerInvoiceCostService.GetAll(new CustomerInvoiceCostFilter()
            { CustomerInvoiceCostCustomerInvoiceId = (int)customerInvoiceDgv.CurrentRow.Cells["CustomerInvoiceID"].Value });
            customerInvoiceCostDgv.DataSource = data;
        }


    }
}
