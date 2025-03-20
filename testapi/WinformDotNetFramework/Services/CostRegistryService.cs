using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;

namespace WinformDotNetFramework.Services
{
    internal class CostRegistryService:BaseCallService
    {
        public async Task<ICollection<CostRegistry>> GetAll()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            List<CostRegistry> returnItems = await GetList<CostRegistry>(client, "get-all-cost-registry", null);
            return  returnItems;
        }
    }
}
