using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class GraphTestForm : Form
    {
        ProceduresService _procedureService;
        public GraphTestForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _procedureService = new ProceduresService();
        }

        private async void GraphTestForm_Load(object sender, EventArgs e)
        {
            var list = await _procedureService.GetClassifySalesByProfit(new Entities.Filters.ClassifySalesByProfitFilter());

            
            foreach (var item in list.ActiveClosedStatusChart)
                chart1.Series[0].Points.AddXY(item.Key, item.Value);

            foreach (var item in list.ProgitNoProfitRiskyChart)
                chart3.Series[0].Points.AddXY(item.Key, item.Value);
            chart4.Series[0].ChartType = SeriesChartType.Bar;
            chart5.Series[0].ChartType = SeriesChartType.Bar;
            chart6.Series[0].ChartType = SeriesChartType.Bar;
            foreach (var item in list.TotalPerCountryPerSale)
            {
                chart4.Series[0].Points.AddXY(item.Country, item.TotalRevenue);
                chart5.Series[0].Points.AddXY(item.Country, item.TotalProfit);
                chart6.Series[0].Points.AddXY(item.Country, item.TotalSpent);
            }

            foreach (var item in list.TotalPerDatePerSale)
                chart2.Series[0].Points.AddXY(item.Date, item.TotalProfit);
        }

    }
}
