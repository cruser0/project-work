using API.Models.Filters;

namespace Winform.Forms.control
{
    public partial class SearchSupplierInvoiceCost : UserControl
    {
        public SearchSupplierInvoiceCost()
        {
            InitializeComponent();
        }

        public SupplierInvoiceCostFilter GetFilter()
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter()
            {
                SupplierInvoiceCostName = NameTxt.Text,
                SupplierInvoiceCostCostFrom = !string.IsNullOrEmpty(CostFromTxt.GetText()) ? int.Parse(CostFromTxt.GetText()) : null,
                SupplierInvoiceCostCostTo = !string.IsNullOrEmpty(CostToTxt.GetText()) ? int.Parse(CostToTxt.GetText()) : null

            };
            return filter;
        }
    }
}
