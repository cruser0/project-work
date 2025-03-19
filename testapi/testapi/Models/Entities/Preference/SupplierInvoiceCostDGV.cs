namespace API.Models.Entities.Preference
{
    public class SupplierInvoiceCostDGV
    {
        public int? SupplierInvoiceCostDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowSupplierInvoiceID { get; set; }
        public bool? ShowCost { get; set; }
        public bool? ShowQuantity { get; set; }
        public bool? ShowName { get; set; }
        public virtual User? User { get; set; }

    }
}
