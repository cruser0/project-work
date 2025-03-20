using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoiceCost : UserControl
    {
        CostRegistryService costRegistryService;
        ICollection<CostRegistry> list = new List<CostRegistry>();
        public SearchCustomerInvoiceCost()
        {
            costRegistryService = new CostRegistryService();
            InitializeComponent();

        }

        public CustomerInvoiceCostFilter GetFilter()
        {
            CustomerInvoiceCostFilter customerInvoiceCostfilter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                CustomerInvoiceCostCustomerInvoiceCode = string.IsNullOrEmpty(InvoiceCodeTxt.Text) ? null : InvoiceCodeTxt.Text,
                RegistryCode = string.IsNullOrEmpty(CostRegistryCmbx.Text) ? null : CostRegistryCmbx.Text,


            };

            if (string.IsNullOrEmpty(CostFromTxt.GetText()))
                customerInvoiceCostfilter.CustomerInvoiceCostCostFrom = null;
            else
                customerInvoiceCostfilter.CustomerInvoiceCostCostFrom = int.Parse(CostFromTxt.GetText());

            if (string.IsNullOrEmpty(CostToTxt.GetText()))
                customerInvoiceCostfilter.CustomerInvoiceCostCostTo = null;
            else
                customerInvoiceCostfilter.CustomerInvoiceCostCostTo = int.Parse(CostToTxt.GetText());
            
            return customerInvoiceCostfilter;
        }

        private async void SearchCustomerInvoiceCost_Load(object sender, System.EventArgs e)
        {
            list=await costRegistryService.GetAll();
            CostRegistryCmbx.DataSource=list;
        }
    }
}
