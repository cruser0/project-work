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
        
        public List<string> Role { get; set; }
    }
    public class UserRoleDTO
    {
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Role { get; set; }
        public UserRoleDTO(User user,List<string> list)
        {
            Email = user.Email;
            Name = user.Name;
            LastName = user.LastName;
            Role = list;
        }
    }
    public class UserRoleDTOPass : UserRoleDTO
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRoleDTOPass(User user, List<string> list) : base(user,list)
        {
            PasswordHash = user.PasswordHash;
            PasswordSalt = user.PasswordSalt;
        }
    }

}
