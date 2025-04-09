using Entity_Validator.Entity.Entities;
using System;

namespace Entity_Validator.Entity.DTO
{
    public class RefreshTokenDTO
    {
        public RefreshTokenDTO()
        {

        }
        public RefreshTokenDTO(RefreshToken tk)
        {
            TokenID = tk.TokenID;
            UserID = tk.UserID==null?null:tk.UserID;
            CustomerUserID = tk.CustomerUserID == null?null:tk.CustomerUserID;
            Token = tk.Token;
            Created = (DateTime)tk.Created;
            Expires = (DateTime)tk.Expires;
        }
        public int TokenID { get; set; }
        public int? UserID { get; set; }
        public int? CustomerUserID { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
    }
}
