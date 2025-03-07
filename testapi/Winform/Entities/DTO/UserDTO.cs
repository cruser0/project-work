namespace Winform.Entities.DTO
{
    public class UserDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserDTOEdit : UserDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
    public class UserDTOCreate : UserDTOEdit
    {
        public List<string>? Role { get; set; } = new List<string>();
    }
    public class AssignRoleDTO
    {
        public int? UserID { get; set; }
        public List<string>? Roles { get; set; } = new List<string>();
    }
    public class UserRoleDTO
    {
        public int? UserID { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public List<string>? Role { get; set; }
        public string Roles
        {
            get
            {
                return string.Join(", ", Role); // Converts the list to a comma-separated string
            }
        }
    }
}
