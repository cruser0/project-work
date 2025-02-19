namespace API.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Country { get; set; }

        public bool? Deprecated { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int OriginalID { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public Customer Returns(Customer expectedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
