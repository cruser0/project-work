using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]  // Marks this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public Customer Returns(Customer expectedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
