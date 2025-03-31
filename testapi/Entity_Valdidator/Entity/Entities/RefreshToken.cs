using System;

namespace Entity_Validator.Entity.Entities
{
    public class RefreshToken
    {
        public int TokenID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Expires { get; set; }
        public virtual User User { get; set; }

    }
}
