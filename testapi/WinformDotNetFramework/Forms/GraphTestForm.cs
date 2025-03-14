using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Procedures;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class GraphTestForm : Form
    {
        private ProceduresService _procedureService;


        // Data collections for the report and subreports
        private List<ClassifySalesByProfit> _saleData = new List<ClassifySalesByProfit>();
        private List<TotalAmountGainedPerCustomerInvoice> _customerInvoiceData = new List<TotalAmountGainedPerCustomerInvoice>();
        private List<TotalAmountSpentPerSupplierInvoice> _supplierInvoiceData = new List<TotalAmountSpentPerSupplierInvoice>();


        public GraphTestForm()
        {
            Init();
            InitializeComponent();
        }

        private void Init()
        {
            _procedureService = new ProceduresService();
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

            _saleData = new List<ClassifySalesByProfit>();
            _customerInvoiceData = new List<TotalAmountGainedPerCustomerInvoice>();
            _supplierInvoiceData = new List<TotalAmountSpentPerSupplierInvoice>();

            await LoadReportData();
            ReportDataSource mainDataSource = new ReportDataSource()
            {
                Name = "SaleByProfit",
                Value = _saleData
            };
            reportViewer1.LocalReport.DataSources.Add(mainDataSource);

            reportViewer1.RefreshReport();
        }

        private async Task LoadReportData()
        {
            var tasks = new List<Task>();

            if (true)  // Main report always needs this data
            {
                var profitTask = LoadSaleData();
                tasks.Add(profitTask);
            }

            if (checkBox1.Checked)
            {
                var cusInvoiceTask = LoadCustomerInvoiceData();
                tasks.Add(cusInvoiceTask);
            }

            if (checkBox3.Checked)
            {
                var supInvoiceTask = LoadSupplierInvoiceData();
                tasks.Add(supInvoiceTask);
            }


            await Task.WhenAll(tasks);
        }

        private async Task LoadSaleData()
        {
            var filter = new ClassifySalesByProfitFilter();
            _saleData = await _procedureService.GetClassifySalesByProfit(filter);
        }

        private async Task LoadCustomerInvoiceData()
        {
            var filter = new TotalAmountGainedPerCustomerInvoiceFilter();
            _customerInvoiceData = await _procedureService.GetTotalAmountGainedPerCustomerInvoice(filter);
        }

        private async Task LoadSupplierInvoiceData()
        {
            var filter = new TotalAmountSpentPerSupplierInvoiceFilter();
            _supplierInvoiceData = await _procedureService.GetTotalAmountSpentPerSupplierInvoice(filter);
        }



        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("SaleCountByStatus", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleCountByCountry", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleCountByMargin", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleCountByDateCountry", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleProfitSumByDate", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSpentSumByDate", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleProfitSumByCountry", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleTotalSpentSumByCountry", _saleData));
            e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSumByCountry", _saleData));
            e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByStatus", _customerInvoiceData));
            e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByCountry", _customerInvoiceData));
            e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByDate", _customerInvoiceData));
            e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByDate", _customerInvoiceData));
            e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByCountry", _customerInvoiceData));
            e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByCountry", _supplierInvoiceData));
            e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByStatus", _supplierInvoiceData));
            e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByDate", _supplierInvoiceData));
            e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByDate", _supplierInvoiceData));
            e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByCountry", _supplierInvoiceData));
        }
    }
}