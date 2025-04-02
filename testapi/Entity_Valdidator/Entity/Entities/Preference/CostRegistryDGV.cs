namespace Entity_Validator.Entity.Entities.Preference
{
    public class CostRegistryDGV
    {
        public int? CostRegistryDGVID { get; set; }
        public int? UserID { get; set; }
        public bool? ShowRegistryID { get; set; }
        public bool? ShowRegistryCode { get; set; }
        public bool? ShowRegistryName { get; set; }
        public bool? ShowRegistryPrice { get; set; }
        public bool? ShowRegistryQuantity { get; set; }
        public virtual User User { get; set; }
    }
}
