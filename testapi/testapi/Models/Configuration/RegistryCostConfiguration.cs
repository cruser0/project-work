using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Models.Configuration
{
    public class RegistryCostConfiguration : IEntityTypeConfiguration<CostRegistry>
    {
        public void Configure(EntityTypeBuilder<CostRegistry> builder)
        {
            builder.HasData(new CostRegistry() { CostRegistryID = 1, CostRegistryName = "Generic", CostRegistryPrice = 1, CostRegistryQuantity = 1, CostRegistryUniqueCode = "GNC" });
        }
    }
}
