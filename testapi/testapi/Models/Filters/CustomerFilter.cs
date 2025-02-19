namespace API.Models.Filters
{
    public class CustomerFilter
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool? Deprecated { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public int? OriginalID { get; set; }
        public int? page { get; set; }
    }
}
