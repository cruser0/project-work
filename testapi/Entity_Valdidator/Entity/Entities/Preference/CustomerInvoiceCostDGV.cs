namespace Entity_Valdidator.Entity.Entities.Preference
{
    public class CustomerInvoiceCostDGV
    {
        public int? CustomerInvoiceCostDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowID { get; set; }
        public bool? ShowInvoiceID { get; set; }
        public bool? ShowCost { get; set; }
        public bool? ShowQuantity { get; set; }
        public bool? ShowName { get; set; }
        public virtual User User { get; set; }
    }
}
