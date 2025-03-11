using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoiceCost : UserControl
    {
        public SearchCustomerInvoiceCost()
        {
            InitializeComponent();
        }

        public CustomerInvoiceCostFilter GetFilter()
        {
            CustomerInvoiceCostFilter customerInvoiceCostfilter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostCustomerInvoiceId = null,
                CustomerInvoiceCostName = NameTxt.Text
            };

            if (string.IsNullOrEmpty(CostFromTxt.GetText()))
            {
                customerInvoiceCostfilter.CustomerInvoiceCostCostFrom = null;
            }
            else
            {
                customerInvoiceCostfilter.CustomerInvoiceCostCostFrom = int.Parse(CostFromTxt.GetText());
            }

            if (string.IsNullOrEmpty(CostToTxt.GetText()))
            {
                customerInvoiceCostfilter.CustomerInvoiceCostCostTo = null;
            }
            else
            {
                customerInvoiceCostfilter.CustomerInvoiceCostCostTo = int.Parse(CostToTxt.GetText());
            }
            return customerInvoiceCostfilter;
        }
    }
}
