using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Procedures;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class GraphTestForm : Form
    {
        ProceduresService _procedureService;
        private List<ClassifySalesByProfit> orderDetailsData = null;

        public GraphTestForm()
        {
            Init();
            InitializeComponent();
        }
        private async void Init()
        {
            _procedureService = new ProceduresService();
            orderDetailsData = await _procedureService.GetClassifySalesByProfit(new Entities.Filters.ClassifySalesByProfitFilter());
        }

        private void GraphTestForm_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            reportViewer1.LocalReport.SubreportProcessing +=
                        new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);


            ReportDataSource dataSource = new ReportDataSource()
            {
                Name = "SaleByProfit",
                Value = orderDetailsData
            };
            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.RefreshReport();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        void DemoSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("SaleStatus", orderDetailsData));
            e.DataSources.Add(new ReportDataSource("SaleMargins", orderDetailsData));
            e.DataSources.Add(new ReportDataSource("SaleMArginsTemporal", orderDetailsData));
        }



    }
}
