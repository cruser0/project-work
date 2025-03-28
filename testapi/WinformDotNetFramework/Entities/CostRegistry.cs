namespace WinformDotNetFramework.Entities
{
    public class CostRegistry
    {
        public string CostRegistryUniqueCode { get; set; }
        public string CostRegistryName { get; set; }
        public decimal? CostRegistryPrice { get; set; }
        public int? CostRegistryQuantity { get; set; }
    }
    public class CostRegistryDTOPut
    {
        public int? CostRegistryID { get; set; }
    }

}
