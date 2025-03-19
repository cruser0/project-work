namespace API.Models.DTO
{
    public class CostRegistryDTO
    {
        public string? CostRegistryUniqueCode { get; set; }
        public string? CostRegistryName { get; set; }
        public decimal? CostRegistryPrice { get; set; }
        public int? CostRegistryQuantity { get; set; }
    }
    public class CostRegistryDTOGet : CostRegistryDTO
    {
        public int? CostRegistryID { get; set; }
    }
}
