namespace API.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();   
        }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public int CountryID { get; set; }
        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int OriginalID { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
