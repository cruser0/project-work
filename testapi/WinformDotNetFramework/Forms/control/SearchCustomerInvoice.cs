using Entity_Validator.Entity.Filters;
using System.Windows.Forms;

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
                CustomerInvoiceSaleBk = string.IsNullOrEmpty(InvoiceSaleBkTxt.Text)?null: InvoiceSaleBkTxt.Text,
                CustomerInvoiceSaleBoL = string.IsNullOrEmpty(InvoiceBoLTxt.Text)?null: InvoiceBoLTxt.Text,
                CustomerInvoiceCode = string.IsNullOrEmpty(CustomerInvoiceCodeTxt.Text)?null: CustomerInvoiceCodeTxt.Text,
                CustomerInvoiceStatus = StatusCmb.Text,
            };

            if (DateFromClnd.Checked)
                customerInvoiceFilter.CustomerInvoiceInvoiceDateFrom = DateFromClnd.Value;
            else
                customerInvoiceFilter.CustomerInvoiceInvoiceDateFrom = null;

            if (DateToClnd.Checked)
                customerInvoiceFilter.CustomerInvoiceInvoiceDateTo = DateToClnd.Value;
            else
                customerInvoiceFilter.CustomerInvoiceInvoiceDateTo = null;


            if (string.IsNullOrEmpty(AmountFromTxt.GetText()))
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountFrom = null;
            else
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountFrom = int.Parse(AmountFromTxt.GetText());

            if (string.IsNullOrEmpty(AmountToTxt.GetText()))
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountTo = null;
            else
                customerInvoiceFilter.CustomerInvoiceInvoiceAmountTo = int.Parse(AmountToTxt.GetText());

            return customerInvoiceFilter;
        }
    }
}
