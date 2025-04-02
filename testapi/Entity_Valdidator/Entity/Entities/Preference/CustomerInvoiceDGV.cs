namespace Entity_Validator.Entity.Entities.Preference
{
    public class CustomerInvoiceDGV
    {
        public int? CustomerInvoiceDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowSaleID { get; set; }
        public bool? ShowInvoiceAmount { get; set; }
        public bool? ShowDate { get; set; }
        public bool? ShowStatus { get; set; }
        public bool? ShowInvoiceCode { get; set; }
        public bool? ShowSaleBookingNumber { get; set; }
        public bool? ShowSaleBoL { get; set; }
        public virtual User User { get; set; }
    }
}
