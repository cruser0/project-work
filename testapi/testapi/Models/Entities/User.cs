namespace API.Models.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        //public virtual CustomerDGV CustomerDGV { get; set; }
        //public virtual CustomerInvoiceDGV CustomerInvoiceDGV { get; set; }
        //public virtual CustomerInvoiceCostDGV CustomerInvoiceCostDGV { get; set; }
        //public virtual SupplierDGV SupplierDGV { get; set; }
        //public virtual SupplierInvoiceDGV SupplierInvoiceDGV { get; set; }
        //public virtual SupplierInvoiceCostDGV SupplierInvoiceCostDGV { get; set; }
        //public virtual SaleDGV SaleDGV { get; set; }
        //public virtual UserDGV UserDGV { get; set; }
        //public virtual SupplierGroupSplit SupplierGroupSplit { get; set; }
        //public virtual CustomerGroupSplit CustomerGroupSplit { get; set; }
        public virtual ICollection<UserFavouritePage> UserFavouritePages { get; set; }=new List<UserFavouritePage> ();



    }
}
