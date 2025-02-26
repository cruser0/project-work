using API.Models.Entities;

namespace API.Models.DTO
{
    public class UserDTO
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserDTOCreate:UserDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Role { get; set; }
    }
    public class UserRoleDTO
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> Role { get; set; }
        public UserRoleDTO(User user,List<string> list)
        {
            Email = user.Email;
            PasswordHash=user.PasswordHash;
            PasswordSalt=user.PasswordSalt;
            Name = user.Name;
            LastName = user.LastName;
            Role = list;
        }
    }

}
