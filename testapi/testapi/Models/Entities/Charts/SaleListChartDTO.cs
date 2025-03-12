using API.Models.Procedures;

namespace API.Models.Entities.Charts
{
    public class SaleListChartDTO
    {
        public Dictionary<string, int> ActiveClosedStatusChart { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> ProgitNoProfitRiskyChart { get; set; } = new Dictionary<string, int>();
        public List<SaleDateTotalDTO> TotalPerDatePerSale { get; set; } = new List<SaleDateTotalDTO>();
        public List<SaleCountryTotalDTO> TotalPerCountryPerSale { get; set; } = new List<SaleCountryTotalDTO>();
        public List<ClassifySalesByProfit> ClassifySalesByProfit { get; set; }=new List<ClassifySalesByProfit>();
    }
}
