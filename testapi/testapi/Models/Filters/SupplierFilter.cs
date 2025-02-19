namespace API.Models.Filters
{
    public class SupplierFilter
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool? Deprecated { get; set; }
        public int? page { get; set; }
    }
}
