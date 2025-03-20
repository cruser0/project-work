using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoice : UserControl
    {
        public SearchSupplierInvoice()
        {
            InitializeComponent();
            
            Init();
        }
        public async void Init()
        {
            StatusCmb.SelectedIndex = 0;
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }
        public SupplierInvoiceFilter GetFilter()
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter();
            filter.SupplierInvoiceStatus = StatusCmb.Text;
            filter.SupplierInvoiceCode = string.IsNullOrEmpty(SupplierInvoiceCodeTxt.Text) ? null: SupplierInvoiceCodeTxt.Text;
            filter.SupplierInvoiceSaleBoL = string.IsNullOrEmpty(SaleBoLTxt.Text) ? null: SaleBoLTxt.Text;
            filter.SupplierInvoiceSaleBk = string.IsNullOrEmpty(SaleBkTxt.Text) ? null: SaleBkTxt.Text;

            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    filter.SupplierInvoiceSupplierCountry = null;
                else
                    filter.SupplierInvoiceSupplierCountry = CountryCmbx.Text;
            }
            else
                filter.SupplierInvoiceSupplierCountry = null;

            if (!string.IsNullOrEmpty(NameSupplierTxt.Text))
                filter.SupplierInvoiceSupplierName = NameSupplierTxt.Text;
            else
                filter.SupplierInvoiceSupplierName = null;


            if (!string.IsNullOrEmpty(InvoiceAmountFromTxt.GetText()))
                filter.SupplierInvoiceInvoiceAmountFrom = int.Parse(InvoiceAmountFromTxt.GetText());
            else
                filter.SupplierInvoiceInvoiceAmountFrom = null;

            if (!string.IsNullOrEmpty(InvoiceAmountToTxt.GetText()))
                filter.SupplierInvoiceInvoiceAmountTo = int.Parse(InvoiceAmountToTxt.GetText());
            else
                filter.SupplierInvoiceInvoiceAmountTo = null;

            if (DateFromClnd.Checked)
                filter.SupplierInvoiceInvoiceDateFrom = DateFromClnd.Value;
            else
                filter.SupplierInvoiceInvoiceDateFrom = null;

            if (DateToClnd.Checked)
                filter.SupplierInvoiceInvoiceDateTo = DateToClnd.Value;
            else
                filter.SupplierInvoiceInvoiceDateTo = null;


            return filter;
        }
    }
}
