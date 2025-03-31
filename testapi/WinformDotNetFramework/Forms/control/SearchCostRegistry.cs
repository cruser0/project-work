using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCostRegistry : UserControl
    {
        public SearchCostRegistry()
        {
            InitializeComponent();
            Init();
        }
        public async void Init()
        {
            List<CostRegistryDTO> list = (await UtilityFunctions.GetCostRegistry()).ToList();
            NameCmbx.DataSource =list.Select(x=>x.CostRegistryName).ToList() ;
            CodeCmbx.DataSource =list.Select(x=>x.CostRegistryUniqueCode).ToList() ;

        }
        public CostRegistryFilter GetFilter()
        {
            CostRegistryFilter costRegistryfilter = new CostRegistryFilter();

            if (!string.IsNullOrEmpty(NameCmbx.Text))
            {
                if (NameCmbx.Text.Equals("All"))
                    costRegistryfilter.CostRegistryName = null;
                else
                    costRegistryfilter.CostRegistryName = NameCmbx.Text;
            }
            else
                costRegistryfilter.CostRegistryName = null;
            
            if (!string.IsNullOrEmpty(CodeCmbx.Text))
            {
                if (CodeCmbx.Text.Equals("All"))
                    costRegistryfilter.CostRegistryCode = null;
                else
                    costRegistryfilter.CostRegistryCode = CodeCmbx.Text;
            }
            else
                costRegistryfilter.CostRegistryCode = null;

            return costRegistryfilter;
        }
    }
}
