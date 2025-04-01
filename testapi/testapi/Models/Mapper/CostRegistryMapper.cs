

using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;

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
                CostRegistryPrice = costRegistry.CostRegistryPrice.HasValue ? costRegistry.CostRegistryPrice : null,
                CostRegistryQuantity = costRegistry.CostRegistryQuantity.HasValue ? costRegistry.CostRegistryQuantity : null
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
                CostRegistryID = costRegistry.CostRegistryID.HasValue ? costRegistry.CostRegistryID : null,
                CostRegistryUniqueCode = costRegistry.CostRegistryUniqueCode,
                CostRegistryName = costRegistry.CostRegistryName,
                CostRegistryPrice = costRegistry.CostRegistryPrice.HasValue ? costRegistry.CostRegistryPrice : null,
                CostRegistryQuantity = costRegistry.CostRegistryQuantity.HasValue ? costRegistry.CostRegistryQuantity : null
            };

        }
    }
}
