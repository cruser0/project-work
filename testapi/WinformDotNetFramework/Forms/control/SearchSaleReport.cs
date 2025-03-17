using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSaleReport : UserControl
    {
        public SearchSaleReport()
        {
            InitializeComponent();
            StatusCmbx.SelectedIndex = 0;
            FilterMarginCmbx.SelectedIndex = 0;
        }
        public ClassifySalesByProfitFilter GetFilter()
        {
            var filter = new ClassifySalesByProfitFilter()
            {
                BKNumber = string.IsNullOrEmpty(BKNumberTxt.Text) ? null : BKNumberTxt.Text,
                BoLNumber = string.IsNullOrEmpty(BoLNumberTxt.Text) ? null : BoLNumberTxt.Text,
                CustomerCountry=string.IsNullOrEmpty(CountryTxt.Text) ? null : CountryTxt.Text,
                CustomerName=string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                FilterMargin= FilterMarginCmbx.Text.ToLower().Equals("all") ? null : FilterMarginCmbx.Text.ToLower(),
                Status=StatusCmbx.Text.ToLower().Equals("all")?null: StatusCmbx.Text,
            };
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
            if (filter.TotalRevenueFrom != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalRevenueTo != null || filter.BKNumber != null || filter.BoLNumber != null || filter.CustomerCountry != null || filter.TotalSpentTo != null || filter.TotalSpentFrom != null || filter.ProfitFrom != null || filter.ProfitTo != null||filter.CustomerName!=null||filter.FilterMargin!=null||filter.Status!=null)
                return false;
            else
                return true;
        }
    }
}
