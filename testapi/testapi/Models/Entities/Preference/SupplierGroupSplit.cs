namespace API.Models.Entities.Preference
{
    public class SupplierGroupSplit
    {
        public int? SupplierGroupSplitID { get; set; }
        public int? UserID { get; set; }
        public int? Split1 { get; set; }
        public int? Split2 { get; set; }
        public int? Split3 { get; set; }
        public User? User { get; set; }
    }
}
