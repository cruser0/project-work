using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var list=await _procedureService.GetClassifySalesByProfit(new Entities.Filters.ClassifySalesByProfitFilter());
            chart1.DataSource = list;
            chart2.DataSource = list;
            chart3.DataSource = list;
            chart4.DataSource = list;
            chart5.DataSource = list;
            chart6.DataSource = list;
            int profit = 0;
            int noProfit = 0;
            int risky = 0;
            foreach (var item in list)
            {
            chart1.Series[0].Points.AddXY(item.CustomerName, item.TotalRevenue.ToString());
                if (item.SaleMargins.ToLower().Equals("profit"))
                    profit++;
                if (item.SaleMargins.ToLower().Equals("no profit"))
                    noProfit++;
                if (item.SaleMargins.ToLower().Equals("risky"))
                    risky++;
            }
            chart2.Series[0].Points.AddXY($"January",list.Where(x=>x.SaleDate.Value.Month==1).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("February" , list.Where(x => x.SaleDate.Value.Month == 2).Sum(x => x.TotalRevenue));
            chart2.Series[0].Points.AddXY("March", list.Where(x=>x.SaleDate.Value.Month==3).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("April", list.Where(x=>x.SaleDate.Value.Month==4).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("May", list.Where(x=>x.SaleDate.Value.Month==5).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("June", list.Where(x=>x.SaleDate.Value.Month==6).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("July", list.Where(x=>x.SaleDate.Value.Month==7).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("August", list.Where(x=>x.SaleDate.Value.Month==8).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("September", list.Where(x=>x.SaleDate.Value.Month==9).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("October", list.Where(x=>x.SaleDate.Value.Month==10).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("November", list.Where(x=>x.SaleDate.Value.Month==11).Sum(x=>x.TotalRevenue));
            chart2.Series[0].Points.AddXY("December", list.Where(x=>x.SaleDate.Value.Month==12).Sum(x=>x.TotalRevenue));
            chart3.Series[0].Points.AddXY("profit", profit);
            chart3.Series[0].Points.AddXY("noprofit", noProfit);
            chart3.Series[0].Points.AddXY("risky", risky);

            
        }
    }
}
