using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoice : UserControl
    {
        public SearchCustomerInvoice()
        {
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
        }

        public CustomerInvoiceFilter GetFilter()
        {
            CustomerInvoiceFilter customerInvoiceFilter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = null
            };

            if (DateFromClnd.Checked)
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceDateFrom = DateFromClnd.Value;
            }
            else
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceDateTo = DateToClnd.Value;
            }
            else
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceDateTo = null;
            }

            customerInvoiceFilter.CustomerInvoiceStatus = StatusCmb.Text;

            if (string.IsNullOrEmpty(AmountFromTxt.GetText()))
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountFrom = null;
            }
            else
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountFrom = int.Parse(AmountFromTxt.GetText());
            }

            if (string.IsNullOrEmpty(AmountToTxt.GetText()))
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountTo = null;
            }
            else
            {
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountTo = int.Parse(AmountToTxt.GetText());
            }
            return customerInvoiceFilter;
        }
    }
}
