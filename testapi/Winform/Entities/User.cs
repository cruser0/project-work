using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities
{
    internal class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
    }
}
