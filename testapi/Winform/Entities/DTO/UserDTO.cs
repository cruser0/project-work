using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserDTOCreate : UserDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
