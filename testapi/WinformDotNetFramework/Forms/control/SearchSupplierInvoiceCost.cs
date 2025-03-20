
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoiceCost : UserControl
    {
        public SearchSupplierInvoiceCost()
        {
            InitializeComponent();
        }

        public SupplierInvoiceCostFilter GetFilter()
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter();
            filter.SupplierInvoiceCostName = NameTxt.Text;
            if (!string.IsNullOrEmpty(RegistryTxt.Text))
                filter.SupplierInvoiceCostRegistryCode = RegistryTxt.Text;
            else
                filter.SupplierInvoiceCostRegistryCode = null;

            if (!string.IsNullOrEmpty(InvoiceIDTxt.GetText()))
                filter.SupplierInvoiceCostSupplierInvoiceId = int.Parse(InvoiceIDTxt.GetText());
            else
                filter.SupplierInvoiceCostSupplierInvoiceId = null;
            if (!string.IsNullOrEmpty(CostFromTxt.GetText()))
                filter.SupplierInvoiceCostCostFrom = int.Parse(CostFromTxt.GetText());
            else
                filter.SupplierInvoiceCostCostFrom = null;

            if (!string.IsNullOrEmpty(CostToTxt.GetText()))
                filter.SupplierInvoiceCostCostTo = int.Parse(CostToTxt.GetText());
            else
                filter.SupplierInvoiceCostCostTo = null;

            return filter;
        }
    }
}
