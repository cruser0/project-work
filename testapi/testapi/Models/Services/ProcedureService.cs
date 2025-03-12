using API.Models.Entities.Charts;
using API.Models.Procedures;

namespace API.Models.Services
{
    public class ProcedureService
    {
        internal SaleListChartDTO GetCharths(List<ClassifySalesByProfit> profit)
        {
            
            
            int activeSale = profit.Where(x=>x.Status.ToLower().Equals("active")).Count();
            int closedSale = profit.Where(x => x.Status.ToLower().Equals("closed")).Count();
            Dictionary<string, int> ActiveClosedStatusChart = new Dictionary<string, int>();
            ActiveClosedStatusChart.Add("active", activeSale);
            ActiveClosedStatusChart.Add("closed",closedSale);


            int profitSale = profit.Where(x => x.SaleMargins.ToLower().Equals("profit")).Count();
            int noProfitSale = profit.Where(x => x.SaleMargins.ToLower().Equals("no profit")).Count();
            int riskySale = profit.Where(x => x.SaleMargins.ToLower().Equals("risky")).Count();
            Dictionary<string, int> ProgitNoProfitRiskyChart = new Dictionary<string, int>();
            ProgitNoProfitRiskyChart.Add("profit", profitSale);
            ProgitNoProfitRiskyChart.Add("no profit", noProfitSale);
            ProgitNoProfitRiskyChart.Add("risky", riskySale);



            List<SaleDateTotalDTO> TotalPerDatePerSale = profit.GroupBy(x => x.SaleDate)
                .Select(g => new SaleDateTotalDTO
                {
                        Date = g.Key,
                        TotalRevenue = g.Sum(x => x.TotalRevenue),
                        TotalProfit = g.Sum(x => x.Profit),
                        TotalSpent = g.Sum(x => x.TotalSpent)

                }).ToList();

            List<SaleCountryTotalDTO> TotalPerCountryPerSale = profit.GroupBy(x => x.Country)
                .Select(g => new SaleCountryTotalDTO
                {
                    Country = g.Key,
                    TotalRevenue = g.Sum(x => x.TotalRevenue),
                    TotalProfit = g.Sum(x => x.Profit),
                    TotalSpent = g.Sum(x => x.TotalSpent)
                }).ToList();

            return new SaleListChartDTO
            {
                TotalPerCountryPerSale=TotalPerCountryPerSale,
                ActiveClosedStatusChart=ActiveClosedStatusChart,
                ClassifySalesByProfit=profit,
                ProgitNoProfitRiskyChart=ProgitNoProfitRiskyChart,
                TotalPerDatePerSale=TotalPerDatePerSale,
            };
        }
    }
}
