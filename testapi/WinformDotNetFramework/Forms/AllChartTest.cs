using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class AllChartTest : Form
    {

        SaleService saleService;
        SaleFilter saleFilter;
        List<SaleCustomerDTO> lista;
        public AllChartTest()
        {
            saleFilter = new SaleFilter();
            saleService = new SaleService();
            InitializeComponent();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            saleFilter = searchSale1.GetFilter();
            var query = await saleService.GetAll(saleFilter);
            lista = query.ToList();

            PieChart(lista);
            BarChart(lista);
        }


        private void PieChart(List<SaleCustomerDTO> lista)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Aggiungi un titolo al grafico
            chart1.Titles.Clear();
            chart1.Titles.Add(new Title($"Active/Closed Sales", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black));

            // Aggiungi un'area di grafico
            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);

            var series = new Series($"Sale Status")
            {
                ChartType = SeriesChartType.Pie,
                BorderWidth = 1
            };

            int active = 0;
            int closed = 0;

            foreach (var sale in lista)
            {
                if (sale.Status == "Active")
                {
                    active++;
                }
                else
                {
                    closed++;
                }
            }

            series.Points.AddXY($"Active", active);
            series.Points.Last().ToolTip = $"{active}";
            series.Points.AddXY($"Closed", closed);
            series.Points.Last().ToolTip = $"{closed}";

            chart1.Series.Add(series);
        }

        private void BarChart(List<SaleCustomerDTO> lista)
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            // Aggiungi un titolo al grafico
            chart2.Titles.Clear();
            chart2.Titles.Add(new Title($"Andamento Sales", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black));

            // Aggiungi un'area di grafico
            ChartArea chartArea = new ChartArea("MainArea");
            chart2.ChartAreas.Add(chartArea);

            var series = new Series($"Sale Status")
            {
                ChartType = SeriesChartType.Bar,
                BorderWidth = 1
            };

            Dictionary<DateTime, decimal> values = new Dictionary<DateTime, decimal>();

            foreach (var item in lista)
            {
                if (values.ContainsKey((DateTime)item.SaleDate))
                    values[(DateTime)item.SaleDate] += (decimal)item.TotalRevenue;
                else
                    values.Add((DateTime)item.SaleDate, (decimal)item.TotalRevenue);
            }
        }
    }
}
