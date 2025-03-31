
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoiceCost : UserControl
    {
        UtilityService _costRegistryService;
        ICollection<CostRegistryDTO> list = new List<CostRegistryDTO>();

        public SearchSupplierInvoiceCost()
        {
            _costRegistryService = new UtilityService();
            InitializeComponent();
            Init();

        }
        public async void Init()
        {
            CostRegistryCmbx.DataSource = (await UtilityFunctions.GetCostRegistry()).Select(x=>x.CostRegistryUniqueCode).ToList();
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
    }
}
