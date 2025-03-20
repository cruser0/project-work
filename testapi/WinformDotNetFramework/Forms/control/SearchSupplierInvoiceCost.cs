
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoiceCost : UserControl
    {
        CostRegistryService _costRegistryService;
        ICollection<CostRegistry> list = new List<CostRegistry>();

        public SearchSupplierInvoiceCost()
        {
            _costRegistryService = new CostRegistryService();
            InitializeComponent();
        }

        public SupplierInvoiceCostFilter GetFilter()
        {
            SupplierInvoiceCostFilter filter = new SupplierInvoiceCostFilter();
            filter.SupplierInvoiceCostName = string.IsNullOrEmpty(NameTxt.Text)?null:NameTxt.Text;
            if (!string.IsNullOrEmpty(CostRegistryCmbx.Text))
            {
                if(CostRegistryCmbx.Text.Equals("All"))
                    filter.SupplierInvoiceCostName = null;
                else
                    filter.SupplierInvoiceCostRegistryCode = CostRegistryCmbx.Text;
            }
            else
                filter.SupplierInvoiceCostRegistryCode = null;

            if (!string.IsNullOrEmpty(InvoiceCodeTxt.Text))
                filter.SupplierInvoiceCostSupplierInvoiceCode = InvoiceCodeTxt.Text;
            else
                filter.SupplierInvoiceCostSupplierInvoiceCode = null;
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
        private async void SearchCustomerInvoiceCost_Load(object sender, System.EventArgs e)
        {
            list = await _costRegistryService.GetAll();
            list.Add(new CostRegistry() { CostRegistryID = 0, CostRegistryName = "All", CostRegistryPrice = 0, CostRegistryQuantity = 0, CostRegistryUniqueCode = "All" });
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).ToList();
        }
    }
}
