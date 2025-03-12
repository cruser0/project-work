
using System.Collections.Generic;
using WinformDotNetFramework.Procedures;

namespace WinformDotNetFramework.Entities.Charts
{
    public class SaleListChartDTO
    {
        public Dictionary<string, int> ActiveClosedStatusChart { get; set; }
        public Dictionary<string, int> ProgitNoProfitRiskyChart { get; set; }
        public List<SaleDateTotalDTO> TotalPerDatePerSale { get; set; }
        public List<SaleCountryTotalDTO> TotalPerCountryPerSale { get; set; }
        public List<ClassifySalesByProfit> ClassifySalesByProfit { get; set; }
    }
}
