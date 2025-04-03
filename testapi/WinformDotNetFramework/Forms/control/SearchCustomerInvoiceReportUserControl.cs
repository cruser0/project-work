using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoiceReportUserControl : UserControl
    {
        public SearchCustomerInvoiceReportUserControl()
        {
            InitializeComponent();
        }
        public async Task Init()
        {
            if (DesignMode)
                return;
            StatusCmbx.SelectedIndex = 0;
            for (int i = 0; i < GrapCBL.Items.Count; i++)
            {
                GrapCBL.SetItemChecked(i, true);
            }
            RegionCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.Region).ToList();
            RegionCmbx.SelectedIndex = 1;
            await  SetCountry();
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
        private async Task SetCountry()
        {

            if (RegionCmbx.SelectedItem.ToString().Equals("All")){
                var filteredCountry = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
                CountryCmbx.DataSource =(filteredCountry).ToList();
            }
            else
            {
            var zeroIndex = new List<string>() { "All" };
            var filteredCountry = (await UtilityFunctions.GetCountries()).Where(x => x.Region.Equals(RegionCmbx.SelectedItem.ToString())).Select(x => x.CountryName).ToList();
            CountryCmbx.DataSource = zeroIndex.Concat(filteredCountry).ToList();
            }
        }
        public TotalAmountGainedPerCustomerInvoiceFilter GetFilter()
        {
            TotalAmountGainedPerCustomerInvoiceFilter filter = new TotalAmountGainedPerCustomerInvoiceFilter()
            {
                CustomerName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                Status = StatusCmbx.Text.Equals("All") ? null : StatusCmbx.Text,
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

            if (!string.IsNullOrEmpty(GainedFromIntegerTxt.GetText()))
                filter.TotalGainedFrom = int.Parse(GainedFromIntegerTxt.GetText());
            else
                filter.TotalGainedFrom = null;

            if (!string.IsNullOrEmpty(GainedToIntegerTxt.GetText()))
                filter.TotalGainedTo = int.Parse(GainedToIntegerTxt.GetText());
            else
                filter.TotalGainedTo = null;

            return filter;
        }
        public bool IsFilterEmpty(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            if (filter.CustomerCountry != null || filter.CustomerName != null || filter.Status != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalGainedFrom != null || filter.TotalGainedTo != null || filter.CountryRegion!=null)
                return false;
            else
                return true;
        }

        private async void RegionCmbx_SelectionChangeCommitted(object sender, EventArgs e)
        {

            await SetCountry();
        }

        private async void SearchCustomerInvoiceReportUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            await Init();
        }
    }
}
