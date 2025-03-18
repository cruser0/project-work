using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoice : UserControl
    {
        public SearchSupplierInvoice()
        {
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
        }

        public SupplierInvoiceFilter GetFilter()
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter();
            filter.SupplierInvoiceStatus = StatusCmb.Text;

            if (!string.IsNullOrEmpty(SaleIDTxt.GetText()))
            {
                filter.SupplierInvoiceSaleID = int.Parse(SaleIDTxt.GetText());
            }
            else
            {
                filter.SupplierInvoiceSaleID = null;
            }
            if (!string.IsNullOrEmpty(SupplierIDTxt.GetText()))
            {
                filter.SupplierInvoiceSupplierID = int.Parse(SupplierIDTxt.GetText());
            }
            else
            {
                filter.SupplierInvoiceSupplierID = null;
            }

            if (!string.IsNullOrEmpty(InvoiceAmountFromTxt.GetText()))
            {
                filter.SupplierInvoiceInvoiceAmountFrom = int.Parse(InvoiceAmountFromTxt.GetText());
            }
            else
            {
                filter.SupplierInvoiceInvoiceAmountFrom = null;
            }

            if (!string.IsNullOrEmpty(InvoiceAmountToTxt.GetText()))
            {
                filter.SupplierInvoiceInvoiceAmountTo = int.Parse(InvoiceAmountToTxt.GetText());
            }
            else
            {
                filter.SupplierInvoiceInvoiceAmountTo = null;
            }

            if (DateFromClnd.Checked)
            {
                filter.SupplierInvoiceInvoiceDateFrom = DateFromClnd.Value;
            }
            else
            {
                filter.SupplierInvoiceInvoiceDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                filter.SupplierInvoiceInvoiceDateTo = DateToClnd.Value;
            }
            else
            {
                filter.SupplierInvoiceInvoiceDateTo = null;
            }

            return filter;
        }
    }
}
