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
    }
}
