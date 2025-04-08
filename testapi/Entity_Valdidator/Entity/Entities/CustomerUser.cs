using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Validator.Entity.Entities
{
    public class CustomerUser
    {
        public int CustomerUserID { get; set; }
        public int CustomerID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }=new List<RefreshToken>();
        public virtual Customer Customer{ get; set; }
        public virtual Role Role{ get; set; }
        
    }
}
