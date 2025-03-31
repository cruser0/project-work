
using System;

namespace Entity_Validator.Entity.DTO
{
    public class RefreshTokenDTO
    {
        public int TokenID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public RefreshTokenDTO(RefreshToken tk)
        {
            TokenID=tk.TokenID;
            UserID=tk.UserID;
            Token = tk.Token;
            Created = tk.Created;
            Expires = tk.Expires;
        }
    }
}
