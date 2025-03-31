using Entity_Validator.Entity.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator.Entity.DTO
{
    public class UserDTO
    {
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Email is Invalid.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPost { get; set; }
    }

    public class UserDTOEdit : UserDTO
    {
        [RequiredIf("IsPost",true)]
        [MaxLength(100)]
        public string Name { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string LastName { get; set; }
    }

    public class UserDTOCreate : UserDTOEdit
    {
        [RequiredIf("IsPost",true)]
        public List<string> Role { get; set; } = new List<string>();
    }

    public class UserDTOGet
    {
        [RequiredIf("IsPost", true)]
        public int? UserID { get; set; }
        [RequiredIf("IsPost", true)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Email is Invalid.")]
        public string Email { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string Name { get; set; }
        [RequiredIf("IsPost", true)]
        [MaxLength(100)]
        public string LastName { get; set; }
    }

    public class UserRoleDTO : UserDTOGet
    {
        [RequiredIf("IsPost", true)]

        public List<string> Role { get; set; }


        public UserRoleDTO(User user, List<string> list)
        {
            UserID = user.UserID;
            Email = user.Email;
            Name = user.Name;
            LastName = user.LastName;
            Role = list;
        }
    }
    public class AssignRoleDTO
    {
        [RequiredIf("IsPost", true)]

        public int? UserID { get; set; }
        [RequiredIf("IsPost", true)]

        public List<string> Roles { get; set; }
        public bool IsPost { get; set; }
    }



}
