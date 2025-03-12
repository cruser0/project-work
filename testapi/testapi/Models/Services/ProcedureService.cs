using API.Models.Entities.Charts;
using API.Models.Procedures;

namespace API.Models.Services
{
    public class ProcedureService
    {
        private readonly Progetto_FormativoContext _context;
        public ProcedureService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        internal SaleListChartDTO GetCharths(List<ClassifySalesByProfit> profit)
        {


            int activeSale = profit.Where(x => x.Status.ToLower().Equals("active")).Count();
            int closedSale = profit.Where(x => x.Status.ToLower().Equals("closed")).Count();
            Dictionary<string, int> ActiveClosedStatusChart = new Dictionary<string, int>();
            ActiveClosedStatusChart.Add("active", activeSale);
            ActiveClosedStatusChart.Add("closed", closedSale);


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
                TotalPerCountryPerSale = TotalPerCountryPerSale,
                ActiveClosedStatusChart = ActiveClosedStatusChart,
                ClassifySalesByProfit = profit,
                ProgitNoProfitRiskyChart = ProgitNoProfitRiskyChart,
                TotalPerDatePerSale = TotalPerDatePerSale,
            };
        }

        public Dictionary<DateTime, decimal> DateTimeDecimalChart<T>(List<T> lista, string dateName, string totalName)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("The list cannot be null or empty.");

            Dictionary<DateTime, decimal> dict = new Dictionary<DateTime, decimal>();

            foreach (T entity in lista)
            {
                var properties = entity.GetType().GetProperties();
                DateTime? X = null;
                decimal? Y = null;

                foreach (var property in properties)
                {
                    if (property.Name.ToLower() == dateName.ToLower())
                        X = property.GetValue(entity) as DateTime?;
                    else if (property.Name.ToLower() == totalName.ToLower())
                        Y = property.GetValue(entity) as decimal?;
                }

                if (dict.ContainsKey((DateTime)X))
                    dict[(DateTime)X] += (decimal)Y;
                else
                    dict[(DateTime)X] = (decimal)Y;
            }
            return dict;
        }
        public Dictionary<string, decimal> StringAndDecimalChart<T>(List<T> lista, string stringName, string decimalName)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("The list cannot be null or empty.");

            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

            foreach (T entity in lista)
            {
                var properties = entity.GetType().GetProperties();
                string? X = null;
                decimal? Y = null;

                foreach (var property in properties)
                {
                    if (property.Name.ToLower() == stringName.ToLower())
                        X = property.GetValue(entity) as string;
                    else if (property.Name.ToLower() == decimalName.ToLower())
                        Y = property.GetValue(entity) as decimal?;
                }

                if (dict.ContainsKey((string)X))
                    dict[X] += (decimal)Y;
                else
                    dict[X] = (decimal)Y;
            }
            return dict;
        }

        public Dictionary<string, int> StringIntChart<T>(List<T> lista, string statusName)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("The list cannot be null or empty.");

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (T entity in lista)
            {
                var properties = entity.GetType().GetProperties();
                string? Y = null;

                foreach (var property in properties)
                {
                    if (property.Name.ToLower() == statusName.ToLower())
                        Y = property.GetValue(entity) as string;
                }

                if (dict.ContainsKey(Y))
                    dict[Y] += 1;
                else
                    dict[Y] = 1;
            }
            return dict;
        }
    }
}
