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
        private async void Init()
        {
            List<CostRegistry> list = (await UtilityFunctions.GetCostRegistry()).ToList();
            NameCmbx.DataSource =list.Select(x=>x.CostRegistryName).ToList() ;
            CodeCmbx.DataSource =list.Select(x=>x.CostRegistryUniqueCode).ToList() ;

        }
    }
}
