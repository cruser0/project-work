using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Entities
{
    public class CostRegistry
    {
        public string CostRegistryUniqueCode { get; set; }
        public string CostRegistryName { get; set; }
        public decimal? CostRegistryPrice { get; set; }
        public int? CostRegistryQuantity { get; set; }
        public int? CostRegistryID { get; set; }
    }

}
