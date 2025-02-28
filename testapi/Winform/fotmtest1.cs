using API.Models.Filters;
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


        double itemsPage = 10.0;
        public fotmtest1()
        {
            _userService = new UserService();
            _customerService = new CustomerService();
            _customerInvoiceService = new CustomerInvoiceService();
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            _saleService = new SaleService();
            _valueService = new ValueService();

            customerPages = (int)Math.Ceiling(_customerService.Count(new CustomerFilter()) / itemsPage);

            InitializeComponent();
        }

        private void fotmtest1_Load(object sender, EventArgs e)
        {
            _userService.Login(new UserDTO() { Email = "Admin", Password = "Admin" });

            var data = _customerService.GetAll(new CustomerFilter());
            customerDgv.DataSource = data;


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

            testDTO tabelle = _valueService.GetTables(filter1, filter2, filter3, filter4);

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
