namespace Entity_Valdidator.Entity.Entities
{
    public class UserRole
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        
    }
}
