namespace Entity_Valdidator.Entity.Entities.Preference
{
    public class SupplierInvoiceDGV
    {
        public int? SupplierInvoiceDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowSaleID { get; set; }
        public bool? ShowInvoiceAmount { get; set; }
        public bool? ShowInvoiceDate { get; set; }
        public bool? ShowStatus { get; set; }
        public bool? ShowSupplierID { get; set; }
        public bool? ShowSupplierName { get; set; }
        public bool? ShowCountry { get; set; }
        public virtual User User { get; set; }

    }
}
