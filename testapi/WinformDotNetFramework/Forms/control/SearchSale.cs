using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSale : UserControl
    {
        public SearchSale()
        {
            InitializeComponent();
            Init();
        }
        public async void Init()
        {
            StatusCB.SelectedIndex = 0;
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }
        public SaleFilter GetFilter()
        {
            SaleFilter saleFilter = new SaleFilter
            {
                SaleBookingNumber = string.IsNullOrEmpty(BNTextBox.Text)?null: BNTextBox.Text,
                SaleBoLnumber = string.IsNullOrEmpty(BoLTextBox.Text) ? null : BoLTextBox.Text
            };

            if(!string.IsNullOrEmpty(CustomerNameTxt.Text))
                saleFilter.SaleCustomerName = CustomerNameTxt.Text;
            else
                saleFilter.SaleCustomerName = null;

            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    saleFilter.SaleCustomerCountry = null;
                else
                    saleFilter.SaleCustomerCountry = CountryCmbx.Text;
            }
            else
                saleFilter.SaleCustomerCountry = null;

            // For SaleRevenueFrom and SaleRevenueTo, check if text is empty or null before parsing
            if (string.IsNullOrEmpty(RevenueFromTxt.GetText()))
                saleFilter.SaleRevenueFrom = null;
            else
                saleFilter.SaleRevenueFrom = int.Parse(RevenueFromTxt.GetText());

            if (string.IsNullOrEmpty(RevenueToTxt.GetText()))
                saleFilter.SaleRevenueTo = null;
            else
                saleFilter.SaleRevenueTo = int.Parse(RevenueToTxt.GetText());
            if (StatusCB.Text == "All")
                saleFilter.SaleStatus = null;
            else
                saleFilter.SaleStatus = StatusCB.Text;

            if (DateFromDTP.Checked)
                saleFilter.SaleDateFrom = DateFromDTP.Value;
            else
                saleFilter.SaleDateFrom = null;

            if (DateToDTP.Checked)
                saleFilter.SaleDateTo = DateToDTP.Value;
            else
                saleFilter.SaleDateTo = null;

            return saleFilter;
        }
    }
}
