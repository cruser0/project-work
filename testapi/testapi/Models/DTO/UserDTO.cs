using API.Models.Entities;

namespace API.Models.DTO
{
    public class UserDTO
    {
        
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserDTOEdit:UserDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }

    public class UserDTOCreate: UserDTOEdit
    {
        
        public List<string>? Role { get; set; }=new List<string>();
    }
    public class UserRoleDTO
    {
        public int? UserID { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<string>? Role { get; set; }
        public UserRoleDTO(User user,List<string> list)
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
        public int? UserID { get; set; }
        public List<string>? Roles { get; set; }
    }

}
