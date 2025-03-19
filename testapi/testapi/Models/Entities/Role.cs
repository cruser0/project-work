using System.ComponentModel.DataAnnotations;

namespace API.Models.Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles=new HashSet<UserRole>();
        }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
