using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Procedures;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class GraphTestForm : Form
    {
        private ProceduresService _procedureService;
        private CustomerService _customerService;

        // Data collections for the report and subreports
        private List<ClassifySalesByProfit> _profitData = new List<ClassifySalesByProfit>();
        private List<Customer> _customerData = new List<Customer>();

        public GraphTestForm()
        {
            Init();
            InitializeComponent();
        }

        private void Init()
        {
            _procedureService = new ProceduresService();
            _customerService = new CustomerService();
        }

        private void GraphTestForm_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.SubreportProcessing +=
                        new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            _profitData = new List<ClassifySalesByProfit>();
            _customerData = new List<Customer>();

            await LoadReportData();
            ReportDataSource mainDataSource = new ReportDataSource()
            {
                Name = "SaleByProfit",
                Value = _profitData
            };
            reportViewer1.LocalReport.DataSources.Add(mainDataSource);

            reportViewer1.RefreshReport();
        }

        private async Task LoadReportData()
        {
            var tasks = new List<Task>();

            if (true || checkBox1.Checked || checkBox3.Checked)  // Main report always needs this data
            {
                var profitTask = LoadProfitData();
                tasks.Add(profitTask);
            }

            if (checkBox2.Checked)
            {
                var customerTask = LoadCustomerData();
                tasks.Add(customerTask);
            }

            await Task.WhenAll(tasks);
        }

        private async Task LoadProfitData()
        {
            var filter = new ClassifySalesByProfitFilter();
            _profitData = await _procedureService.GetClassifySalesByProfit(filter);
        }

        private async Task LoadCustomerData()
        {
            var filter = new CustomerFilter();
            var customers = await _customerService.GetAll(filter);
            _customerData = customers as List<Customer> ?? new List<Customer>(customers);
        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {

            if (checkBox1.Checked)
                e.DataSources.Add(new ReportDataSource("SaleByProfit", _profitData));
            else
                e.DataSources.Add(new ReportDataSource("SaleByProfit", new List<ClassifySalesByProfit>()));

            if (checkBox2.Checked)
                e.DataSources.Add(new ReportDataSource("Customers", _customerData));
            else
                e.DataSources.Add(new ReportDataSource("Customers", new List<Customer>()));

            if (checkBox3.Checked)
                e.DataSources.Add(new ReportDataSource("SaleTemporal", _profitData));
            else
                e.DataSources.Add(new ReportDataSource("SaleTemporal", new List<ClassifySalesByProfit>()));

        }
    }
}