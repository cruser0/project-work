using System.Collections.Generic;
using System.Linq;
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


            };
            if (!string.IsNullOrEmpty(CostRegistryCmbx.Text))
            {
                if (CostRegistryCmbx.Text.Equals("All"))
                    customerInvoiceCostfilter.RegistryCode = null;
                else
                    customerInvoiceCostfilter.RegistryCode = CostRegistryCmbx.Text;
            } 
            else
                customerInvoiceCostfilter.RegistryCode = null;

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
            list.Add(new CostRegistry() { CostRegistryID = 0, CostRegistryName = "All", CostRegistryPrice = 0, CostRegistryQuantity = 0, CostRegistryUniqueCode = "All" });
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).ToList();
        }
    }
}
