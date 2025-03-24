using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSaleReport : UserControl
    {
        public SearchSaleReport()
        {
            InitializeComponent();
            
            Init();
        }
        public async void Init()
        {
            StatusCmbx.SelectedIndex = 0;
            FilterMarginCmbx.SelectedIndex = 0;
            for (int i = 0; i < GrapCBL.Items.Count; i++)
            {
                GrapCBL.SetItemChecked(i, true);
            }
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }
        public ClassifySalesByProfitFilter GetFilter()
        {
            var filter = new ClassifySalesByProfitFilter()
            {
                BKNumber = string.IsNullOrEmpty(BKNumberTxt.Text) ? null : BKNumberTxt.Text,
                BoLNumber = string.IsNullOrEmpty(BoLNumberTxt.Text) ? null : BoLNumberTxt.Text,
                CustomerName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                FilterMargin = FilterMarginCmbx.Text.ToLower().Equals("all") ? null : FilterMarginCmbx.Text.ToLower(),
                Status = StatusCmbx.Text.ToLower().Equals("all") ? null : StatusCmbx.Text,
            };
            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    filter.CustomerCountry = null;
                else
                    filter.CustomerCountry = CountryCmbx.Text;
            }
            else
                filter.CustomerCountry = null;

            if (DateFromClnd.Checked)
                filter.DateFrom = DateFromClnd.Value;
            else
                filter.DateFrom = null;

            if (DateToClnd.Checked)
                filter.DateTo = DateToClnd.Value;
            else
                filter.DateTo = null;

            if (string.IsNullOrEmpty(ProfitFromIntegerTxt.GetText()))
                filter.ProfitFrom = null;
            else
                filter.ProfitFrom = int.Parse(ProfitFromIntegerTxt.GetText());
            if (string.IsNullOrEmpty(ProfitToIntegerTxt.GetText()))
                filter.ProfitTo = null;
            else
                filter.ProfitTo = int.Parse(ProfitToIntegerTxt.GetText());

            if (string.IsNullOrEmpty(RevenueFromIntegerTxt.GetText()))
                filter.TotalRevenueFrom = null;
            else
                filter.TotalRevenueFrom = int.Parse(RevenueFromIntegerTxt.GetText());
            if (string.IsNullOrEmpty(RevenueToIntegerTxt.GetText()))
                filter.TotalRevenueTo = null;
            else
                filter.TotalRevenueTo = int.Parse(RevenueToIntegerTxt.GetText());

            if (string.IsNullOrEmpty(SpentFromIntegerTxt.GetText()))
                filter.TotalSpentFrom = null;
            else
                filter.TotalSpentFrom = int.Parse(SpentFromIntegerTxt.GetText());
            if (string.IsNullOrEmpty(SpentToIntegerTxt.GetText()))
                filter.TotalSpentTo = null;
            else
                filter.TotalSpentTo = int.Parse(SpentToIntegerTxt.GetText());
            return filter;
        }

        public bool IsFilterEmpty(ClassifySalesByProfitFilter filter)
        {
            if (filter.TotalRevenueFrom != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalRevenueTo != null || filter.BKNumber != null || filter.BoLNumber != null || filter.CustomerCountry != null || filter.TotalSpentTo != null || filter.TotalSpentFrom != null || filter.ProfitFrom != null || filter.ProfitTo != null || filter.CustomerName != null || filter.FilterMargin != null || filter.Status != null)
                return false;
            else
                return true;
        }
    }
}
