namespace API.Models.Entities
{
    public class SupplierDGV
    {
        public int? SupplierDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowName { get; set; }
        public bool? ShowCountry { get; set; }
        public bool? ShowDate { get; set; }
        public bool? ShowOriginalID { get; set; }
        public bool? ShowStatus { get; set; }
       // public virtual User? User { get; set; }
    }
}
