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
        public async Task<ICollection<CostRegistryDTO>> GetAllCostRegistry()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            List<CostRegistryDTO> returnItems = await GetList<CostRegistryDTO>(client, "get-all-cost-registry", null);
            return  returnItems;
        }
        public async Task<ICollection<CountryDTOGet>> GetAllCountry()
        {
            ClientAPI client = new ClientAPI(UserAccessInfo.Token);
            List<CountryDTOGet> returnItems = await GetList<CountryDTOGet>(client, "get-all-country", null);
            return returnItems;
        }
    }
}
