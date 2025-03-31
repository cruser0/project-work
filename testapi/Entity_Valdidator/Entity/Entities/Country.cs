using System.Collections.Generic;

namespace Entity_Validator.Entity.Entities
{
    public class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
            Suppliers = new HashSet<Supplier>();
        }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string ISOCode { get; set; }
        public string Region { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
