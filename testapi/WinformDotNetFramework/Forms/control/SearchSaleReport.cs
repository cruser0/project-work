using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            RegionCmbx.SelectedIndex = 0;
            FilterMarginCmbx.SelectedIndex = 0;
            for (int i = 0; i < GrapCBL.Items.Count; i++)
            {
                GrapCBL.SetItemChecked(i, true);
            }
            RegionCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.Region).ToList();
            RegionCmbx.SelectedIndex = 1;
            SetCountry();
            DateFromClnd.Checked = true;
            DateToClnd.Checked = true;
            DateTime todayDate = DateTime.Now;
            int month = todayDate.Month - 1;
            int year = todayDate.Year;

            if (todayDate.Month == 1)
            {
                month = 12;
                year -= 1;
            }
            DateTime firstDayOfLastMonth = new DateTime(year, month, 1);
            DateTime lastDayOfLastMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            DateFromClnd.Value = firstDayOfLastMonth;
            DateToClnd.Value = lastDayOfLastMonth;
        }
        private async void SetCountry()
        {

            if (RegionCmbx.SelectedItem.ToString().Equals("All"))
            {
                var filteredCountry = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
                CountryCmbx.DataSource = (filteredCountry).ToList();
            }
            else
            {
                var zeroIndex = new List<string>() { "All" };
                var filteredCountry = (await UtilityFunctions.GetCountries()).Where(x => x.Region.Equals(RegionCmbx.SelectedItem.ToString())).Select(x => x.CountryName).ToList();
                CountryCmbx.DataSource = zeroIndex.Concat(filteredCountry).ToList();
            }
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

            if (!string.IsNullOrEmpty(RegionCmbx.Text))
            {
                if (RegionCmbx.Text.Equals("All"))
                    filter.CountryRegion = null;
                else
                    filter.CountryRegion = RegionCmbx.Text.Split(' ')[0];
            }
            else
                filter.CountryRegion = null;


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
            if (filter.TotalRevenueFrom != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalRevenueTo != null || filter.BKNumber != null || filter.BoLNumber != null || filter.CustomerCountry != null || filter.CountryRegion != null || filter.TotalSpentTo != null || filter.TotalSpentFrom != null || filter.ProfitFrom != null || filter.ProfitTo != null || filter.CustomerName != null || filter.FilterMargin != null || filter.Status != null || filter.CountryRegion!=null)
                return false;
            else
                return true;
        }

        private void RegionCmbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetCountry();
        }
    }
}
