using API.Models.Entities;

namespace API.Models.DTO
{
    public class UserAccessInfoDTO
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public UserAccessInfoDTO(UserRoleDTO user, string token, RefreshToken refreshToken)
        {
            Token = token;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role;
            RefreshToken = refreshToken;
        }
    }
}
