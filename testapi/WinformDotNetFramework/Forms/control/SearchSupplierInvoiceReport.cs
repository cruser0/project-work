using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoiceReport : UserControl
    {
        public SearchSupplierInvoiceReport()
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
        public TotalAmountSpentPerSupplierInvoiceFilter GetFilter()
        {
            TotalAmountSpentPerSupplierInvoiceFilter filter = new TotalAmountSpentPerSupplierInvoiceFilter()
            {
                SupplierName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                Status = comboBox1.Text.Equals("All") ? null : comboBox1.Text,

            };
            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    filter.SupplierCountry = null;
                else
                    filter.SupplierCountry = CountryCmbx.Text;
            }
            else
                filter.SupplierCountry = null;

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
            if (!string.IsNullOrEmpty(SpentFromIntegerTxt.GetText()))
                filter.TotalSpentFrom = int.Parse(SpentFromIntegerTxt.GetText());
            else
                filter.TotalSpentFrom = null;
            if (!string.IsNullOrEmpty(SpentToIntegerTxt.GetText()))
                filter.TotalSpentTo = int.Parse(SpentToIntegerTxt.GetText());
            else
                filter.TotalSpentTo = null;
            return filter;
        }
        public bool IsFilterEmpty(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            if (filter.SupplierCountry != null || filter.SupplierName != null || filter.Status != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalSpentFrom != null || filter.TotalSpentTo != null)
                return false;
            else
                return true;
        }
    }
}
