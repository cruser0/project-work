namespace API.Models.Filters
{
    public class CostRegistryFilter
    {
        public string? CostRegistryUniqueCode { get; set; }
        public string? CostRegistryName { get; set; }
        public int? CostRegistryPriceFrom { get; set; }
        public int? CostRegistryPriceTo { get; set; }
    }
}
