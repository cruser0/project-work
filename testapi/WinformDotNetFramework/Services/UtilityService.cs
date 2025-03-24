using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformDotNetFramework.Entities;

namespace WinformDotNetFramework.Services
{
    internal class UtilityService:BaseCallService
    {
        public async Task<ICollection<CostRegistry>> GetAllCostRegistry()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            List<CostRegistry> returnItems = await GetList<CostRegistry>(client, "get-all-cost-registry", null);
            return  returnItems;
        }
        public async Task<ICollection<Country>> GetAllCountry()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            List<Country> returnItems = await GetList<Country>(client, "get-all-country", null);
            return returnItems;
        }
    }
}
