using Entity_Validator.Entity.Entities;
using System.Collections.Generic;

namespace Entity_Validator.Entity.DTO
{
    public class UserDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDTOEdit : UserDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class UserDTOCreate : UserDTOEdit
    {
        public Dictionary<string, string> Preferences { get; set; } = new Dictionary<string, string>();
        public List<string> Role { get; set; } = new List<string>();
    }

    public class UserDTOGet
    {
        public int? UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class UserRoleDTO : UserDTOGet
    {

        public List<string> Role { get; set; }
        public Dictionary<string, string> Preferences { get; set; }


        public UserRoleDTO(User user, List<string> list)
        {
            UserID = user.UserID;
            Email = user.Email;
            Name = user.Name;
            LastName = user.LastName;
            Role = list;
        }
    }
    public class AssignPrefDTO
    {
        public int? UserID { get; set; }
        public Dictionary<string, string> Preferences { get; set; }
    }

    public class AssignRoleDTO
    {
        public int? UserID { get; set; }
        public List<string> Roles { get; set; }
    }



}
