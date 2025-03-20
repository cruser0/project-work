using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplier : UserControl
    {
        public SearchSupplier()
        {
            InitializeComponent();
            
            Init();
        }
        public async void Init()
        {
            comboBox1.SelectedIndex = 0;
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }
        public SupplierFilter GetFilter()
        {
            SupplierFilter filter = new SupplierFilter();
            filter.SupplierName = NameSupplierTxt.Text;
            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    filter.SupplierCountry = null;
                else
                    filter.SupplierCountry = CountryCmbx.Text;
            }
            else
                filter.SupplierCountry = null;

            if (DateFromClnd.Checked)
            {
                filter.SupplierCreatedDateFrom = DateFromClnd.Value;
            }
            else
            {
                filter.SupplierCreatedDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                filter.SupplierCreatedDateTo = DateToClnd.Value;
            }
            else
            {
                filter.SupplierCreatedDateTo = null;
            }


            // Utilizzo del switch tradizionale per SupplierDeprecated
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    filter.SupplierDeprecated = false;
                    break;
                case 2:
                    filter.SupplierDeprecated = true;
                    break;
                default:
                    filter.SupplierDeprecated = null;
                    break;
            }


            return filter;
        }
    }
}
