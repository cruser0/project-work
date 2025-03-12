using API.Models.Procedures;

namespace API.Models.Services
{
    public class ProcedureService
    {
        internal object GetCharths(List<ClassifySalesByProfit> profit)
        {
            int activeSale = profit.Where(x => x.Status.ToLower().Equals("active")).Count();
            int closedSale = profit.Where(x => x.Status.ToLower().Equals("closed")).Count();
            Dictionary<string, int> ActiveClosedStatusChart = new Dictionary<string, int>();
            ActiveClosedStatusChart.Add("active", activeSale);
            ActiveClosedStatusChart.Add("closed", closedSale);

            return ActiveClosedStatusChart;
        }
    }
}
