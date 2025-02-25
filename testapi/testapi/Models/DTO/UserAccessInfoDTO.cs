using API.Models.Entities;

namespace API.Models.DTO
{
    public class UserAccessInfoDTO
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserAccessInfoDTO(User user,string token)
        {
            Token = token;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
        }
    }
}
