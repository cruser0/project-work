using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSale : UserControl
    {
        public SearchSale()
        {
            InitializeComponent();
            StatusCB.SelectedIndex = 0;
        }

        public SaleFilter GetFilter()
        {
            SaleFilter saleFilter = new SaleFilter
            {
                SaleBookingNumber = BNTextBox.Text,
                SaleBoLnumber = BoLTextBox.Text
            };

            if(!string.IsNullOrEmpty(CustomerNameTxt.Text))
                saleFilter.SaleCustomerName = CustomerNameTxt.Text;
            else
                saleFilter.SaleCustomerName = null;

            if (!string.IsNullOrEmpty(CustomerCountryTxt.Text))
                saleFilter.SaleCustomerCountry = CustomerCountryTxt.Text;
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

            saleFilter.SaleCustomerId = null;

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
