using API.Models.DTO;
using API.Models.Entities;

namespace API.Models.Mapper
{
    public class CostRegistryMapper
    {
        public static CostRegistryDTO Map(CostRegistry costRegistry)
        {
            return new CostRegistryDTO
            {
                CostRegistryUniqueCode = costRegistry.CostRegistryUniqueCode,
                CostRegistryName = costRegistry.CostRegistryName,
                CostRegistryPrice = costRegistry.CostRegistryPrice,
                CostRegistryQuantity = costRegistry.CostRegistryQuantity
            };
        }
        public static CostRegistry Map(CostRegistryDTO costRegistry)
        {
            return new CostRegistry
            {
                CostRegistryUniqueCode = costRegistry.CostRegistryUniqueCode,
                CostRegistryName = costRegistry.CostRegistryName,
                CostRegistryPrice = (decimal)costRegistry.CostRegistryPrice!,
                CostRegistryQuantity = (int)costRegistry.CostRegistryQuantity!
            };
        }

        public static CostRegistryDTOGet MapGet(CostRegistry costRegistry)
        {
            return new CostRegistryDTOGet
            {
                CostRegistryID = costRegistry.CostRegistryID,
                CostRegistryUniqueCode = costRegistry.CostRegistryUniqueCode,
                CostRegistryName = costRegistry.CostRegistryName,
                CostRegistryPrice = costRegistry.CostRegistryPrice,
                CostRegistryQuantity = costRegistry.CostRegistryQuantity
            };
        }
        public static CostRegistry MapGet(CostRegistryDTOGet costRegistry)
        {
            return new CostRegistry
            {
                CostRegistryID = (int)costRegistry.CostRegistryID!,
                CostRegistryUniqueCode = costRegistry.CostRegistryUniqueCode,
                CostRegistryName = costRegistry.CostRegistryName,
                CostRegistryPrice = (decimal)costRegistry.CostRegistryPrice!,
                CostRegistryQuantity = (int)costRegistry.CostRegistryQuantity!
            };
        }
    }
}
