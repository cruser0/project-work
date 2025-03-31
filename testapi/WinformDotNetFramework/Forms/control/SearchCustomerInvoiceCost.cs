using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomerInvoiceCost : UserControl
    {
        public SearchCustomerInvoiceCost()
        {
            InitializeComponent();
            Init();

        }
        public async void Init()
        {
            CostRegistryCmbx.DataSource = (await UtilityFunctions.GetCostRegistry()).Select(x => x.CostRegistryUniqueCode).ToList();
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
    }
}
