using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoiceReportUserControl : UserControl
    {
        public SearchCustomerInvoiceReportUserControl()
        {
            InitializeComponent();
            Init();
        }
        public async void Init()
        {
            comboBox1.SelectedIndex = 0;
            for (int i = 0; i < GrapCBL.Items.Count; i++)
            {
                GrapCBL.SetItemChecked(i, true);
            }
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }
        public TotalAmountGainedPerCustomerInvoiceFilter GetFilter()
        {
            TotalAmountGainedPerCustomerInvoiceFilter filter = new TotalAmountGainedPerCustomerInvoiceFilter()
            {
                CustomerName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                Status = comboBox1.Text.Equals("All") ? null : comboBox1.Text,
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

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                if (comboBox1.Text.Equals("All"))
                    filter.CountryRegion = null;
                else
                    filter.CountryRegion = comboBox1.Text.Split(' ')[0];
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
            if (filter.CustomerCountry != null || filter.CustomerName != null || filter.Status != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalGainedFrom != null || filter.TotalGainedTo != null)
                return false;
            else
                return true;
        }
    }
}
