using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class GraphTestForm : Form
    {
        ProceduresService _procedureService;
        CustomerService _customerService;
        public GraphTestForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _procedureService = new ProceduresService();
            _customerService = new CustomerService();
        }

        private async void GraphTestForm_Load(object sender, EventArgs e)
        {
            //var data = await _customerService.GetAll(new Entities.Filters.CustomerFilter());

            var data = await _procedureService.GetClassifySalesByProfit(new Entities.Filters.ClassifySalesByProfitFilter());

            ReportDataSource dataSource = new ReportDataSource()
            {
                Name = "DataSet1",
                Value = data.ClassifySalesByProfit
            };

            ReportDataSource dataSource2 = new ReportDataSource()
            {
                Name = "DataSet2",
                Value = data.TotalPerCountryPerSale
            };



            chart1.Series[0].Points.Clear();

            foreach (var item in data.ProgitNoProfitRiskyChart)
            {
                chart1.Series[0].Points.AddXY(item.Key, item.Value);

            }

            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.DataSources.Add(dataSource2);
            reportViewer1.RefreshReport();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (reportViewer1.LocalReport.ReportEmbeddedResource == "WinformDotNetFramework.Report2.rdlc")
            {
                chart1.SaveImage("Chart1.bmp", ChartImageFormat.Bmp);


                ReportParameter ImageLink = new ReportParameter("ImageLink");

                string relativePath = "Chart1.bmp";
                string fullPath = Path.GetFullPath(relativePath);
                Uri fileUri = new Uri(fullPath, UriKind.Absolute);
                ImageLink.Values.Add(fileUri.AbsoluteUri);
                reportViewer1.LocalReport.SetParameters(ImageLink);
                reportViewer1.RefreshReport();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (reportViewer1.LocalReport.ReportEmbeddedResource == "WinformDotNetFramework.Report2.rdlc")
            {

                reportViewer1.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Report1.rdlc";

                var data = await _customerService.GetAll(new Entities.Filters.CustomerFilter());

                ReportDataSource dataSource = new ReportDataSource()
                {
                    Name = "Customers",
                    Value = data
                };

                reportViewer1.LocalReport.DataSources.Add(dataSource);
            }
            else
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Report2.rdlc";
                var data = await _procedureService.GetClassifySalesByProfit(new Entities.Filters.ClassifySalesByProfitFilter());

                ReportDataSource dataSource = new ReportDataSource()
                {
                    Name = "DataSet1",
                    Value = data.ClassifySalesByProfit
                };

                ReportDataSource dataSource2 = new ReportDataSource()
                {
                    Name = "DataSet2",
                    Value = data.TotalPerCountryPerSale
                };

                reportViewer1.LocalReport.DataSources.Add(dataSource);
                reportViewer1.LocalReport.DataSources.Add(dataSource2);
            }

            reportViewer1.Refresh();
        }

        int count = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = (SeriesChartType)(count % 8);
            count++;
        }
    }
}
