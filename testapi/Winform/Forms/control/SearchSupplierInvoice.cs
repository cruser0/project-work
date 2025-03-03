using API.Models.Filters;

namespace Winform.Forms.control
{
    public partial class SearchSupplierInvoice : UserControl
    {
        public SearchSupplierInvoice()
        {
            InitializeComponent();
        }

        public SupplierInvoiceFilter GetFilter()
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter()
            {
                SupplierInvoiceSaleID = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                SupplierInvoiceInvoiceAmountFrom = !string.IsNullOrEmpty(InvoiceAmountFromTxt.GetText()) ? int.Parse(InvoiceAmountFromTxt.GetText()) : null,
                SupplierInvoiceInvoiceAmountTo = !string.IsNullOrEmpty(InvoiceAmountToTxt.GetText()) ? int.Parse(InvoiceAmountToTxt.GetText()) : null,
                SupplierInvoiceInvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                SupplierInvoiceInvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                SupplierInvoiceStatus = StatusCmb.Text

            };
            return filter;
        }
    }
}
