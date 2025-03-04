namespace API.Models.Entities
{
    public class SaleDGV
    {
        public int? SaleDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowBKNumber { get; set; }
        public bool? ShowBoLNumber { get; set; }
        public bool? ShowDate { get; set; }
        public bool? ShowCustomerID { get; set; }
        public bool? ShowStatus{ get; set; }
        public bool? ShowCustomerName { get; set; }
        public bool? ShowCustomerCountry { get; set; }
        public bool? ShowTotalRevenue { get; set; }
        //public virtual User? User { get; set; }
    }
}
